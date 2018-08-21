using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using WMPLib;
using System.Net;
using System.Net.Sockets;
using Space_invaders.Model.BO;
using Space_invaders.Model.Controls;

namespace Space_invaders.View
{
    public partial class AppForm : Form
    {
        #region Sound
        SoundPlayer StartMenuSound;
        SoundPlayer shootSound;
        WMPLib.WindowsMediaPlayer stage1 = new WMPLib.WindowsMediaPlayer();
        WMPLib.WindowsMediaPlayer GamePauseIn = new WMPLib.WindowsMediaPlayer();
        WMPLib.WindowsMediaPlayer GamePauseOut = new WMPLib.WindowsMediaPlayer();
        #endregion

        #region Instances
        public Game game { get; set; }
        public Space space { get; set; }
        public Invader invader { get; set; }
        public AboutForm FormAboutUs = new AboutForm();
        #endregion

        #region variable
        public int count { get; set; }
        Random random = new Random();

        public Server server { get; set; }
        public Client client { get; set; }
        public Nullable<Boolean> est_serveur { get; set; }
        #endregion

        public AppForm(String ip,int port,bool isServer)
        {
            InitializeComponent();

            count = 3;

            // gestion de mon serveur
            if (isServer)
            {
                this.est_serveur = true;
                this.Text = "Space Invaders: Server";
                server = new Server(ip, port);
                server.ClientAccepted += Server_ClientAccepted;
                server.Start();
            }
            else
            {
                this.est_serveur = false;
                this.Text = "Space Invaders: Client";
                client = new Client();
                client.Connect(ip, port);
                client.ReceivedData += Client_ReceivedData;
            }

            // Fin gestion de mon serveur
            shootSound = new SoundPlayer("shoot.wav");
            StartMenuSound = new SoundPlayer("StartMenuSound.wav");
        }

        private void timerGame_Tick(object sender, EventArgs e)
        {
            timerGame.Enabled = true;
            if (labelCountDown.Visible == false)
            {
                if (game != null && game.space != null && game.bullets != null)
                {
                    
                    foreach (var bullet in game.bullets)
                    {
                        bullet.go();
                    }
                    foreach (var bulletINV in game.bulletsINV)
                    {
                        bulletINV.go_invader();
                    }
                }
            }
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
                startNewGame();
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            exitGame();
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (labelCountDown.Visible==false)
            {
                if (game != null && game.space != null)
                {
                    // -- Action sur moi -- //
                    game.space.move();
                    
                    if (client != null)
                    {
                        //send mouse info on network  (check if client is connected)
                        Program.formClient.client.DataToSend = new ClientData(new SocketMessage(e.X, this.est_serveur.Value));
                        Program.formClient.client.Send();
                    }

                    // -- Action chez l'autre -- //
                    //if (est_serveur.Value && Program.formClient.est_serveur.HasValue)
                    //{

                    //}
                }
            }
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            SpaceshipShoot(e);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //timer
            timerStartMenu.Enabled = true;
            //sound
            StartMenuSound.Play();
            //background
            this.BackgroundImage = Properties.Resources.homebackground;
            this.BackgroundImageLayout = ImageLayout.Center;
            //Cursor.Hide();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Space)
            {
                if (game == null )
                {
                    startNewGame();
                }
            }
            if(e.KeyData == Keys.P)
            {
                PauseGame();
            }
        }

        private void timerStartMenu_Tick(object sender, EventArgs e)
        {
            //if (client != null)
            //{
            //    labelClientConnected.Text = ("Network status: Connected");
            //}
            //else
            //{
            //    labelClientConnected.Text = ("Network status: Disconnected");
            //}

            //Faire clignoter le Start menu
            if (pictureBoxPressStart.Visible)
            {
                pictureBoxPressStart.Visible = false;
            }
            else
            {
                pictureBoxPressStart.Visible = true;
            }
        }

        private void timerGameCountdown_Tick(object sender, EventArgs e)
        {
            CountdownStart();
        }

        private void aboutUsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAboutUs.ShowDialog();
        }

        private void timerMoveInvaders_Tick(object sender, EventArgs e)
        {
            if (labelCountDown.Visible==false)
            {
                if (game != null && game.space != null && game.bullets != null)
                {
                    foreach (var invader in game.InvaderList)
                    {
                        invader.moveLeft();
                        labelScore.Text = game.countDeadInvs.ToString();
                        
                    }
                }  
            }

            //foreach (Bullets b in game.bullets)
            //{
            //    if (b.IsOutOfBounds())
            //    {
            //        MessageBox.Show("test");
            //    }
            //}
        }

        private void timerInvadersBulletShoot_Tick(object sender, EventArgs e)
        {
            InvaderShoot(e);
        }

