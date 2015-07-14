using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Web;
using System.Collections.Specialized;
using System.Windows.Forms;
using WebAPI.ApiResult;

namespace WebAPI
{
    public class ApiActions
    {
        public const int CACHE_ENTRY_NOT_FOUND = 0;
        public const int CONNECT_FAILURE = 1;
        public const int CONNECTION_CLOSED = 2;
        public const int KEEP_ALIVE_FAILURE = 3;
        public const int MESSAGE_LENGTH_LIMIT_EXCEEDED = 4;
        public const int NAME_RESOLUTION_FAILURE = 5;
        public const int PENDING = 6;
        public const int PIPE_LINE_FAILURE = 7;
        public const int PROTOCOL_ERROR = 8;
        public const int PROXY_NAME_RESOLUTION_FAILURE = 9;
        public const int RECEIVE_FAILURE = 10;
        public const int REQUEST_CANCEL = 11;
        public const int REQUEST_PROHIBITED_BY_CACHE_POLICY = 12;
        public const int REQUEST_PROHIBITED_BY_PROXY = 13;
        public const int SECURE_CHANNEL_FAILURE = 14;
        public const int SEND_FAILURE = 15;
        public const int SERVER_PROTOCOL_VIOLATION = 16;
        public const int TIME_OUT = 17;
        public const int TRUST_FAILURE = 18;
        public const int UNKNOWN_ERROR = 19;
        public const int SUCCESS = 99;

        /*
        public static Boolean server_connected(int user_id)
        {
            string get_result = ApiActions.GET(ApiConfig.API_SITE + "users/check_connection?id=" + user_id);
            GeneralPostResult res = JsonConvert.DeserializeObject<GeneralPostResult>(get_result);

            if (res.result == SERVER_CONNECTED)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        */

        // Get data as JSON string from server
        /// <summary>
        /// Get data from Server as JSON array (both singular data object and multiple daba object),
        /// </summary>
        /// <param name="url">Url path to web api to get data</param>
        /// <returns> CRUDResult containing 3 public value : bool result, int result_code, string data</returns>
        public static CRUDResult GET(string url)
        {
            Cursor.Current = Cursors.WaitCursor;
            CRUDResult res = new CRUDResult();

            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                
                WebResponse response = request.GetResponse();

                using (Stream responseStream = response.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                    res.result = true;
                    res.result_code = SUCCESS;
                    res.data = reader.ReadToEnd();
                }
            }
            catch (WebException ex)
            {
                res.result = false;
                res = ApiActions.formatErrorData(res, ex.Status);
            }
            Cursor.Current = Cursors.Default;
            return res;
        }

