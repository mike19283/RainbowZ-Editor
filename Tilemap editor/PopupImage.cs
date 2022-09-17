using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tilemap_editor
{
    public partial class PopupImage : Form
    {
        public PopupImage(Bitmap bmp)
        {
            InitializeComponent();
            this.Size = bmp.Size;
            pictureBox_copyPreview.Image = bmp;
        }
    }
}
