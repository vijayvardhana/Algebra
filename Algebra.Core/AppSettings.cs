using System;
using System.Collections.Generic;
using System.Text;

namespace Algebra.Core
{
    public class AppSettings
    {
        public AppSettings()
        {
        }

        public string Website { get; set; }
        public string Name { get; set; }
        public string Version { get; set; }
        public string TempFolder { get; set; }
        public string AssetFolder { get; set; }
    }
}
