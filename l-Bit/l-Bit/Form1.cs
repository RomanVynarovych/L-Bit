using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Un4seen.Bass;


namespace l_Bit
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            pictureBox1.Image = Image.FromFile(@".\images.jpg");
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {

        }

        private void bunifuImageButton5_Click(object sender, EventArgs e)
        {
            PlayAnimation.ShowSync(List);
            SetAnimation.Hide(Settings);
            HAnimator.Hide(HP);
            BAnimator.ShowSync(PList);
            
        }

        private void MnuBtn_Click(object sender, EventArgs e)
        {
            if (MnuPanel.Width == 225)
            {
                BAnimator.Hide(PList);
                MnuPanel.Visible = false;
                MnuPanel.Width = 45;
                MnuAnimator.ShowSync(MnuPanel);
                PlayAnimation.Hide(List);
                HAnimator.Hide(HP);
                SetAnimation.Hide(Settings);
            }
            else
            {
                HAnimator.Hide(HP);
                PlayAnimation.Hide(List);
                MnuPanel.Visible = false;
                MnuPanel.Width = 225;
                MnuAnimator.ShowSync(MnuPanel);
                BAnimator.ShowSync(PList);
                
            }
        }

        private void Panel_Paint(object sender, PaintEventArgs e)
        {
            
        
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            f.ShowDialog();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Sttngs_Click(object sender, EventArgs e)
        {
            PlayAnimation.Hide(List);
            SetAnimation.ShowSync(Settings);
            HAnimator.Hide(HP);
            BAnimator.ShowSync(PList);
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Help_Click(object sender, EventArgs e)
        {
            BAnimator.ShowSync(PList);
            SetAnimation.Hide(Settings);
            PlayAnimation.Hide(List);
            HAnimator.ShowSync(HP);

        }

        private void bunifuCustomLabel2_Click(object sender, EventArgs e)
        {

        }

        private void bunifuSlider1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void bunifuProgressBar1_progressChanged(object sender, EventArgs e)
        {

        }

        private void bunifuImageButton9_Click(object sender, EventArgs e)
        {
           openFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            Vars.Files.Add(openFileDialog1.FileName);
            PlayList.Items.Add(Vars.GetFileName(openFileDialog1.FileName));
        }

        private void Settings_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuImageButton3_Click(object sender, EventArgs e)
        {
            if((PlayList.Items.Count != 0) && (PlayList.SelectedIndex != -1))
            {
                string current = Vars.Files[PlayList.SelectedIndex];
                Vars.CurrentTrackNumber = PlayList.SelectedIndex;
                bassbit.Play(current, bassbit.Volume);
                Label2.Text = TimeSpan.FromSeconds(bassbit.GetPosOfStream(bassbit.Stream)).ToString();
                Label3.Text = TimeSpan.FromSeconds(bassbit.GetTimeOfStream(bassbit.Stream)).ToString();
                Slider1.MaximumValue = bassbit.GetTimeOfStream(bassbit.Stream);
                Slider1.Value = bassbit.GetPosOfStream(bassbit.Stream);
                timer1.Enabled = true;
                TagLib.File tagFile = TagLib.File.Create(@Vars.Files[PlayList.SelectedIndex]);
                if (tagFile.Tag.Pictures.Length >= 1)
                {
                    var bin = (byte[])(tagFile.Tag.Pictures[0].Data.Data);
                    pictureBox1.Image = Image.FromStream(new System.IO.MemoryStream(bin));
                }
                else
                {
                    pictureBox1.Image = Image.FromFile(@"E:\3 курс\Бокла\Player\l-Bit\l-Bit\images.jpg");
                }
            }

            

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Label2.Text = TimeSpan.FromSeconds(bassbit.GetPosOfStream(bassbit.Stream)).ToString();
            Slider1.Value = bassbit.GetPosOfStream(bassbit.Stream);

            if (bassbit.ToNextTrack())
            {
                PlayList.SelectedIndex = Vars.CurrentTrackNumber;
                Label2.Text = TimeSpan.FromSeconds(bassbit.GetPosOfStream(bassbit.Stream)).ToString();
                Label3.Text = TimeSpan.FromSeconds(bassbit.GetTimeOfStream(bassbit.Stream)).ToString();
                Slider1.MaximumValue = bassbit.GetTimeOfStream(bassbit.Stream);
                Slider1.Value = bassbit.GetPosOfStream(bassbit.Stream);
                TagLib.File tagFile = TagLib.File.Create(@Vars.Files[PlayList.SelectedIndex]);
                if (tagFile.Tag.Pictures.Length >= 1)
                {
                    var bin = (byte[])(tagFile.Tag.Pictures[0].Data.Data);
                    pictureBox1.Image = Image.FromStream(new System.IO.MemoryStream(bin));
                }
                else
                {
                    pictureBox1.Image = Image.FromFile(@"E:\3 курс\Бокла\Player\l-Bit\l-Bit\images.jpg");
                }
            }

            if (bassbit.EndPlayList)
            {
                bunifuImageButton10_Click(this, new EventArgs());
                PlayList.SelectedIndex = Vars.CurrentTrackNumber = 0;
                bassbit.EndPlayList = false;    
            }

        }

        private void bunifuImageButton10_Click(object sender, EventArgs e)
        {
            bassbit.Stop();
            timer1.Enabled = false;
            Slider1.Value = 0;
            Label2.Text = "00:00:00";
        }

        private void Slider1_ValueChanged(object sender, EventArgs e)
        {
            bassbit.SetPosOfScroll(bassbit.Stream, Slider1.Value);
        }

        private void bunifuSlider2_ValueChanged(object sender, EventArgs e)
        {
            bassbit.SetVolumeToString(bassbit.Stream, Vol.Value);
        }

        private void Label3_Click(object sender, EventArgs e)
        {

        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void bunifuImageButton8_Click(object sender, EventArgs e)
        {
            Vol.Value += 2;
            bassbit.SetVolumeToString(bassbit.Stream, Vol.Value);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuCustomLabel1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuImageButton7_Click(object sender, EventArgs e)
        {
            Vol.Value -= 2;
            bassbit.SetVolumeToString(bassbit.Stream, Vol.Value);
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void bunifuCheckbox1_OnChange(object sender, EventArgs e)
        {
            if (bunifuCheckbox1.Checked)
            {
                Vol.Value = 30;
                bassbit.SetVolumeToString(bassbit.Stream, Vol.Value);
            }
            else
            {
                Vol.Value = 80;
                bassbit.SetVolumeToString(bassbit.Stream, Vol.Value);
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            PlayList.Items.Clear();
        }

       

        private void button1_Click(object sender, EventArgs e)
        {
            PlayList.Items.Clear();
            Form3 f = new Form3();
            f.Show();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int time = Int32.Parse(textBox2.Text);
            time = time * 1000;
            timer2.Interval = time;
            timer2.Enabled = true;
        }

        private void bunifuImageButton11_Click(object sender, EventArgs e)
        {
            bassbit.Pause();
        }

        private void bunifuImageButton5_Click_1(object sender, EventArgs e)
        {
            if ((PlayList.SelectedIndex - 1) >= 0)
            {
                PlayList.SelectedIndex = PlayList.SelectedIndex - 1;
                string current = Vars.Files[PlayList.SelectedIndex];
                bassbit.Play(current, bassbit.Volume);
                TagLib.File tagFile = TagLib.File.Create(@Vars.Files[PlayList.SelectedIndex]);
                if (tagFile.Tag.Pictures.Length >= 1)
                {
                    var bin = (byte[])(tagFile.Tag.Pictures[0].Data.Data);
                    pictureBox1.Image = Image.FromStream(new System.IO.MemoryStream(bin));
                }
                else
                {
                    pictureBox1.Image = Image.FromFile(@"E:\3 курс\Бокла\Player\l-Bit\l-Bit\images.jpg");
                }
            }
        }

        private void bunifuImageButton6_Click(object sender, EventArgs e)
        {
            PlayList.SelectedIndex = PlayList.SelectedIndex + 1;
            string current = Vars.Files[PlayList.SelectedIndex];
            bassbit.Play(current, bassbit.Volume);
            TagLib.File tagFile = TagLib.File.Create(@Vars.Files[PlayList.SelectedIndex]);
            if (tagFile.Tag.Pictures.Length >= 1)
            {
                var bin = (byte[])(tagFile.Tag.Pictures[0].Data.Data);
                pictureBox1.Image = Image.FromStream(new System.IO.MemoryStream(bin));
            }
            else
            {
                pictureBox1.Image = Image.FromFile(@"E:\3 курс\Бокла\Player\l-Bit\l-Bit\images.jpg");
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
