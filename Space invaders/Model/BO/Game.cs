using Space_invaders.Model.Controls;
using Space_invaders.View;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Space_invaders.Model.BO
{
    public class Game
    {
        public Space space { get; set; }
        public Space space_2 { get; set; }
        public List<Bullets> bullets { get; set; }
        public List<Invader> InvaderList { get; set; }
        public Invader invader { get; set; }
        public Cursor cursor { get; set; }
        public List<Bullets_Invaders> bulletsINV { get; set; }
        public AppForm form1 { get; set; }
        public int countDeadInvs { get; set; }

        public Game(AppForm form)
        {
            countDeadInvs = 0;
            InvaderList = new List<Invader> ();
            space = new Space();
            space_2 = new Space();
            bullets = new List<Bullets>();
            bulletsINV = new List<Bullets_Invaders>();
            form1 = form;
            
            CreateInvaders(3);
            CreateSpace(form);
        }

        private void CreateInvaders(int count)
        {
            for (int i = 0; i < count; i++)
            {
                var point = new Point(80 + i + i * 160, 73);
                Invader invader = new Invader(point);
                invader.LocationChanged += Invader_Outside;

                InvaderList.Add(invader);
            }
        }

        private void Invader_Outside(object sender, EventArgs e)
        {
            Invader invader = (Invader)sender;
            if (invader.Location.X <= 0)
            {
                invader.Location = new Point(form1.Width, invader.Location.Y + 50);
            }
        }

        private void CreateSpace(AppForm form)
        {
            var formWidth = form.Width;             //pour acceder aux objets Graphique d'une autre classe
            var formheight = form.Height;
            var point = new Point((formWidth / 2) - 22, formheight - 120);
            space = new Space(point);
            space_2 = new Space(point);
        }

        public Bullets CreateBullet()
        {
            Bullets bullet = new Bullets();
            bullet.LocationChanged += invaderisDead;
            bullets.Add(bullet);

            return bullet;
        }

        public void invaderisDead(object sender, EventArgs e)
        {
            Bullets bullet = (Bullets)sender;
            for (int i = 0; i < InvaderList.Count; i++)
            {
                Invader inv = InvaderList[i];

                if (bullet.Bounds.IntersectsWith(inv.Bounds))
                {
                    inv.Dispose();
                    if (!inv.isDead)
                    {
                        countDeadInvs ++;
                        bullet.Dispose();
                    }
                    inv.isDead = true;
                    //var point = new Point(250, 73);
                    //Invader invadd = new Invader(point);
                    //InvaderList.Add(invadd);
                }
            }
        }
        
        public Bullets_Invaders CreateBulletINV()
        {
            Bullets_Invaders bulletINV = new Bullets_Invaders();
            bulletsINV.Add(bulletINV);
            return bulletINV;
        }

        private void countInvadersInForm(Label l)
        {
            var invaderCount = 0;
            foreach (Control c in form1.Controls)
            {
                if (c is Invader)
                invaderCount++;
                l.Text = invaderCount.ToString();
            }
        }
    }
}
