using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Tilemap_editor
{
    public partial class DKCLevel
    {
        public List<Entrance> entrances = new List<Entrance>();
        public List<VerticalCamera> verticalCameras = new List<VerticalCamera>();
        public bool autoconnectVertical = false;

        public List<Entrance> GetEntrancesByLevel()
        {
            Entrance.GetGraphic();

            Entrance.counter = 0;
            List<Entrance> @return = new List<Entrance>();
            for (int i = 1; i < 0xe5; i++)
            {
                var entrance = rom.levelNameByCode[i];
                var index = i * 4;
                var offset = 0xBCBEF0 + index;
                bool checkpoint = entrance.Contains("Save");
                if (checkpoint && Global.bindCheckpoints)
                    continue;
                if (i == 0x16 && Global.bind1_1)
                    continue;
                if (entrance.Contains("- Bonus") || entrance.Contains("Kong's Cabin") || entrance.Contains("empty") || entrance.Contains("empty") || entrance.Contains("full"))
                    continue;
                if (entrance.Contains(lvlName))
                {
                    // i == code
                    @return.Add(new Entrance(offset, rom, this, i));                    
                }
            }
            return @return;
        }
        public void WriteEntrancesToROM()
        {
            foreach (var entrance in entrances)
            {
                int address = entrance.address;
                rom.Write16(address + 0, entrance.x);
                rom.Write16(address + 2, entrance.y);

            }
        }
        private List<VerticalCamera> GetVerticalCameras()
        {
            List<VerticalCamera> @return = new List<VerticalCamera>();
            if (rom.IsVertical(levelCode))
            {
                verticalCameras = new List<VerticalCamera>();
                // FIXME
                WriteLayersToROM();


                int offset;
                if (levelCode == 0x6d)
                {
                    offset = 0xb35f;
                } else
                {
                    offset = 0xab8c;
                }
                int start = rom.verticalCameraStart[levelCode];
                int end = rom.verticalCameraEnd[levelCode];
                string temp = "";
                for (int i = start, j = 0; i <= end; i += 2, j++)
                {
                    int prevPointerAddress = 0xb80000 + offset + i - 2;
                    int prevPointer = rom.Read16(prevPointerAddress);
                    int pointerAddress = 0xb80000 + offset + i;
                    int pointer = rom.Read16(pointerAddress);
                    int nextAddress = 0xb80000 + offset + i + 2;
                    int nextPointer = rom.Read16(nextAddress);
                    if (pointer == nextPointer)
                    {
                        break;
                    }
                    var vc = new VerticalCamera(offset, rom, this, j, i, i + 2, pointerAddress, nextAddress, prevPointer, prevPointerAddress);
                    //var vc = new VerticalCamera(offset, rom, this, j, poi, nextPointer);
                    @return.Add(vc);
                    //temp += $"{i.ToString("X2")}: {vc} Pointer {pointer.ToString("X")}\n";
                    temp += $"{i.ToString("X2")}: {vc}\n";
                }
                //Clipboard.SetText(temp);

            }

            return @return;
        }
        private void WriteVcamsToROM()
        {
            if (!rom.IsVertical(levelCode))
                return;


            if (CheckSizeOfVerticalCameras())
            {
                // Write new pointers
                int offset;
                if (levelCode == 0x6d)
                {
                    offset = 0xb35f;
                }
                else
                {
                    offset = 0xab8c;
                }
                // Start at first pointr per level
                int start = rom.verticalCameraStart[levelCode];
                int end = rom.verticalCameraEnd[levelCode];
                int startAddress = 0xb80000 + offset + start;
                int endAddress = 0xb80000 + offset + end;
                int pointer = rom.Read16(startAddress);
                for (int i = 0; i < verticalCameras.Count; i++)
                {
                    var cam = verticalCameras[i];
                    cam.address = 0xb80000 + pointer + offset;

                    // Modify
                    startAddress += 2;
                    // Leave for now
                    //if (startAddress == endAddress)
                    //    break;
                    pointer += cam.GetBytes().Length;
                    rom.Write16(startAddress, pointer);

                }
                while (startAddress < endAddress - 2)
                {
                    startAddress += 2;
                    rom.Write16(startAddress, pointer);
                }



                //return;
                foreach (var v in verticalCameras)
                {
                    v.WriteCamToROM();
                }
            }
            else
            {
                MessageBox.Show("Too many cameras.\nCameras not updated in ROM");
            }
        }

        private bool CheckSizeOfVerticalCameras()
        {
            int offset;
            if (levelCode == 0x6d)
            {
                offset = 0xb35f;
            }
            else
            {
                offset = 0xab8c;
            }

            int start = 0xb80000 + offset + rom.verticalCameraStart[levelCode];
            int end = 0xb80000 + offset + rom.verticalCameraEnd[levelCode];
            int dif = (end - start + 2) / 2;
            if (dif < verticalCameras.Count)
            {
                return false;
            }

            ushort endAddressOG = rom.Read16(end + 2);
            ushort startAddressOG = rom.Read16(start);
            int romSize = endAddressOG - startAddressOG;
            int potentialSize = 0;
            foreach (var vCam in verticalCameras)
            {
                potentialSize += vCam.GetBytes().Length;
            }
            return (potentialSize <= romSize);
        }
        private void AutoconnectVerticalCameras ()
        {
            Dictionary<string, string> oppositeDirectionLUT = new Dictionary<string, string>()
            {
                ["U"] = "D",
                ["D"] = "U",
                ["L"] = "R",
                ["R"] = "L",
            };
            for (int i = 0; i < verticalCameras.Count - 1; i++)
            {
                // Look at camera i
                var camera = verticalCameras[i];
                // Look at next camera
                var nextCamera = verticalCameras[i + 1];
                string direction = nextCamera.FindDirectionOfNextCamera(camera.xStart, camera.yStart, camera.xEnd, camera.yEnd);
                camera.AddUniqueConnection(direction, 1, true);

            }
        }
        private void ConnectNextVerticalCamera (int index)
        {
            Dictionary<string, string> oppositeDirectionLUT = new Dictionary<string, string>()
            {
                ["U"] = "D",
                ["D"] = "U",
                ["L"] = "R",
                ["R"] = "L",
            };
            // Look at camera i
            var camera = verticalCameras[index];
            // Look at next camera
            var nextCamera = verticalCameras[index + 1];
            string direction = nextCamera.FindDirectionOfNextCamera(camera.xStart, camera.yStart, camera.xEnd, camera.yEnd);
            camera.AddUniqueConnection(direction, 1, true);

        }
        public void ConnectAllVerticalCameras()
        {
            AutoconnectVerticalCameras();

            Dictionary<string, string> oppositeDirectionLUT = new Dictionary<string, string>()
            {
                ["U"] = "D",
                ["D"] = "U",
                ["L"] = "R",
                ["R"] = "L",
            };
            // Look at each camera
            for (int i = 0; i < verticalCameras.Count; i++)
            {
                var verticalCamera = verticalCameras[i];
                // Search connections
                for (int j = 0; j < verticalCamera.vConnections.Count; j++)
                {
                    var connection = verticalCamera.vConnections[j];
                    // What direction is this in? 
                    string directionFrom = connection.direction;
                    // Where do we go?
                    string directionTo = oppositeDirectionLUT[directionFrom];
                    // Is this a relative pointer or absolute?
                    var relative = connection.relative;
                    var connectFrom = i;
                    var connectTo = connection.nextIndex;
                    int connectToAdd = connection.nextIndex;
                    if (relative)
                    {
                        if (connectTo >= 8)
                        {
                            connectTo -= 0x10;
                            connectToAdd = 0x10 - connectToAdd;
                        }
                        else
                        {
                            connectToAdd = 0x10 - connectToAdd;
                        }
                        connectTo += connectFrom;
                    }
                    // Connect if that camera exists
                    if (connectTo < verticalCameras.Count && connectTo >= 0)
                    {
                        verticalCameras[connectTo].AddUniqueConnection(directionTo, connectToAdd, relative);
                    }
                }
            }
            foreach (var camera in verticalCameras)
            {
                camera.SetAllMultiples();
            }

        }
        public void ConnectVerticalCameras(int index)
        {
            ConnectNextVerticalCamera(index);

            Dictionary<string, string> oppositeDirectionLUT = new Dictionary<string, string>()
            {
                ["U"] = "D",
                ["D"] = "U",
                ["L"] = "R",
                ["R"] = "L",
            };
            // Look at each camera
            for (int i = index; i <= index; i++)
            {
                var verticalCamera = verticalCameras[i];
                // Search connections
                for (int j = 0; j < verticalCamera.vConnections.Count; j++)
                {
                    var connection = verticalCamera.vConnections[j];
                    // What direction is this in? 
                    string directionFrom = connection.direction;
                    // Where do we go?
                    string directionTo = oppositeDirectionLUT[directionFrom];
                    // Is this a relative pointer or absolute?
                    var relative = connection.relative;
                    var connectFrom = i;
                    var connectTo = connection.nextIndex;
                    int connectToAdd = connection.nextIndex;
                    if (relative)
                    {
                        if (connectTo >= 8)
                        {
                            connectTo -= 0x10;
                            connectToAdd = 0x10 - connectToAdd;
                        }
                        else
                        {
                            connectToAdd = 0x10 - connectToAdd;
                        }
                        connectTo += connectFrom;
                    }
                    // Connect if that camera exists
                    if (connectTo < verticalCameras.Count && connectTo >= 0)
                    {
                        verticalCameras[connectTo].AddUniqueConnection(directionTo, connectToAdd, relative);
                    }
                }
            }
            verticalCameras[index].SetAllMultiples();
        }
    }
}
