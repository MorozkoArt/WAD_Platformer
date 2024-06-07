using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Test228
{
    public partial class MainWindow : Form
    {
        Image PictureImage;
        Image PictureImage2;
        Image PictureImage3;
        Image PictureImage4;
        Image PictureImage6;
        Image PictureImage7;
        Image PictureImage5;
        Image PictureImage8;
        Image PictureImage9;
        Image PictureImage10;
        Image PictureImage11;
        Image PictureImage12;
        Image PictureImage13;
        Image PictureImage14;
        Image PictureImage15;
        Image PictureImage16;
        Image PictureImage17;
        Image PictureImage18;
        Image PictureImage19;
        Image PictureImage20;
        Image PictureImage21;
        Image PictureImage22;
        Image PictureImage23;
        Image PictureImage24;
        Image PictureImage25;
        Image PictureImage26;
        Image PictureImage27;
        Image PictureImage28;
        Image PictureImage29;
        Image PictureImage30;
        Image PictureImage31;
        Image PictureImage32;
        Image PictureImage33;
        Image PictureImage34;
        Image PictureImage35;
        Image PictureImage36;
        Image PictureImage37;
        Image PictureImage38;
        Image PictureImage39;
        Image PictureImage40;
        Image PictureImage41;
        Player player;
        private int CurrFrame = 0;
        private int CurrFrame_Mob1 = 0;
        private int CurrFrame_Mob2 = 0;
        private int CurrFrame_Mob3 = 0;
        int[,] map;
        int[,] map2;
        const int width = 14;
        const int height = 60;
        int[,] map_copy;
        private int Cakecap=-1;
        public Point delta;
        public List<int> keys = new List<int>();
        private bool isRunR;
        private bool isRunL;
        private bool isAttack1;
        private bool isAttack2;
        private bool isBlock;
        private bool isEnd;
        private int side;
        private Font drawFont = new Font("Arial", 14);      
        private SolidBrush drawBrush = new SolidBrush(Color.Black);
        private int index1;
        private int index2;
        private int index2_1;
        private bool restart;
        private int index;
        private int lvl;
        private bool new_urow;
        private int last_DirMob1;
        private int last_DirMob2;
        private int last_DirMob3;
        private int count_kill;
        private int count_tick;
        public WMPLib.WindowsMediaPlayer WMP = new WMPLib.WindowsMediaPlayer();
        public WMPLib.WindowsMediaPlayer WMP2 = new WMPLib.WindowsMediaPlayer();
        public WMPLib.WindowsMediaPlayer WMP3 = new WMPLib.WindowsMediaPlayer();
        public WMPLib.WindowsMediaPlayer WMP4 = new WMPLib.WindowsMediaPlayer();
        public WMPLib.WindowsMediaPlayer WMP5 = new WMPLib.WindowsMediaPlayer();
        public List <Mob_1> Mobs = new List <Mob_1>();
        public List<int> MobPosition = new List <int>();
        public Random rnd = new Random();

        public MainWindow()
        {
            InitializeComponent();
            Sprayt();
            initialization();
            this.KeyUp += Form1_KeyUp;
            this.KeyDown += Form1_KeyDown;
            timer1.Interval = 5;
            timer2.Interval = 5;
            timer1.Tick += Timer1_Tick;
            timer2.Tick += Timer2_Tick;
            timer1.Start();
            timer2.Start();
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            WMP.MediaChange += WMP_MediaChange;
            int value = rnd.Next(3, 8);
            for( int i = 0; i < value; i++ )
            {
                int c = rnd.Next(0, 60);
                while (Mobs.Count != i)
                {
                    if ((map[10, c] == 9 || map[10, c] == 2) && map[9, c] != 9 && map[9, c] != 2 && map[8, c] != 9 && map[8, c] != 2)
                    {
                        MobPosition.Add(c);
                        Mob_1 mob = new Mob_1(c * side, 550, map, rnd.Next(1, 5), rnd.Next(1, 4));
                        Mobs.Add(mob);
                    }
                    else
                    {
                        c = rnd.Next(0, 60);
                    }
                }
                
       
                
            }
        }

        private void WMP_MediaChange(object Item)
        {
            WMP.controls.play();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            WMP.URL = "C:\\Users\\Артём Морозов\\Desktop\\Звуки\\Boulevard Depo - White Trash [prod. by ЛАУД] (Минус) (256  kbps).mp3";
            WMP.settings.volume = 20; 
            WMP.controls.play();            
        }
        private void initialization()
        {
            side = 60;
            isRunR = false;
            isRunL = false;
            delta = new Point(0, 0);
            index1 = 0; index2 = 0; index2_1 = 0;
            restart  = false;
            new_urow = false;
            isAttack1 = false;
            isAttack2 = false;
            isBlock = false;
            isEnd = false;
            lvl = 1;
            count_tick = 0;
            count_kill = 0;
            map = new int[width, height] { {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1 },
                                           {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,3,1,1,4,4,4,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1 },
                                           {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,9,1,9,9,9,9,9,9,9,9,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1 },
                                           {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,9,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1 },
                                           {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,9,2,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1 },
                                           {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,9,2,2,2,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1 },
                                           {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,9,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,9,2,2,1,2,2,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1 },
                                           {1,1,1,1,1,1,1,4,4,1,1,1,1,1,1,1,1,1,1,1,1,1,9,1,1,1,1,1,1,1,1,1,1,1,1,1,1,9,9,1,2,1,2,2,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1 },
                                           {6,1,1,1,9,9,2,9,9,2,9,1,1,1,1,1,1,1,1,1,1,1,9,1,1,1,1,1,1,1,1,1,1,1,1,1,9,9,9,1,2,1,2,2,1,1,1,1,1,1,1,1,1,1,1,1,1,1,7,1 },
                                           {1,1,1,9,9,9,1,9,9,1,9,9,1,4,1,1,1,1,2,9,1,1,9,3,4,1,1,1,1,1,1,1,1,1,1,9,9,9,9,1,2,1,2,2,3,1,9,1,1,1,1,1,1,1,1,1,1,1,1,1 },
                                           {9,9,9,9,9,9,1,9,9,1,9,9,9,9,4,4,2,9,1,9,9,1,1,9,9,9,9,9,1,1,9,9,9,9,9,9,9,9,9,1,2,1,2,2,9,2,9,9,9,9,9,9,9,9,9,9,9,9,9,9 },
                                           {2,2,2,2,2,2,1,2,2,1,2,2,2,2,2,2,1,1,1,2,2,1,1,1,1,1,1,1,1,2,2,2,2,2,2,2,2,2,2,1,2,1,2,2,2,1,2,2,2,2,2,2,2,2,2,2,2,2,2,2 },
                                           {2,2,2,2,2,2,1,2,2,1,2,2,2,2,2,2,1,1,1,2,2,4,1,5,1,1,4,4,2,2,2,2,2,2,2,2,2,2,2,1,2,1,2,2,2,1,2,2,2,2,2,2,2,2,2,2,2,2,2,2 },
                                           {2,2,2,2,2,2,1,2,2,1,2,2,2,2,2,2,1,1,1,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,1,2,1,2,2,2,1,2,2,2,2,2,2,2,2,2,2,2,2,2,2 },
                         };
            map2 = new int[width, height] { {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1 },
                                           {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,5,1,4,1,3,1,4,1,4,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1 },
                                           {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,9,1,9,1,9,1,9,1,9,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1 },
                                           {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,9,9,9,9,1,1,4,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1 },
                                           {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,9,9,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1 },
                                           {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,9,2,2,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1 },
                                           {1,1,1,1,1,1,1,1,1,1,1,1,1,1,4,1,1,1,1,1,9,1,1,1,1,1,1,1,1,1,1,1,1,1,9,1,2,2,2,1,9,1,4,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1 },
                                           {1,1,1,1,1,1,1,1,1,1,1,1,4,1,9,1,1,1,9,1,1,1,1,1,1,1,1,1,1,1,1,1,1,9,2,1,2,2,2,1,2,1,9,1,4,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1 },
                                           {6,1,1,1,1,1,1,1,1,1,1,1,9,1,2,1,9,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,9,2,2,1,2,2,2,1,2,1,2,1,9,1,3,1,9,1,4,1,1,1,1,1,1,1,7,1 },
                                           {1,1,1,1,4,4,4,1,1,1,9,1,2,1,2,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,9,2,2,2,1,2,2,2,1,2,1,2,1,2,1,9,1,2,1,9,1,1,1,1,1,1,1,1,1 },
                                           {9,9,9,9,9,9,9,9,9,1,2,1,2,1,2,1,1,1,1,3,1,9,9,9,9,9,9,9,9,9,9,9,2,2,2,1,2,2,2,1,2,1,2,1,2,1,2,1,2,1,2,9,9,9,9,9,9,9,9,9 },
                                           {2,2,2,2,2,2,2,2,2,1,2,1,2,1,2,1,1,1,1,2,1,2,2,2,2,2,2,2,2,2,2,2,2,2,2,1,2,2,2,1,2,1,2,1,2,1,2,1,2,1,2,2,2,2,2,2,2,2,2,2 },
                                           {2,2,2,2,2,2,2,2,2,1,2,1,2,1,2,1,1,1,1,2,1,2,2,2,2,2,2,2,2,2,2,2,2,2,2,1,2,2,2,1,2,1,2,1,2,1,2,1,2,1,2,2,2,2,2,2,2,2,2,2 },
                                           {2,2,2,2,2,2,2,2,2,1,2,1,2,1,2,1,1,1,1,2,1,2,2,2,2,2,2,2,2,2,2,2,2,2,2,1,2,2,2,1,2,1,2,1,2,1,2,1,2,1,2,2,2,2,2,2,2,2,2,2 },
                         };
            WMP2.URL = "C:\\Users\\Артём Морозов\\Desktop\\Звуки\\12_Player_Movement_SFX\\03_Step_grass_03.wav";
            WMP2.settings.volume = 100;
            WMP3.URL = "C:\\Users\\Артём Морозов\\Desktop\\Звуки\\12_Player_Movement_SFX\\30_Jump_03.wav";
            WMP3.settings.volume = 100; 
            WMP4.URL = "C:\\Users\\Артём Морозов\\Desktop\\Звуки\\12_Player_Movement_SFX\\56_Attack_03.wav";
            WMP4.settings.volume = 100; 
            WMP5.URL = "C:\\Users\\Артём Морозов\\Desktop\\Звуки\\12_Player_Movement_SFX\\61_Hit_03.wav";
            WMP5.settings.volume = 100; 
            player = new Player(0, 550, this, map);
            map_copy = map.Clone() as int[,];
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    if (map[i, j] == 7)
                    {
                        index = j; break;
                    }
                }
            }
        }
        private void Sprayt()
        {
            PictureImage = new Bitmap("C:\\Users\\Артём Морозов\\Desktop\\Спрайты\\Fighter\\Run.png");
            PictureImage2 = new Bitmap("C:\\Users\\Артём Морозов\\Desktop\\Спрайты\\Fighter\\Run2.png");
            PictureImage3 = new Bitmap("C:\\Users\\Артём Морозов\\Desktop\\Спрайты\\Fighter\\Idle.png");
            PictureImage4 = new Bitmap("C:\\Users\\Артём Морозов\\Desktop\\Спрайты\\Fighter\\Jump.png");
            PictureImage6 = new Bitmap("C:\\Users\\Артём Морозов\\Desktop\\Спрайты\\Fighter\\Attack_1.png");
            PictureImage7 = new Bitmap("C:\\Users\\Артём Морозов\\Desktop\\Спрайты\\Fighter\\Attack_2.png");
            PictureImage5 = new Bitmap("C:\\Users\\Артём Морозов\\Desktop\\ФОн\\PNG\\41.png");
            PictureImage8 = new Bitmap("C:\\Users\\Артём Морозов\\Desktop\\ФОн\\PNG\\42.png");
            PictureImage9 = new Bitmap("C:\\Users\\Артём Морозов\\Desktop\\Спрайты\\Fighter\\Jump2.png");
            PictureImage10 = new Bitmap("C:\\Users\\Артём Морозов\\Desktop\\Спрайты\\Fighter\\Hurt.png");
            PictureImage11 = new Bitmap("C:\\Users\\Артём Морозов\\Desktop\\Спрайты\\Fighter\\Hurt2.png");
            PictureImage12 = new Bitmap("C:\\Users\\Артём Морозов\\Desktop\\ФОн\\PNG\\сердце2.png");
            PictureImage13 = new Bitmap("C:\\Users\\Артём Морозов\\Desktop\\ФОн\\PNG\\монетка4.png");
            PictureImage14 = new Bitmap("C:\\Users\\Артём Морозов\\Desktop\\ФОн\\PNG\\ключик2.png");
            PictureImage15 = new Bitmap("C:\\Users\\Артём Морозов\\Desktop\\ФОн\\PNG\\дверь2.png");
            PictureImage16 = new Bitmap("C:\\Users\\Артём Морозов\\Desktop\\ФОн\\ФонLVl2.jpg");
            PictureImage17 = new Bitmap("C:\\Users\\Артём Морозов\\Desktop\\Спрайты для мобов\\Gotoku\\Idle.png");
            PictureImage18 = new Bitmap("C:\\Users\\Артём Морозов\\Desktop\\Спрайты для мобов\\Gotoku\\Run.png");
            PictureImage19 = new Bitmap("C:\\Users\\Артём Морозов\\Desktop\\Спрайты для мобов\\Gotoku\\Run2.png");
            PictureImage20 = new Bitmap("C:\\Users\\Артём Морозов\\Desktop\\Спрайты для мобов\\Onre\\Run.png");
            PictureImage21 = new Bitmap("C:\\Users\\Артём Морозов\\Desktop\\Спрайты для мобов\\Onre\\Run2.png");
            PictureImage22 = new Bitmap("C:\\Users\\Артём Морозов\\Desktop\\Спрайты для мобов\\Yurei\\Run.png");
            PictureImage23 = new Bitmap("C:\\Users\\Артём Морозов\\Desktop\\Спрайты для мобов\\Yurei\\Run2.png");
            PictureImage24 = new Bitmap("C:\\Users\\Артём Морозов\\Desktop\\Спрайты для мобов\\Onre\\Idle.png");
            PictureImage25 = new Bitmap("C:\\Users\\Артём Морозов\\Desktop\\Спрайты для мобов\\Yurei\\Idle.png");
            PictureImage26 = new Bitmap("C:\\Users\\Артём Морозов\\Desktop\\Спрайты для мобов\\Gotoku\\Idle2.png");
            PictureImage27 = new Bitmap("C:\\Users\\Артём Морозов\\Desktop\\Спрайты\\Fighter\\Idle2.png");
            PictureImage28 = new Bitmap("C:\\Users\\Артём Морозов\\Desktop\\Спрайты для мобов\\Onre\\Idle2.png");
            PictureImage29 = new Bitmap("C:\\Users\\Артём Морозов\\Desktop\\Спрайты для мобов\\Yurei\\Idle2.png");
            PictureImage30 = new Bitmap("C:\\Users\\Артём Морозов\\Desktop\\Спрайты\\Fighter\\Attack_1_2.png");
            PictureImage31 = new Bitmap("C:\\Users\\Артём Морозов\\Desktop\\Спрайты\\Fighter\\Attack_2_2.png");
            PictureImage32 = new Bitmap("C:\\Users\\Артём Морозов\\Desktop\\Спрайты для мобов\\Gotoku\\Attack_1.png");
            PictureImage33 = new Bitmap("C:\\Users\\Артём Морозов\\Desktop\\Спрайты для мобов\\Gotoku\\Attack_1_2.png");
            PictureImage34 = new Bitmap("C:\\Users\\Артём Морозов\\Desktop\\Спрайты\\Fighter\\Dead.png");
            PictureImage35 = new Bitmap("C:\\Users\\Артём Морозов\\Desktop\\Спрайты для мобов\\Gotoku\\Dead.png");
            PictureImage36 = new Bitmap("C:\\Users\\Артём Морозов\\Desktop\\Спрайты для мобов\\Onre\\Dead.png");
            PictureImage37 = new Bitmap("C:\\Users\\Артём Морозов\\Desktop\\Спрайты для мобов\\Yurei\\Dead.png");
            PictureImage38 = new Bitmap("C:\\Users\\Артём Морозов\\Desktop\\Спрайты для мобов\\Onre\\Attack_1.png");
            PictureImage39 = new Bitmap("C:\\Users\\Артём Морозов\\Desktop\\Спрайты для мобов\\Yurei\\Attack_1.png");
            PictureImage40 = new Bitmap("C:\\Users\\Артём Морозов\\Desktop\\Спрайты для мобов\\Onre\\Attack_1_2.png");
            PictureImage41 = new Bitmap("C:\\Users\\Артём Морозов\\Desktop\\Спрайты для мобов\\Yurei\\Attack_1_2.png");

        }
        private void Timer2_Tick(object sender, EventArgs e)
        {
            for(int i = 0; i<Mobs.Count; i++)
            {
                if (Mobs[i].countLives != 0)
                {
                    if (Mobs[i].CheckPerson(player._x + 60, player._y) == 1)
                    {
                        if (player._x > Mobs[i]._x)
                            last_DirMob1 = 1;
                        else if (player._x < Mobs[i]._x)
                            last_DirMob1 = 2;
                        if (count_tick % 20 != 0) Mobs[i].Dir = 0;
                        else if (count_tick % 20 == 0)
                        {
                            Mobs[i].Dir = 3;
                            WMP5.controls.play();
                            if (isBlock != true && player.count_lives != 0) player.count_lives--;
                            else if (isBlock == true && player.last_Dir == last_DirMob1 && player.count_lives != 0) player.count_lives--;
                        }
                        if ((isAttack1 == true || isAttack2 == true) && player.last_Dir != last_DirMob1 && Mobs[i].countLives != 0)
                        {
                            isAttack1 = false;
                            isAttack2 = false;
                            Mobs[i].countLives--;
                            if (Mobs[i].countLives == 0)
                            {
                                count_kill++;
                                CurrFrame_Mob1 = 0;
                            }
                        }
                    }
                    else if (Mobs[i].CheckPerson(player._x + 60, player._y) == 3)
                    {
                        if (player.last_Dir == 1)
                        {
                            if (count_tick % 10 != 0)
                            {
                                Mobs[i].Dir = 1;
                                if (Mobs[i].CheckPre() == true) Mobs[i].Right();
                                else if (Mobs[i].CheckPre() == false) Mobs[i].Rotate(1, player._x + 60);
                            }
                            else if (count_tick % 10 == 0)
                            {
                                Mobs[i].Dir = 3;
                                WMP5.controls.play();
                                if (isBlock != true && player.count_lives != 0) player.count_lives--;
                                else if (isBlock == true && player.last_Dir == last_DirMob1 && player.count_lives != 0) player.count_lives--;
                            }
                            if ((isAttack1 == true || isAttack2 == true) && Mobs[i].countLives != 0 && Mobs[i]._x > player._x)
                            {
                                isAttack1 = false;
                                isAttack2 = false;
                                Mobs[i].countLives--;
                                if (Mobs[i].countLives == 0)
                                {
                                    count_kill++;
                                    CurrFrame_Mob1 = 0;
                                }
                            }
                        }
                        else if (player.last_Dir == 2)
                        {
                            if (count_tick % 10 != 0)
                            {
                                Mobs[i].Dir = 2;
                                if (Mobs[i].CheckPre() == true) Mobs[i].Left();
                                else if (Mobs[i].CheckPre() == false) Mobs[i].Rotate(2, player._x + 60);
                            }
                            else if (count_tick % 10 == 0)
                            {
                                Mobs[i].Dir = 3;
                                WMP5.controls.play();
                                if (isBlock != true && player.count_lives != 0) player.count_lives--;
                                else if (isBlock == true && player.last_Dir == last_DirMob1 && player.count_lives != 0) player.count_lives--;
                            }
                            if ((isAttack1 == true || isAttack2 == true) && Mobs[i].countLives != 0 && Mobs[i]._x < player._x)
                            {
                                isAttack1 = false;
                                isAttack2 = false;
                                Mobs[i].countLives--;
                                if (Mobs[i].countLives == 0)
                                {
                                    count_kill++;
                                    CurrFrame_Mob1 = 0;
                                }
                            }
                        }
                    }
                    else if (Mobs[i].CheckPerson(player._x + 60, player._y) == 2)
                    {
                        Mobs[i].Dir = 1;
                        if (Mobs[i].CheckPre() == true) Mobs[i].Right();
                    }
                    else if (Mobs[i].CheckPerson(player._x + 60, player._y) == 4)
                    {
                        Mobs[i].Dir = 2;
                        if (Mobs[i].CheckPre() == true) Mobs[i].Left();
                    }
                    else if (Mobs[i].Dir == 1 && Mobs[i].CheckPre() == true) Mobs[i].Right();
                    else if (Mobs[i].Dir == 1 && Mobs[i].CheckPre() == false) Mobs[i].Dir = 2;
                    else if (Mobs[i].Dir == 2 && Mobs[i].CheckPre() == true) Mobs[i].Left();
                    else if (Mobs[i].Dir == 2 && Mobs[i].CheckPre() == false) Mobs[i].Dir = 1;
                }
            }
          
            // Второй мобик
            /*
            if (Mob_2.countLives != 0)
            {
                if (Mob_2.CheckPerson(player._x + 60, player._y) == 1)
                {
                    if (player._x > Mob_2._x)
                        last_DirMob2 = 1;
                    else if (player._x < Mob_2._x)
                        last_DirMob2 = 2;
                    if (count_tick % 20 != 0) Mob_2.Dir = 0;
                    else if (count_tick % 20 == 0)
                    {
                        Mob_2.Dir = 3;
                        WMP5.controls.play();
                        if (isBlock != true && player.count_lives != 0) player.count_lives--;
                        else if (isBlock == true && player.last_Dir == last_DirMob2 && player.count_lives != 0) player.count_lives--;
                    }
                    if ((isAttack1 == true || isAttack2 == true) && player.last_Dir != last_DirMob2 && Mob_2.countLives != 0)
                    {
                        isAttack1 = false;
                        isAttack2 = false;
                        Mob_2.countLives--;
                        if (Mob_2.countLives == 0)
                        {
                            count_kill++;
                            CurrFrame_Mob2 = 0;
                        }
                    }
                }
                else if (Mob_2.CheckPerson(player._x + 60, player._y) == 3)
                {
                    if (player.last_Dir == 1)
                    {
                        if (count_tick % 10 != 0)
                        {
                            Mob_2.Dir = 1;
                            if (Mob_2.CheckPre() == true) Mob_2.Right();
                            else if (Mob_2.CheckPre() == false) Mob_2.Rotate(1, player._x + 60);
                        }
                        else if (count_tick % 10 == 0)
                        {
                            Mob_2.Dir = 3;
                            WMP5.controls.play();
                            if (isBlock != true && player.count_lives != 0) player.count_lives--;
                            else if (isBlock == true && player.last_Dir == last_DirMob2 && player.count_lives != 0) player.count_lives--;
                        }
                        if ((isAttack1 == true || isAttack2 == true) && Mob_2.countLives != 0 && Mob_2._x > player._x)
                        {
                            isAttack1 = false;
                            isAttack2 = false;
                            Mob_2.countLives--;
                            if (Mob_2.countLives == 0)
                            {
                                count_kill++;
                                CurrFrame_Mob2 = 0;
                            }
                        }
                    }
                    else if (player.last_Dir == 2)
                    {
                        if (count_tick % 10 != 0)
                        {
                            Mob_2.Dir = 2;
                            if (Mob_2.CheckPre() == true) Mob_2.Left();
                            else if (Mob_2.CheckPre() == false) Mob_2.Rotate(2, player._x + 60);
                        }
                        else if (count_tick % 10 == 0)
                        {
                            Mob_2.Dir = 3;
                            WMP5.controls.play();
                            if (isBlock != true && player.count_lives != 0) player.count_lives--;
                            else if (isBlock == true && player.last_Dir == last_DirMob2 && player.count_lives != 0) player.count_lives--;
                        }
                        if ((isAttack1 == true || isAttack2 == true) && Mob_2.countLives != 0 && Mob_2._x < player._x)
                        {
                            isAttack1 = false;
                            isAttack2 = false;
                            Mob_2.countLives--;
                            if (Mob_2.countLives == 0)
                            {
                                count_kill++;
                                CurrFrame_Mob2 = 0;
                            }
                        }
                    }
                }
                else if (Mob_2.CheckPerson(player._x + 60, player._y) == 2)
                {
                    Mob_2.Dir = 1;
                    if (Mob_2.CheckPre() == true) Mob_2.Right();
                }
                else if (Mob_2.CheckPerson(player._x + 60, player._y) == 4)
                {
                    Mob_2.Dir = 2;
                    if (Mob_2.CheckPre() == true) Mob_2.Left();
                }
                else if (Mob_2.Dir == 1 && Mob_2.CheckPre() == true) Mob_2.Right();
                else if (Mob_2.Dir == 1 && Mob_2.CheckPre() == false) Mob_2.Dir = 2;
                else if (Mob_2.Dir == 2 && Mob_2.CheckPre() == true) Mob_2.Left();
                else if (Mob_2.Dir == 2 && Mob_2.CheckPre() == false) Mob_2.Dir = 1;
            }
            // Третий мобик
            if (Mob_3.countLives != 0)
            {
                if (Mob_3.CheckPerson(player._x + 60, player._y) == 1)
                {
                    if (player._x > Mob_3._x)
                        last_DirMob3 = 1;
                    else if (player._x < Mob_3._x)
                        last_DirMob3 = 2;
                    if (count_tick % 20 != 0) Mob_3.Dir = 0;
                    else if (count_tick % 20 == 0)
                    {
                        Mob_3.Dir = 3;
                        WMP5.controls.play();
                        if (isBlock != true && player.count_lives != 0) player.count_lives--;
                        else if (isBlock == true && player.last_Dir == last_DirMob3 && player.count_lives != 0) player.count_lives--;
                    }
                    if ((isAttack1 == true || isAttack2 == true) && player.last_Dir != last_DirMob3 && Mob_3.countLives != 0)
                    {
                        isAttack1 = false;
                        isAttack2 = false;
                        Mob_3.countLives--;
                        if (Mob_3.countLives == 0)
                        {
                            count_kill++;
                            CurrFrame_Mob3 = 0;
                        }

                    }
                }
                else if (Mob_3.CheckPerson(player._x + 60, player._y) == 3)
                {
                    if (player.last_Dir == 1)
                    {
                        if (count_tick % 10 != 0)
                        {
                            Mob_3.Dir = 1;
                            if (Mob_3.CheckPre() == true) Mob_3.Right();
                            else if (Mob_3.CheckPre() == false) Mob_3.Rotate(1, player._x + 60);
                        }
                        else if (count_tick % 10 == 0)
                        {
                            Mob_3.Dir = 3;
                            WMP5.controls.play();
                            if (isBlock != true && player.count_lives != 0) player.count_lives--;
                            else if (isBlock == true && player.last_Dir == last_DirMob3 && player.count_lives != 0) player.count_lives--;
                        }
                        if ((isAttack1 == true || isAttack2 == true) && Mob_3.countLives != 0 && Mob_3._x > player._x)
                        {
                            isAttack1 = false;
                            isAttack2 = false;
                            Mob_3.countLives--;
                            if (Mob_3.countLives == 0)
                            {
                                count_kill++;
                                CurrFrame_Mob3 = 0;
                            }
                        }
                    }
                    else if (player.last_Dir == 2)
                    {
                        if (count_tick % 10 != 0)
                        {
                            Mob_3.Dir = 2;
                            if (Mob_3.CheckPre() == true) Mob_3.Left();
                            else if (Mob_3.CheckPre() == false) Mob_3.Rotate(2, player._x + 60);
                        }
                        else if (count_tick % 10 == 0)
                        {
                            Mob_3.Dir = 3;
                            WMP5.controls.play();
                            if (isBlock != true && player.count_lives != 0) player.count_lives--;
                            else if (isBlock == true && player.last_Dir == last_DirMob3 && player.count_lives != 0) player.count_lives--;
                        }
                        if ((isAttack1 == true || isAttack2 == true) && Mob_3.countLives != 0 && Mob_3._x < player._x)
                        {
                            isAttack1 = false;
                            isAttack2 = false;
                            Mob_3.countLives--;
                            if (Mob_3.countLives == 0)
                            {
                                count_kill++;
                                CurrFrame_Mob3 = 0;
                            }
                        }
                    }
                }
                else if (Mob_3.CheckPerson(player._x + 60, player._y) == 2)
                {
                    Mob_3.Dir = 1;
                    if (Mob_3.CheckPre() == true) Mob_3.Right();
                }
                else if (Mob_3.CheckPerson(player._x + 60, player._y) == 4)
                {
                    Mob_3.Dir = 2;
                    if (Mob_3.CheckPre() == true) Mob_3.Left();
                }
                else if (Mob_3.Dir == 1 && Mob_3.CheckPre() == true) Mob_3.Right();
                else if (Mob_3.Dir == 1 && Mob_3.CheckPre() == false) Mob_3.Dir = 2;
                else if (Mob_3.Dir == 2 && Mob_3.CheckPre() == true) Mob_3.Left();
                else if (Mob_3.Dir == 2 && Mob_3.CheckPre() == false) Mob_3.Dir = 1;
            }  */          
            // Основной персонаж
            switch (Cakecap)
            {
                case 6:
                    player.isJumping = true;
                    player.jumpCount = 0;
                    int b = player.CheckPlat(player.last_Dir);
                    player.contin = false;
                    /*
                    if (Mob_1.Dir != 0 && Mob_2.Dir != 0 && Mob_3.Dir != 0)
                    {
                        last_DirMob1 = Mob_1.Dir;
                        last_DirMob2 = Mob_2.Dir;
                        last_DirMob3 = Mob_3.Dir;
                    }
                    Mob_1.Dir = 0;
                    Mob_2.Dir = 0;
                    Mob_3.Dir = 0;
                    */
                    player.Jump(2);
                    WMP3.controls.play();
                    if (player._x > 780 && player._x < side * height - 780 && b != 3)
                    {
                        if (player.last_Dir == 1 && b == 1) delta.X -= player.speed;
                        else if (player.last_Dir == 2 && b == 1) delta.X += player.speed;
                        else if (player.last_Dir == 1 && b != 1) delta.X -= 3 * player.speed;
                        else if (player.last_Dir == 2 && b != 1) delta.X += 3 * player.speed;
                    }
                    else if(player._x < 780) delta.X = 0;
                    break;
                case 1:
                    if (player.CheckPlat(player.last_Dir) != 1 && player.CheckPlat(player.last_Dir) != 3)
                    {                      
                        player.Right();
                        WMP2.controls.play();
                        if (player._x > 780 && player._x < side * height - 780)
                            delta.X -= player.speed;
                        if (player.CheckPlat(player.last_Dir) == 0)
                        {
                            player.contin = false;
                            /*
                            if (Mob_1.Dir != 0 && Mob_2.Dir != 0 && Mob_3.Dir != 0)
                            {
                                last_DirMob1 = Mob_1.Dir;
                                last_DirMob2 = Mob_2.Dir;
                                last_DirMob3 = Mob_3.Dir;
                            }
                            Mob_1.Dir = 0;
                            Mob_2.Dir = 0;
                            Mob_3.Dir = 0;
                            */
                            player.JumpDoun();
                        }
                    }
                    else if (player._x < 780) delta.X = 0;
                    break;
                case 2:
                    if (player.CheckPlat(player.last_Dir) != 1 && player.CheckPlat(player.last_Dir) != 3)
                    {
                        player.Left();
                        WMP2.controls.play();
                        if (player._x >= 780 && player._x < side * height - 780)
                            delta.X += player.speed;
                        if (player.CheckPlat(player.last_Dir) == 0)
                        {
                            /*
                            player.contin = false;
                            if(Mob_1.Dir != 0 && Mob_2.Dir != 0 && Mob_3.Dir != 0)
                            {
                                last_DirMob1 = Mob_1.Dir;
                                last_DirMob2 = Mob_2.Dir;
                                last_DirMob3 = Mob_3.Dir;
                            }
                            Mob_1.Dir = 0;
                            Mob_2.Dir = 0;
                            Mob_3.Dir = 0;
                            */
                            player.JumpDoun();
                        }
                    }
                    else if (player._x < 780) delta.X = 0;
                    break;
                case 0:
                    player.isJumping = true;
                    player.jumpCount = 0;
                    int b_2 = player.CheckPlat(player.last_Dir);
                    /*
                    player.contin = false;
                    if (Mob_1.Dir != 0 && Mob_2.Dir != 0 && Mob_3.Dir != 0)
                    {
                        last_DirMob1 = Mob_1.Dir;
                        last_DirMob2 = Mob_2.Dir;
                        last_DirMob3 = Mob_3.Dir;
                    }
                    Mob_1.Dir = 0;
                    Mob_2.Dir = 0;
                    Mob_3.Dir = 0;
                    */
                    player.Jump(1);
                    WMP3.controls.play();
                    if (player._x > 780 && player._x < side * height - 780 && b_2 != 3)
                    {
                        if (player.last_Dir == 1) delta.X -= player.speed;
                        else if (player.last_Dir == 2 ) delta.X += player.speed;

                    }
                    else if (player._x < 780) delta.X = 0;
                    break;

            }
            // Сбор плюшек
            index1 = (player._y + player.Height - 50) / 50 - 4;
            index2 = (player._x + side) / side;
            index2_1 = (player._x + side/2) / side;
            if (index1 < width && index2 < height)
            {
                if (player._x % side == 0 && map[index1, index2] == 4)
                {
                    map[index1, index2] = 1;
                    player.points += 1;
                }
                else if(player._x % side != 0 && map[index1, index2_1] == 4)
                {
                    map[index1, index2_1] = 1;
                    player.points += 1;
                }
                if (player._x % side == 0 && map[index1, index2] == 5)
                {
                    map[index1, index2] = 1;
                    player.keys += 1;
                }
                else if (player._x % side != 0 && map[index1, index2_1] == 5)
                {
                    map[index1, index2_1] = 1;
                    player.keys += 1;
                }
                if (player._x % side == 0 && map[index1, index2] == 3)
                {
                    map[index1, index2] = 1;
                    if(player.count_lives != player.count_livesMax) player.count_lives += 1;
                }
                else if (player._x % side != 0 && map[index1, index2_1] == 3)
                {
                    map[index1, index2_1] = 1;
                    if (player.count_lives != player.count_livesMax) player.count_lives += 1;
                }
            }
            /*
            if (player.contin == true)
            {
                Mob_1.Dir = last_DirMob1;
                Mob_2.Dir = last_DirMob2;
                Mob_3.Dir = last_DirMob3;
                player.contin = false;
            }*/
            // Проигрыш из-за падения
            if (player._y > 900 || isEnd == true)
            {
                WMP.close();
                timer1.Stop();
                timer2.Stop();
                Results results = new Results(1);
                if(results.ShowDialog() == DialogResult.OK)
                {
                    timer1.Start();
                    timer2.Start();
                    restart = results.get_restart();
                    update();
                }                  
            }
            // Прошел 2-ой уровень
            if (player._x + player.hitX >= index * side && lvl == 2 && player.keys == 1 && count_kill == 3)
            {
                WMP.close();
                Cakecap = -1;
                timer2.Stop();
                lvl = 2;
                Results results = new Results(3);
                results.ShowDialog();
            }
            // Прошел 1-ый уровень
            if (player._x + player.hitX >= index * side && lvl == 1 && player.keys == 1 && count_kill == 3)
            {
                WMP.close();
                Cakecap = -1;
                timer2.Stop();
                lvl = 2;
                Results results = new Results(2);
                if (results.ShowDialog() == DialogResult.OK)
                {
                    this.BackgroundImage = PictureImage16;
                    timer2.Start();
                    new_urow = results.get_new_urow();
                    update();
                }
            }
            count_tick++;
            this.Invalidate();
        }
        private void update()
        {
            // В случае проигрыша уровня - перезапуск
            if (restart)
            {
                WMP.controls.play();
                map = map_copy.Clone() as int[,];
                player._x = 0;
                player._y = 550;
                for (int i = 0; i < Mobs.Count; i++)
                {
                    Mobs[i]._x = MobPosition[i];
                    Mobs[i]._y = 550;
                }
                delta.X = 0;
                restart = false;
                player.keys = 0;
                player.points = 0;
                player.count_lives = player.count_livesMax;
                Cakecap = -1;
                keys.Clear();
                isEnd = false;
                count_kill = 0;
            }
            // Если игрок прошел 1-ый уровень - перевод на второй
            else if (new_urow)
            {
                WMP.close();
                WMP.controls.play();
                map = map2.Clone() as int[,];
                map_copy = map2.Clone() as int[,];
                player.map = map;

                player._x = 0;
                player._y = 550;
                for (int i = 0; i < Mobs.Count; i++)
                {
                    Mobs[i]._x = MobPosition[i];
                    Mobs[i]._y = 550;
                }
                delta.X = 0;
                new_urow = false;
                player.keys = 0;
                player.points = 0;
                player.count_lives = player.count_livesMax;
                Cakecap = -1;
                keys.Clear();
                count_kill = 0;
                for (int i = 0; i < width; i++)
                {
                    for (int j = 0; j < height; j++)
                    {
                        if (map[i, j] == 7)
                        {
                            index = j; break;
                        }
                    }
                }
            }
        }
                          
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (isRunR == true && e.KeyCode == Keys.Space && !player.isJumping)
            {
                Cakecap = 6;
                if (keys.Contains(Cakecap) == false) keys.Add(Cakecap);
            }
            else if (isRunL == true && e.KeyCode == Keys.Space && !player.isJumping)
            {
                Cakecap = 6;
                if (keys.Contains(Cakecap) == false) keys.Add(Cakecap);
            }
            else if (e.KeyCode == Keys.Space && !player.isJumping)
            {
                Cakecap = 0;
                if (keys.Contains(Cakecap) == false) keys.Add(Cakecap);
            }
            else if (e.KeyCode == Keys.D && !player.isJumping)
            {
                player.last_Dir = 1;
                isRunR = true;
                Cakecap = 1;
                if (keys.Contains(Cakecap) == false) keys.Add(Cakecap);
            }
            else if (e.KeyCode == Keys.A && !player.isJumping)
            {
                player.last_Dir = 2;
                isRunL = true;
                Cakecap = 2;
                if (keys.Contains(Cakecap) == false) keys.Add(Cakecap);
            }
            else if (e.KeyCode == Keys.P && isAttack1 == false)
            {
                WMP4.controls.play();
                isAttack1 = true;
                Cakecap = 3;
                if (keys.Contains(Cakecap) == false) keys.Add(Cakecap);
            }
            else if (e.KeyCode == Keys.O && isAttack2 == false )
            {
                WMP4.controls.play();
                isAttack2 = true;
                Cakecap = 4;
                if (keys.Contains(Cakecap) == false) keys.Add(Cakecap);
            }
            else if (e.KeyCode == Keys.ShiftKey)
            {
                isBlock = true;
                Cakecap = 5;
                if (keys.Contains(Cakecap) == false) keys.Add(Cakecap);
            }
            else
                Cakecap = -1;

        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.D)
            {
                keys.Remove(1);
                isRunR = false;
                if (keys.Contains(6) == true) keys.Remove(6);
            }                         
            else if (e.KeyCode == Keys.A)
            {
                keys.Remove(2);
                isRunL = false;
                if (keys.Contains(6) == true) keys.Remove(6);
            }                                    
            else if (e.KeyCode == Keys.P)
            {
                isAttack1 = false;
                keys.Remove(3);
            }                    
            else if (e.KeyCode == Keys.O)
            {
                isAttack2 = false;
                keys.Remove(4);
            }                     
            else if (e.KeyCode == Keys.Space)
            {
                keys.Remove(0);
                if (keys.Contains(6) == true) keys.Remove(6);
                {
                    keys.Remove(6);
                    
                }
                if (keys.Count > 0)
                {
                    Cakecap = keys[keys.Count - 1];
                }
            }            
            else if (e.KeyCode == Keys.ShiftKey)
            {
                isBlock = false;
                keys.Remove(5);
            }
            if (keys.Count == 0)           
                Cakecap = -1;           
            CurrFrame = 0;
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            for(int i = 0; i < Mobs.Count; i++)
            {
                if(Mobs[i].tipe == 1)
                {
                    if (Mobs[i].countLives != 0)
                    {
                        if (Mobs[i].Dir == 1)
                        {
                            if (CurrFrame_Mob1 == 6)
                            {
                                CurrFrame_Mob1 = 0;
                            }
                            CurrFrame_Mob1++;
                        }
                        else if (Mobs[i].Dir == 2)
                        {
                            if (CurrFrame_Mob1 == 0)
                            {
                                CurrFrame_Mob1 = 6;
                            }
                            CurrFrame_Mob1--;
                        }
                    }
                    else
                    {
                        if (CurrFrame_Mob1 == 3)
                        {
                            CurrFrame_Mob1 = -1;
                        }
                        else if (CurrFrame_Mob1 != 3 && CurrFrame_Mob1 != -1) CurrFrame_Mob1++;
                    }
                }
                else if (Mobs[i].tipe == 2)
                {
                    if (Mobs[i].countLives != 0)
                    {
                        if (Mobs[i].Dir == 1)
                        {
                            if (CurrFrame_Mob2 == 6)
                            {
                                CurrFrame_Mob2 = 0;
                            }
                            CurrFrame_Mob2++;
                        }
                        else if (Mobs[i].Dir == 2)
                        {
                            if (CurrFrame_Mob2 == 0)
                            {
                                CurrFrame_Mob2 = 6;
                            }
                            CurrFrame_Mob2--;
                        }
                    }
                    else
                    {
                        if (CurrFrame_Mob2 == 4)
                        {
                            CurrFrame_Mob2 = -1;
                        }
                        else if (CurrFrame_Mob2 != 4 && CurrFrame_Mob2 != -1) CurrFrame_Mob2++;
                    }
                }
                else if (Mobs[i].tipe == 3)
                {
                    if (Mobs[i].countLives != 0)
                    {
                        if (Mobs[i].Dir == 1)
                        {
                            if (CurrFrame_Mob3 == 4)
                            {
                                CurrFrame_Mob3 = 0;
                            }
                            CurrFrame_Mob3++;
                        }
                        else if (Mobs[i].Dir == 2)
                        {
                            if (CurrFrame_Mob3 == 0)
                            {
                                CurrFrame_Mob3 = 4;
                            }
                            CurrFrame_Mob3--;
                        }
                    }
                    else
                    {
                        if (CurrFrame_Mob3 == 3)
                        {
                            CurrFrame_Mob3 = -1;
                        }
                        else if (CurrFrame_Mob3 != 3 && CurrFrame_Mob3 != -1) CurrFrame_Mob3++;
                    }
                }
                
            }
            /*
            if(Mob_1.countLives != 0)
            {
                if (Mob_1.Dir == 1)
                {
                    if (CurrFrame_Mob1 == 6)
                    {
                        CurrFrame_Mob1 = 0;
                    }
                    CurrFrame_Mob1++;
                }
                else if (Mob_1.Dir == 2)
                {
                    if (CurrFrame_Mob1 == 0)
                    {
                        CurrFrame_Mob1 = 6;
                    }
                    CurrFrame_Mob1--;
                }
            }
            else
            {
                if (CurrFrame_Mob1 == 3)
                {
                    CurrFrame_Mob1 = -1;
                }
                else if (CurrFrame_Mob1 != 3 && CurrFrame_Mob1!= -1)  CurrFrame_Mob1++;
            }
            if (Mob_2.countLives != 0)
            {
                if (Mob_2.Dir == 1)
                {
                    if (CurrFrame_Mob2 == 6)
                    {
                        CurrFrame_Mob2 = 0;
                    }
                    CurrFrame_Mob2++;
                }
                else if (Mob_2.Dir == 2)
                {
                    if (CurrFrame_Mob2 == 0)
                    {
                        CurrFrame_Mob2 = 6;
                    }
                    CurrFrame_Mob2--;
                }
            }
            else
            {
                if (CurrFrame_Mob2 == 4)
                {
                    CurrFrame_Mob2 = -1;
                }
                else if (CurrFrame_Mob2 != 4 && CurrFrame_Mob2 != -1) CurrFrame_Mob2++;
            }
            if (Mob_3.countLives != 0)
            {
                if (Mob_3.Dir == 1)
                {
                    if (CurrFrame_Mob3 == 4)
                    {
                        CurrFrame_Mob3 = 0;
                    }
                    CurrFrame_Mob3++;
                }
                else if (Mob_3.Dir == 2)
                {
                    if (CurrFrame_Mob3 == 0)
                    {
                        CurrFrame_Mob3 = 4;
                    }
                    CurrFrame_Mob3--;
                }
            }
            else
            {
                if (CurrFrame_Mob3 == 3)
                {
                    CurrFrame_Mob3 = -1;
                }
                else if (CurrFrame_Mob3 != 3 && CurrFrame_Mob3 != -1) CurrFrame_Mob3++;
            }*/
            if(player.count_lives != 0)
            {
                if (Cakecap == 0)
                {
                    if (player.last_Dir == 1)
                    {
                        if (CurrFrame == 9)
                        {
                            CurrFrame = 0;
                        }
                        CurrFrame++;
                    }
                    else if (player.last_Dir == 2)
                    {
                        if (CurrFrame == 0)
                        {
                            CurrFrame = 9;
                        }
                        CurrFrame--;
                    }
                }
                else if (Cakecap == 1)
                {
                    if (CurrFrame == 7)
                    {
                        CurrFrame = 0;
                    }
                    CurrFrame++;
                }
                else if (Cakecap == 2)
                {
                    if (CurrFrame == 0)
                    {
                        CurrFrame = 7;
                    }
                    CurrFrame--;
                }
                else if (Cakecap == 5)
                {
                    if (player.last_Dir == 1)
                    {
                        if (CurrFrame == 2)
                        {
                            CurrFrame = 0;
                        }
                        CurrFrame++;
                    }
                    else if (player.last_Dir == 2)
                    {
                        if (CurrFrame == 0)
                        {
                            CurrFrame = 2;
                        }
                        CurrFrame--;
                    }
                }
                else if (Cakecap == 6)
                {
                    if (player.last_Dir == 1)
                    {
                        if (CurrFrame == 9)
                        {
                            CurrFrame = 0;
                        }
                        CurrFrame++;
                    }
                    else if (player.last_Dir == 2)
                    {
                        if (CurrFrame == 0)
                        {
                            CurrFrame = 9;
                        }
                        CurrFrame--;
                    }
                }
            }
            else
            {
                if (CurrFrame == 2)
                {
                   isEnd = true;
                }
                else CurrFrame++;
                
            }
            
            this.Invalidate();
        }
         
        
        private void CreateMap(Graphics gr)
        {
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    if (map[i, j] == 9)
                    {
                        gr.DrawImage(PictureImage5, new Rectangle(j* side + delta.X, (i + 4) * 50, side,50), 0, 0, side, 50, GraphicsUnit.Pixel);
                    }
                    else if (map[i, j] == 2)
                    {
                        gr.DrawImage(PictureImage8, new Rectangle(j * side + delta.X, (i + 4) * 50, side, 50), 0, 0, side, 50, GraphicsUnit.Pixel);
                    }
                    else if (map[i, j] == 3)
                    {
                        gr.DrawImage(PictureImage12, new Rectangle(j * side + delta.X, (i + 4) * 50, side, 50), 0, 0, 50, 50, GraphicsUnit.Pixel);
                    }
                    else if (map[i, j] == 4)
                    {
                        gr.DrawImage(PictureImage13, new Rectangle(j * side + delta.X, (i + 4) * 50, side, 50), 0, 0, 50, 50, GraphicsUnit.Pixel);
                    }
                    else if (map[i, j] == 5)
                    {
                        gr.DrawImage(PictureImage14, new Rectangle(j * side + delta.X, (i + 4) * 50, side, 50), 0, 0, 50, 50, GraphicsUnit.Pixel);
                    }
                    else if (map[i, j] == 6)
                    {
                        gr.DrawImage(PictureImage15, new Rectangle(j * side + delta.X, (i + 4) * 50, 55, 100), 20, 0, 55, 100, GraphicsUnit.Pixel);
                    }
                    else if (map[i, j] == 7)
                    {
                        gr.DrawImage(PictureImage15, new Rectangle(j * side + delta.X, (i + 4) * 50, side, 100), 20, 0, 55, 100, GraphicsUnit.Pixel);
                    }
                }
            }
        }
        private void PlayAnimation(Graphics gr)
        {
            for(int i = 0; i < Mobs.Count; i++)
            {
                if (Mobs[i].tipe == 1)
                {
                    if (Mobs[i].countLives != 0)
                    {
                        if (Mobs[i].Dir == 1)
                            gr.DrawImage(PictureImage18, new Rectangle(Mobs[i]._x + delta.X, Mobs[i]._y + delta.Y, Mobs[i].Width, Mobs[i].Height), 128 * CurrFrame_Mob1, 0, 128, 128, GraphicsUnit.Pixel);
                        else if (Mobs[i].Dir == 2)
                            gr.DrawImage(PictureImage19, new Rectangle(Mobs[i]._x + delta.X, Mobs[i]._y + delta.Y, Mobs[i].Width, Mobs[i].Height), 128 * CurrFrame_Mob1, 0, 128, 128, GraphicsUnit.Pixel);
                        else if (Mobs[i].Dir == 0)
                        {
                            if (last_DirMob1 == 1)
                                gr.DrawImage(PictureImage17, new Rectangle(Mobs[i]._x + delta.X, Mobs[i]._y + delta.Y, Mobs[i].Width, Mobs[i].Height), 0, 0, 128, 128, GraphicsUnit.Pixel);
                            else if (last_DirMob1 == 2)
                                gr.DrawImage(PictureImage26, new Rectangle(Mobs[i]._x + delta.X, Mobs[i]._y + delta.Y, Mobs[i].Width, Mobs[i].Height), 0, 0, 128, 128, GraphicsUnit.Pixel);
                        }
                        else if (Mobs[i].Dir == 3)
                        {
                            if (last_DirMob1 == 1)
                                gr.DrawImage(PictureImage32, new Rectangle(Mobs[i]._x + delta.X, Mobs[i]._y + delta.Y, Mobs[i].Width, Mobs[i].Height), 128 * 3, 0, 128, 128, GraphicsUnit.Pixel);
                            else if (last_DirMob1 == 2)
                                gr.DrawImage(PictureImage33, new Rectangle(Mobs[i]._x + delta.X, Mobs[i]._y + delta.Y, Mobs[i].Width, Mobs[i].Height), 0, 0, 128, 128, GraphicsUnit.Pixel);
                        }
                    }
                    else
                        gr.DrawImage(PictureImage35, new Rectangle(Mobs[i]._x + delta.X, Mobs[i]._y + delta.Y, Mobs[i].Width, Mobs[i].Height), 128 * CurrFrame_Mob1, 0, 128, 128, GraphicsUnit.Pixel);
                }
                else if (Mobs[i].tipe == 2)
                {
                    if (Mobs[i].countLives != 0)
                    {
                        if (Mobs[i].Dir == 1)
                            gr.DrawImage(PictureImage20, new Rectangle(Mobs[i]._x + delta.X, Mobs[i]._y + delta.Y, Mobs[i].Width, Mobs[i].Height), 128 * CurrFrame_Mob2, 0, 128, 128, GraphicsUnit.Pixel);
                        else if (Mobs[i].Dir == 2)
                            gr.DrawImage(PictureImage21, new Rectangle(Mobs[i]._x + delta.X, Mobs[i]._y + delta.Y, Mobs[i].Width, Mobs[i].Height), 128 * CurrFrame_Mob2, 0, 128, 128, GraphicsUnit.Pixel);
                        else if (Mobs[i].Dir == 0)
                        {
                            if (last_DirMob2 == 1)
                                gr.DrawImage(PictureImage24, new Rectangle(Mobs[i]._x + delta.X, Mobs[i]._y + delta.Y, Mobs[i].Width, Mobs[i].Height), 0, 0, 128, 128, GraphicsUnit.Pixel);
                            else if (last_DirMob2 == 2)
                                gr.DrawImage(PictureImage28, new Rectangle(Mobs[i]._x + delta.X, Mobs[i]._y + delta.Y, Mobs[i].Width, Mobs[i].Height), 0, 0, 128, 128, GraphicsUnit.Pixel);
                        }
                        else if (Mobs[i].Dir == 3)
                        {
                            if (last_DirMob2 == 1)
                                gr.DrawImage(PictureImage38, new Rectangle(Mobs[i]._x + delta.X, Mobs[i]._y + delta.Y, Mobs[i].Width, Mobs[i].Height), 128 * 4, 0, 128, 128, GraphicsUnit.Pixel);
                            else if (last_DirMob2 == 2)
                                gr.DrawImage(PictureImage40, new Rectangle(Mobs[i]._x + delta.X, Mobs[i]._y + delta.Y, Mobs[i].Width, Mobs[i].Height), 0, 0, 128, 128, GraphicsUnit.Pixel);
                        }
                    }
                    else
                        gr.DrawImage(PictureImage36, new Rectangle(Mobs[i]._x + delta.X, Mobs[i]._y + delta.Y, Mobs[i].Width, Mobs[i].Height), 128 * CurrFrame_Mob2, 0, 128, 128, GraphicsUnit.Pixel);
                }
                else if (Mobs[i].tipe == 3)
                {
                    if (Mobs[i].countLives != 0)
                    {
                        if (Mobs[i].Dir == 1)
                            gr.DrawImage(PictureImage22, new Rectangle(Mobs[i]._x + delta.X, Mobs[i]._y + delta.Y, Mobs[i].Width, Mobs[i].Height), 128 * CurrFrame_Mob3, 0, 128, 128, GraphicsUnit.Pixel);
                        else if (Mobs[i].Dir == 2)
                            gr.DrawImage(PictureImage23, new Rectangle(Mobs[i]._x + delta.X, Mobs[i]._y + delta.Y, Mobs[i].Width, Mobs[i].Height), 128 * CurrFrame_Mob3, 0, 128, 128, GraphicsUnit.Pixel);
                        else if (Mobs[i].Dir == 0)
                        {
                            if (last_DirMob3 == 1)
                                gr.DrawImage(PictureImage25, new Rectangle(Mobs[i]._x + delta.X, Mobs[i]._y + delta.Y, Mobs[i].Width, Mobs[i].Height), 0, 0, 128, 128, GraphicsUnit.Pixel);
                            else if (last_DirMob3 == 2)
                                gr.DrawImage(PictureImage29, new Rectangle(Mobs[i]._x + delta.X, Mobs[i]._y + delta.Y, Mobs[i].Width, Mobs[i].Height), 0, 0, 128, 128, GraphicsUnit.Pixel);
                        }
                        else if (Mobs[i].Dir == 3)
                        {
                            if (last_DirMob3 == 1)
                                gr.DrawImage(PictureImage39, new Rectangle(Mobs[i]._x + delta.X, Mobs[i]._y + delta.Y, Mobs[i].Width, Mobs[i].Height), 128 * 3, 0, 128, 128, GraphicsUnit.Pixel);
                            else if (last_DirMob3 == 2)
                                gr.DrawImage(PictureImage41, new Rectangle(Mobs[i]._x + delta.X, Mobs[i]._y + delta.Y, Mobs[i].Width, Mobs[i].Height), 0, 0, 128, 128, GraphicsUnit.Pixel);
                        }
                    }
                    else
                        gr.DrawImage(PictureImage37, new Rectangle(Mobs[i]._x + delta.X, Mobs[i]._y + delta.Y, Mobs[i].Width, Mobs[i].Height), 128 * CurrFrame_Mob3, 0, 128, 128, GraphicsUnit.Pixel);
                }
            }
                               
            if (player.count_lives != 0)
            {
                if (Cakecap == 1)
                    gr.DrawImage(PictureImage, new Rectangle(player._x + delta.X, player._y + delta.Y, player.Width, player.Height), 128 * CurrFrame, 0, 128, 128, GraphicsUnit.Pixel);
                else if (Cakecap == 2)
                    gr.DrawImage(PictureImage2, new Rectangle(player._x + delta.X, player._y + delta.Y, player.Width, player.Height), 128 * CurrFrame, 0, 128, 128, GraphicsUnit.Pixel);
                else if (Cakecap == 0 || Cakecap == 6)
                {
                    if (player.last_Dir == 1)
                        gr.DrawImage(PictureImage4, new Rectangle(player._x + delta.X, player._y + delta.Y, player.Width, player.Height), 128 * CurrFrame, 0, 128, 128, GraphicsUnit.Pixel);
                    else if (player.last_Dir == 2)
                        gr.DrawImage(PictureImage9, new Rectangle(player._x + delta.X, player._y + delta.Y, player.Width, player.Height), 128 * CurrFrame, 0, 128, 128, GraphicsUnit.Pixel);
                }
                else if (Cakecap == 3)
                {
                    if (player.last_Dir == 1)
                        gr.DrawImage(PictureImage6, new Rectangle(player._x + delta.X, player._y + delta.Y, player.Width, player.Height), 128 * 3, 0, 128, 128, GraphicsUnit.Pixel);
                    else if (player.last_Dir == 2)
                        gr.DrawImage(PictureImage30, new Rectangle(player._x + delta.X, player._y + delta.Y, player.Width, player.Height), 0, 0, 128, 128, GraphicsUnit.Pixel);
                }
                else if (Cakecap == 4)
                {
                    if (player.last_Dir == 1)
                        gr.DrawImage(PictureImage7, new Rectangle(player._x + delta.X, player._y + delta.Y, player.Width, player.Height), 128 * 2, 0, 128, 128, GraphicsUnit.Pixel);
                    else if (player.last_Dir == 2)
                        gr.DrawImage(PictureImage31, new Rectangle(player._x + delta.X, player._y + delta.Y, player.Width, player.Height), 0, 0, 128, 128, GraphicsUnit.Pixel);
                }
                else if (Cakecap == 5)
                {
                    if (player.last_Dir == 1)
                        gr.DrawImage(PictureImage10, new Rectangle(player._x + delta.X, player._y + delta.Y, player.Width, player.Height), 128 * CurrFrame, 0, 128, 128, GraphicsUnit.Pixel);
                    else if (player.last_Dir == 2)
                        gr.DrawImage(PictureImage11, new Rectangle(player._x + delta.X, player._y + delta.Y, player.Width, player.Height), 128 * CurrFrame, 0, 128, 128, GraphicsUnit.Pixel);
                }
                else
                {
                    if (player.last_Dir == 1)
                        gr.DrawImage(PictureImage3, new Rectangle(player._x + delta.X, player._y + delta.Y, player.Width, player.Height), 0, 0, 128, 128, GraphicsUnit.Pixel);
                    else if (player.last_Dir == 2)
                        gr.DrawImage(PictureImage27, new Rectangle(player._x + delta.X, player._y + delta.Y, player.Width, player.Height), 0, 0, 128, 128, GraphicsUnit.Pixel);
                }
            }
            else           
                gr.DrawImage(PictureImage34, new Rectangle(player._x + delta.X, player._y + delta.Y, player.Width, player.Height), 128 * CurrFrame, 0, 128, 128, GraphicsUnit.Pixel);          
        }
        private void LivesPoints(Graphics gr)
        {
            for (int i = 0; i < player.count_lives; ++i)
            {
                gr.DrawImage(PictureImage12, new Rectangle(70 * i, 10, 50, 50), 0, 0, 50, 50, GraphicsUnit.Pixel);
            }
            gr.DrawString("Монеты: " + player.points.ToString() + " / " + player.pointsMax.ToString(), drawFont, drawBrush, 0, 70);
            gr.DrawString("Ключи: " + player.keys.ToString() + " / " + player.keysMax.ToString(), drawFont, drawBrush, 0, 100);
        }       
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics gr = e.Graphics;
            LivesPoints(gr);
            CreateMap(gr);
            PlayAnimation(gr);
        }       
    }
}
