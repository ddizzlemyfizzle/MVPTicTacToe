using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TicTacToeGuiMVP;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {

        public class TestUIInterface : UIInterface
        {

            public bool resetBoardCalled = false;
            public string updateStatusString = "";

            public void DrawTicTacToeSymbol(int player, int row, int col)
            {
                throw new NotImplementedException();
            }

            public void ResetBoard()
            {
                resetBoardCalled = true;
            }

            public void ShowError(string v)
            {
                throw new NotImplementedException();
            }

            public void ShowNextPlayer(int nextPlayer)
            {
                throw new NotImplementedException();
            }

            public void UpdateGameFinished(string v)
            {
                throw new NotImplementedException();
            }

            public void UpdateStatus(string v)
            {
                throw new NotImplementedException();
            }
        }

        public TestUIInterface theUIInterface = new TestUIInterface();


        [TestMethod]
        public void Test_StartGame()
        {
            //Arrange
            TestUIInterface theTestedUI = new TestUIInterface();
            Presenter thePresenter = new Presenter(theUIInterface);

            //Act
            thePresenter.StartGame();

            //Assert
            //Reset board was called
            Assert.IsTrue(theTestedUI.resetBoardCalled);
            Assert.AreEqual("status: ready", theTestedUI.updateStatusString);

           // IView.UpdateStatus("Status: ready");
        }
    }
}
