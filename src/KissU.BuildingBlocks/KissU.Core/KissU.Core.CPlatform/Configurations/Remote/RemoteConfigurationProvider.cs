﻿using System;
using System.Net.Http;
using System.Net.Http.Headers;
using KissU.Core.CPlatform.Utilities;
using Microsoft.Extensions.Configuration;

namespace KissU.Core.CPlatform.Configurations.Remote
{
    /// <summary>
    /// 远程配置提供者.
    /// Implements the <see cref="ConfigurationProvider" />
    /// </summary>
    /// <seealso cref="ConfigurationProvider" />
    internal class RemoteConfigurationProvider : ConfigurationProvider
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RemoteConfigurationProvider"/> class.
        /// </summary>
        /// <param name="source"></param>
        public RemoteConfigurationProvider(RemoteConfigurationSource source)
        {
            Check.NotNull(source, "source");
            if (!string.IsNullOrEmpty(source.ConfigurationKeyPrefix))
            {
                Check.CheckCondition(() => source.ConfigurationKeyPrefix.Trim().StartsWith(":"), CPlatformResource.InvalidStartCharacter, "source.ConfigurationKeyPrefix", ":");
                Check.CheckCondition(() => source.ConfigurationKeyPrefix.Trim().EndsWith(":"), CPlatformResource.InvalidEndCharacter, "source.ConfigurationKeyPrefix",":");
            }

            Source = source;
            Backchannel = new HttpClient(source.BackchannelHttpHandler ?? new HttpClientHandler());
            Backchannel.DefaultRequestHeaders.UserAgent.ParseAdd("获取CacheConfiugration信息");
            Backchannel.Timeout = source.BackchannelTimeout;
            Backchannel.MaxResponseContentBufferSize = 1024 * 1024 * 10;
            Parser = source.Parser ?? new JsonConfigurationParser();
        }

        public RemoteConfigurationSource Source { get; }

        public IConfigurationParser Parser { get; }

        public HttpClient Backchannel { get; }

        /// <summary>
        /// Loads (or reloads) the data for this provider.
        /// </summary>
        /// <exception cref="Exception">调用远程配置终结点发生错误</exception>
        public override void Load()
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Get, Source.ConfigurationUri);
            requestMessage.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue(Source.MediaType));
            Source.Events.SendingRequest(requestMessage);
            try
            {
                var response = Backchannel.SendAsync(requestMessage)
                    .ConfigureAwait(false)
                    .GetAwaiter()
                    .GetResult();

                if (response.IsSuccessStatusCode)
                {
                    using (var stream = response.Content.ReadAsStreamAsync()
                        .ConfigureAwait(false)
                        .GetAwaiter()
                        .GetResult())
                    {
                        var data = Parser.Parse(stream, Source.ConfigurationKeyPrefix?.Trim());
                        Data = Source.Events.DataParsed(data);
                    }
                }
                else if (!Source.Optional)
                {
                    throw new Exception(string.Format(CPlatformResource.HttpException, response.StatusCode, response.ReasonPhrase));
                }
            }
            catch (Exception)
            {
                if (!Source.Optional)
                {
                    throw;
                }
            }
        }
    }
}