        #region Methodes
        private void startNewGame()
        {
            //timer
            timerGameCountdown.Enabled = true;
            timerStartMenu.Enabled = false;
            timerGame.Enabled = true;
            timerInvadersBulletShoot.Enabled = true;
            timerMoveInvaders.Enabled = true;
            //background
            BackgroundImage = Properties.Resources.BACKGROUND2;
            BackgroundImageLayout = ImageLayout.Stretch;
            //sound
            StartMenuSound.Stop();
            stage1.URL = "02-rounds-1-9.mp3";
            //print
            labelCountDown.Visible = true;

            for (int i = this.Controls.Count - 1; i >= 0; i--)
            {
                if (this.Controls[i] is PictureBox) this.Controls[i].Dispose();
            }
            //create game add invaders
            game = new Game(this);
            Controls.Add(game.space);
            //Cursor.Hide();
            //add invaders
            for (int i = 0; i < game.InvaderList.Count; i++)
            {
                Controls.Add(game.InvaderList[i]);
            }


            
            if (client != null)
            {
                this.Controls.Add(game.space_2);
            }
            
            ///fin test

        }

        private void exitGame()
        {
            //timer
            timerStartMenu.Enabled = false;
            timerMoveInvaders.Enabled = false;
            timerGame.Enabled = false;
            timerGameCountdown.Enabled = false;
            timerInvadersBulletShoot.Enabled = false;
            //sound
            StartMenuSound.Stop();
            stage1.controls.pause();

            if (game != null && game.space != null)
            {
                //jeu crée
                labelGamePaused.Visible = true;
            }
            else
            {
                labelGamePaused.Visible = false;
            }
            DialogResult dialogResult = MessageBox.Show("Do you want to exit the game ? (all saves will be lost)", "Space Invaders", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (dialogResult == DialogResult.Yes)
            {
                Close();
            }
            else if (dialogResult == DialogResult.No)
            {
                if (game != null && game.space != null)
                {
                    StartMenuSound.Stop();
                }
                else { StartMenuSound.Play(); }
                //timer
                timerInvadersBulletShoot.Enabled = true;
                timerStartMenu.Enabled = true;
                timerGameCountdown.Enabled = true;
                timerMoveInvaders.Enabled = true;
                timerGame.Enabled = true;
                //print
                labelGamePaused.Visible = false;
                //sound
                stage1.controls.play();

            }
        }
        private void SpaceshipShoot(MouseEventArgs e)
        {
            if (game != null && game.space != null)
            {
                var bullet = game.CreateBullet();
                bullet.Location = new Point(game.space.Location.X+25, this.Height - 80 - 80);
                this.Controls.Add(bullet);
                shootSound.Play();
            }
        }

        private void InvaderShoot(EventArgs e)
        {
            //if (game != null && game.space != null)
            //{
            //    if (timerGameCountdown.Enabled == false)
            //    {
            //        int i = random.Next(0, 7);
            //        Invader invader = game.InvaderTab[i];
            //        if (!invader.isDead)
            //        {
            //            var bulletIV = game.CreateBulletINV();
            //            bulletIV.Location = new Point(invader.Location.X + 17, invader.Location.Y);
            //            shootSound.Play();
            //            this.Controls.Add(bulletIV);

            //        }
            //    }
            //}
        }

        private void PauseGame()
        {
            if (game != null && game.space != null)
            {
                if (timerGame.Enabled)
                {
                    //timer
                    timerGame.Enabled = false;
                    timerMoveInvaders.Enabled = false;
                    timerInvadersBulletShoot.Enabled = false;
                    //sound
                    stage1.controls.pause();
                    GamePauseIn.URL = "GamePauseIn.wav";
                    //print
                    labelGamePaused.Text = "Pause";
                    labelGamePaused.Visible = true;
                }
                else
                {
                    //timer
                    timerGame.Enabled = true;
                    timerInvadersBulletShoot.Enabled = true;
                    timerMoveInvaders.Enabled = true;
                    //sound
                    GamePauseIn.URL = "GamePauseIn.wav";
                    stage1.controls.play();
                    //print
                    labelGamePaused.Visible = false;
                }
            }
        }

        private void CountdownStart()
        {
            labelCountDown.Text = count.ToString();
            if (count == 0)
            {
                labelCountDown.Text = "Ready";
                timerGameCountdown.Enabled = false;
                labelCountDown.Visible = false;
                count = 4;
            }
            count--;
        }
        
        private void Server_ClientAccepted(object sender, Socket e)
        {
            client = new Client(e);
            client.ReceivedData += Client_ReceivedData;
            client.SentData += Client_SentData;
        }

        private void Client_SentData(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
        }

        private void Client_ReceivedData(object sender, EventArgs e)
        { //Données recues du serveur
            
            Client c = (Client)sender;

            if (label1.InvokeRequired)
                label1.Invoke(new Action(() =>
                {
                    label1.BackColor = Color.Blue;
                    label1.Text = c.DataReceived.Message;
                }));
              
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            // -- Fermer l'application en cours d'execution -- //
            //Application.Exit();
            Program.formMain.Show();

            // -- Reset mon formulaire -- //
            est_serveur = null;
        }
        #endregion
    }
}