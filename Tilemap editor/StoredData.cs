using System.ComponentModel;
using System.Drawing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tilemap_editor
{
    public class StoredData
    {
        /*
            This class emulates an ini file. All data
            is kept in dictionaries and represented
            as strings
        */

        private string name;
        Dictionary<string, Dictionary<string, string>> data;

        public StoredData(string fileName)
        {
            this.name = fileName;
            string[] lines = LoadFile();
            data = Parse(lines);
        }
        // Read file
        private string[] LoadFile()
        {
            string[] lines = new string[] { };
            // If it doesn't exist, create it
            try
            {
                lines = File.ReadAllLines(name);
                return lines;
            }
            catch (Exception)
            {
                System.IO.File.WriteAllText(name, "");
                return lines;

            }
        }
        // Parse to dictionary format
        private Dictionary<string, Dictionary<string,string>> Parse(string[] lines)
        {
            Dictionary<string, Dictionary<string, string>> @return = new Dictionary<string, Dictionary<string, string>>();

            string category = "";
            // Loop through lines
            foreach (var line in lines)
            {
                // Do 1 of 3 things based on contents
                if (line == "")
                {
                    continue;
                }
                else if (line.StartsWith("[") && line.EndsWith("]"))
                {
                    // New category
                    category = line.Substring(1, line.Length - 2);
                    //category = line;
                    @return[category] = new Dictionary<string, string>();
                    continue;
                }
                else
                {
                    // Line of format "id=value"
                    string[] split = line.Split('=');
                    string id = split[0].Trim(),
                           value = split[1].Trim();
                    @return[category][id] = value;
                }

            }
            return @return;
        }
        public void Remove(string category, string id)
        {
            if (data[category].ContainsKey(id))
            {
                data[category].Remove(id);
                MessageBox.Show("Removed");
                SaveRbs();
                RefreshRbs();
            }
            else
            {
                MessageBox.Show("Not present");
            }
        }
        public void RemoveAll(string category)
        {
            if (data.ContainsKey(category))
            {
                data.Remove(category);
                MessageBox.Show("Removed");
                SaveRbs();
                RefreshRbs();
            }

        }
        // Read .rbs
        public string Read(string cat, string id)
        {
            RefreshRbs();
            try
            {
                return data[cat][id];
            }
            catch
            {
                //MessageBox.Show("Not present");
                return "";
            }
        }
        // Read category
        public Dictionary<string, string> ReadCategory(string cat)
        {
            Dictionary<string, string> temp = new Dictionary<string, string>();

            try
            {

                // Set up as a dictionary of dictionaries
                foreach (var line in data[cat])
                {
                    string key = line.Key;
                    string value = line.Value;
                    temp[key] = value;
                }
            }
            catch
            {
                //MessageBox.Show("Not present");
            }
            return temp;
        }
        public void Write(string cat, string id, string value)
        {
            // Add if not present
            if (!data.ContainsKey(cat))
            {
                data[cat] = new Dictionary<string, string>();
            }
            data[cat][id] = value;
            SaveRbs();
        }
        public void SaveRbs()
        {
            // Write dictionary
            System.IO.File.WriteAllLines(name, GetDAsLnes());
        }

        public void RefreshRbs()
        {
            string[] lines = LoadFile();
            data = Parse(lines);
        }

        private string[] GetDAsLnes()
        {
            List<string> @return = new List<string>();

            // Loop through each category
            foreach (var cat in data.Keys)
            {
                @return.Add($"[{cat}]");
                // Then through each id
                foreach (var pair in data[cat])
                {
                    string temp = $"{pair.Key}={pair.Value}";
                    @return.Add(temp);
                }
                @return.Add("");
            }

            return @return.ToArray();
        }
        public List<List<int>> DeserializeListList(string cat, string id)
        {
            string serialized = data[cat][id];
            string[] serializedArr = serialized.Split(',');
            int w = Convert.ToInt32(serializedArr[0]);
            int h = Convert.ToInt32(serializedArr[1]);
            List<List<int>> @return = new List<List<int>>();
            serializedArr = serializedArr.Skip(2).ToArray();
            int index = 0;

            for (int i = 0; i < w; i++)
            {
                @return.Add(new List<int>());
                for (int j = 0; j < h; j++)
                {
                    var item = Convert.ToInt32(serializedArr[index++], 16);
                    @return[i].Add(item);
                }
            }

            return @return;


        }
        public string StringifyBitmap (Bitmap bmp)
        {
            string @return = "";
            int width = bmp.Width;
            int height = bmp.Height;
            int[] intArray = new int[width * height + 2];
            intArray[0] = width;
            intArray[1] = height;
            int arrayIndex = 2;
            StringBuilder sb = new StringBuilder();
            sb.Append($"{width.ToString("X")},{height.ToString("X")}");
            for (int y = 0; y < bmp.Height; y++)
            {
                for (int x = 0; x < bmp.Width; x++)
                {
                    Color clr = bmp.GetPixel(x, y);
                    int clrCoded = (clr.A << 24) | (clr.R << 16) | (clr.G << 8) | (clr.B << 0);
                    sb.Append("," + clrCoded.ToString("X8"));
                }
                sb.Append('\n');
            }

            return sb.ToString();
        }
        //public Bitmap ParseBitmap(string str)
        //{
        //    int[] intArray = str.Split(',').Select(e => Convert.ToInt32(e, 16)).ToArray();
        //    int w = 
        //    DirectBitmap directBitmap = 
        //}

    }
}
