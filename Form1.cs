using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
namespace black_jack
{
    public partial class frm_BJ : Form
    {
        PictureBox [] pic_card = new PictureBox[10];
        int ind=0;
        Cards card = new Cards();
        Game game = new Game();
        DialogResult ans;
        int sash=105;
        bool flag = true;

        public frm_BJ()
        {
            InitializeComponent();
            

        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            try
            {
                int num;
                if (game._Name == null)
                    MessageBox.Show("ENTER NAME", "M-Bjack", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                    if (game._Bet == 0)
                        MessageBox.Show("NEED BET", "M-Bjack", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else
                        if (flag == true)
                        {


                            num = card.Human();
                            pic_card[ind] = new PictureBox();
                            pic_card[ind].Image = Image.FromFile("img\\" + num.ToString() + ".jpg");
                            pic_card[ind].Top = pictureBox1.Top;
                            pic_card[ind].Left = pictureBox1.Left + sash;
                            pic_card[ind].Height = 150;
                            pic_card[ind].Width = 100;
                            pic_card[ind].SizeMode = PictureBoxSizeMode.StretchImage;
                            this.Controls.Add(pic_card[ind]);

                            game.Human(num);

                            lbl_HScore.Text = "You     " + game._HumanScore.ToString();

                            if (game._HumanScore == 21)
                            {
                                game._Money += game._Bet;
                                lbl_Money.Text = game._Money.ToString();
                                ans = MessageBox.Show("YOU WON \n NEW GAME ?", "M-Bjack", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                flag = false;
                            }
                            else if (game._HumanScore > 21)
                            {
                                game._Money -= game._Bet;
                                lbl_Money.Text = game._Money.ToString();
                                ans = MessageBox.Show("YOU LOST \n NEW GAME ?", "M-Bjack", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                flag = false;
                            }

                            sash += 105;
                            ind++;
                        }

                if (ans == DialogResult.Yes)
                {
                    ans = DialogResult.Cancel;
                    NewGame();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "M-Bjack", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
       }

        private void cmb_Stand_Click(object sender, EventArgs e)
        {
            try
            {
                int win;
                sash = 105;

                if (game._Name == null)
                    MessageBox.Show("ENTER NAME", "M-Bjack", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                    if (game._Bet == 0)
                        MessageBox.Show("NEED BET", "M-Bjack", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else
                        if (flag == true)
                        {
                            int num;
                            do
                            {
                                num = card.Comp();
                                pic_card[ind] = new PictureBox();
                                pic_card[ind].Image = Image.FromFile("img\\" + num.ToString() + ".jpg");
                                pic_card[ind].Top = pictureBox1.Top + 200;
                                pic_card[ind].Left = pictureBox1.Left + sash;
                                pic_card[ind].Height = 150;
                                pic_card[ind].Width = 100;
                                pic_card[ind].SizeMode = PictureBoxSizeMode.StretchImage;
                                this.Controls.Add(pic_card[ind]);

                                game.Comp(num);
                                lbl_CScore.Text = "Comp  " + game._CompScore.ToString();
                                sash += 105;
                                ind++;
                            } while (game.AI() == true);

                            win = game.Winner();
                            if (game._Money < 0)
                            {
                                MessageBox.Show("YOU LOSE", "M-Bjack", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                this.Close();
                            }
                            lbl_Money.Text = game._Money.ToString();

                            if (win == 1)
                                ans = MessageBox.Show("YOU WON\n NEW GAME ?", "M-Bjack", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            else if (win == 2)
                                ans = MessageBox.Show("TIE\n NEW GAME ?", "M-Bjack", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            else
                                ans = MessageBox.Show("YOU LOST\n NEW GAME ?", "M-Bjack", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        }
                if (ans == DialogResult.Yes)
                {
                    ans = DialogResult.Cancel;
                    NewGame();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "M-Bjack", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        void NewGame()
        {
            Cards card = new Cards();
            for (ind--; ind >= 0; ind--)
                this.Controls.Remove(pic_card[ind]);

            sash = 105;
            game._CompScore = 0;
            game._HumanScore = 0;
            flag = true;
            ind = 0;
            game._Bet = 0;
            lbl_Bet.Text = "0";
            lbl_CScore.Text = "Comp";
            lbl_HScore.Text = "You";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NewGame();
        }

        private void cmb_ok_name_Click(object sender, EventArgs e)
        {
            try
            {
                game._Name = txt_name.Text;
                game._Money = 200;
                this.Controls.Remove(label1);
                this.Controls.Remove(txt_name);
                this.Controls.Remove(cmb_ok_name);
                this.Text += " " + game._Name;
                lbl_Money.Text = game._Money.ToString();
                lbl_Bet.Text = "0";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "M-Bjack", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void cmb_BetPlus_Click(object sender, EventArgs e)
        {
            try
            {
                game._Bet += 10;
                if (game._Bet > game._Money)
                {
                    MessageBox.Show("YOU NOT HAVE ENOUGTH MONEY", "M-Bjack", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    game._Bet = 0;
                }

                lbl_Bet.Text = game._Bet.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "M-Bjack", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void cmb_BetMinus_Click(object sender, EventArgs e)
        {
            try
            {
                if (game._Bet == 0)
                {
                    MessageBox.Show("THE BET ... CAN'T BE <0", "M-Bjack", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    game._Bet = 0;
                }
                game._Bet -= 10;

                lbl_Bet.Text = game._Bet.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "M-Bjack", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void cmb_BetMax_Click(object sender, EventArgs e)
        {
            try
            {
                game._Bet = 50;
                if (game._Bet > game._Money)
                {
                    MessageBox.Show("YOU NOT HAVE ENOUGTH MONEY", "M-Bjack", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    game._Bet = 0;
                }
                lbl_Bet.Text = game._Bet.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "M-Bjack", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                FileStream fs = new FileStream(game._Name + ".sav", FileMode.Create);
                StreamWriter sw = new StreamWriter(fs);
                sw.WriteLine(game._Name);
                sw.WriteLine(game._Money.ToString());
                sw.Close();
                fs.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "M-Bjack", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string name;
                OFD.Filter = "game saves|*.sav";
                OFD.Title = "Choose your save file";
                OFD.FilterIndex = 0;
                if (OFD.ShowDialog() == DialogResult.OK)
                {
                    name = OFD.FileName;
                    StreamReader sr = new StreamReader(name);
                    game._Name = sr.ReadLine();
                    game._Money = int.Parse(sr.ReadLine());

                    this.Controls.Remove(label1);
                    this.Controls.Remove(txt_name);
                    this.Controls.Remove(cmb_ok_name);
                    this.Text += " " + game._Name;
                    lbl_Money.Text = game._Money.ToString();
                    lbl_Bet.Text = "0";

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "M-Bjack", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "M-Bjack", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void frm_BJ_Load(object sender, EventArgs e)
        {

        }

        private void lbl_HScore_Click(object sender, EventArgs e)
        {

        }
    }
}