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
    public partial class LayerControl : Form
    {
        List<VerticalLayer> layers;
        VerticalLayer selected;
        public LayerControl(List<VerticalLayer> layers)
        {
            InitializeComponent();
            this.layers = layers;

            var newLayers = new List<VerticalLayer>();
            newLayers.AddRange(layers);
            newLayers.RemoveAt(newLayers.Count - 1);
            comboBox1.Items.AddRange(newLayers.ToArray());
            comboBox1.SelectedIndex = 0;

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            selected = (VerticalLayer)comboBox1.SelectedItem;
            numericUpDown1.Value = selected.x;
            numericUpDown2.Value = selected.y;            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            selected.x = (int)numericUpDown1.Value;
            selected.y = (int)numericUpDown2.Value;

        }
    }
}
