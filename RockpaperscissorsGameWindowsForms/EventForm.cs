using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RockpaperscissorsGameWindowsForms
{


    public partial class EventForm : Form
    {
        public delegate void EventHandler(Results Result, Status ExchangedComputerChoice);
        public event EventHandler PopUpEvent;
        
        int UserChoice; // 사용자의 선택값

        public enum Status
        {
            Scissors = 0,
            Rock = 1,
            Paper = 2,
            None = -1
        }

        public enum Results
        {
            Win = 0,
            Draw = 1,
            Lose = 2,
            None = -1
        }


        public EventForm()
        {
            InitializeComponent();

            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void DoSomething()
        {
            Results Result; // 게임 결과
            Status ExchangedComputerChoice;
            
            EventForm Form = new EventForm();

            Play(UserChoice, out Result, out ExchangedComputerChoice);

            PopUpEvent(Result, ExchangedComputerChoice);
        }

        private void btn_scissors_clicked(object sender, EventArgs e)
        {
            EventForm Form = new EventForm();

            Form.UserChoice = 0;

            pictureBox1.Load(@"E:\Projects\RockpaperscissorsGameWindowsForms\RockpaperscissorsGameWindowsForms\Scissors.png");

            Form.PopUpEvent += new EventHandler(PopupMessage);
            Form.DoSomething();
        }


        private void btn_rock_clicked(object sender, EventArgs e)
        {
            EventForm Form = new EventForm();

            Form.UserChoice = 1;

            pictureBox1.Load(@"E:\Projects\RockpaperscissorsGameWindowsForms\RockpaperscissorsGameWindowsForms\Rock.png");

            Form.PopUpEvent += new EventHandler(PopupMessage);
            Form.DoSomething();
        }

        private void btn_paper_clicked(object sender, EventArgs e)
        {
            EventForm Form = new EventForm();

            Form.UserChoice = 2;

            pictureBox1.Load(@"E:\Projects\RockpaperscissorsGameWindowsForms\RockpaperscissorsGameWindowsForms\Paper.png");

            Form.PopUpEvent += new EventHandler(PopupMessage);
            Form.DoSomething();
        }

        private void Play(int UserChoice, out Results Results, out Status ExchangedComputerChoice)
        {
            Results = Results.None;                   // 게임 결과
            int ComputerChoice;                               // 컴퓨터의 선택값
            Status ExchangedUserChoice = Status.None;     // 사용자 선택의 변환값
            ExchangedComputerChoice = Status.None;  // 컴퓨터의 선택값의 변환값

            // 사용자 선택의 변환값을 구한다.
            switch (UserChoice)
            {
                case 0:
                    ExchangedUserChoice = Status.Scissors;
                    break;
                case 1:
                    ExchangedUserChoice = Status.Rock;
                    break;
                case 2:
                    ExchangedUserChoice = Status.Paper;
                    break;
                default:
                    break;
            }

            // 컴퓨터의 선택을 구한다.
            Random Random = new Random();
            ComputerChoice = Random.Next(0, 3);

            // 컴퓨터 선택의 변환값을 구한다.
            switch (ComputerChoice)
            {
                case 0:
                    ExchangedComputerChoice = Status.Scissors;
                    break;
                case 1:
                    ExchangedComputerChoice = Status.Rock;
                    break;
                case 2:
                    ExchangedComputerChoice = Status.Paper;
                    break;
                default:
                    break;
            }

            // 가위바위보 게임을 한다.
            if (ExchangedUserChoice == Status.Scissors)
            {
                switch (ExchangedComputerChoice)
                {
                    case Status.Scissors:
                        Results = Results.Draw;
                        break;
                    case Status.Rock:
                        Results = Results.Lose;
                        break;
                    case Status.Paper:
                        Results = Results.Win;
                        break;
                    default:
                        break;
                }
            }
            if (ExchangedUserChoice == Status.Rock)
            {
                switch (ExchangedComputerChoice)
                {
                    case Status.Scissors:
                        Results = Results.Win;
                        break;
                    case Status.Rock:
                        Results = Results.Draw;
                        break;
                    case Status.Paper:
                        Results = Results.Lose;
                        break;
                    default:
                        break;
                }
            }
            if (ExchangedUserChoice == Status.Paper)
            {
                switch (ExchangedComputerChoice)
                {
                    case Status.Scissors:
                        Results = Results.Lose;
                        break;
                    case Status.Rock:
                        Results = Results.Win;
                        break;
                    case Status.Paper:
                        Results = Results.Draw;
                        break;
                    default:
                        break;
                }
            }
        }

        public void PopupMessage(Results Result, Status ExchangedComputerChoice)
        {
            EventForm Form = new EventForm();


            // 컴퓨터 선택의 변환값을 화면에 표시한다.
            switch (ExchangedComputerChoice)
            {
                case Status.Scissors:
                    pictureBox2.Load(@"E:\Projects\RockpaperscissorsGameWindowsForms\RockpaperscissorsGameWindowsForms\Scissors.png");
                    break;
                case Status.Rock:
                    pictureBox2.Load(@"E:\Projects\RockpaperscissorsGameWindowsForms\RockpaperscissorsGameWindowsForms\Rock.png");
                    break;
                case Status.Paper:
                    pictureBox2.Load(@"E:\Projects\RockpaperscissorsGameWindowsForms\RockpaperscissorsGameWindowsForms\Paper.png");
                    break;
                default:
                    break;
            }

            switch (Result)
            {
                case Results.Win:
                    lb_result.Text = "당신은 이겼습니다.";
                    break;
                case Results.Draw:
                    lb_result.Text = "당신은 비겼습니다.";
                    break;
                case Results.Lose:
                    lb_result.Text = "당신은 졌습니다.";
                    break;
                default:
                    break;
            }
        }
    }
}
