using System;
using System.Net.Http;
using System.Net.Http.Headers;
using KissU.Infrastructure.Core.Helpers;
using Microsoft.Extensions.Configuration;

namespace KissU.Caching.Configurations.Remote
{
    /// <summary>
    /// RemoteConfigurationProvider.
    /// Implements the <see cref="Microsoft.Extensions.Configuration.ConfigurationProvider" />
    /// </summary>
    /// <seealso cref="Microsoft.Extensions.Configuration.ConfigurationProvider" />
    internal class RemoteConfigurationProvider : ConfigurationProvider
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RemoteConfigurationProvider" /> class.
        /// </summary>
        /// <param name="source">The source.</param>
        public RemoteConfigurationProvider(RemoteConfigurationSource source)
        {
            CheckHelper.NotNull(source, "source");
            if (!string.IsNullOrEmpty(source.ConfigurationKeyPrefix))
            {
                CheckHelper.CheckCondition(() => source.ConfigurationKeyPrefix.Trim().StartsWith(":"),
                    CachingResources.InvalidStartCharacter, "source.ConfigurationKeyPrefix", ":");
                CheckHelper.CheckCondition(() => source.ConfigurationKeyPrefix.Trim().EndsWith(":"),
                    CachingResources.InvalidEndCharacter, "source.ConfigurationKeyPrefix", ":");
            }

            Source = source;
            Backchannel = new HttpClient(source.BackchannelHttpHandler ?? new HttpClientHandler());
            Backchannel.DefaultRequestHeaders.UserAgent.ParseAdd("获取CacheConfiugration信息");
            Backchannel.Timeout = source.BackchannelTimeout;
            Backchannel.MaxResponseContentBufferSize = 1024 * 1024 * 10;
            Parser = source.Parser ?? new JsonConfigurationParser();
        }

        /// <summary>
        /// Gets the source.
        /// </summary>
        public RemoteConfigurationSource Source { get; }

        /// <summary>
        /// Gets the parser.
        /// </summary>
        public IConfigurationParser Parser { get; }

        /// <summary>
        /// Gets the backchannel.
        /// </summary>
        public HttpClient Backchannel { get; }

        /// <summary>
        /// Loads this instance.
        /// </summary>
        /// <exception cref="Exception"></exception>
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
                    throw new Exception(string.Format(CachingResources.HttpException, response.StatusCode,
                        response.ReasonPhrase));
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