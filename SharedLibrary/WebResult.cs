using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibrary
{
    public class WebResult
    {
        public bool IsSuccessful { get; set; }
        public bool CallWasSuccessful { get; set; }
        public string Data { get; set; }
        public bool GoodToGo
        {
            get {
                return CallWasSuccessful && IsSuccessful;
            }
        }
        public string ErrorMessage { get; set; }
        public List<string> ErrorMessages
        {
            get {
                var list = new List<string>();
                if (!GoodToGo) {
                    list.Add(Data);
                    if (ErrorMessage != null) {
                        list.Add(ErrorMessage);
                    }
                }
                return list;
            }
        }
    }
}
