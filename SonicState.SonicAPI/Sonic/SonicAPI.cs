﻿using Newtonsoft.Json;
using System.Net;

namespace SonicState.SonicAPI
{
    internal abstract class SonicApi
    {
        private readonly string _urlFormat = "https://api.sonicapi.com/{0}?access_id=72c66333-17cb-4d96-b4a5-a5ef27b10580&input_file={1}&format=json";
        	
        protected T Analyze<T>(string action, string fileUrl)
        {
            string address = EndpointAdress(action, fileUrl);
            string analizeAsString = Web().DownloadString(address);
            return DeserializeJson<T>(analizeAsString);
        }

        private WebClient Web()
        {
            var web = new WebClient();
            web.Headers.Add("user-agent", "SonicApiDemo");
            return web;
        }

        private string EndpointAdress(string taskUrl, string fileUrl)
        {
            return string.Format(_urlFormat, taskUrl, fileUrl);
        }

        private static T DeserializeJson<T>(string input)
        {
            var result = JsonConvert.DeserializeObject(input);
            var result2 = JsonConvert.DeserializeObject(result.ToString());
            return JsonConvert.DeserializeObject<T>(result2.ToString());
        }
    }
}
