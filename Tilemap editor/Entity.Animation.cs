using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tilemap_editor
{
    public partial class Entity
    {
        List<Bitmap> animation = new List<Bitmap>();
        int frameNumber = 0;
        List<int> duration = new List<int>();
        int durationIndex = 0;
        static byte[] paramAnimationCountLut = new byte[] { 0,   };



    }
}
