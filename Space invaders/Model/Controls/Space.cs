using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;

namespace Space_invaders.Model.Controls
{
    public class Space : PictureBox
    {
        private Point point;

        public Space() { }

        public Space(Point point)
        {
            this.point = point;
        }

        public Space(Point point, Boolean mon_avion)
        {
            Location = point;
            Size = new Size(70, 70);
            BackgroundImage = (mon_avion) ? Properties.Resources.spaceship1
                                          : Properties.Resources.spaceship2;
            BackgroundImageLayout = ImageLayout.Stretch;
            BackColor = Color.Transparent;
        }

        public void move()
        {
            Location = new Point(Cursor.Position.X-235, Location.Y);
        }

        public void move(int xLocation)
        {
            Location = new Point(xLocation - 235, Location.Y);
        }
    }
}
