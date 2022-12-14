using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Galaxy.DI.Web
{
    public class GuidServiceSingleton
    {
        private Guid _serviceGuid { get; }
        public GuidServiceSingleton()
        {
            _serviceGuid = Guid.NewGuid();
        }
        public string GetGuid()
        {
            return _serviceGuid.ToString();
        }
    }
}
