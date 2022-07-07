using ArtBloger.Shared.Utilities.Results.Abstract;
using ArtBloger.Shared.Utilities.Results.ComplexTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtBloger.Shared.Utilities.Results.Concrete
{
    public class DataResult<T> : IDataResult<T>
    {
        public DataResult(T data, ResultStatus resultStatus)
        {
            Data = data;
            ResultStatus = resultStatus;
        }

        public DataResult(T data, ResultStatus resultStatus, string message) : this(data, resultStatus)
        {
            Message = message;
        }

        public DataResult(T data, ResultStatus resultStatus, string message, Exception exception) : this(data, resultStatus, message)
        {
            Exception = exception;
        }

        public T Data { get; }

        public ResultStatus ResultStatus { get; }

        public string Message { get; }

        public Exception Exception { get; }
    }
}
