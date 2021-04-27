using System;
using TicTacToeGame;
using TicTacToeGuiMVP;
using System.Windows;


namespace TicTacToeGuiMVP
{
    public class Presenter
    {
        UIInterface IView;
        TicTacToeModel gameModel;

        public Presenter(UIInterface view)
        {
            IView = view;
            gameModel = new TicTacToeModel();
            StartGame();
        }

        // =========================================================================
        // User clicked one of the tic tac toe cells;
        // =========================================================================
        public void OnCellClicked(int row, int col)
        {
            var player = gameModel.NextPlayer;

            if (gameModel.MakePlay(player, row, col))
            {
                IView.DrawTicTacToeSymbol(player, row, col);
                switch (gameModel.status)
                {
                    case TicTacToeModel.PlayStatus.won:
                        IView.UpdateGameFinished($"Player {player} WON!!");
                        break;
                    case TicTacToeModel.PlayStatus.draw:
                        IView.UpdateGameFinished("The game ended in a draw");
                        break;
                    default:
                        IView.ShowNextPlayer(gameModel.NextPlayer);
                        break;
                }
                IView.ShowError("");
            }
            else
            {
                IView.ShowError(Enum.GetName(typeof(TicTacToeModel.ErrorCodes), gameModel.GameError));
            }
            IView.UpdateStatus("status: " + Enum.GetName(typeof(TicTacToeModel.PlayStatus), gameModel.status));
        }

        // =========================================================================
        // User clicked the StartGame button
        // =========================================================================
        public void StartGame()
        {
            gameModel.NewBoard();
            IView.ResetBoard();
            IView.UpdateStatus("status: " + Enum.GetName(typeof(TicTacToeModel.PlayStatus), gameModel.status));
            IView.ShowNextPlayer(gameModel.NextPlayer);
            IView.ShowError("");
        }

    }

}

   
