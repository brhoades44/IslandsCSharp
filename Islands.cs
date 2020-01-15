///////////////////////////////////////////////////////////////////////////////////////////////
// Bruce Rhoades -  Class representing a "Geographic Area" (A 2 x 2 2D grid)
//
// It currently has a method to determing the number of "Islands" in the area. An island is 
// considered to be an area of 1's (land) with 0's (water) or borders surrounding it. 
///////////////////////////////////////////////////////////////////////////////////////////////

using System;

namespace Islands
{
    class GeographicArea
    {
        // No of rows and columns 
        // Can be expanded to allow for dimensions to be allocated by client code
        static int ROW = 5, COL = 5;

        ///////////////////////////////////////////////////////////////////////////////////////////
        // A function to check if a given cell (row, col) can be included in a search to determine
        // if it is part of an island
        //
        // matrix: Reference to full matrix area the code is analyzing
        // row: The current row of the target cell
        // column: The current column of the target cell
        // visited: Reference to matrix representing cells that have already been examined 
        ///////////////////////////////////////////////////////////////////////////////////////////
        private static bool isSafe(int[,] matrix, int row,
                           int col, bool[,] visited)
        {
            // Return true if row and column number is in range, 
            // and cell value is 1 and not yet visited 
            // Otherwise return false
            return (row >= 0) && (row < ROW) && (col >= 0) && (col < COL) && (matrix[row, col] == 1 && !visited[row, col]);
        }

        ///////////////////////////////////////////////////////////////////////////////////////////
        // A recursive utility function to traverseNeighbors through a 2D boolean matrix
        // It considers the 8 neighbors as adjacent vertices
        //
        // matrix: Reference to full matrix area the code is analyzing
        // row: The current row of the target cell
        // column: The current column of the target cell
        // visited: Reference to matrix representing cells that have already been examined 
        ///////////////////////////////////////////////////////////////////////////////////////////
        private static void traverseNeighbors(int[,] matrix, int row,
                        int col, bool[,] visited)
            {
                // These arrays are used to get row and column numbers of 8 neighbors of a given cell 
                int[] rowNbr = new int[] { -1, -1, -1, 0,
                                            0, 1, 1, 1 };
                int[] colNbr = new int[] { -1, 0, 1, -1,
                                            1, -1, 0, 1 };

                // Mark this cell as visited 
                visited[row, col] = true;

                // Recur for all neighbors 
                for (int k = 0; k < 8; ++k)
                    if (isSafe(matrix, row + rowNbr[k], col + colNbr[k], visited))
                        traverseNeighbors(matrix, row + rowNbr[k],
                            col + colNbr[k], visited);
            }

        ///////////////////////////////////////////////////////////////////////////////////////////
        // The main driver function that traverses the 2D matrix and returns the count of islands 
        //
        // matrix: Reference to full matrix area the code is analyzing
        ///////////////////////////////////////////////////////////////////////////////////////////
        public static int countIslands(int[,] matrix)
        {
            // Make a bool array to mark visited cells. Initially all cells are unvisited (false)
            bool[,] visited = new bool[ROW, COL];

            // Initialize count as 0 and traverse through all cells of given matrix 
            int count = 0;
            for (int i = 0; i < ROW; ++i)
                for (int j = 0; j < COL; ++j)
                    if (matrix[i, j] == 1 && !visited[i, j])
                    {
                        // If a cell with value 1 is not visited yet, then a new island is found
                        // Visit all cells in this island and increment island count 
                        traverseNeighbors(matrix, i, j, visited);
                        ++count;
                    }

            return count;
        }
    }
}
