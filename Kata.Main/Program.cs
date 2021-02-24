using Kata.Main.Tools;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kata.Main
{
    static class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Started! ");
            var testData = FileReaderHelper.ReadFileAsSingleLineInt(@"C:\EtoroFiles\whatflavors.txt", " ");
            //1  4 10  20  35  56  84
            var stop = new Stopwatch();//1, 3, 6, 10, 15, 21  28   
                                        //   000 111 222
            stop.Start();              //    012 345 678
            var pow = timeToInput("91566165", "639485712");
            stop.Stop();
            Console.WriteLine("elapsed ms: " + stop.ElapsedMilliseconds + ". Elapsed s: " + stop.ElapsedMilliseconds / 1000);
            Console.WriteLine($"Result: {pow}");
        }

        public static int timeToInput(string s, string keypad)
        {
            var secondsPassed = 0;
            for (int i = 0; i < s.Length - 1; i++)
            {
                var currentKeyIndex = keypad.IndexOf(s[i]);
                var xCurrent = currentKeyIndex % 3;
                var yCurrent = currentKeyIndex / 3;

                var nextKeyIndex = keypad.IndexOf(s[i + 1]);
                var xNext = nextKeyIndex % 3;
                var yNext = nextKeyIndex / 3;
                secondsPassed += Math.Max(Math.Abs(xCurrent - xNext), Math.Abs(yCurrent - yNext));
            }
            return secondsPassed;
        }

        public static List<int> minimalReplaces(string[] words, int words_count)
        {
            var result = new List<int>();

            for (int i = 0; i < words_count; i++)
            {
                var replaces = CountReplaces(words[i]);
                result.Add(replaces);
            }

            return result;
        }

        private static int CountReplaces(string word)
        {
            var replaces = 0;
            for (int i = 0; i < word.Length - 1; i++)
            {
                if(word[i] == word[i + 1])
                {
                    i++;
                    replaces++;
                }
            }
            return replaces;
        }

        static string isBalanced(string s)
        {
            var stack = new Stack<char>();
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '{' || s[i] == '[' || s[i] == '(')
                {
                    stack.Push(s[i]);
                    continue;
                }
                if (stack.Count == 0)
                    return "NO";
                switch (s[i])
                {
                    case '}':
                        if (stack.Peek() != '{')
                            return "NO";
                        break;
                    case ']':
                        if (stack.Peek() != '[')
                            return "NO";
                        break;
                    case ')':
                        if (stack.Peek() != '(')
                            return "NO";
                        break;
                }
                stack.Pop();
            }

            return stack.Count == 0 ? "YES" : "NO";
        }

        static long maximumSum(long[] a, long m)
        {
            var result = a.Max(f => f % m);
            if (result == m - 1)
                return result;

            var prefixSums = new long[a.Length + 1];
            for (int i = 0; i < a.Length; i++)
                prefixSums[i + 1] = a[i] + prefixSums[i];

            var size = 2;
            while (size <= a.Length)
            {
                for (int i = 0; i <= a.Length - size; i++)
                {
                    var subSumMod = prefixSums[size + i] - prefixSums[i] % m;
                    if (subSumMod == m - 1)
                        return subSumMod;
                    Math.Max(result, subSumMod);
                }
                size++;
            }

            return result;
        }

        static long triplets(int[] a, int[] b, int[] c)
        {
            var result = 0;
            a = a.OrderBy(o => o).ToArray();
            b = b.OrderBy(o => o).ToArray();
            c = c.OrderBy(o => o).ToArray();
            for (int i = 0; i < a.Length; i++)
            {
                if (i > 0 && a[i] == a[i - 1])
                    continue;

                for (int j = 0; j < b.Length; j++)
                {
                    if ((j > 0 && b[j] == b[j - 1]) || b[j] < a[i])
                        continue;

                    for (int k = 0; k < c.Length; k++)
                    {
                        if (k > 0 && a[k] == a[k - 1])
                            continue;
                        if (b[j] < c[k])
                            break;
                        result++;
                    }
                }
            }
            return result;
        }

        static string whatFlavors(int[] cost, int money)
        {
            for (int i = 0; i < cost.Length; i++)
            {
                if (cost[i] >= money)
                    continue;

                var lookFor = money - cost[i];
                var index = Array.IndexOf(cost, lookFor);
                if (index == -1)
                    continue;
                if (index == i)
                {
                    index = Array.IndexOf(cost.Skip(index + 1).ToArray(), lookFor);
                    if (index != -1)
                        index += 1;
                }
                if (index != -1)
                {
                    Console.WriteLine(i + 1 + " " + (index + 1));
                    return null;
                }
            }

            return null;
        }

        static long substrCount(int n, string s)
        {
            var specialStrings = n;
            var size = 2;
            while (size <= s.Length)
            {
                for (int i = 0; i <= s.Length - size; i++)
                {
                    var sub = s.Substring(i, size);
                    var sameAsFirstCount = sub.Count(s1 => s1 == sub[0]);
                    if (sameAsFirstCount == sub.Length ||
                        (sub.Length % 2 != 0 && sameAsFirstCount == sub.Length - 1 && sub[sub.Length / 2] != sameAsFirstCount))
                        specialStrings++;
                }
                size++;
            }
            return specialStrings;
        }

        static long countInversions(int[] arr)
        {
            var sorted = arr.OrderBy(a => a).ToArray();
            var inversions = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == sorted[i])
                    continue;
                var index = Array.LastIndexOf(arr, sorted[i]);
                Swap(arr, i, index);
                inversions++;
            }

            return inversions;

        }

        private static void Swap(int[] arr, int i, int index)
        {
            var aux = arr[i];
            arr[i] = arr[index];
            arr[index] = aux;
        }

        static List<int> freqQuery(List<List<int>> queries)
        {
            var results = new List<int>();
            var dict = new Dictionary<int, int>();
            foreach (var q in queries)
            {
                switch (q[0])
                {
                    case 1:
                        if (dict.ContainsKey(q[1]))
                            dict[q[1]]++;
                        else
                            dict.Add(q[1], 1);
                        break;
                    case 2:
                        if (dict.ContainsKey(q[1]))
                        {
                            if (dict[q[1]] <= 1)
                                dict.Remove(q[1]);
                            else
                                dict[q[1]]--;
                        }
                        break;
                    case 3:
                        if (dict.Values.Any(v => v == q[1]))
                            results.Add(1);
                        else
                            results.Add(0);
                        break;
                    default:
                        break;
                }
            }
            return results;
        }

        static long countTriplets(List<long> arr, long r)
        {
            long triplets = 0;
            var dict = new Dictionary<long, int>();
            for (int i = 0; i < arr.Count - 2; i++)
            {
                if (dict.ContainsKey(arr[i]))
                {
                    if (dict[arr[i]] == 0)
                        continue;
                    if (r == 1)
                    {
                        var lastIndex = arr.LastIndexOf(arr[i]) - i + 1;
                        for (int a = lastIndex; a > 0; a--)
                            triplets += ((a - 1) * (a - 2)) / 2;
                        i = lastIndex;
                    }
                    else
                        triplets += dict[arr[i]];
                    continue;
                }
                else
                    dict.Add(arr[i], 0);

                for (int j = i + 1; j < arr.Count - 1; j++)
                {
                    if (arr[i] > arr[j])
                        continue;

                    for (int k = j + 1; k < arr.Count; k++)
                    {
                        if (arr[j] > arr[k])
                            continue;

                        if (r == 1 && arr[i] == arr[j] && arr[j] == arr[k])
                        {
                            var lastIndex = arr.LastIndexOf(arr[i]) - i + 1;
                            for (int a = lastIndex; a > 0; a--)
                                triplets += ((a - 1) * (a - 2)) / 2;
                            i = j = lastIndex;
                            break;
                        }

                        if (arr[i] == arr[j] / r && arr[j] == arr[k] / r)
                        {
                            triplets++;
                            dict[arr[i]]++;
                        }
                    }
                }
            }

            return triplets;

        }

    }
}
