using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlappyBirdGame
{
    public partial class Form1 : Form
    {

        int pipeSpeed = 8; //cкорость столба 
        int gravity = 5; //скорость падения птицы
        int score = 0; //очки
        public Form1()
        {
            InitializeComponent();
        }

        private void gameTimerEvent(object sender, EventArgs e)
        {
            FluppyBird.Top += gravity;//связь птицы с гравитацией,добавление скорости гравитации к верхнему положению полей
            pipeBottom.Left -= pipeSpeed;//связь положения нижней трубы со скоростью трубы,уменьшает значение скорости трубы из левого положения, поэтому труба будет перемещаться влево
            pipeTop.Left -= pipeSpeed;//то же самое происходит с верхней трубой
            scoreText.Text = "Очки: " +score;//показать текущие очки

            //проверка выхода трубы за границы формы
            if (pipeBottom.Left < -150)
            {
                //если позиция нижней трубы -150, то сбрасываем на 800 и добавим 1 очко
                pipeBottom.Left = 800;
                score++;
            }
            if (pipeTop.Left < -180)
            {
                //если позиция верхней трубы -180, то сбросывваем на 950 и добавим 1 очко.
                pipeTop.Left = 950;
                score++;
            }

            //проверка, произошло ли касание птицы с трубой, формой
            if (FluppyBird.Bounds.IntersectsWith(pipeBottom.Bounds) || FluppyBird.Bounds.IntersectsWith(pipeTop.Bounds) || FluppyBird.Bounds.IntersectsWith(ground.Bounds) || FluppyBird.Top < -25)
            {
                endGame(); //конец игры
            }

            //если очко больше 5, то увеличиваем скорость трубы на 15
            if (score > 5)
            {    
                pipeSpeed = 15;
            }
        }

        /*Связь между формой и клавишей пробел*/
        private void gamekeisdown(object sender, KeyEventArgs e)//событие, когда пробел не нажат
        {
            if (e.KeyCode == Keys.Space)//если нажата клавиша пробела, то скорость падения птицы = -15
            {
                gravity = -5;
            }
        }

        private void gamekeyisup(object sender, KeyEventArgs e)//событие, когда пробел нажат
        {
            if (e.KeyCode == Keys.Space)//если отпустить клавишу пробела, то gravity = 15
            {
                gravity = 5;
            }
        }


        private void endGame()//событие окончания игры
        {
            Gametimer.Stop(); //остановка игры
            scoreText.Text += " Конец игры! "; 
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
