using System;
using System.ComponentModel.DataAnnotations;

namespace ProjectApi.CommConstants
{
    public interface IRequest
    {
        bool HasData { get; }
    }

    public abstract class DataRequest : IRequest
    {
        public bool HasData 
        { 
            get { return true; } 
        }
    }

    public abstract class NoDataRequest : IRequest
    {
        protected NoDataRequest()
        {

        }

        public bool HasData
        {
            get { return false; }
        }
    }
}
