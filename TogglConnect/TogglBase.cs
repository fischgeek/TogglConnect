using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SharedLibrary;
using static SharedLibrary.ConsoleShortcuts;

namespace TogglConnect
{
    public class TogglBase
    {
        public static TogglBase Instance = new TogglBase();

        private TogglBase() { }

        public static TogglBase GetInstance()
        {
            return Instance;
        }

        private static string baseUrl = "https://www.toggl.com/api/v8";
        public string username { get; set; }
        public string password { get; set; }
        public string apiKey { get; set; }
        public string authString
        {
            get {
                return JFUtil.Base64Encode($"{this.apiKey}:api_token");
            }
        }
        public int wid { get; set; }

        public void Init(string apiKey, int wid)
        {
            this.apiKey = apiKey;
            this.wid = wid;
        }

        public void Init(string apiKey, string username, string password, int wid)
        {
            this.apiKey = apiKey;
            this.username = username;
            this.password = password;
            this.wid = wid;
        }

        public User GetMe()
        {
            var url = $"{baseUrl}/me";
            var x = WebCall.GetRequestWithErrorHandling(url, this.authString);
            var t = JsonConvert.DeserializeObject<User>(x.Data);
            return t;
        }

        public void GetClients()
        {
            var url = $"{baseUrl}/clients";
            var x = WebCall.GetRequestWithErrorHandling(url, this.authString);
            var t = JsonConvert.DeserializeObject<List<Client>>(x.Data);
        }

        public List<Project> GetProjects()
        {
            var url = $"{baseUrl}/workspaces/{this.wid}/projects";
            var x = WebCall.GetRequestWithErrorHandling(url, this.authString);
            var t = JsonConvert.DeserializeObject<List<Project>>(x.Data);
            return t;
        }

        public TimeEntry GetRunningTimer()
        {
            var x = WebCall.GetRequestWithErrorHandling($"{baseUrl}/time_entries/current", this.authString);
            var t = JsonConvert.DeserializeObject<TimeEntryData>(x.Data);
            var timeEntry = t.data;
            return timeEntry;
        }

        public void StartTimer(TimeEntryWrapper wrapper)
        {
            var url = $"{baseUrl}/time_entries/start";
            var x = WebCall.PostRequestWithErrorHandling(url, wrapper, this.authString);
        }

        public void StopRunningTimer()
        {
            var te = GetRunningTimer();
            if (te != null) {
                var url = $"{baseUrl}/time_entries/{te.id}/stop";
                WebCall.PutRequest(url, basicAuth: this.authString);
            }
        }

        public string CurrentTimerDuration()
        {
            var ct = GetRunningTimer();
            if (ct != null) {
                var seconds = JFUtil.SecondsSinceEpoch() + ct.duration;
                var ts = new TimeSpan(0, 0, seconds);
                return $"{ts.Days}d {ts.Hours}h {ts.Minutes}m {ts.Seconds}s";
            }
            return "00:00:00";
        }
    }
}
