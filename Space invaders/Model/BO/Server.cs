using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Space_invaders.Model.BO
{
    public class Server
    {
        private Socket listenSocket;
        private List<Client> remoteClients = new List<Client>();
        private IPEndPoint bindingIp;

        public bool IsRunning { get; private set; }

        public event EventHandler<Socket> ClientAccepted;
        public event EventHandler Stopped;
        public event EventHandler Started;


        public Server(string ip, int port)
        {
            IPAddress localIP = IPAddress.Parse(ip);
            bindingIp = new IPEndPoint(localIP, port);

            IsRunning = false;
        }

        public void Start()
        {
            if (listenSocket == null)
            {
                listenSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                listenSocket.Bind(bindingIp);
                listenSocket.Listen(100); //maximum number of connections queu
                AcceptClient(listenSocket);
            }
            OnStart();
        }

        private void OnStart()
        {
            IsRunning = true;
            if (Started != null)
            {
                Started(this, EventArgs.Empty);
            }

        }
        public void Stop()
        {
            if (IsRunning)
            {
                listenSocket.Close();
            }
            OnStop();
        }

        private void AcceptClient(Socket listener)
        {
            Console.WriteLine("Waiting for a connection...");
            listener.BeginAccept(new AsyncCallback(AcceptClientCallback), listener);
        }

        private void AcceptClientCallback(IAsyncResult ar)
        {
            try
            {
                Socket listener = (Socket)ar.AsyncState;
                Socket client = listener.EndAccept(ar);
                Console.WriteLine("client {0} connected", client.RemoteEndPoint.ToString());
                OnClientAccepted(client);
                AcceptClient(listener);
            }
            catch (Exception e)
            {
                OnStop();
            }
        }

        private void OnStop()
        {
            IsRunning = false;
            if (Stopped != null)
            {
                Stopped(this, EventArgs.Empty);
            }
        }

        private void OnClientAccepted(Socket client)
        {
            if (ClientAccepted != null)
            {
                ClientAccepted(this, client);
            }
        }
    }
}

