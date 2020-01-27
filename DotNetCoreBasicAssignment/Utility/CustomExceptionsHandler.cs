using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;

namespace DotNetCoreBasicAssignment.Utility
{
    public class CustomExceptionsHandler : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            //HttpStatusCode status = HttpStatusCode.InternalServerError;
            String message = String.Empty;
            string resultData = "";         
            var exceptionType = GetErrorCode(context.Exception.GetType());
            string Source = context.Exception.Source;
            var Target = context.Exception.TargetSite;
            string errorMessage = context.Exception.Message;
            string customErrorMessage = context.Exception.Message;
            string stackTrace = context.Exception.StackTrace;

            
            HttpResponse response = context.HttpContext.Response;
            response.StatusCode = (int)exceptionType;
            response.ContentType = "application/json";
            resultData = "Error: " + errorMessage + Environment.NewLine +
                         "Source: " + Source + Environment.NewLine +
                         "Target: " + Target + Environment.NewLine +
                         "Exception Type:" + context.Exception.GetType() + Environment.NewLine +
                         "StackTrace: " + stackTrace;

            logErrorIntoFile(resultData);
           
        }

        private void logErrorIntoFile(string resultData)
        {
            string fileName = "ExceptionLog" + "_" + DateTime.Now.ToString("MM_dd_yyyy_HH_mm_ss_fff");
            string path = @"C:\Temp\ExceptionLogFile\" + fileName + ".txt";
           
            using (StreamWriter streamWriter = File.AppendText(path))
            {
                streamWriter.WriteLine(resultData);
                //foreach (var lines in resultData) {
                //    lines.WriteAllText(path, resultData);
                //}
            }
        }

        private HttpStatusCode GetErrorCode(Type exceptionType)
        {
            Exceptions tryParseResult;
            if (Enum.TryParse<Exceptions>(exceptionType.Name, out tryParseResult))
            {
                switch (tryParseResult)
                {
                    case Exceptions.NullReferenceException:
                        return HttpStatusCode.LengthRequired;

                    case Exceptions.FileNotFoundException:
                        return HttpStatusCode.NotFound;

                    case Exceptions.OverflowException:
                        return HttpStatusCode.RequestedRangeNotSatisfiable;

                    case Exceptions.OutOfMemoryException:
                        return HttpStatusCode.ExpectationFailed;

                    case Exceptions.InvalidCastException:
                        return HttpStatusCode.PreconditionFailed;

                    case Exceptions.ObjectDisposedException:
                        return HttpStatusCode.Gone;

                    case Exceptions.UnauthorizedAccessException:
                        return HttpStatusCode.Unauthorized;

                    case Exceptions.NotImplementedException:
                        return HttpStatusCode.NotImplemented;

                    case Exceptions.NotSupportedException:
                        return HttpStatusCode.NotAcceptable;

                    case Exceptions.InvalidOperationException:
                        return HttpStatusCode.MethodNotAllowed;

                    case Exceptions.TimeoutException:
                        return HttpStatusCode.RequestTimeout;

                    case Exceptions.ArgumentException:
                        return HttpStatusCode.BadRequest;

                    case Exceptions.StackOverflowException:
                        return HttpStatusCode.RequestedRangeNotSatisfiable;

                    case Exceptions.FormatException:
                        return HttpStatusCode.UnsupportedMediaType;

                    case Exceptions.IOException:
                        return HttpStatusCode.NotFound;

                    case Exceptions.IndexOutOfRangeException:
                        return HttpStatusCode.ExpectationFailed;
                    
                    default:
                        return HttpStatusCode.InternalServerError;
                }
            }
            else
            {
                return HttpStatusCode.InternalServerError;
            }
        }
    }
}
