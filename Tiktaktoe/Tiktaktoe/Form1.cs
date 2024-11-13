using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tiktaktoe
{
    public partial class frmGame : Form
    {
        public frmGame()
        {
            InitializeComponent();
            Yenile();
        }
        private void frmGame_Load(object sender, EventArgs e)
        {
            Yenile();
        }  
        public enum Oyuncular
        {
            X, O
        }
        Oyuncular oyuncuX;
        int oyuncu = 0;
        int bilgisayar = 0;
        Random random = new Random();
        List<Button> butonlar;

        private void PlayerTime(object sender, EventArgs e)
        {
            if (butonlar.Count > 0)
            {
                int index = random.Next(butonlar.Count);
                butonlar[index].Enabled = false;
                oyuncuX = Oyuncular.O;
                butonlar[index].Text = oyuncuX.ToString();
                butonlar[index].BackColor = Color.Blue;
                butonlar.RemoveAt(index);
                tmrCpu.Stop();
            }
        }

        private void YenileButon(object sender, EventArgs e)
        {
            Yenile();
        }

        private void OyuncuTikla(object sender, EventArgs e)
        {
            var button = (Button)sender;
            oyuncuX = Oyuncular.X;
            button.Text = oyuncuX.ToString();
            button.Enabled = false;
            button.BackColor = Color.Red;
            butonlar.Remove(button);
            tmrCpu.Start();

        }
        private void Yenile()
        {
            butonlar = new List<Button>()
            {
                button1,button2, button3, button4, button5, button6,button7,button8,button9
            };
            foreach (Button b in butonlar)
            {
                b.Enabled = true;
                b.Text = "?";
                b.BackColor = DefaultBackColor;
            }

        }
        private void oyunKontrol()
        {
              if(button1.Text == "X" && button2.Text == "X" && button3.Text == "X"
                || button4.Text == "X" && button5.Text == "X" && button6.Text == "X"
                || button7.Text == "X" && button8.Text == "X" && button9.Text == "X"
                || button1.Text == "X" && button4.Text == "X" && button7.Text == "X"
                || button2.Text == "X" && button5.Text == "X" && button8.Text == "X"
                || button3.Text == "X" && button6.Text == "X" && button9.Text == "X"
                || button1.Text == "X" && button5.Text == "X" && button9.Text == "X"
                || button3.Text == "X" && button5.Text == "X" && button7.Text == "X")
            {
                tmrCpu.Stop();
                MessageBox.Show("kazanan oyuncu");
                oyuncu++;
                lblUser.Text = oyuncu.ToString();
                Yenile();
            }
            else if (button1.Text == "O" && button2.Text == "O" && button3.Text == "O"
                || button4.Text == "O" && button5.Text == "O" && button6.Text == "O"
                || button7.Text == "O" && button8.Text == "O" && button9.Text == "O"
                || button1.Text == "O" && button4.Text == "O" && button7.Text == "O"
                || button2.Text == "O" && button5.Text == "O" && button8.Text == "O"
                || button3.Text == "O" && button6.Text == "O" && button9.Text == "O"
                || button1.Text == "O" && button5.Text == "O" && button9.Text == "O"
                || button3.Text == "O" && button5.Text == "O" && button7.Text == "O")
            {
                tmrCpu.Stop();
                MessageBox.Show("cpu kazandı");
                bilgisayar++;
                lblPc.Text= bilgisayar.ToString();
                Yenile();
            }
        }
    }
}
