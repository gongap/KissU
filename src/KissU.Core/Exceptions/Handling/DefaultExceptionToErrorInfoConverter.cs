using System;
using System.Text;
using KissU.Dependency;

namespace KissU.Exceptions.Handling
{
    public class DefaultExceptionToErrorInfoConverter : IExceptionToErrorInfoConverter, ISingletonDependency
    {
        private readonly CPlatformContainer _serviceProvider;

        public DefaultExceptionToErrorInfoConverter(CPlatformContainer serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public RemoteServiceErrorInfo Convert(Exception exception, bool includeSensitiveDetails)
        {
            if (exception is CPlatformCommunicationException communicationException)
            {
                return new RemoteServiceErrorInfo
                {
                    Code = communicationException.Code,
                    Message = communicationException.Message,
                    Data = communicationException.Data,
                    Details = communicationException.Details,
                    ValidationErrors = communicationException.ValidationErrors,
                };
            }

            if (exception.GetBaseException() is CPlatformCommunicationException communicationException1)
            {
                return new RemoteServiceErrorInfo
                {
                    Code = communicationException1.Code,
                    Message = communicationException1.Message,
                    Data = communicationException1.Data,
                    Details = communicationException1.Details,
                    ValidationErrors = communicationException1.ValidationErrors,
                };
            }

            var abpErrorInfoConverter = _serviceProvider.GetInstances<IExceptionToErrorInfoConverter>("Abp");
            if (abpErrorInfoConverter != null)
            {
                return abpErrorInfoConverter.Convert(exception, includeSensitiveDetails);
            }

            if (includeSensitiveDetails)
            {
                return CreateDetailedErrorInfoFromException(exception);
            }

            exception = TryToGetActualException(exception);
            return new RemoteServiceErrorInfo
            {
                Message = "�������ڲ�����",
                Data = exception.Data
            };
        }

        protected virtual Exception TryToGetActualException(Exception exception)
        {
            if (exception is AggregateException && exception.InnerException != null)
            {
                var aggException = exception as AggregateException;
                return aggException.InnerException;
            }

            return exception;
        }

        protected virtual RemoteServiceErrorInfo CreateDetailedErrorInfoFromException(Exception exception)
        {
            var detailBuilder = new StringBuilder();

            AddExceptionToDetails(exception, detailBuilder);

            return new RemoteServiceErrorInfo(exception.Message, detailBuilder.ToString());
        }

        protected virtual void AddExceptionToDetails(Exception exception, StringBuilder detailBuilder)
        {
            //Exception Message
            detailBuilder.AppendLine(exception.GetType().Name + ": " + exception.Message);

            //Exception StackTrace
            if (!string.IsNullOrEmpty(exception.StackTrace))
            {
                detailBuilder.AppendLine("STACK TRACE: " + exception.StackTrace);
            }

            //Inner exception
            if (exception.InnerException != null)
            {
                AddExceptionToDetails(exception.InnerException, detailBuilder);
            }

            //Inner exceptions for AggregateException
            if (exception is AggregateException)
            {
                var aggException = exception as AggregateException;
                if (aggException.InnerExceptions == null || aggException.InnerExceptions.Count <= 0)
                {
                    return;
                }

                foreach (var innerException in aggException.InnerExceptions)
                {
                    AddExceptionToDetails(innerException, detailBuilder);
                }
            }
        }
    }
}
