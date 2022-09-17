using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tilemap_editor
{
    public partial class ROM
    {
        public static Dictionary<int, Dictionary<int, List<List<int>>>> links = new Dictionary<int, Dictionary<int, List<List<int>>>>();

        public void SetupLinks()
        {
            // new Dictionary<int, Dictionary<int, List<List<int>>>>
            // List<List<int>> = (links[Level code])([tile])
            // 

        }
    }
}
