using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace LoWLancher
{
    public partial class Form1 : Form
    {

        /*//CURRENT VERSION NUMBER CONSTANT
        string game_version_ID = "Alpha 0.7";
        string launcher_version_ID = "1";

        //WEB URLS CONSTANT
        string game_version_ID_URL = "https://dl.dropboxusercontent.com/u/97492438/Versions/gameversion.txt";
        string game_update_URL = "https://dl.dropboxusercontent.com/u/97492438/Versions/Data.zip";
        string launcher_version_ID_URL = "https://dl.dropboxusercontent.com/u/97492438/Versions/launcherversion.txt";*/

        //Audio stuff
        System.Media.SoundPlayer player = new System.Media.SoundPlayer();
        bool is_muted = false;

        public Form1()
        {
            InitializeComponent();

            player.SoundLocation = "Music\\bg_music.wav";
            player.PlayLooping();

        }

        /*//Installs game if not installed already
        private void CheckToInstall()
        {
            if (!Directory.Exists("C:\\LoWOrigins"))
            {
                MessageBox.Show("Installing game.");
                Directory.CreateDirectory("C:\\LoWOrigins");
                CheckForUpdates();
                MessageBox.Show("Game installed. Press launch button again to play.");

            }
            else MessageBox.Show("Directory already exists! Is game.exe in wrong directory?");

        }

        //Updates game if not at most recent update
        private void CheckForUpdates()
        {
            if (game_version_ID != new WebClient().DownloadString(game_version_ID_URL))
            {
                MessageBox.Show("Game version out of date. Press OK to download latest update.");
                System.Diagnostics.Process.Start(game_update_URL);

            }

            if (launcher_version_ID != new WebClient().DownloadString(launcher_version_ID_URL))
            {
                MessageBox.Show("Launcher version out of date. Press OK to download latest update.");

            }

        }*/

        private void LaunchButton_Click(object sender, EventArgs e)
        {
            //Trys if game.exe is in right directory, else catch
            try
            {
                //CheckForUpdates();

                Process.Start("game.exe");
                Environment.Exit(0);

            }
            catch
            {
                MessageBox.Show("Please put game.exe in same directory with launcher.");
                //CheckToInstall();

            }

        }

        private void MuteButton_Click(object sender, EventArgs e)
        {
            if (!is_muted)
            {
                //Visuals
                MuteButton.Text = "Play";
                MuteButton.BackColor = Color.FromArgb(0, 192, 0);
                MuteButton.FlatAppearance.BorderColor = Color.Green;
                MuteButton.FlatAppearance.MouseDownBackColor = Color.Green;

                //Code
                player.Stop();
                is_muted = true;

            }
            else
            {
                //Visuals
                MuteButton.Text = "Mute";
                MuteButton.BackColor = Color.FromArgb(192, 0, 0);
                MuteButton.FlatAppearance.BorderColor = Color.Maroon;
                MuteButton.FlatAppearance.MouseDownBackColor = Color.Maroon;

                //Code
                player.PlayLooping();
                is_muted = false;

            }

        }

    }

}
