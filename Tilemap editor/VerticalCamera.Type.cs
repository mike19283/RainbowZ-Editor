using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tilemap_editor
{
    public partial class VerticalCamera
    {
        List<Point> line = new List<Point>();
        Bitmap region;
        public List<Func<Bitmap, int, Bitmap>> funcs = new List<Func<Bitmap, int, Bitmap>>();
        // Game vars
        int _1e0f = 0;
        int _50 = 0;
        int _52 = 0;
        int _54 = 0;
        int _56 = 0;
        int _58 = 0;
        int _5a = 0;
        int _5c = 0;
        int _5e = 0;
        int _4e = 0;
        int _4c = 0;
        // Proposed x
        int _1a5e = 0;
        // Proposed Y
        int _1a50 = 0;
        int aR = 0, xR = 0, yR = 0, yR2 = 0;
        bool zFlag, cFlag;
    


        public void GameSetup()
        {
            _1e0f = pointer;
            yR = rom.Read16(0xb80000 + _58 + pointer);
            _5c = rom.Read16(0xb80000 + _58 + nextPointer); 

            // Read xStart
            aR = ReadIndexedIndirect(yR);
            _50 = aR;
            yR += 2;
            // Read xSize
            aR = ReadIndexedIndirect(yR);
            aR &= 0xff;
            xSize = aR;
            aR <<= 2;
            // Calculate xEnd
            aR += _50;
            _52 = aR;
            yR++;

            // Read yStart
            aR = ReadIndexedIndirect(yR);
            _54 = aR;
            yR += 2;
            // Read ySize
            aR = ReadIndexedIndirect(yR);
            aR &= 0xff;
            ySize = aR;
            aR <<= 2;
            // Calculate yEnd
            aR += _54;
            _56 = aR;
            yR++;

            _5a = yR;

            xStart = _50;
            xEnd = _52;
            yStart = _54;
            yEnd = _56;

            zFlag = false;
            cFlag = false;

            ReadAllTypes();

            //Bitmap bmp = new Bitmap(xSize * 4 + 0x200, ySize * 4 + 0x1c0);
            //_50 = 
            //region = bmp;
        }
        private void ReadAllTypes()
        {
            line = new List<Point>();
            yR2 = yR;

            // Setup size
            //Bitmap bmp = new Bitmap(xSize * 4 + 0x100, ySize * 4 + 0xe0);

            for (int y = yStart; y <= yEnd + 0xe0; y++)
            {
                int max = 0, min = 0x800;
                for (int x = xStart; x <= xEnd; x++)
                {
                    yR = yR2;
                    _1a5e = x;
                    _1a50 = y;

                ReadAllTypes_Start:;
                    LDA_var(ref _5a);
                    yR = aR;
                    CMP(ref _5c);
                    if (zFlag)
                        goto ReadAllTypes_break;
                    aR = ReadIndexedIndirect(yR);
                    aR &= 0xf0;
                    aR >>= 4;
                    typesRaw[aR].Invoke();
                    //yR++;
                    //_5a++;
                    if (!cFlag)
                        goto ReadAllTypes_Start;
                    ReadAllTypes_break:;

                    // xCam
                    aR = _50;
                    CMP(ref _1a5e);
                    if (cFlag)
                        goto b8a8bb;
                    aR = _52;
                    CMP(ref _1a5e);
                    if (cFlag)
                        goto b8a8be;
                    b8a8bb:;
                    _1a5e = _50;
                    b8a8be:;

                    // yCam
                    aR = _54;
                    CMP(ref _1a50);
                    if (cFlag)
                        goto b8a8cc;
                    aR = _56;
                    CMP(ref _1a50);
                    if (cFlag)
                        goto b8a8cf;
                    b8a8cc:;
                    //_1a5e = _50;
                b8a8cf:;

                    // Put at (0,0)
                    _1a5e -= xStart;
                    _1a50 -= yStart;

                    // Is this max? min?
                    if (_1a5e > max)
                        max = _1a5e;
                    if (_1a5e < min)
                        min = _1a5e;
                    //using (Graphics g = Graphics.FromImage(bmp))
                    //{
                    //    //g.FillRectangle()
                    //    g.FillRectangle(new SolidBrush(Color.FromArgb(0x80, 40, 255, 0)), _1a5e, _1a50, 0x100, 0xe0);

                    //}



                }
                line.Add(new Point(min, max + 0x100));

            }
            //region = bmp;

        }
        public int Function0()
        {
            GetNextPointer();
            //b8a9aa();
            //_52 = 0;
            return 0;
        }
        public int Function3()
        {
            GetNextPointer();
            return 0;
        }
        public int Function4()
        {
            GetNextPointer();
            return 0;
        }
        public int Function6()
        {
            GetNextPointer();
            return 0;
        }
        public int Function8()
        {
            GetNextPointer();
            return 0;
        }
        public int Function9()
        {
            GetNextPointer();
            return 0;
        }
        public int Functiona()
        {
            GetNextPointer();
            return 0;
        }
        private void GetNextPointer ()
        {

            //a_b8a964_b8a964:	__LDA ($58),Y          // PC[b8a964]={b1 58      }  s0
            aR = ReadIndexedIndirect(yR);
            //			__AND #$000f           // PC[b8a966]={29 0f 00   }  s0
            aR &= 0xf;
            //			▼▼BEQ $=_a97a          // PC[b8a969]={f0 0f      }  s0
            if (aR == 0)
                goto b8a97a;
            //			__ASL A                // PC[b8a96b]={0a         }  s0
            aR <<= 1;
            //			__CMP #$0010           // PC[b8a96c]={c9 10 00   }  s0
            //			▼▼BCC $=_a975          // PC[b8a96f]={90 04      }  s0
            if (aR < 0x10)
                goto b8a975;
            //			__ORA #$fff0           // PC[b8a971]={09 f0 ff   }  s0
            //			__CLC                  // PC[b8a974]={18         }  s0
            aR -= 0x20;
            b8a975:;
            //a_b8a964_b8a975:	__ADC $1e0f            // PC[b8a975]={6d 0f 1e   }  s0
            aR += _1e0f;
            //			▼▼BRA $=_a981          // PC[b8a978]={80 07      }  s0
            goto b8a981;

        b8a97a:;
            //a_b8a964_b8a97a:	__INY                  // PC[b8a97a]={c8         }  s0
            yR++;
            //			__LDA ($58),Y          // PC[b8a97b]={b1 58      }  s0
            aR = ReadIndexedIndirect(yR);
            //			__AND #$00ff           // PC[b8a97d]={29 ff 00   }  s0
            aR &= 0xff;
            //			__ASL A                // PC[b8a980]={0a         }  s0
            aR <<= 1;
        b8a981:;
            //a_b8a964_b8a981:	__INY                  // PC[b8a981]={c8         }  s0
            yR++;
            //			__STY $5a              // PC[b8a982]={84 5a      }  s0
            _5a = yR;
            //			__STA $5e              // PC[b8a984]={85 5e      }  s0
            _5e = aR;
            //			__TAY                  // PC[b8a986]={a8         }  s0
            yR = aR;
            //			__LDA ($58),Y          // PC[b8a987]={b1 58      }  s0
            aR = rom.Read16(0xb80000 + _58 + yR);
            //			__TAY                  // PC[b8a989]={a8         }  s0
            yR = aR;
            //			__RTS                  // PC[b8a98a]={60         }  s0

             
        }

        // Get next index
        //a_b8a964_b8a964:	__LDA($58),Y          // PC[b8a964]={b1 58      }  s0
        //           a = rom.Read16(pointer + y)

        //            __AND #$000f           // PC[b8a966]={29 0f 00   }  s0
        //			a &= 0x000f
        //			▼▼BEQ $=_a97a          // PC[b8a969]={f0 0f      }  s0
        //			if (a == 0)
        //				goto b8a97a
        //            __ASL A                // PC[b8a96b]={0a         }  s0
        //            a *= 2

        //            __CMP #$0010           // PC[b8a96c]={c9 10 00   }  s0
        //			▼▼BCC $=_a975          // PC[b8a96f]={90 04      }  s0
        //			if a< 0x10
        //				goto b8a975

        //            __ORA #$fff0           // PC[b8a971]={09 f0 ff   }  s0
        //			a |= 0xfff0

        //            __CLC                  // PC[b8a974]={18         }  s0
        //a_b8a964_b8a975:	__ADC $1e0f            // PC[b8a975]={6d 0f 1e   }  s0

        //            a += $1e0f
        //			▼▼BRA $=_a981          // PC[b8a978]={80 07      }  s0
        //			goto b8a981
        //a_b8a964_b8a97a:	__INY                  // PC[b8a97a]={c8         }  s0

        //            y++ (index)
        //            __LDA($58),Y          // PC[b8a97b]={b1 58      }  s0
        //           a = rom.Read16(pointer + y)

        //            __AND #$00ff           // PC[b8a97d]={29 ff 00   }  s0
        //			a &= 0xff

        //            __ASL A                // PC[b8a980]={0a         }  s0

        //            a *= 2
        //a_b8a964_b8a981:	__INY                  // PC[b8a981]={c8         }  s0
        //            y++ (index)
        //            __STY $5a              // PC[b8a982]={84 5a      }  s0
        //			$5a(pointer) = y
        //           __STA $5e              // PC[b8a984]={85 5e      }  s0
        //			$5e (next index) = a
        //            __TAY                  // PC[b8a986]={a8         }  s0

        //            y = a
        //            __LDA($58),Y          // PC[b8a987]={b1 58      }  s0

        //           __TAY                  // PC[b8a989]={a8         }  s0

        //            __RTS                  // PC[b8a98a]={60         }  s0
        //    }
        private int ReadIndexedIndirect(int y_Register)
        {
            int @return = 0xb80000 + _58 + y_Register;
            zFlag = @return == 0;
            return LDA_val(@return);
        }
        private int LDA_val(int value)
        {
            aR = rom.Read16(value);
            zFlag = aR == 0;
            return aR;
        }
        private void LDA_var(ref int value)
        {
            aR = value;
            zFlag = aR == 0;
        }
        private void CMP(ref int value)
        {
            cFlag = aR >= value;
            zFlag = aR - value == 0;
        }
        List<Func<int>> typesRaw = new List<Func<int>>();

        private void b8a9aa ()
        {

            //a_b8a9aa_b8a9aa: __INY                  // PC[b8a9aa]={c8         }  s0
            yR++;
            //                 __INY                  // PC[b8a9ab]={c8         }  s0
            yR++;

            //            __LDA($58),Y          // PC[b8a9ac]={b1 58      }  s0
            aR = ReadIndexedIndirect(yR);
            //           __DEY                  // PC[b8a9ae]={88         }  s0
            yR--;
            //            __DEY                  // PC[b8a9af]={88         }  s0
            yR--;
            //            __AND #$00ff           // PC[b8a9b0]={29 ff 00   }  s0
            aR &= 0xff;
            //			__ASL A                // PC[b8a9b3]={0a         }  s0
            aR <<= 1;
            //            __ASL A                // PC[b8a9b4]={0a         }  s0
            aR <<= 1;
            //            __ADC($58),Y          // PC[b8a9b5]={71 58      }  s0
            aR += ReadIndexedIndirect(yR);
            //           __STA $4e              // PC[b8a9b7]={85 4e      }  s0
            _4e = aR;
            //            __SEC                  // PC[b8a9b9]={38         }  s0
            //            __SBC $1a5e            // PC[b8a9ba]={ed 5e 1a   }  s0
            CMP(ref _1a5e);
            aR -= _1a5e;
            //            __STA $4c              // PC[b8a9bd]={85 4c      }  s0
            _4c = aR;
            //			▼▼BCC $= _a9fb          // PC[b8a9bf]={90 3a      }  s0
            if (!cFlag)
                goto b8a9fb;

            //            __LDA $4e              // PC[b8a9c1]={a5 4e      }  s0
            LDA_var(ref _4e);
            //            __SBC $50              // PC[b8a9c3]={e5 50      }  s0
            aR -= _50;
            //            __STA $4e              // PC[b8a9c5]={85 4e      }  s0
            _4e = aR;
            //            __PHY                  // PC[b8a9c7]={5a         }  s2
            var temp = yR;
            //            __JSR $__aaf9          // PC[b8a9c8]={20 f9 aa   }  s2
            b8aaf9();
            //            __PLY                  // PC[b8a9cb]={7a         }  s0
            yR = temp;
            //            __LDA($58),Y          // PC[b8a9cc]={b1 58      }  s0
            aR = ReadIndexedIndirect(yR);
            //           __STA $50              // PC[b8a9ce]={85 50      }  s0
            _50 = aR;
            //			▼▼BRA $= _a9f9          // PC[b8a9d0]={80 27      }  s0
            goto b8a9f9;
        //a_b8a9aa_b8a9f9: __SEC                  // PC[b8a9f9]={38         }  s0
        b8a9f9:;
            cFlag = true;
            return;
        //         __RTS                  // PC[b8a9fa]={60         }  s0
        //a_b8a9aa_b8a9fb: __CLC                  // PC[b8a9fb]={18         }  s0
        b8a9fb:;
            cFlag = false;
            return;
            //         __RTS                  // PC[b8a9fc]={60         }  s0
            //}

        }
        private void b8aaf9 ()
        {
            int divResult;
            //        a_b8aaf9_b8aaf9:    ▼▼BEQ $= _aaff          // PC[b8aaf9]={f0 04      }  s0
            if (aR == 0)
                goto b8aaff;
            //            __CMP $4c              // PC[b8aafb]={c5 4c      }  s0
            CMP(ref _4c);
            //			▼▼BCS $= _ab19          // PC[b8aafd]={b0 1a      }  s0
            if (cFlag)
                goto b8ab19;
            //a_b8aaf9_b8aaff: __INY                  // PC[b8aaff]={c8         }  s0
            b8aaff:;
            yR++;
            //         __INY                  // PC[b8ab00]={c8         }  s0
            yR++;
            //            __INY                  // PC[b8ab01]={c8         }  s0
            yR++;
            //            __LDA($58),Y          // PC[b8ab02]={b1 58      }  s0
            aR = ReadIndexedIndirect(yR);
            //           __STA $54              // PC[b8ab04]={85 54      }  s0
            _54 = aR;
            //            __INY                  // PC[b8ab06]={c8         }  s0
            yR++;
            //            __INY                  // PC[b8ab07]={c8         }  s0
            yR++;
            //            __LDA($58),Y          // PC[b8ab08]={b1 58      }  s0
            aR = ReadIndexedIndirect(yR);
            //           __AND #$00ff           // PC[b8ab0a]={29 ff 00   }  s0
            aR &= 0xff;
            //			__ASL A                // PC[b8ab0d]={0a         }  s0
            aR <<= 1;
            //            __ASL A                // PC[b8ab0e]={0a         }  s0
            aR <<= 1;
            //            __ADC $54              // PC[b8ab0f]={65 54      }  s0
            aR += _54;
            //            __STA $56              // PC[b8ab11]={85 56      }  s0
            _56 = aR;
            //            __LDA $5e              // PC[b8ab13]={a5 5e      }  s0
            aR = _5e;
            //            __STA $1e0f            // PC[b8ab15]={8d 0f 1e   }  s0


            //            __RTS                  // PC[b8ab18]={60         }  s0
            return;
        //a_b8aaf9_b8ab19:	__INY                  // PC[b8ab19]={c8         }  s0
        b8ab19:;
            yR++;
            //            __INY                  // PC[b8ab1a]={c8         }  s0
            yR++;
            //            __INY                  // PC[b8ab1b]={c8         }  s0
            yR++;
            //            __LDA($58),Y          // PC[b8ab1c]={b1 58      }  s0
            aR = ReadIndexedIndirect(yR);
            //           __SEC                  // PC[b8ab1e]={38         }  s0
            //            __SBC $54              // PC[b8ab1f]={e5 54      }  s0
            aR -= _54;
            //			▼▼BPL $= _ab35          // PC[b8ab21]={10 12      }  s0
            if (aR >= 0)
                goto b8ab35;
            //            __EOR #$ffff           // PC[b8ab23]={49 ff ff   }  s0
            //			__INC A                // PC[b8ab26]={1a         }  s0
            aR *= -1;
            //            __JSR $__ab72          // PC[b8ab27]={20 72 ab   }  s0
            divResult = b8ab72();
            //            __LDA $54              // PC[b8ab2a]={a5 54      }  s0
            aR = _54;
            //            __SEP #$01             // PC[b8ab2c]={e2 01      }  s0
            //			__SBC $4214            // PC[b8ab2e]={ed 14 42   }  s0
            aR -= divResult;
            //            __STA $54              // PC[b8ab31]={85 54      }  s0
            _54 = aR;
            //			▼▼BRA $= _ab41          // PC[b8ab33]={80 0c      }  s0
            goto b8ab41;
        //a_b8aaf9_b8ab35: __JSR $__ab72          // PC[b8ab35]={20 72 ab   }  s0
        b8ab35:;
            divResult = b8ab72();
            //         __LDA $54              // PC[b8ab38]={a5 54      }  s0
            aR = _54;
            //            __REP #$01             // PC[b8ab3a]={c2 01      }  s0
            //			__ADC $4214            // PC[b8ab3c]={6d 14 42   }  s0
            aR += divResult;
            //            __STA $54              // PC[b8ab3f]={85 54      }  s0
            _54 = aR;
        //a_b8aaf9_b8ab41: __INY                  // PC[b8ab41]={c8         }  s0
        b8ab41:;
            yR++;
            //         __INY                  // PC[b8ab42]={c8         }  s0
            yR++;
            //            __LDA($58),Y          // PC[b8ab43]={b1 58      }  s0
            aR = ReadIndexedIndirect(yR);
            //           __AND #$00ff           // PC[b8ab45]={29 ff 00   }  s0
            aR &= 0xff;
            //			__ASL A                // PC[b8ab48]={0a         }  s0
            aR <<= 1;
            //            __ASL A                // PC[b8ab49]={0a         }  s0
            aR <<= 1;
            //            __DEY                  // PC[b8ab4a]={88         }  s0
            yR--;
            //            __DEY                  // PC[b8ab4b]={88         }  s0
            yR--;
            //            __ADC($58),Y          // PC[b8ab4c]={71 58      }  s0
            aR += ReadIndexedIndirect(yR);
            //           __SEC                  // PC[b8ab4e]={38         }  s0
            //            __SBC $56              // PC[b8ab4f]={e5 56      }  s0
            aR -= _56;
            //			▼▼BPL $= _ab65          // PC[b8ab51]={10 12      }  s0
            if (aR >= 0)
                goto b8ab65;
            //            __EOR #$ffff           // PC[b8ab53]={49 ff ff   }  s0
            //			__INC A                // PC[b8ab56]={1a         }  s0
            aR *= -1;
            //            __JSR $__ab72          // PC[b8ab57]={20 72 ab   }  s0
            divResult = b8ab72();
            //            __LDA $56              // PC[b8ab5a]={a5 56      }  s0
            aR = _56;
            //            __SEP #$01             // PC[b8ab5c]={e2 01      }  s0
            //			__SBC $4214            // PC[b8ab5e]={ed 14 42   }  s0
            aR -= divResult;
            //            __STA $56              // PC[b8ab61]={85 56      }  s0
            _56 = aR;
            //			▼▼BRA $= _ab71          // PC[b8ab63]={80 0c      }  s0
            goto b8ab71;
        //a_b8aaf9_b8ab65: __JSR $__ab72          // PC[b8ab65]={20 72 ab   }  s0
        b8ab65:;
            divResult = b8ab72();
            //         __LDA $56              // PC[b8ab68]={a5 56      }  s0
            aR = _56;
            //            __REP #$01             // PC[b8ab6a]={c2 01      }  s0
            //			__ADC $4214            // PC[b8ab6c]={6d 14 42   }  s0
            aR += divResult;
            //            __STA $56              // PC[b8ab6f]={85 56      }  s0
            _56 = aR;
        //a_b8aaf9_b8ab71: __RTS                  // PC[b8ab71]={60         }  s0
        b8ab71:;
            return;
            //}

        }
        private int b8ab72 ()
        {
            int a8 = 0, b8 = 0;
            //     a_b8ab72_b8ab72: __SEP #$20             // PC[b8ab72]={e2 20      }  s0
            b8 = aR >> 8;
            a8 = (aR & 0xff);
            //m_XBA                  // PC[b8ab74]={eb         }  s0
            a8 ^= b8;  
            b8 ^= a8;  
            a8 ^= b8;
            //         m_LDA $4c              // PC[b8ab75]={a5 4c      }  s0
            a8 = _4c & 0xff;
            //         m_TAX                  // PC[b8ab77]={aa         }  s0
            //         __STX $4202            // PC[b8ab78]={8e 02 42   }  s0
            int _4216 = a8 * b8;
            //         m_LDA $4e              // PC[b8ab7b]={a5 4e      }  s0
            a8 = _4e & 0xff;
            //         m_LDA $4e              // PC[b8ab7d]={a5 4e      }  s0
            //         __NOP                  // PC[b8ab7f]={ea         }  s0
            //         __LDX $4216            // PC[b8ab80]={ae 16 42   }  s0

            //         __STX $4204            // PC[b8ab83]={8e 04 42   }  s0

            //         m_STA $4206            // PC[b8ab86]={8d 06 42   }  s0

            int @return;
            if (a8 == 0)
                @return = 0;
            else
                @return = _4216 / a8;
            //         __REP #$20             // PC[b8ab89]={c2 20      }  s0
            //__RTS                  // PC[b8ab8b]={60         }  s0

            aR = (b8 << 8) | (a8 << 0);

            return @return;
        }

    }
}
