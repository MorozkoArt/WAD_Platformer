using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test228
{
    public class Mob_1
    {
        public int _x;
        public int _y;
        public int[,] map;
        public int speed;
        public int Width, Height, hitX, hitY;
        public int Dir;
        public int index1 = 0;
        public int index2 = 0;
        public int index2_1 = 0;
        public int countLives;
        public int tipe;
        public Mob_1(int _x, int _y,  int[,] map, int countLives, int tipe)
        {
            this._x = _x;
            this._y = _y;
            this.map = map;
            speed = 15;
            Width = 150;
            Height = 150;
            hitX = 61;
            hitY = 50;
            Dir = 1;
            this.countLives = countLives;
            this.tipe = tipe;
        }
        public void Left()
        {
             _x -= speed;
        }
        public void Right()
        {
             _x += speed;
        }
        public bool CheckPre()
        {
            index1 = (_y + Height) / 50 - 4;
            index2 = (_x + 60) / 60;
            index2_1 = (_x + 30) / 60;
            if (Dir == 1 && _x % 60 != 0 && index2_1 + 1 > 59) return false; 
            else if (Dir == 1 && _x % 60 != 0 && (map[index1, index2_1 + 1] != 2 && map[index1, index2_1 + 1] != 9))
            {
                return false;
            }
            else if (Dir == 1 && _x % 60 != 0 && (map[index1 - 1, index2_1 + 1] == 2 || map[index1 - 1, index2_1 + 1] == 9))
            {
                return false;
            }
            else if (Dir == 1 && _x % 60 != 0 && (map[index1 - 2, index2_1 + 1] == 2 || map[index1 - 2, index2_1 + 1] == 9))
            {
                return false;
            }
            else if (Dir == 2 && _x % 60 == 0 && index2 - 1 < 0) return false; 
            else if (Dir == 2 && _x % 60 == 0 && (map[index1, index2 - 1] != 2 && map[index1, index2 - 1] != 9))
            {
                return false;
            }
            else if (Dir == 2 && _x % 60 == 0 && (map[index1 - 1, index2 - 1] == 2 || map[index1 - 1, index2 - 1] == 9))
            {
                return false;
            }
            else if (Dir == 2 && _x % 60 == 0 && (map[index1 - 2, index2 - 1] == 2 || map[index1 - 2, index2 - 1] == 9))
            {
                return false;
            }
            return true;
        }
        public int CheckPerson(int X, int Y)
        {
            if (Y == _y && Math.Abs(X - (_x + 60)) == 45)
            {     
                return 1;
            }
            else if (Y == _y && Math.Abs(X - (_x + 60)) < 45)
            {
                return 3;
            }
            else if(Y == _y && Math.Abs(X - (_x+60))<= 240 && Math.Abs(X - (_x + 60)) > 45)
            {
                if (X > _x + 60)
                {
                    return 2;
                }
                else if (X < _x + 60)
                {
                    return 4;
                }
            }
            return 0;
        }
        public void Rotate(int Dir, int X)
        {
            int Long;
            if (Dir == 1)
            {
                Long = (_x + hitX) - X;
                for (int i = 0; i < 3+(Long/speed); i++) 
                {
                    Left();
                }
            }
            else if (Dir == 2)
            {
                Long =  X - (_x + hitX);
                for (int i = 0; i < 4 + (Long / speed); i++)
                {
                    Right();
                }
            }
        }
    }
}
