using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tilemap_editor
{
    partial class Tile_display
    {
        private void button_waterSet_Click(object sender, EventArgs e)
        {
            form.autoWaterSize = (int)numericUpDown_size.Value;
            label_height_width.Text = form.autoWaterSize.ToString("X2");

        }

    }
}
