using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XOvsCPU
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public int mode = 0; //0: vs CPU ; 1: 2 players

        public int first = 2;
        public string pl1 = "O";
        public string pl2 = "X";

        public int sm = 0; //score me
        public int sd = 0; //score draw
        public int sc = 0; //score cpu

        public int turns = 0;

        public bool onturn = true; //true- my turn, false- cpu turn

        private void buttonE_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonClick(object sender, EventArgs e)
        {
            radioButton1.Enabled = radioButton2.Enabled = false;

            Button button = (Button)sender;

            if (mode == 0) // vs CPU
            {

                if (radioButton4.Checked)
                {

                    if (button.Text == "")
                    {
                        if (onturn == true)
                            button.Text = "X";
                        else
                            button.Text = "O";
                        turns++;
                        onturn = !onturn;
                    }
                    if (CheckWinner() == true)
                    {
                        if (onturn == false)
                        {
                            sm++;
                            if (sm < 5)
                            {
                                MessageBox.Show("You got a point!");
                                NewGame(mode, 1);
                            }
                            else
                            {
                                MessageBox.Show("Congratulations!\nYou Win! ");
                                buttonR.PerformClick();
                            }
                        }
                        else
                        {
                            sc++;
                            if (sc < 5)
                            {
                                MessageBox.Show("CPU got a point!");
                                NewGame(mode, 1);
                            }
                            else
                            {
                                MessageBox.Show("CPU Wins! :(");
                                buttonR.PerformClick();
                            }
                        }
                    }
                    if (CheckDraw() == true && CheckWinner() == false)
                    {
                        sd++;
                        if (sd < 10)
                        {
                            MessageBox.Show("It's a draw!");
                            NewGame(mode, 1);
                        }
                        else
                        {
                            MessageBox.Show("There is no winner! Try again! :)");
                            buttonR.PerformClick();
                        }
                        
                    }

                    if (onturn == false)
                    {
                        CPU().PerformClick();
                    }
                }
                else if (radioButton5.Checked)
                {
                    if (button.Text == "")
                    {
                        if (onturn == true)
                            button.Text = "O";
                        else
                            button.Text = "X";
                        turns++;
                        onturn = !onturn;
                    }
                    if (CheckWinner() == true)
                    {
                        if (onturn == false)
                        {
                            sm++;
                            if (sm < 5)
                            {
                                MessageBox.Show("You got a point!");
                                NewGame(mode, 1);
                            }
                            else
                            {
                                MessageBox.Show("Congratulations!\nYou Win! ");
                                buttonR.PerformClick();
                            }
                        }
                        else
                        {
                            sc++;
                            if (sc < 5)
                            {
                                MessageBox.Show("CPU got a point!");
                                NewGame(mode, 1);
                            }
                            else
                            {
                                MessageBox.Show("CPU Wins! :(");
                                buttonR.PerformClick();
                            }
                        }
                    }
                    if (CheckDraw() == true && CheckWinner() == false)
                    {
                        sd++;
                        if (sd < 10)
                        {
                            MessageBox.Show("It's a draw!");
                            NewGame(mode, 1);
                        }
                        else
                        {
                            MessageBox.Show("There is no winner! Try again! :)");
                            buttonR.PerformClick();
                        }
                    }

                    if (onturn == false && turns != 1)
                    {
                        CPU().PerformClick();
                    }

                }
            }
            else //mode=1 (2 players)
            {
                if (button.Text == "")
                {
                    if (turns % 2 == 0)
                    {
                        button.Text = "X";
                        turns++;
                    }
                    else
                    {
                        button.Text = "O";
                        turns++;
                    }
                    if (CheckDraw() == true)
                    {
                        MessageBox.Show("Tie game!");
                        sd++;
                        NewGame(mode,1);
                    }
                    if (CheckWinner() == true)
                    {
                        if ((button.Text == "X" && first==1) || (button.Text=="O" && first==2))
                        {
                            sm++;
                            if (sm < 5)
                            {
                                MessageBox.Show("Player 1 got a point!");
                                NewGame(mode, 1);
                            }
                            else
                            {
                                MessageBox.Show("Congratulations!\nPlayer 1 Win!");
                                buttonR.PerformClick();
                            }
                          
                        }
                        else
                        {
                            sc++;
                            if (sc < 5)
                            {
                                MessageBox.Show("Player 2 got a point!");
                                NewGame(mode, 1);
                            }
                            else
                            {
                                MessageBox.Show("Congratulations!\nPlayer 2 Win!");
                                buttonR.PerformClick();
                            }
                        }
                    }
                }
            }
        }

        public void NewGame(int m, int n)
        {
            if (m == 0)
            {
                A00.Text = A01.Text = A02.Text = A10.Text = A11.Text = A12.Text = A20.Text = A21.Text = A22.Text = "";
                turns = 0;
                //radioButton1.Enabled = radioButton2.Enabled = true;
                MeWin.Text = "Me: " + sm;
                Draws.Text = "Draws: " + sd;
                CPUWin.Text = "CPU: " + sc;

                if (sm == 0 && sd == 0 && sc == 0)
                {
                    radioButton2.Checked = radioButton1.Checked = false;
                    radioButton1.Enabled = radioButton2.Enabled = true;

                    A00.Enabled = A01.Enabled = A02.Enabled = A10.Enabled = A11.Enabled = A12.Enabled = A20.Enabled = A21.Enabled = A22.Enabled = false;
                }

                if (n == 1)
                { //zavrsila se prethodna, promena znaka
                    if (radioButton4.Checked) //bio sam X, u novoj sam O
                    {
                        onturn = false;
                        radioButton5.Checked = true;
                        CPU().PerformClick();
                    }
                    else //u novoj sam X
                    {
                        onturn = true;
                        radioButton4.Checked = true;
                    }
                }
                else
                { //prekinuta je prethodna, nema promene znaka
                    if (radioButton4.Checked) //ja sam X
                    {
                        onturn = true;
                    }
                    else //ja sam O
                    {
                        onturn = false;
                        CPU().PerformClick();
                    }

                }
            }
            else
            {
                if (first == 1) //prvi je bio Player 1
                {
                    first = 2; //sad je prvi Player 2
                }
                else //prvi je bio Player 2
                {
                    first = 1; //sad je prvi Player 1
                }
                turns = 0;

                A00.Text = A01.Text = A02.Text = A10.Text = A11.Text = A12.Text = A20.Text = A21.Text = A22.Text = "";
                //update labels each time new game starts
                MeWin.Text = "Player 1: " + sm;
                CPUWin.Text = "Player 2: " + sc;
                Draws.Text = "Draws: " + sd;

                if (pl1 == "X")
                {
                    pl1 = "O";
                    pl2 = "X";
                }
                else
                {
                    pl2 = "O";
                    pl1 = "X";
                }

                labelPl1.Text = "Player1 :  " + pl1;
                labelPl2.Text = "Player2 :  " + pl2;

            }



        }

        bool CheckDraw()
        {
            if (turns == 9 && CheckWinner() == false)
                return true;
            else
                return false;
        }

        bool CheckWinner()
        {
            //horizontal checks
            if (A00.Text == A01.Text && A01.Text == A02.Text && A00.Text != "")
                return true;
            else if (A10.Text == A11.Text && A11.Text == A12.Text && A10.Text != "")
                return true;
            else if (A20.Text == A21.Text && A21.Text == A22.Text && A20.Text != "")
                return true;

            //vertical checks
            if (A00.Text == A10.Text && A10.Text == A20.Text && A00.Text != "")
                return true;
            else if (A01.Text == A11.Text && A11.Text == A21.Text && A01.Text != "")
                return true;
            else if (A02.Text == A12.Text && A12.Text == A22.Text && A02.Text != "")
                return true;

            //diagonal checks
            if (A00.Text == A11.Text && A11.Text == A22.Text && A00.Text != "")
                return true;
            else if (A20.Text == A11.Text && A11.Text == A02.Text && A20.Text != "")
                return true;

            return false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            A00.Enabled = A01.Enabled = A02.Enabled = A10.Enabled = A11.Enabled = A12.Enabled = A20.Enabled = A21.Enabled = A22.Enabled = false;
            MeWin.Text = "Me: " + sm;
            Draws.Text = "Draws: " + sd;
            CPUWin.Text = "CPU: " + sc;

            radioButton5.Enabled = radioButton4.Enabled = false;

            groupBox4.Visible = false;
        }

        private void buttonR_Click(object sender, EventArgs e)
        {
            sm= sc = sd = 0;
            radioButton5.Checked = true;
            if (mode == 1)
            {
                pl1 = "O"; pl2 = "X";
                first = 2;
            }
            NewGame(mode,1);
        }

        private void buttonNG_Click(object sender, EventArgs e)
        {
            NewGame(mode,0);
        }


        public Button CPU()
        {
            Button b = null;
            if (radioButton2.Checked == true) { 
                if(radioButton4.Checked==true) //ja sam X
                    b = CPUTryToWinOrDefend("O"); //branim se od O
                else //ja sam O
                    b = CPUTryToWinOrDefend("X"); //branim se od X

                if (b != null)
                    return b;
                else
                {
                    if (radioButton4.Checked == true) //ja sam X
                        b = CPUTryToWinOrDefend("X"); //napadam gde ima 2X
                    else //ja sam O
                        b = CPUTryToWinOrDefend("O"); //napadam gde ima 2O

                    if (b != null)
                        return b;
                    else
                        return CPUMoveRandom();
                }
            }
            else if (radioButton1.Checked == true)
            {
                b = CPUMoveRandom();
                //return b;
            }
            return b;
        }

        public Button CPUTryToWinOrDefend(string s)
        {

            //horizontal checks
            if (A00.Text == A01.Text && A01.Text == s && A02.Text == "")
                return A02;
            if (A02.Text == A01.Text && A01.Text == s && A00.Text == "")
                return A00;
            if (A00.Text == A02.Text && A02.Text == s && A01.Text == "")
                return A01;

            if (A10.Text == A11.Text && A11.Text == s && A12.Text == "")
                return A12;
            if (A12.Text == A11.Text && A11.Text == s && A10.Text == "")
                return A10;
            if (A10.Text == A12.Text && A12.Text == s && A11.Text == "")
                return A11;

            if (A20.Text == A21.Text && A21.Text == s && A22.Text == "")
                return A22;
            if (A22.Text == A21.Text && A21.Text == s && A20.Text == "")
                return A20;
            if (A20.Text == A22.Text && A22.Text == s && A21.Text == "")
                return A21;

            //vertical checks
            if (A00.Text == A10.Text && A10.Text == s && A20.Text == "")
                return A20;
            if (A20.Text == A10.Text && A10.Text == s && A00.Text == "")
                return A00;
            if (A00.Text == A20.Text && A20.Text == s && A10.Text == "")
                return A10;

            if (A01.Text == A11.Text && A11.Text == s && A21.Text == "")
                return A21;
            if (A21.Text == A11.Text && A11.Text == s && A01.Text == "")
                return A01;
            if (A01.Text == A21.Text && A21.Text == s && A11.Text == "")
                return A11;

            if (A02.Text == A12.Text && A12.Text == s && A22.Text == "")
                return A22;
            if (A22.Text == A12.Text && A12.Text == s && A02.Text == "")
                return A02;
            if (A02.Text == A22.Text && A22.Text == s && A12.Text == "")
                return A12;

            //diagonal checks
            if (A00.Text == A11.Text && A11.Text == s && A22.Text == "")
                return A22;
            if (A00.Text == A22.Text && A22.Text == s && A11.Text == "")
                return A11;
            if (A11.Text == A22.Text && A22.Text == s && A00.Text == "")
                return A00;

            if (A02.Text == A11.Text && A11.Text == s && A20.Text == "")
                return A20;
            if (A02.Text == A20.Text && A20.Text == s && A11.Text == "")
                return A11;
            if (A20.Text == A11.Text && A11.Text == s && A02.Text == "")
                return A02;

            return null;
        }

        public Button CPUMoveRandom()
        {
            Button b = null;
            Random r = new Random();
            int rand;

            do
            {
                int i = 0;
                rand = (int)(r.NextDouble() * 9);
                rand += 3; //rand je broj izmedju 3 i 11, to su redni brojevi buttona u nizu Controls (0,1 i 2 su NG,E i R)
                foreach (Control C in Controls)
                {                    
                    b = C as Button;
                    if (b != null)
                    {
                        if (i < rand)
                        {
                            i++;
                            continue;
                        }
                        if (b.Text == "")
                            return b;
                    }
                }

            } while (true);

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            A00.Enabled = A01.Enabled = A02.Enabled = A10.Enabled = A11.Enabled = A12.Enabled = A20.Enabled = A21.Enabled = A22.Enabled = true;
            //radioButton1.Enabled = radioButton2.Enabled = false;

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            A00.Enabled = A01.Enabled = A02.Enabled = A10.Enabled = A11.Enabled = A12.Enabled = A20.Enabled = A21.Enabled = A22.Enabled = true;
        }

        private void opcijeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void playersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            A00.Enabled = A01.Enabled = A02.Enabled = A10.Enabled = A11.Enabled = A12.Enabled = A20.Enabled = A21.Enabled = A22.Enabled = true;
            groupBox4.Visible = true;
            labelPl1.Text = "Player1 :  " + pl1;
            labelPl2.Text = "Player2 :  " + pl2;
            int oldMode = mode;
            mode = 1;
            if (oldMode != mode)
            {
                groupBox1.Visible = groupBox2.Visible = false;
                buttonR.PerformClick();
            }
        }

        private void vsCPUToolStripMenuItem_Click(object sender, EventArgs e)
        {
            groupBox4.Visible = false;

            int oldMode = mode;
            mode = 0;
            if (oldMode != mode)
            {
                groupBox1.Visible = groupBox2.Visible = true;
                buttonR.PerformClick();
            }
        }

        private void userGuideToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("U padajucem meniju mozete izabrati mod igre: da li zelite da igrate sa prijateljem ili protiv kompjutera.\n\n" +
                "Ukoliko igrate protiv kompjutera, igra funkcionise na sledeci nacin:\n" +
                "Prvo se bira nivo (easy ili normal), nakon cega je omoguceno polje za igru.\n" +
                "Igra traje dok neko ne stigne do 5 pobeda ili dok ne bude 10 neresenih partija. Na kraju svake partije menja se znak, " +
                "tj. ako ste bili X u sledecoj partiji ste O i obrnuto. U prvoj partiji, vi ste X, a kompjuter O. U svakom trenutku mozete videti " +
                "koji ste znak u donjem levom uglu forme. Rezultat mozete pratiti u gornjem desnom uglu forme.\n\n" +
                "Ukoliko igrate sa prijateljem, igra funkcionise na sledeci nacin:\n" +
                "Na pocetku odredite ko je Player1, a ko je Player2. U prvoj partiji, Player1 je X, a Player2 je O, dok se nakon toga znakovi " +
                "naizmenicno menjaju. U svakom trenutku mozete videti koji igrac je koji znak levo od table, dok rezultat pratite u gornjem desnom uglu. " +
                "Igra traje dok neki igrac ne stigne do 5 pobeda ili dok ne bude 10 neresenih partija.\n\n" +
                "Pomocna dugmad:\n" +
                "New Game - Dugme kojim pokrecete novu partiju, rezultat se ne restartuje.\n" +
                "Reset - Dugme kojim resetujete igru, rezultat svakog igraca se postavlja na 0, a ukoliko igrate " +
                "protiv kompjutera, ponovo se bira i nivo (easy ili normal).\n" +
                "Exit - Izlaz iz igre.\n\nSrecno!", "Korisnicko uputstvo");

            
        }
    }

    
}
