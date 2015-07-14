using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebAPI.ApiResult
{
    public class CRUDResult
    {
        public bool result { get; set; }
        public int result_code { get; set; }
        public string data { get; set; }
    }
}
