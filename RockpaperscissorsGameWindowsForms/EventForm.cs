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
        RockpaperscissorsGame RpsGame = new RockpaperscissorsGame();

        public EventForm()
        {
            InitializeComponent();

            leftPicBox.SizeMode = PictureBoxSizeMode.StretchImage;
            rightPicBox.SizeMode = PictureBoxSizeMode.StretchImage;
            RpsGame.PopUpEvent += ShowResult;
        }

        private void btn_scissors_clicked(object sender,EventArgs e)
        {
            GameTrigger(sender.ToString());
        }

        private void btn_rock_clicked(object sender, EventArgs e)
        {
            GameTrigger(sender.ToString());
        }

        private void btn_paper_clicked(object sender, EventArgs e)
        {
            GameTrigger(sender.ToString());
        }

        public void GameTrigger(string buttonText)
        {
            switch(buttonText)
            {
                case "System.Windows.Forms.Button, Text: 가위":
                    RpsGame.UserChoice = 0;
                    leftPicBox.Load(@"E:\Projects\RockpaperscissorsGameWindowsForms\RockpaperscissorsGameWindowsForms\Scissors.png");
                    break;
                case "System.Windows.Forms.Button, Text: 바위":
                    RpsGame.UserChoice = 1;
                    leftPicBox.Load(@"E:\Projects\RockpaperscissorsGameWindowsForms\RockpaperscissorsGameWindowsForms\Rock.png");
                    break;
                case "System.Windows.Forms.Button, Text: 보":
                    RpsGame.UserChoice = 2;
                    leftPicBox.Load(@"E:\Projects\RockpaperscissorsGameWindowsForms\RockpaperscissorsGameWindowsForms\Paper.png");
                    break;
                default:
                    break;
            }

            RpsGame.DoSomething(RpsGame);
        }

        public void ShowResult(RockpaperscissorsGame RpsGame)
        {
            // 컴퓨터 선택의 변환값을 화면에 표시한다.
            switch (RpsGame.ExchangedComputerChoice)
            {
                case RockpaperscissorsGame.Status.Scissors:
                    rightPicBox.Load(@"E:\Projects\RockpaperscissorsGameWindowsForms\RockpaperscissorsGameWindowsForms\Scissors.png");
                    break;
                case RockpaperscissorsGame.Status.Rock:
                    rightPicBox.Load(@"E:\Projects\RockpaperscissorsGameWindowsForms\RockpaperscissorsGameWindowsForms\Rock.png");
                    break;
                case RockpaperscissorsGame.Status.Paper:
                    rightPicBox.Load(@"E:\Projects\RockpaperscissorsGameWindowsForms\RockpaperscissorsGameWindowsForms\Paper.png");
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
        public delegate void GameEventHandler(RockpaperscissorsGame RpsGame);
        public event GameEventHandler PopUpEvent;
        public Results Result;
        public Status ExchangedComputerChoice;
        public Status ExchangedUserChoice;
        public int UserChoice; // 사용자의 선택값

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
            RpsGame.ExchangedUserChoice = Status.None;     // 사용자 선택의 변환값
            RpsGame.ExchangedComputerChoice = Status.None;  // 컴퓨터의 선택값의 변환값

            // 사용자 선택의 변환값을 구한다.
            switch (UserChoice)
            {
                case 0:
                    RpsGame.ExchangedUserChoice = Status.Scissors;
                    break;
                case 1:
                    RpsGame.ExchangedUserChoice = Status.Rock;
                    break;
                case 2:
                    RpsGame.ExchangedUserChoice = Status.Paper;
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
                    RpsGame.ExchangedComputerChoice = Status.Scissors;
                    break;
                case 1:
                    RpsGame.ExchangedComputerChoice = Status.Rock;
                    break;
                case 2:
                    RpsGame.ExchangedComputerChoice = Status.Paper;
                    break;
                default:
                    break;
            }

            // 가위바위보 게임을 한다.
            RpsGame.Result = CompareTwo(RpsGame.ExchangedUserChoice, RpsGame.ExchangedComputerChoice);

            return RpsGame;
        }

        Results CompareTwo(Status User, Status Computer)
        {
            Results result = Results.None;
             
            if(User < Computer)
            {
                result = Results.Lose;
            }
            else if (User > Computer)
            {
                result = Results.Win;
            }
            else
            {
                result = Results.Draw;
            }

            if(User == Status.Paper && Computer == Status.Scissors)
            {
                result = Results.Lose;
            }
            if(User == Status.Scissors && Computer == Status.Paper)
            {
                result = Results.Win;
            }

            return result;
        }

        public void DoSomething(RockpaperscissorsGame RpsGame)
        {
            RpsGame = Play(UserChoice);

            if (PopUpEvent != null)
                PopUpEvent(RpsGame);
        }

        public class GameEventArgs : System.EventArgs
        {
            public string gameEvent; // 이벤트 변수 설정

            public GameEventArgs(string e_gameEvent)
            {
                gameEvent = e_gameEvent;
            }
        }
    }

}
