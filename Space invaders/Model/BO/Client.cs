using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace Space_invaders.Model.BO
{
    public class Client
    {
        ClientData dataToSend = new ClientData();
        ClientData dataReceived = new ClientData();

        Socket remoteClient = new Socket(SocketType.Stream, ProtocolType.Tcp);

        public ClientData DataToSend { get { return dataToSend; } set { dataToSend = value; } }
        public ClientData DataReceived { get { return dataReceived; } }
        public bool IsConnected { get; private set; }

        public event EventHandler ReceivedData;
        public event EventHandler SentData;
        public event EventHandler Connected;

        public Client()
        {
            dataToSend.Message = "message";
        }
        public Client(Socket client)
        {
            dataToSend.Message = "message";
            remoteClient = client;
            Receive(remoteClient);
        }

        public void Connect(string remoteIp, int port)
        {
            IPEndPoint EP = new IPEndPoint(IPAddress.Parse(remoteIp), port);
            remoteClient.BeginConnect(EP, new AsyncCallback(connectCallback), null);
        }

        private void connectCallback(IAsyncResult ar)
        {
            remoteClient.EndConnect(ar);
            Receive(remoteClient);
        }
        public void Send()
        {
            byte[] buffer = Data.Serialize(dataToSend);
            remoteClient.BeginSend(buffer, 0, buffer.Length, SocketFlags.None,
                new AsyncCallback(SendCallback), null);
        }

        private void SendCallback(IAsyncResult ar)
        {
            remoteClient.EndSend(ar);
            OnSentData(EventArgs.Empty);
        }

        private void Receive(Socket client)
        {
            try
            {
                // Create the state object.  
                StateObject state = new StateObject();
                state.workSocket = client;

                // Begin receiving the data from the remote device.  
                client.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                    new AsyncCallback(ReceiveCallback), state);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
        private void ReceiveCallback(IAsyncResult ar)
        {
            try
            {
                // Retrieve the state object and the client socket   
                // from the asynchronous state object.  
                StateObject state = (StateObject)ar.AsyncState;
                Socket client = state.workSocket;
                // Read data from the remote device.  
                int bytesRead = client.EndReceive(ar);
                if (bytesRead > 0)
                {
                    // There might be more data, so store the data received so far.  
                    state.TransmissionBuffer.AddRange(state.buffer);
                    //  Get the rest of the data.
                    if (client.Available > 0)
                        client.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                            new AsyncCallback(ReceiveCallback), state);
                    else
                    {
                        transferDone(Data.Deserialize(state.TransmissionBuffer.ToArray()));
                    }
                }
                else
                {
                    transferDone(Data.Deserialize(state.TransmissionBuffer.ToArray()));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        private void transferDone(object data)
        {
            dataReceived = (ClientData)data;
            Receive(remoteClient);
            OnReceivedData(EventArgs.Empty);

        }

        private void OnReceivedData(EventArgs e)
        {
            if (ReceivedData != null)
            {
                ReceivedData(this, e);
            }
        }
        private void OnSentData(EventArgs e)
        {
            if (SentData != null)
            {
                SentData(this, e);
            }
        }

        private void OnConnected(EventArgs e)
        {
            IsConnected = true;
            if (Connected != null)
            {
                Connected(this, e);
                
            }
        }

        public Boolean isconnected2()
        {
            Boolean a ;
            if (remoteClient.Connected)
            {
                a=true;
            }
            else
            {
                a = false;
            }
            return a;
        }

       
    }

}
