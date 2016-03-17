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
        public delegate void EventHandler(RockpaperscissorsGame RpsGame);
        public event EventHandler PopUpEvent;

        public int UserChoice; // 사용자의 선택값

        public EventForm()
        {
            RockpaperscissorsGame RpsGame = new RockpaperscissorsGame();

            InitializeComponent();

            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            PopUpEvent += new EventHandler(PopupMessage);
        }

        private void DoSomething()
        {
            RockpaperscissorsGame RpsGame = new RockpaperscissorsGame();

            RockpaperscissorsGame.Results Result;                 // 게임 결과
            RockpaperscissorsGame.Status ExchangedComputerChoice;
           
            RpsGame.Play(UserChoice);

            PopUpEvent(RpsGame);
        }

        private void btn_scissors_clicked(object sender, EventArgs e)
        {
            RockpaperscissorsGame RpsGame = new RockpaperscissorsGame();
            UserChoice = 0;
            pictureBox1.Load(@"E:\Projects\RockpaperscissorsGameWindowsForms\RockpaperscissorsGameWindowsForms\Scissors.png");
            DoSomething();
        }


        private void btn_rock_clicked(object sender, EventArgs e)
        {
            RockpaperscissorsGame RpsGame = new RockpaperscissorsGame();
            UserChoice = 1;
            pictureBox1.Load(@"E:\Projects\RockpaperscissorsGameWindowsForms\RockpaperscissorsGameWindowsForms\Rock.png");
            DoSomething();
        }

        private void btn_paper_clicked(object sender, EventArgs e)
        {
            RockpaperscissorsGame RpsGame = new RockpaperscissorsGame();
            UserChoice = 2;
            pictureBox1.Load(@"E:\Projects\RockpaperscissorsGameWindowsForms\RockpaperscissorsGameWindowsForms\Paper.png");
            DoSomething();
        }

        

        public void PopupMessage(RockpaperscissorsGame RpsGame)
        {
            // 컴퓨터 선택의 변환값을 화면에 표시한다.
            switch (RpsGame.ExchangedComputerChoice)
            {
                case RockpaperscissorsGame.Status.Scissors:
                    pictureBox2.Load(@"E:\Projects\RockpaperscissorsGameWindowsForms\RockpaperscissorsGameWindowsForms\Scissors.png");
                    break;
                case RockpaperscissorsGame.Status.Rock:
                    pictureBox2.Load(@"E:\Projects\RockpaperscissorsGameWindowsForms\RockpaperscissorsGameWindowsForms\Rock.png");
                    break;
                case RockpaperscissorsGame.Status.Paper:
                    pictureBox2.Load(@"E:\Projects\RockpaperscissorsGameWindowsForms\RockpaperscissorsGameWindowsForms\Paper.png");
                    break;
                default:
                    break;
            }

            switch (RpsGame.Result)
            {
                case RockpaperscissorsGame.Results.Win:
                    lb_result.Text = "당신은 이겼습니다.";
                    break;
                case RockpaperscissorsGame.Results.Draw:
                    lb_result.Text = "당신은 비겼습니다.";
                    break;
                case RockpaperscissorsGame.Results.Lose:
                    lb_result.Text = "당신은 졌습니다.";
                    break;
                default:
                    break;
            }
        }
    }

    public class RockpaperscissorsGame
    {
       
        
        public Results Result;
        public Status ExchangedComputerChoice;

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

        public RockpaperscissorsGame Play(int UserChoice)
        {
            RockpaperscissorsGame RpsGame = new RockpaperscissorsGame();
            RpsGame.Result = Results.None;                   // 게임 결과
            int ComputerChoice;                               // 컴퓨터의 선택값
            Status ExchangedUserChoice = Status.None;     // 사용자 선택의 변환값
            RpsGame.ExchangedComputerChoice = Status.None;  // 컴퓨터의 선택값의 변환값

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
                        Result = Results.Draw;
                        break;
                    case Status.Rock:
                        Result = Results.Lose;
                        break;
                    case Status.Paper:
                        Result = Results.Win;
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
                        Result = Results.Win;
                        break;
                    case Status.Rock:
                        Result = Results.Draw;
                        break;
                    case Status.Paper:
                        Result = Results.Lose;
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
                        Result = Results.Lose;
                        break;
                    case Status.Rock:
                        Result = Results.Win;
                        break;
                    case Status.Paper:
                        Result = Results.Draw;
                        break;
                    default:
                        break;
                }
            }

            return RpsGame;
        }
    }

}
