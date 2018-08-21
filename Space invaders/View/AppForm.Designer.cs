namespace Space_invaders.View
{
    partial class AppForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AppForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutUsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timerGame = new System.Windows.Forms.Timer(this.components);
            this.labelScore = new System.Windows.Forms.Label();
            this.timerStartMenu = new System.Windows.Forms.Timer(this.components);
            this.labelCountDown = new System.Windows.Forms.Label();
            this.timerGameCountdown = new System.Windows.Forms.Timer(this.components);
            this.labelGamePaused = new System.Windows.Forms.Label();
            this.timerMoveInvaders = new System.Windows.Forms.Timer(this.components);
            this.timerInvadersBulletShoot = new System.Windows.Forms.Timer(this.components);
            this.pictureBoxPressStart = new System.Windows.Forms.PictureBox();
            this.pictureBoxCopyright = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPressStart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCopyright)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1184, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newGameToolStripMenuItem,
            this.toolStripSeparator1,
            this.quitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newGameToolStripMenuItem
            // 
            this.newGameToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("newGameToolStripMenuItem.Image")));
            this.newGameToolStripMenuItem.Name = "newGameToolStripMenuItem";
            this.newGameToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.newGameToolStripMenuItem.Text = "New Game";
            this.newGameToolStripMenuItem.ToolTipText = "Start a new game";
            this.newGameToolStripMenuItem.Click += new System.EventHandler(this.newGameToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(129, 6);
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Image = global::Space_invaders.Properties.Resources.close;
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.quitToolStripMenuItem.Text = "Quit";
            this.quitToolStripMenuItem.ToolTipText = "Exit Space Invaders";
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutUsToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(42, 20);
            this.helpToolStripMenuItem.Text = "help";
            // 
            // aboutUsToolStripMenuItem
            // 
            this.aboutUsToolStripMenuItem.Name = "aboutUsToolStripMenuItem";
            this.aboutUsToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.aboutUsToolStripMenuItem.Text = "About us";
            this.aboutUsToolStripMenuItem.Click += new System.EventHandler(this.aboutUsToolStripMenuItem_Click);
            // 
            // timerGame
            // 
            this.timerGame.Interval = 10;
            this.timerGame.Tick += new System.EventHandler(this.timerGame_Tick);
            // 
            // labelScore
            // 
            this.labelScore.AutoSize = true;
            this.labelScore.BackColor = System.Drawing.Color.Transparent;
            this.labelScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelScore.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelScore.Location = new System.Drawing.Point(3, 24);
            this.labelScore.Name = "labelScore";
            this.labelScore.Size = new System.Drawing.Size(167, 33);
            this.labelScore.TabIndex = 4;
            this.labelScore.Text = "SCORE : 0";
            // 
            // timerStartMenu
            // 
            this.timerStartMenu.Interval = 850;
            this.timerStartMenu.Tick += new System.EventHandler(this.timerStartMenu_Tick);
            // 
            // labelCountDown
            // 
            this.labelCountDown.BackColor = System.Drawing.Color.Transparent;
            this.labelCountDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 249.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCountDown.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelCountDown.Location = new System.Drawing.Point(0, 24);
            this.labelCountDown.Name = "labelCountDown";
            this.labelCountDown.Size = new System.Drawing.Size(84, 7);
            this.labelCountDown.TabIndex = 5;
            this.labelCountDown.Text = " ";
            this.labelCountDown.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelCountDown.Visible = false;
            // 
            // timerGameCountdown
            // 
            this.timerGameCountdown.Interval = 800;
            this.timerGameCountdown.Tick += new System.EventHandler(this.timerGameCountdown_Tick);
            // 
            // labelGamePaused
            // 
            this.labelGamePaused.BackColor = System.Drawing.Color.Transparent;
            this.labelGamePaused.Font = new System.Drawing.Font("Microsoft Sans Serif", 249.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGamePaused.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.labelGamePaused.Location = new System.Drawing.Point(0, 24);
            this.labelGamePaused.Name = "labelGamePaused";
            this.labelGamePaused.Size = new System.Drawing.Size(84, 7);
            this.labelGamePaused.TabIndex = 6;
            this.labelGamePaused.Text = " Pause";
            this.labelGamePaused.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelGamePaused.Visible = false;
            // 
            // timerMoveInvaders
            // 
            this.timerMoveInvaders.Tick += new System.EventHandler(this.timerMoveInvaders_Tick);
            // 
            // timerInvadersBulletShoot
            // 
            this.timerInvadersBulletShoot.Interval = 3000;
            this.timerInvadersBulletShoot.Tick += new System.EventHandler(this.timerInvadersBulletShoot_Tick);
            // 
            // pictureBoxPressStart
            // 
            this.pictureBoxPressStart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxPressStart.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxPressStart.Image")));
            this.pictureBoxPressStart.Location = new System.Drawing.Point(423, 432);
            this.pictureBoxPressStart.Name = "pictureBoxPressStart";
            this.pictureBoxPressStart.Size = new System.Drawing.Size(318, 50);
            this.pictureBoxPressStart.TabIndex = 2;
            this.pictureBoxPressStart.TabStop = false;
            // 
            // pictureBoxCopyright
            // 
            this.pictureBoxCopyright.Image = global::Space_invaders.Properties.Resources.copy;
            this.pictureBoxCopyright.Location = new System.Drawing.Point(649, 658);
            this.pictureBoxCopyright.Name = "pictureBoxCopyright";
            this.pictureBoxCopyright.Size = new System.Drawing.Size(524, 50);
            this.pictureBoxCopyright.TabIndex = 1;
            this.pictureBoxCopyright.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(12, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "label1";
            // 
            // AppForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(1184, 711);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelGamePaused);
            this.Controls.Add(this.labelCountDown);
            this.Controls.Add(this.labelScore);
            this.Controls.Add(this.pictureBoxPressStart);
            this.Controls.Add(this.pictureBoxCopyright);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "AppForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = ".::: Space invaders :::.";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseClick);
            //this.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDoubleClick);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPressStart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCopyright)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutUsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.Timer timerGame;
        private System.Windows.Forms.PictureBox pictureBoxCopyright;
        private System.Windows.Forms.PictureBox pictureBoxPressStart;
        private System.Windows.Forms.Label labelScore;
        private System.Windows.Forms.Timer timerStartMenu;
        private System.Windows.Forms.Label labelCountDown;
        private System.Windows.Forms.Timer timerGameCountdown;
        private System.Windows.Forms.Label labelGamePaused;
        private System.Windows.Forms.Timer timerMoveInvaders;
        private System.Windows.Forms.Timer timerInvadersBulletShoot;
        private System.Windows.Forms.Label label1;
    }
}

