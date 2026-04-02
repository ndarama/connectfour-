namespace ConnectFour;

public class GameState
{
    public byte CurrentTurn { get; private set; } = 0;
    public int PlayerTurn => CurrentTurn % 2 + 1;
    private readonly byte[] board = new byte[42];

    public byte GetCell(byte row, byte column)
    {
        if (row > 5 || column > 6)
        {
            throw new ArgumentOutOfRangeException();
        }

        return board[column + (row * 7)];
    }

    public void ResetBoard()
    {
        CurrentTurn = 0;
        Array.Clear(board);
    }

    public byte PlayPiece(byte column)
    {
        // Check if column is valid
        if (column > 6)
        {
            throw new ArgumentException("Column must be between 0 and 6");
        }

        // Check if column is full
        if (board[column] != 0)
        {
            throw new ArgumentException("Column is full");
        }

        // Find the lowest empty row in the column
        byte row = 0;
        for (byte i = 0; i < 6; i++)
        {
            if (board[column + (i * 7)] == 0)
            {
                row = i;
            }
            else
            {
                break;
            }
        }

        // Place the piece
        board[column + (row * 7)] = (byte)PlayerTurn;
        CurrentTurn++;

        return row;
    }

    public WinState CheckForWin()
    {
        // Check for horizontal wins
        for (byte row = 0; row < 6; row++)
        {
            for (byte col = 0; col < 4; col++)
            {
                var idx = col + (row * 7);
                if (board[idx] != 0 &&
                    board[idx] == board[idx + 1] &&
                    board[idx] == board[idx + 2] &&
                    board[idx] == board[idx + 3])
                {
                    return board[idx] == 1 ? WinState.Player1_Wins : WinState.Player2_Wins;
                }
            }
        }

        // Check for vertical wins
        for (byte col = 0; col < 7; col++)
        {
            for (byte row = 0; row < 3; row++)
            {
                var idx = col + (row * 7);
                if (board[idx] != 0 &&
                    board[idx] == board[idx + 7] &&
                    board[idx] == board[idx + 14] &&
                    board[idx] == board[idx + 21])
                {
                    return board[idx] == 1 ? WinState.Player1_Wins : WinState.Player2_Wins;
                }
            }
        }

        // Check for diagonal wins (down-right)
        for (byte col = 0; col < 4; col++)
        {
            for (byte row = 0; row < 3; row++)
            {
                var idx = col + (row * 7);
                if (board[idx] != 0 &&
                    board[idx] == board[idx + 8] &&
                    board[idx] == board[idx + 16] &&
                    board[idx] == board[idx + 24])
                {
                    return board[idx] == 1 ? WinState.Player1_Wins : WinState.Player2_Wins;
                }
            }
        }

        // Check for diagonal wins (down-left)
        for (byte col = 3; col < 7; col++)
        {
            for (byte row = 0; row < 3; row++)
            {
                var idx = col + (row * 7);
                if (board[idx] != 0 &&
                    board[idx] == board[idx + 6] &&
                    board[idx] == board[idx + 12] &&
                    board[idx] == board[idx + 18])
                {
                    return board[idx] == 1 ? WinState.Player1_Wins : WinState.Player2_Wins;
                }
            }
        }

        // Check for tie (board full)
        if (CurrentTurn >= 42)
        {
            return WinState.Tie;
        }

        return WinState.No_Winner;
    }

    public enum WinState
    {
        No_Winner,
        Player1_Wins,
        Player2_Wins,
        Tie
    }
}
