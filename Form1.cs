 using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flappy_Bird_Windows_Form
{
   
    public partial class Form1 : Form
    {
        int pipeSpeed = 8;
        int gravity = 10;
        int score = 0;



        public Form1()
        {
            InitializeComponent();
        }

        private void loadGame(object sender, EventArgs e)
        {
            Form1 gameWindow = new Form1();
            gameWindow.Show();

        }
        private void gameTimerEvent(object sender, EventArgs e)
        {
            flappyBird.Top += gravity;
            pipeBottom.Left -= pipeSpeed;
            pipeTop.Left -= pipeSpeed;
            scoreText.Text = "Punkty: " + score;


            if (pipeBottom.Left < -80)
            {
                pipeBottom.Left = 500;
                score++;
            }
            if (pipeTop.Left < -110)
            {
                pipeTop.Left = 550;
                score++;
            }

            if (flappyBird.Bounds.IntersectsWith(pipeBottom.Bounds) ||
                flappyBird.Bounds.IntersectsWith(pipeTop.Bounds) ||
                flappyBird.Bounds.IntersectsWith(ground.Bounds) || flappyBird.Top < -15
                )
            {
                endGame();
            }

            if(score > 5)
            {
                pipeSpeed = 10;

            }

           


        }


     

        private void gamekeyisdown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Space)
            {
                gravity = -10;
            }

        }

        private void gamekeyisup(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Space)
            {
                gravity = 10;
            }
        }

        private void endGame()
        {
            gameTimer.Stop();
            scoreText.Text += " Przegrałeś!!!"; 
        }

       
    }

}
