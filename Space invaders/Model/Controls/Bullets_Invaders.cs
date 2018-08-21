using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Space_invaders.Model.Controls
{
    public class Bullets_Invaders : Bullets
    {

        public Bullets_Invaders()
        {
            Size = new Size(15, 30);
            BackgroundImage = Properties.Resources.bullet;
            BackgroundImageLayout = ImageLayout.Stretch;
            BackColor = Color.Transparent;
        }
        public void go_invader()
        {
            this.Top += 5;
        }
    }
}
