using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Space_invaders.Model.Controls
{
    public class Invader : PictureBox
    {
        public bool isDead;
        public Invader(Point point) : base()
        {
            Location = point;
            Size = new Size(55,55);
            BackgroundImage = Properties.Resources.about;
            BackgroundImageLayout = ImageLayout.Stretch;
            BackColor = Color.Transparent;
            isDead = false;
        }

        public void moveLeft()
        {
            this.Left -= 3;
        }
    }
}
