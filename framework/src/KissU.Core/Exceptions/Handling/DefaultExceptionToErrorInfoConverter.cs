using System;
using System.Text;
using KissU.Dependency;

namespace KissU.Exceptions.Handling
{
    public class DefaultExceptionToErrorInfoConverter : IExceptionToErrorInfoConverter, ITransientDependency
    {
        public RemoteServiceErrorInfo Convert(Exception exception, bool includeSensitiveDetails)
        {
            if (includeSensitiveDetails)
            {
                return CreateDetailedErrorInfoFromException(exception);
            }

            exception = TryToGetActualException(exception);
            var errorInfo = new RemoteServiceErrorInfo();
            errorInfo.Message = "服务器内部错误";
            errorInfo.Data = exception.Data;
            return errorInfo;

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
