using System;

namespace UncrossedLines
{
    /// <summary>
    /// LeetCode 1035 Uncrossed lines.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var a = new[] {1,3,7,1,7,5};
            
            var b = new[] {1,9,2,5,1};

            Console.WriteLine(new Program().MaxUncrossedLines(a, b));
        }

        /**
         * 看上去不太难，用了一个简单的DP解决。
         * 其实应该可以优化成滚动数组形式减少内存占用。
         * （可以加速吗？）这个不太清楚。// Todo
         */
        public int MaxUncrossedLines(int[] a, int[] b)
        {
            var al = a.Length;
            var bl = b.Length;
            var dp = new int[al + 1, bl + 1];
            for (var i = 1; i <= al; i++)
            {
                for (var j = 1; j <= bl; j++)
                {
                    dp[i, j] = Math.Max(dp[i - 1, j], dp[i, j - 1]);
                    if (a[i - 1] == b[j - 1])
                    {
                        dp[i, j] = Math.Max(dp[i, j], dp[i - 1, j - 1] + 1);
                    }
                }
            }

            /*
            for (int i = 0; i <= al; i++)
            {
                for (int j = 0; j <= bl; j++)
                {
                    Console.Write(dp[i, j] + " ");
                }
                Console.WriteLine();
            }
            */
            
            return dp[al, bl];
        }
    }
}
