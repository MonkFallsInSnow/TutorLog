using System;
using System.Collections.Specialized;
using System.Net;
using TutorLog.Handlers.Errors;

namespace TutorLog.Handlers.Requests
{
    public class LoginRequest : IRequestHandler<string, NameValueCollection>
    {
        private IErrorHandler errorHandler;

        public LoginRequest(IErrorHandler errorHandler)
        {
            this.errorHandler = errorHandler;
        }

        public string MakeRequest(string url, NameValueCollection data)
        {
            if (data != null)
            {
                try
                {
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Constants.LoginURL);

                    request.ContentType = "application/x-www-form-urlencoded";
                    request.Method = WebRequestMethods.Http.Post;
                    request.AllowAutoRedirect = false;

                    byte[] postData = System.Text.Encoding.UTF8.GetBytes(data.ToString());
                    request.ContentLength = postData.Length;


                    using (var stream = request.GetRequestStream())
                    {
                        stream.Write(postData, 0, postData.Length);
                    }

                    using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                    {
                        if (response.StatusCode == HttpStatusCode.Found)
                        {
                            return response.Headers[HttpResponseHeader.SetCookie];
                        }
                        else
                        {
                            this.errorHandler.ShowErrorDialog("Login Error", "User not found!");
                        }
                    }
                }
                catch (Exception ex)
                {
                    this.errorHandler.ShowErrorDialog("Login Error", ex.Message);
                }
            }

            return string.Empty;
        }
    }
}
