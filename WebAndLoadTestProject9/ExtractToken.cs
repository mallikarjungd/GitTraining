using Microsoft.VisualStudio.TestTools.WebTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WebAndLoadTestProject9
{
    public class ExtractToken : ExtractionRule      //comments!
    {
        public override void Extract(object sender, ExtractionEventArgs e)
        {
            WebHeaderCollection list = e.Response.Headers;

            string locationHeader = e.WebTest.Context["token"].ToString();

            string location = locationHeader.ToString().Trim();
            int firstIndex = location.IndexOf('=');
            int lastIndex = location.IndexOf("&token_type");
            string token = location.Substring(firstIndex+1, lastIndex - firstIndex-1);
            e.WebTest.Context["BearerToken"] = token; //something!
        }
    }
}
