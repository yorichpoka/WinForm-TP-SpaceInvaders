using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_invaders.Model.BO
{
    public class SocketMessage
    {
        public int xLocation { get; set; }
        public Boolean est_serveur { get; set; }

        public SocketMessage() { }
        public SocketMessage(int x, Boolean est_server)
        {
            this.xLocation = x;
            this.est_serveur = est_server;
        }
    }
}
