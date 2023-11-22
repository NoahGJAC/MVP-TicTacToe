using TicTacToe;
using Xunit;

namespace TicTacToeTest
{
    public class UnitTest1
    {
        [Fact]
        public void View_Refresh_Is_Called_From_Presenter_Constructor()
        {
            //Arrange
            var view = new TestView();
            view.refreshCalled = false;

            //Act
            var presenter = new Presenter(view);

            //Assert
            Assert.True(view.refreshCalled);


        }

        [Fact]
        public void View_Refresh_Is_Called_From_Presenter_NewGame()
        {
            //Arrange
            var view = new TestView();
            var presenter = new Presenter(view);
            view.refreshCalled = false;

            //Act
            presenter.NewGame();

            //Assert
            Assert.True(view.refreshCalled);
        }

        [Fact]
        public void View_Refresh_Is_Called_From_After_Each_Turn()
        {
            //Arrange
            var view = new TestView();
            var presenter = new Presenter(view);
            presenter.NewGame();
            view.refreshCalled = false;
            //Act
            presenter.ProcessTurn(0, 0);


            //Assert
            Assert.True(view.refreshCalled);
        }

        [Fact]
        public void View_SetCharacterInBoard_Is_Called_From_Presenter_ProcessTurn_First_Player()
        {
            //Arrange
            var view = new TestView();
            view.setCharacterCalled = false;
            var presenter = new Presenter(view);
            presenter.NewGame();

            //Act
            presenter.ProcessTurn(0, 0);

            //Assert
            Assert.True(view.setCharacterCalled);
        }

        [Fact]
        public void View_SetCharacterInBoard_Is_Called_From_Presenter_ProcessTurn_Second_Player()
        {
            //Arrange
            var view = new TestView();
            view.setCharacterCalled = false;
            var presenter = new Presenter(view);
            presenter.NewGame();

            //Act
            presenter.ProcessTurn(0, 0);
            view.setCharacterCalled = false;
            presenter.ProcessTurn(1, 0);

            //Assert
            Assert.True(view.setCharacterCalled);
        }

        [Fact] 
        public void View_Refresh_Is_Called_When_Game_Is_Won_By_Player_One()
        {
            //Arrange
            var view = new TestView();
            var presenter = new Presenter(view);
            presenter.NewGame();


            //Act
            presenter.ProcessTurn(0, 0);
            presenter.ProcessTurn(1, 0);
            presenter.ProcessTurn(0, 1);
            presenter.ProcessTurn(1, 1);
            view.refreshCalled = false;
            presenter.ProcessTurn(0, 2);

            //Assert
            Assert.True(view.refreshCalled);

        }
        [Fact]
        public void View_Refresh_Is_Called_When_Game_Is_Won_By_Player_Two()
        {
            //Arrange
            var view = new TestView();
            var presenter = new Presenter(view);
            presenter.NewGame();


            //Act
            presenter.ProcessTurn(0, 0);
            presenter.ProcessTurn(1, 0);
            presenter.ProcessTurn(0, 1);
            presenter.ProcessTurn(1, 1);
            presenter.ProcessTurn(2, 2);
            view.refreshCalled = false;
            presenter.ProcessTurn(1, 2);

            //Assert
            Assert.True(view.refreshCalled);

        }

        [Fact]
        public void View_ShowWinner_Is_Called_When_Game_Is_Won_By_Player_One()
        {
            //Arrange
            var view = new TestView();
            var presenter = new Presenter(view);
            presenter.NewGame();


            //Act
            presenter.ProcessTurn(0, 0);
            presenter.ProcessTurn(1, 0);
            presenter.ProcessTurn(0, 1);
            presenter.ProcessTurn(1, 1);
            view.showWinnerCalled = false;
            presenter.ProcessTurn(0, 2);

            //Assert
            Assert.True(view.showWinnerCalled);

        }

        [Fact]
        public void View_ShowWinner_Is_Called_When_Game_Is_Won_By_Player_Two()
        {
            //Arrange
            var view = new TestView();
            var presenter = new Presenter(view);
            presenter.NewGame();


            //Act
            presenter.ProcessTurn(0, 0);
            presenter.ProcessTurn(1, 0);
            presenter.ProcessTurn(0, 1);
            presenter.ProcessTurn(1, 1);
            presenter.ProcessTurn(2, 2);
            view.showWinnerCalled = false;
            presenter.ProcessTurn(1, 2);

            //Assert
            Assert.True(view.showWinnerCalled);

        }

