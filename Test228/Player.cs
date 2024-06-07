using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Test228
{
    internal class Player
    {
        public int _x, _y;
        public int speed;
        public int Width, Height, hitX, hitY;
        const int width = 14;
        const int height = 60;
        MainWindow Form1;
        public int[,] map;
        int JumpHeight;
        public int Gravity;
        public int jumpCount;
        public bool isJumping;
        public int last_Dir;
        public int count_lives;
        public int count_livesMax;
        public int points;
        public int pointsMax;
        public int keys;
        public int keysMax;
        public int index1 = 0;
        public int index2 = 0;
        public int index2_1 = 0;
        public bool contin = false;
        public Player( int _x, int _y, MainWindow Form1, int[,] map)
        {
            this._x = _x;
            this._y = _y;
            speed = 30;
            Width = 150;
            Height = 150;
            hitX = 61;
            hitY = 50;
            this.Form1 = Form1;
            this.map = map;
            JumpHeight = 60;
            Gravity = 10;
            jumpCount = 0;
            isJumping = false;
            last_Dir = 1;
            count_lives = 5;
            count_livesMax = 5;
            points = 0;
            pointsMax = 12;
            keys = 0;
            keysMax = 1;
        }
        public void Left()
        {
            if (_x > -30) _x -= speed;           
        }
        public void Right()
        {           
            if (_x < 3460) 
            { 
                _x += speed; 
            }           
        }
        public int CheckDown()
        {
            if (_y % 50 == 0) index1 = (_y + Height) / 50 - 4;
            else index1 = ((_y+10) + Height) / 50 - 4;
            index2 = (_x + 60) / 60;
            index2_1 = (_x + 30) / 60;
            for (int i = index1; i < width; i++)
            {
                if (_x % 60 == 0 && (map[i, index2] == 2 || map[i, index2] == 9)) return (i + 4) * 50 - Height;

                else if (_x % 60 != 0 && (map[i, index2_1] == 2 || map[i, index2] == 9)) return (i + 4) * 50 - Height;
            }
            return Form1.Height;
        }
        public int CheckPlat(int c)
        {
            index1 = (_y + Height) / 50 - 4;
            index2 = (_x + 60) / 60;
            index2_1 = (_x + 30) / 60;
            if(((index2 - 1) >-1 && (index2-1) < 60) && ((index2_1 - 1) > -1 && (index2_1 - 1) < 60) && (index1 - 1) >-1 && (index1 - 1) < 14)
            {
                if((index1 - 2) > -1 && (index1 - 2) < 14)
                {
                    if (_x % 60 == 0 && (map[index1 - 2, index2 - 1] == 9 || map[index1 - 2, index2 - 1] == 2) && c == 2) return 3;
                    else if (_x % 60 != 0 && (map[index1 - 2, index2_1 + 1] == 9 || map[index1 - 2, index2_1 + 1] == 2) && c == 1) return 3;

                }
                if (_x % 60 == 0 && (map[index1 - 1, index2 - 1] == 9 || map[index1 - 1, index2 - 1] == 2) && c == 2) return 1;
                else if (_x % 60 != 0 && (map[index1 - 1, index2_1 + 1] == 9 || map[index1 - 1, index2_1 + 1] == 2) && c == 1) return 1;
                else if (_x % 60 == 0 && (map[index1, index2] == 9 || map[index1, index2] == 2)) return 2;
                else if (_x % 60 != 0 && (map[index1, index2_1] == 9 || map[index1, index2_1] == 2)) return 2;
                else return 0;
            }          
            else return 0;
        }
        
        public bool Checkjump(int c)
        {
            index1 = (_y + Height) / 50 - 4;
            index2 = (_x + 60) / 60;
            index2_1 = (_x + 30) / 60;
            if (index1 - 3 >= 0)
            {
                if (_x % 60 == 0 && (map[index1 - 2, index2 - 1] == 9 || map[index1 - 2, index2 - 1] == 2) && c == 2 && (map[index1 - 1, index2 - 1] == 9 || map[index1 - 1, index2 - 1] == 2)) return false;
                else if (_x % 60 != 0 && (map[index1 - 2, index2_1 + 1] == 9 || map[index1 - 2, index2_1 + 1] == 2) && c == 1 && (map[index1 - 1, index2_1 + 1] == 9 || map[index1 - 1, index2_1 + 1] == 2)) return false;
                else if (_x % 60 == 0 && (map[index1 - 3, index2 - 1] == 9 || map[index1 - 3, index2 - 1] == 2) && c == 2 && (map[index1 - 1, index2 - 1] == 9 || map[index1 - 1, index2 - 1] == 2)) return false;
                else if (_x % 60 != 0 && (map[index1 - 3, index2_1 + 1] == 9 || map[index1 - 3, index2_1 + 1] == 2) && c == 1 && (map[index1 - 1, index2_1 + 1] == 9 || map[index1 - 1, index2_1 + 1] == 2)) return false;
                
            }
            else if (index1 - 2 >= 0)
            {
                if (_x % 60 == 0 && (map[index1 - 2, index2 - 1] == 9 || map[index1 - 2, index2 - 1] == 2) && c == 2) return false;
                else if (_x % 60 != 0 && (map[index1 - 2, index2_1 + 1] == 9 || map[index1 - 2, index2_1 + 1] == 2) && c == 1) return false;
            }
            return true;

        }
        public async void JumpDoun()
        {
            int a = CheckDown();
            while (_y < a)
            {
                _y += Gravity;
                Form1.Invalidate();
                await Task.Delay(5);
            }
            contin = true;
        }
        public async void Jump(int yes_or_not)
        {
            int chePrep = CheckPlat(last_Dir);
            while (jumpCount < JumpHeight && Checkjump(last_Dir) == true)
            {
                _y -= Gravity;
                jumpCount += Gravity;
                if (last_Dir == 1 && yes_or_not == 1 && chePrep!= 3) _x += 5;
                else if (last_Dir == 2 && yes_or_not == 1 && chePrep != 3) _x -= 5;
                else if (last_Dir == 1 && yes_or_not == 2 && chePrep != 3)
                {
                    if (chePrep != 1) _x += 15;
                    else _x += 5;
                }
                else if (last_Dir == 2 && yes_or_not == 2 && chePrep != 3)
                {
                    if (chePrep != 1) _x -= 15;
                    else _x -= 5;
                }
                Form1.Invalidate();
                await Task.Delay(5);
            }
            if(chePrep != 3)
            {
                int cuntCikl = 6 - jumpCount / Gravity;
                if (yes_or_not == 1 && last_Dir == 1)
                {
                    Form1.delta.X += cuntCikl * 5;
                }
                else if (yes_or_not == 1 && last_Dir == 2)
                {
                    Form1.delta.X -= cuntCikl * 5;
                }
                else if (yes_or_not == 2 && last_Dir == 1)
                {
                    Form1.delta.X += cuntCikl * 15;
                }
                else if (yes_or_not == 2 && last_Dir == 2)
                {
                    Form1.delta.X -= cuntCikl * 15;
                }
            }
            
            int a = CheckDown();
            while (_y < a)
            {
                _y += Gravity;
                Form1.Invalidate();
                await Task.Delay(5);
            }
            isJumping = false;
            contin = true;
        }
    }
}
