using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileExplorer.Models
{
    public class FE_LocalDriveInfo_M
    {
        public string Name { get; set; }
        public long UsedSpacePercent { get; set; }
        public string SpaceInfo { get; set; }
        public string DriveImage { get; set; }
        public bool IsReady { get; set; }
    }
}
