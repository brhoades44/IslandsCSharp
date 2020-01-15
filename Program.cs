///////////////////////////////////////////////////////////////////////////////////////////////
// Bruce Rhoades - Driver program to set up a "geographic area" to determine the number of 
// islands in the area. 1's are considered pieces of land and 0's are pieces of water. 
// Islands are made up of "land masses" connected to other land masses that neighbor it on any 
// of its 8 sides (or less if it is a border land mass)
///////////////////////////////////////////////////////////////////////////////////////////////
using System;

namespace Islands
{
    class Program
    {
        static void Main(string[] args)
        {
            // Set up a "geographic area" and determine the number of islands 
            int[,] geoArea = new int[,] { { 1, 1, 0, 0, 0 },
                                          { 0, 1, 0, 0, 1 },
                                          { 1, 0, 0, 1, 1 },
                                          { 0, 0, 0, 0, 0 },
                                          { 1, 0, 1, 0, 1 } };
            Console.Write("Number of islands is: " + GeographicArea.countIslands(geoArea));
        }
    }
}
