using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibrary
{
    public interface IHaveIdNamePath
    {
        string id { get; set; }
        string name { get; set; }
        string path { get; set; }
    }
}
