using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebAPI.ApiResult
{
    /// <summary>
    /// to extract a CRUDResult.data for POST,PATCH,DELETE (a JSON string retrieve from SERVER containing 2 value : int result, string message)
    /// </summary>
    public class GeneralResult
    {
        public int result_code { get; set; }
        public string message { get; set; }
    }
}
