using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using Space_invaders.View;
using Space_invaders.Model.BO;

namespace Space_invaders.Model.Controls
{
    public class Bullets : PictureBox
    {
        public AppForm form;
        public Game game;
     
        public Bullets()
        {
            Size = new Size(15, 30);
            BackgroundImage = Properties.Resources.bullet;
            BackgroundImageLayout = ImageLayout.Stretch;
            BackColor = Color.Transparent;
        }

        public Boolean IsOutOfBounds()
        {
            return (this.Top < 0);
        }

        public void go()
        {
         this.Top -= 20;
        }


    }
}
