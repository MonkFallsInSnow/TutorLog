using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net;
using TutorLog.Data.Models;
using TutorLog.Handlers.Database;
using TutorLog.Handlers.Errors;

namespace TutorLog.Handlers.Requests
{
    public struct RecordRequestData
    {
        public readonly string Cookie;
        public readonly Campus Campus;

        public RecordRequestData(string cookie, Campus campus)
        {
            this.Cookie = cookie;
            this.Campus = campus;
        }
    }

    class RecordRequest : IRequestHandler<BindingList<SignInData>, RecordRequestData>
    {
        private IErrorHandler errorHandler;

        public RecordRequest(IErrorHandler errorHandler)
        {
            this.errorHandler = errorHandler;
        }

        public BindingList<SignInData> MakeRequest(string url, RecordRequestData data)
        {
            BindingList<SignInData> logData = new BindingList<SignInData>();

            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

                request.Headers[HttpRequestHeader.Cookie] = data.Cookie;
                request.Method = WebRequestMethods.Http.Get;

                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        using (var responseStream = response.GetResponseStream())
                        using (var streamReader = new System.IO.StreamReader(responseStream))
                        {
                            string jsonString = streamReader.ReadToEnd();
                            JObject json = JObject.Parse(jsonString);

                            foreach (var element in json[Constants.JsonDataKey])
                            {
                                SignInData row = this.BuildDataRow(element, data.Campus);

                                if (row != null)
                                {
                                    logData.Add(row);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                this.errorHandler.ShowErrorDialog("Request Error", ex.Message);
            }

            return logData;
        }

        private SignInData BuildDataRow(JToken element, Campus campus)
        {
            string currentCampusName = element[(int)Constants.JsonDataIndex.Campus].ToString();

            if (!string.IsNullOrEmpty(currentCampusName))
            {

                if (currentCampusName == campus.Name)
                {
                    return new SignInData(
                        element[(int)Constants.JsonDataIndex.Center].ToString(),
                        element[(int)Constants.JsonDataIndex.Campus].ToString(),
                        this.ExtractStudentID(element[(int)Constants.JsonDataIndex.StudentID].ToString()),
                        element[(int)Constants.JsonDataIndex.StudentName].ToString(),
                        this.ExtractCourseName(element[(int)Constants.JsonDataIndex.Course].ToString())
                    );
                }
            }

            return null;
        }

        private string ExtractStudentID(string value)
        {
            return System.Text.RegularExpressions.Regex.Match(value, @"\d+").Value;
        }

        //TODO: need to account for work indenpendt
        private string ExtractCourseName(string value)
        {
            string courseString = System.Text.RegularExpressions.Regex.Match(value, @"^[A-Z]{3}\-\d{3}").Value;
            string resultString = "";

            for(int i = 0; i < courseString.Length; i++)
            {
                if(courseString[i] != '-')
                {
                    resultString += courseString[i];
                }
                else
                {
                    resultString += ' ';
                }
            }

            return resultString;
        }
    }

    
}
