using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvalancheDotNet.Dto
{
    public class ApiResult<T>
    {
        public string jsonrpc { get; set; }
        public int id { get; set; }
        public T result { get; set; }
    }
    public class ApiResult : ApiResult<object> { }
}