        [Fact]
        public void View_Refresh_Is_Called_When_Game_Is_Drawn()
        {
            //Arrange
            var view = new TestView();
            var presenter = new Presenter(view);
            presenter.NewGame();


            //Act
            presenter.ProcessTurn(1, 1);
            presenter.ProcessTurn(2, 2);
            presenter.ProcessTurn(0, 0);
            presenter.ProcessTurn(2, 0);
            presenter.ProcessTurn(2,1);
            presenter.ProcessTurn(0, 1);
            presenter.ProcessTurn(0, 2);
            presenter.ProcessTurn(1, 0);
            view.refreshCalled = false;
            presenter.ProcessTurn(1,2);

            //Assert
            Assert.True(view.refreshCalled);

        }
        [Fact]
        public void View_ShowDrawnGame_Is_Called_When_Game_Is_Drawn()
        {
            //Arrange
            var view = new TestView();
            var presenter = new Presenter(view);
            presenter.NewGame();


            //Act
            presenter.ProcessTurn(1, 1);
            presenter.ProcessTurn(2, 2);
            presenter.ProcessTurn(0, 0);
            presenter.ProcessTurn(2, 0);
            presenter.ProcessTurn(2, 1);
            presenter.ProcessTurn(0, 1);
            presenter.ProcessTurn(0, 2);
            presenter.ProcessTurn(1, 0);
            view.showDrawnGameCalled = false;
            presenter.ProcessTurn(1, 2);

            //Assert
            Assert.True(view.showDrawnGameCalled);

        }

        [Fact]
        public void Error_When_Move_Played_After_Game_Finished()
        {
            //Arrange
            var view = new TestView();
            var presenter = new Presenter(view);
            presenter.NewGame();


            //Act
            presenter.ProcessTurn(1, 1);
            presenter.ProcessTurn(2, 2);
            presenter.ProcessTurn(0, 0);
            presenter.ProcessTurn(2, 0);
            presenter.ProcessTurn(2, 1);
            presenter.ProcessTurn(0, 1);
            presenter.ProcessTurn(0, 2);
            presenter.ProcessTurn(1, 0);
            presenter.ProcessTurn(0, 2);
            //game is drawn at this point
            view.showErrorCalled = false;
            presenter.ProcessTurn(0, 2);

            //Assert
            Assert.True(view.showErrorCalled);

        }

        [Fact]
        public void Error_When_Same_Move_Is_Repeated()
        {
            //Arrange
            var view = new TestView();
            var presenter = new Presenter(view);
            presenter.NewGame();


            //Act
            presenter.ProcessTurn(0, 0);
            view.showErrorCalled = false;
            presenter.ProcessTurn(0, 0);

            //Assert
            Assert.True(view.showErrorCalled);
        }

        [Fact]
        public void Error_When_Move_Is_Invalid()
        {
            //Arrange
            var view = new TestView();
            var presenter = new Presenter(view);
            presenter.NewGame();


            //Act
            view.showErrorCalled = false;
            presenter.ProcessTurn(3, 4);

            //Assert
            Assert.True(view.showErrorCalled);
        }
    }

    internal class TestView : ViewInterface
    {
        public bool showBoardCalled = false;
        public bool refreshCalled = false;
        public bool setCharacterCalled = false;
        public bool playAgainCalled = false;
        public bool showDrawnGameCalled = false;
        public bool showErrorCalled = false;
        public bool showWinnerCalled = false;
        public bool startCalled = false;


        public void PlayAgain()
        {
            playAgainCalled = true;
        }

        public void Refresh()
        {
            refreshCalled = true;
        }

        public void SetCharacterInBoard(int row, int col, char character)
        {
            setCharacterCalled = true;
        }

        public void ShowBoard(char[,] board)
        {
            showBoardCalled = true;
        }

        public void ShowDrawnGame()
        {
            showDrawnGameCalled = true;
        }

        public void ShowError(string msg)
        {
            showErrorCalled = true;
        }

        public void ShowWinner(int winner)
        {
            showWinnerCalled = true;
        }

        public void Start()
        {
            startCalled = true;
        }
    }
}