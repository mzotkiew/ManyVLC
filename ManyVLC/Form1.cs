using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibVLCSharp.Shared;
using LibVLCSharp.WinForms;

namespace ManyVLC
{
    public partial class Form1 : Form
    {
        LibVLC libVLC;
        public Form1()
        {
            InitializeComponent();
            Core.Initialize();
            libVLC = new LibVLC();
        }

        private void videoView_Click(object sender, EventArgs e)
        {
            if (((VideoView)sender).MediaPlayer == null)
            {
                ((VideoView)sender).MediaPlayer = new MediaPlayer(libVLC);
                ((VideoView)sender).MediaPlayer.EnableMouseInput = false;
                ((VideoView)sender).MediaPlayer.EnableKeyInput = false;
                ((VideoView)sender).MediaPlayer.Play(new Media(libVLC, @"../../video.avi", FromType.FromPath));
            }
            else
            {
                ((VideoView)sender).MediaPlayer.Stop();
                ((VideoView)sender).MediaPlayer = null;
            }
        }
    }
}