        // Delete data on server
        /// <summary>
        /// Delete data on Server by passing row ID
        /// </summary>
        /// <param name="url">Url path to web api to delete data</param>
        /// <returns> CRUDResult containing 3 public value : bool result, int result_code, string data</returns>
        public static CRUDResult DELETE(string url)
        {
            Cursor.Current = Cursors.WaitCursor;
            CRUDResult res = new CRUDResult();

            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

                WebResponse response = request.GetResponse();

                using (Stream responseStream = response.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                    res.result = true;
                    res.result_code = SUCCESS;
                    res.data = reader.ReadToEnd();
                }
            }
            catch (WebException ex)
            {
                res.result = false;
                res = ApiActions.formatErrorData(res, ex.Status);
            }
            Cursor.Current = Cursors.Default;
            return res;
        }

        // POST data as JSON string to server and receive result as JSON string
        /// <summary>
        /// Post data as JSON string to Server to process,
        /// this method for POST,PATCH
        /// </summary>
        /// <param name="url">Url path to web api</param>
        /// <param name="postContent">The JSON string content to post to Server</param>
        /// <returns> CRUDResult containing 3 public value : bool result, int result_code, string data</returns>
        public static CRUDResult POST(string url, string postContent)
        {
            Cursor.Current = Cursors.WaitCursor;
            CRUDResult res = new CRUDResult();
            
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "POST";

                System.Text.UTF8Encoding encoding = new System.Text.UTF8Encoding();
                Byte[] byteArray = encoding.GetBytes(postContent);

                request.ContentLength = byteArray.Length;
                request.ContentType = @"application/json; charset=utf-8";

                using (Stream dataStream = request.GetRequestStream())
                {
                    dataStream.Write(byteArray, 0, byteArray.Length);
                }
                long length = 0;

                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    length = response.ContentLength;

                    using (Stream response_stream = response.GetResponseStream())
                    {
                        using (StreamReader reader = new StreamReader(response_stream))
                        {
                            res.result = true;
                            res.result_code = SUCCESS;
                            res.data = reader.ReadToEnd();
                        }
                    }
                }
            }
            catch (WebException ex)
            {
                res.result = false;
                res = ApiActions.formatErrorData(res, ex.Status);
            }
            Cursor.Current = Cursors.Default;
            return res;
        }


        /// <summary>
        /// Format an error result
        /// </summary>
        /// <param name="crud_result">The CRUDResult to format</param>
        /// <param name="exception_status">The WebExceptionStatus</param>
        /// <returns>CRUDResult that formatted</returns>
        public static CRUDResult formatErrorData(CRUDResult crud_result, WebExceptionStatus exception_status)
        {
            CRUDResult res = crud_result;
            switch (exception_status)
            {
                case WebExceptionStatus.CacheEntryNotFound:
                    res.result_code = CACHE_ENTRY_NOT_FOUND;
                    res.data = "{\"result\":" + CACHE_ENTRY_NOT_FOUND + ",\"message\":\"Cache entry not found.\"}";
                    break;
                case WebExceptionStatus.ConnectFailure:
                    res.result_code = CONNECT_FAILURE;
                    res.data = "{\"result\":1,\"message\":\"ไม่สามารถติดต่อเครื่อง Server ได้ , กรุณาตรวจสอบการเชื่อมต่ออินเตอร์เน็ท\"}";
                    break;
                case WebExceptionStatus.ConnectionClosed:
                    res.result_code = CONNECTION_CLOSED;
                    res.data = "{\"result\":" + CONNECTION_CLOSED + ",\"message\":\"Connection closed.\"}";
                    break;
                case WebExceptionStatus.KeepAliveFailure:
                    res.result_code = KEEP_ALIVE_FAILURE;
                    res.data = "{\"result\":" + KEEP_ALIVE_FAILURE + ",\"message\":\"Keep alive failure.\"}";
                    break;
                case WebExceptionStatus.MessageLengthLimitExceeded:
                    res.result_code = MESSAGE_LENGTH_LIMIT_EXCEEDED;
                    res.data = "{\"result\":" + MESSAGE_LENGTH_LIMIT_EXCEEDED + ",\"message\":\"Message length limit exceeded.\"}";
                    break;
                case WebExceptionStatus.NameResolutionFailure:
                    res.result_code = NAME_RESOLUTION_FAILURE;
                    res.data = "{\"result\":" + NAME_RESOLUTION_FAILURE + ",\"message\":\"Name resolution failure.\"}";
                    break;
                case WebExceptionStatus.Pending:
                    res.result_code = PENDING;
                    res.data = "{\"result\":" + PENDING + ",\"message\":\"Pending.\"}";
                    break;
                case WebExceptionStatus.PipelineFailure:
                    res.result_code = PIPE_LINE_FAILURE;
                    res.data = "{\"result\":" + PIPE_LINE_FAILURE + ",\"message\":\"Pipe line failure.\"}";
                    break;
                case WebExceptionStatus.ProtocolError:
                    res.result_code = PROTOCOL_ERROR;
                    res.data = "{\"result\":" + PROTOCOL_ERROR + ",\"message\":\"Protocol error.\"}";
                    break;
                case WebExceptionStatus.ProxyNameResolutionFailure:
                    res.result_code = PROXY_NAME_RESOLUTION_FAILURE;
                    res.data = "{\"result\":" + PROXY_NAME_RESOLUTION_FAILURE + ",\"message\":\"Proxy name resolution failure.\"}";
                    break;
                case WebExceptionStatus.ReceiveFailure:
                    res.result_code = RECEIVE_FAILURE;
                    res.data = "{\"result\":" + RECEIVE_FAILURE + ",\"message\":\"Receive failure.\"}";
                    break;
                case WebExceptionStatus.RequestCanceled:
                    res.result_code = REQUEST_CANCEL;
                    res.data = "{\"result\":" + REQUEST_CANCEL + ",\"message\":\"Request cancel.\"}";
                    break;
                case WebExceptionStatus.RequestProhibitedByCachePolicy:
                    res.result_code = REQUEST_PROHIBITED_BY_CACHE_POLICY;
                    res.data = "{\"result\":" + REQUEST_PROHIBITED_BY_CACHE_POLICY + ",\"message\":\"Request prohibited by cache policy.\"}";
                    break;
                case WebExceptionStatus.RequestProhibitedByProxy:
                    res.result_code = REQUEST_PROHIBITED_BY_PROXY;
                    res.data = "{\"result\":" + REQUEST_PROHIBITED_BY_PROXY + ",\"message\":\"Request prohibited by proxy.\"}";
                    break;
                case WebExceptionStatus.SecureChannelFailure:
                    res.result_code = SECURE_CHANNEL_FAILURE;
                    res.data = "{\"result\":" + SECURE_CHANNEL_FAILURE + ",\"message\":\"Secure channel failure.\"}";
                    break;
                case WebExceptionStatus.SendFailure:
                    res.result_code = SEND_FAILURE;
                    res.data = "{\"result\":" + SEND_FAILURE + ",\"message\":\"Send failure.\"}";
                    break;
                case WebExceptionStatus.ServerProtocolViolation:
                    res.result_code = SERVER_PROTOCOL_VIOLATION;
                    res.data = "{\"result\":" + SERVER_PROTOCOL_VIOLATION + ",\"message\":\"Server protocol violation.\"}";
                    break;
                //case WebExceptionStatus.Success:
                //    break;
                case WebExceptionStatus.Timeout:
                    res.result_code = TIME_OUT;
                    res.data = "{\"result\":" + TIME_OUT + ",\"message\":\"Time out.\"}";
                    break;
                case WebExceptionStatus.TrustFailure:
                    res.result_code = TRUST_FAILURE;
                    res.data = "{\"result\":" + TRUST_FAILURE + ",\"message\":\"Trust failure.\"}";
                    break;
                case WebExceptionStatus.UnknownError:
                    res.result_code = UNKNOWN_ERROR;
                    res.data = "{\"result\":" + UNKNOWN_ERROR + ",\"message\":\"Unknown error.\"}";
                    break;
                default:
                    res.result_code = UNKNOWN_ERROR;
                    res.data = "{\"result\":" + UNKNOWN_ERROR + ",\"message\":\"Unknown error.\"}";
                    break;
            }
            return crud_result;
        }
    }
}
