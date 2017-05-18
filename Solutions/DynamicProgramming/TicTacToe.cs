using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Solutions.DynamicProgramming
{
    [TestClass]
    public class TicTacToe
    {
        int[] rows;
        int[] cols;
        int dc1;
        int dc2;
        int n;

        public TicTacToe() : this(3)
        {
        }


        /** Initialize your data structure here. */
        public TicTacToe(int n)
        {
            this.n = n;
            this.rows = new int[n];
            this.cols = new int[n];
        }

        /** Player {player} makes a move at ({row}, {col}).
            @param row The row of the board.
            @param col The column of the board.
            @param player The player, can be either 1 or 2.
            @return The current winning condition, can be either:
                    0: No one wins.
                    1: Player 1 wins.
                    2: Player 2 wins. */
        public int move(int row, int col, int player)
        {
            int val = (player == 1 ? 1 : -1);

            rows[row] += val;
            cols[col] += val;

            if (row == col)
            {
                dc1 += val;
            }
            if (col == n - row - 1)
            {
                dc2 += val;
            }

            if (System.Math.Abs(rows[row]) == n
            || System.Math.Abs(cols[col]) == n
            || System.Math.Abs(dc1) == n
            || System.Math.Abs(dc2) == n)
            {
                return player;
            }

            return 0;
        }

        [TestMethod]
        public void Test_Move()
        {
            TicTacToe toe = new TicTacToe(3);
            toe.move(0, 0, 1); //-> Returns 0(no one wins)
            toe.move(0, 2, 2); //-> Returns 0(no one wins)
            toe.move(2, 2, 1); //-> Returns 0(no one wins)
            toe.move(1, 1, 2); //-> Returns 0(no one wins)
            toe.move(2, 0, 1); //-> Returns 0(no one wins)
            toe.move(1, 0, 2); //-> Returns 0(no one wins)
            toe.move(2, 1, 1); //-> Returns 1(player 1 wins)
        }
    }
}
