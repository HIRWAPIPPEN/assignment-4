// See https://aka.ms/new-console-template for more information
internal class GameDisplay
{ }

// TicTacToeGame.cs

class TicTacToeGame
{
    private GameBoard board;
    private GameMechanics mechanics;
    private GameDisplay display;

    public TicTacToeGame()
    {
        board = new GameBoard();
        mechanics = new GameMechanics();
        display = new GameDisplay();
    }

    public void Play()
    {
        while (!mechanics.IsGameOver(board)) ;
        {
            display.PrintBoard(board);
            int[] move = display.GetPlayerMove();
            mechanics.MakeMove(board, move);
        }
        display.PrintBoard(board);
        display.PrintGameOverMessage(mechanics.GetWinner(board));
    }
}

// GameBoard.cs
class GameBoard
{
    private char[,] board;

    public GameBoard()
    {
        board = new char[3, 3] { { ' ', ' ', ' ' }, { ' ', ' ', ' ' }, { ' ', ' ', ' ' } };
    }

    public char[,] GetBoard()
    {
        return board;
    }

    public void MakeMove(int[] move, char player)
    {
        board[move[0], move[1]] = player;
    }

    public char GetWinner()
    {
        // check rows
        for (int i = 0; i < 3; i++)
        {
            if (board[i, 0] == board[i, 1] && board[i, 1] == board[i, 2])
            {
                return board[i, 0];
            }
        }

        // check columns
        for (int i = 0; i < 3; i++)
        {
            if (board[0, i] == board[1, i] && board[1, i] == board[2, i])
            {
                return board[0, i];
            }
        }

        // check diagonals
        if (board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2])
        {
            return board[0, 0];
        }
        if (board[0, 2] == board[1, 1] && board[1, 1] == board[2, 0])
        {
            return board[0, 2];
        }

        // check for a draw
        if (!board.Cast<char>().Any(c => c == ' '))
        {
            return 'D';
        }

        // game is not over
        return ' ';
    }
}

// GameMechanics.cs
class GameMechanics
{
    private char currentPlayer;

    public GameMechanics()
    {
        currentPlayer = 'X';
    }

    public void MakeMove(GameBoard board, int[] move)
    {
        board.MakeMove(move, currentPlayer);
        currentPlayer = (currentPlayer == 'X') ? 'O' : 'X';
    }

    public bool IsGameOver;
}

