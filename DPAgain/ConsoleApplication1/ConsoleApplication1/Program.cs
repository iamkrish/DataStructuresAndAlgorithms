using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {

            StepsJumpWays sj = new StepsJumpWays();
            var ways = sj.PrintWaysToReachNsteps(4);

            SubsetSum subsum = new SubsetSum();
            bool hasmel= subsum.SubSetSumExists(new int[] { 1, 4, 5,2,3 /*5, 3, 2, 7 */ }, 6, 2);
            PerfectSquares ps = new PerfectSquares();
            int numsq= ps.NumSquares(16);
            DecodeWays dw = new DecodeWays();
            int dwways= dw.NumDecodings("1234");
            JumpGame jump = new JumpGame();
            int leastJumps = jump.Jump(new int[] { 4, 1, 1, 3, 1, 1, 1 });
            WordPAttern wpa = new WordPAttern();
            bool fgh= wpa.WordPatternMatch("aba", "wxyzwx");

            PaintHouses pho = new PaintHouses();
            int[,] costs = new int[,]
            {
                {4,16 },
                {15,5 },
                {18,7 }
            };
            int costs_min= pho.MinCostII(costs);
            Regex2 rgx = new Regex2();
            bool mat= rgx.IsMatch("aaba", "a*");

            //WordPattern2 wp2 = new WordPattern2();
            //bool matches = wp2.PatternMatches("dogcatcatdog", "abba");

            HistogramArea ha = new HistogramArea();
            //int answer = ha.LargestRectangleArea(new int[] { 2, 1, 2, 3, 1 });

            MaxSquareAllOnes msq = new MaxSquareAllOnes();
            char[,] input = new char[,] { { '1', '0' } };
          // int xam =  msq.MaximalSquare(input);
            RegularExpressionMatching rex = new RegularExpressionMatching();
            string text = "aaba";
            string pattern = @"ab*a*c*a";
            bool rexx= rex.IsMatch(text, pattern);

            PointsInGrid pg = new PointsInGrid();
            int[,] pgrid = new int[,]
            {
                {1,3,1},
                {1,5,1},
                {4,2,1}
            };

            var w = pg.MinPathSum(pgrid);

            LongestIncreasingPathProblem lip = new LongestIncreasingPathProblem();
            int[,] pa = new int[,]
            {
                {9,9,4},
                {6,6,8 },
                {2,1,1}
            };

            //int x  = lip.LongestIncreasingPath(pa);


            WordSearch ws = new WordSearch();
            string[] di = new string[] { "pea", "oath", "eat", "rain" };

            char[,] puzz = new char[,]
            {
               {'o','a','a','n'},
               { 'e','t','a','e'},
               {'i','h','k','r' },
               {'i','f','l','v' }
            };
            var bag = ws.FindDictionaryWords(puzz, di);



            Combinations cb1 = new Combinations();
            //         cb1.Subsets(new int[] { 1, 2 ,3});

            CoinChange c = new CoinChange();
            int[] Coins = new int[] { 3, 1, 2, 4, 5 };

            int[] Coins2 = new int[] { 1, 2, 5 };
            //var res = c.MinCoinsForSum(Coins2, 11);
            // int numberOfWays = c.CombinationSum(Coins, 4);

            Combinations comb = new Combinations();
            //var res = comb.UniqueCombinationsSum(Coins,2);

            //var  res = comb.UniqueCombinationsSumNoRepeat(new int[] {1,1,2,5},8);

            //var res = comb.UniqueCombinationsKNumbersSumToN(2, 5);

            RobotProblem rb = new RobotProblem();

            int[,] robotPath = new int[3, 4]
            {
                { 1,1,1,-1},
                { 1,-1,1,-1},
                { 1,1,1,1}
            };

            //var paths = rb.NumberOfUniquePaths(robotPath);
            //rb.PrintAllPaths(paths);

            // int[,] islandOperations = new int[,]
            //{{0,1},{1,2},{2,1},{1,0},{0,2},{0,0},{1,1}};



            //Island land = new Island();
            //land.NumIslands2(3, 3, islandOperations);

            char[,] island = new char[,]
            {
                {'1','1','1','1','0'},
                {'1','1','0','1','0'},
                {'1','1','0','0','0' },
                {'0','0','0','0','0' }
            };
            //{["11110", "11010", "11000", "00000"];

            Islands2 is2 = new Islands2();
            int d = is2.NumIslands(island);
            //var r = rb.NumberOfUniquePathsDP(robotPath);



            int[] a = new int[] { 100, 4, 200, 1, 3, 2, 5, 3, 4 };
            Solution s = new Solution();
            // var l = s.LongestConsecutive(a);

            //char[,] puzzle = new char[,]
            //{
            //    {'5','3','.','.','7','.','.','.','.' },
            //    { '6','.','.','1','9','5','.','.','.'},
            //    { '.','9','8','.','.','.','.','6','.'},
            //    { '8','.','.','.','6','.','.','.','3'},
            //    {'5','3','.','.','7','.','.','.','.' },
            //    {'4','.','.','8','.','3','.','.','1' },
            //    {'7','.','.','.','2','.','.','.','6' },
            //    {'.','6','.','.','.','.','2','8','.' },
            //    {'.','.','.','4','1','9','.','.','5' },
            //    {'.','.','.','.','8','.','.','7','9' }
            //};

            //   ["..4...63.",".........","5......9.","...56....","4.3.....1","...7.....","...5.....",".........","........."]

            char[,] puzzle = new char[,]
               {
                {'.','.','4','.','.','.','6','3','.' },
                { '.','.','.','.','.','.','.','.','.'},
                { '5','.','.','.','.','.','.','9','.'},
                { '.','.','.','5','6','.','.','.','.'},

                {'4','.','3','.','.','.','.','.','1' },

                {'.','.','.','7','.','.','.','.','.' },

                {'.','.','.','5','.','.','.','.','.' },
                { '.','.','.','.','.','.','.','.','.'},
                { '.','.','.','.','.','.','.','.','.'},


               };
            Sudoko sd = new Sudoko();
            //var yes = sd.IsValidSudoku(puzzle);

            PhoneNumbers ph = new PhoneNumbers();
            var l = ph.GetLetterCombinations("222");

            Console.ReadLine();
        }

        public class Solution
        {
            public int LongestConsecutive(int[] nums)
            {

                if (nums == null || nums.Length == 0) return 0;
                if (nums.Length == 1) return 1;
                return Helper(nums);
            }

            private int Helper(int[] nums)
            {
                IDictionary<int, int> dic = new Dictionary<int, int>();
                dic.Add(nums[0], 1);

                int max_len = 1;
                int curr_len = 0; ;
                for (int i = 1; i < nums.Length; i++)
                {
                    if (!dic.ContainsKey(nums[i]))
                    {

                        int left = 0, right = 0;
                        if (dic.ContainsKey(nums[i] - 1))
                        {
                            left = dic[nums[i] - 1];
                        }

                        if (dic.ContainsKey(nums[i] + 1))
                        {
                            right = dic[nums[i] + 1];
                        }

                        dic.Add(nums[i], curr_len);

                        curr_len = 1 + left + right;


                        if (curr_len > max_len)
                        {
                            max_len = curr_len;
                        }

                        // Extend the boundaries
                        if (!dic.ContainsKey(nums[i] - left))
                        {
                            dic.Add(nums[i] - left, curr_len);
                        }
                        dic[nums[i] - left] = curr_len;

                        if (!dic.ContainsKey(nums[i] + right))
                        {
                            dic.Add(nums[i] + right, curr_len);
                        }
                        dic[nums[i] + right] = curr_len;
                    }

                }





                return max_len;
            }
        }
    }
}
