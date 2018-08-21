using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Space_invaders.Model.BO
{
    [Serializable]  //ne peut etre herité
    public class ClientData
    {
        public string Message { get; set; }
        public SocketMessage socketMessage { get; set; }

        public ClientData() { }
        public ClientData(SocketMessage message)
        {
            this.socketMessage = message;

            // -- Si c'est un message du serveur -- //
            if (message.est_serveur)
            {
                Program.formClient.game.space_2.move(message.xLocation);
            }
        }

        public byte[] Serialize()
        {
            return Data.Serialize(this);
        }

        public ClientData Deserialize(byte[] buffer)
        {
            return (ClientData)Data.Deserialize(buffer);
        }
    }
}
