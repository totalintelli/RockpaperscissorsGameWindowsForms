using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestRockPaperscissorsGame
{
    [TestClass]
    public class TestRockpaperscissorsGame
    {
        [TestMethod]
        public void TestPlay()
        {
            RockpaperscissorsGameWindowsForms.RockpaperscissorsGame RpsGame = new RockpaperscissorsGameWindowsForms.RockpaperscissorsGame();
            int[,] GamePairs = { { 0, 0 }, { 0, 1 }, { 0, 2 }, { 1, 0 }, { 1, 1 }, { 1, 2 }, { 2, 0 }, { 2, 1 }, { 2, 2 } };
            string Win = "Win";
            string Draw = "Draw";
            string Lose = "Lose";

            RpsGame = RpsGame.Play(GamePairs[0, 0], GamePairs[0, 1]);
            Assert.AreEqual(Draw, RpsGame.Result.ToString());

            RpsGame = RpsGame.Play(GamePairs[1, 0], GamePairs[1, 1]);
            Assert.AreEqual(Lose, RpsGame.Result.ToString());

            RpsGame = RpsGame.Play(GamePairs[2, 0], GamePairs[2, 1]);
            Assert.AreEqual(Win, RpsGame.Result.ToString());

            RpsGame = RpsGame.Play(GamePairs[3, 0], GamePairs[3, 1]);
            Assert.AreEqual(Win, RpsGame.Result.ToString());

            RpsGame = RpsGame.Play(GamePairs[4, 0], GamePairs[4, 1]);
            Assert.AreEqual(Draw, RpsGame.Result.ToString());

            RpsGame = RpsGame.Play(GamePairs[5, 0], GamePairs[5, 1]);
            Assert.AreEqual(Lose, RpsGame.Result.ToString());

            RpsGame = RpsGame.Play(GamePairs[6, 0], GamePairs[6, 1]);
            Assert.AreEqual(Lose, RpsGame.Result.ToString());

            RpsGame = RpsGame.Play(GamePairs[7, 0], GamePairs[7, 1]);
            Assert.AreEqual(Win, RpsGame.Result.ToString());

            RpsGame = RpsGame.Play(GamePairs[8, 0], GamePairs[8, 1]);
            Assert.AreEqual(Draw, RpsGame.Result.ToString());
        }
    }
}
