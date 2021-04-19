using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kata.Main.Algorithms
{
    public static class Miscellaneous
    {

        static int saveThePrisoner(int n, int m, int s)
        {
            var rounds = m + s - 1;
            var result = rounds > n ? rounds % n : rounds;
            return result == 0 ? n : result;
        }

        static int[] circularArrayRotation(int[] a, int k, int[] queries)
        {
            var result = new int[queries.Length];
            var q = 0;
            for (int i = 0; i < a.Length; i++)
            {
                var newIndex = (k + i) % a.Length;
                if (!queries.Any(q => q == newIndex))
                    continue;

                result[q++] = a[i];
            }
            return result;
        }

        public static int pickingNumbers(List<int> a)
        {
            a = a.OrderBy(o => o).ToList();
            var lenghtLongestSubArray = 0;

            for (int i = 0; i < a.Count; i++)
            {
                var nextNumber = a.FirstOrDefault(n => n == a[i] + 1);
                var nextNumberIndex = nextNumber == 0 ?
                    a.LastIndexOf(a[i]) :
                    a.LastIndexOf(nextNumber);

                lenghtLongestSubArray = Math.Max(lenghtLongestSubArray, nextNumberIndex - i + 1);
                i = nextNumberIndex;
            }

            return lenghtLongestSubArray;
        }

        static int getMoneySpent(int[] keyboards, int[] drives, int b)
        {
            var maxSpent = -1;
            for (int i = 0; i < keyboards.Length; i++)
            {
                if (keyboards[i] >= b)
                    continue;
                for (int j = 0; j < drives.Length; j++)
                {
                    if (keyboards[i] + drives[j] > b)
                        continue;
                    maxSpent = Math.Max(maxSpent, keyboards[i] + drives[j]);
                    if (maxSpent == b)
                        return maxSpent;
                }
            }
            return maxSpent;
        }

        static int pageCount(int n, int p)
        {
            var nearest = Math.Min(p - 1, n - p);
            if (n - p == nearest)
            {
                if (n % 2 == 0)
                    return (nearest + 1) / 2;
                return nearest / 2;
            }

            var result = (nearest + 1) / 2;
            return result;
        }

        static string bonAppetit(List<int> bill, int k, int b)
        {
            var billTotal = bill.Sum();
            var billWithoutItemEatByAnna = billTotal - bill[k];

            if (b > billWithoutItemEatByAnna / 2)
                Console.WriteLine($"{b - (billWithoutItemEatByAnna / 2)}");
            else
                Console.WriteLine("Bon Appetit");

            return null;
        }

        static int divisibleSumPairs(int n, int k, int[] ar)
        {
            var divisiblePairsCount = 0;

            for (int i = 0; i < n - 1; i++)
            {
                for (int j = i + 1; j < ar.Length; j++)
                {
                    if ((ar[i] + ar[j]) % k == 0)
                        divisiblePairsCount++;
                }
            }

            return divisiblePairsCount;

        }

        static int migratoryBirds(List<int> arr)
        {
            var birdIds = new int[5];
            for (int i = 0; i < arr.Count; i++)
                birdIds[arr[i] - 1]++;

            var lowestBirdTypeIdMostSighted = Array.IndexOf(birdIds, birdIds.Max());
            return lowestBirdTypeIdMostSighted + 1;
        }

        static int birthday(List<int> s, int d, int m)
        {
            var ways = 0;
            for (int i = 0; i < s.Count - m + 1; i++)
            {
                if (s.GetRange(i, m).Sum() == d)
                    ways++;
            }

            return ways;
        }

        public static int getTotalX(List<int> a, List<int> b)
        {
            var factors = new List<int>();
            var factor = a[a.Count - 1];
            while (factor <= b[0])
            {
                if (!a.Any(an => factor % an != 0))
                    factors.Add(factor);
                factor += a[a.Count - 1];
            }

            var factorsCount = 0;
            for (int i = 0; i < factors.Count; i++)
            {
                if (b.Any(bn => bn % factors[i] != 0))
                    continue;
                factorsCount++;
            }
            return factorsCount;
        }

        static string kangaroo(int x1, int v1, int x2, int v2)
        {
            if (v1 <= v2)
                return "NO";

            while (x1 < x2)
            {
                x1 += v1;
                x2 += v2;
                if (x1 == x2)
                    return "YES";
            }
            return "NO";
        }

        static int whatFlavors(int[] cost, int money)
        {
            for (int i = 0; i < cost.Length - 1; i++)
            {
                if (cost[i] >= money)
                    continue;
                for (int j = i + 1; j < cost.Length; j++)
                {
                    if (cost[i] + cost[j] == money)
                    {
                        Console.WriteLine($"{i + 1} {j + 1}");
                    }
                }
            }
            return 0;
        }

        static long minTime(long[] machines, long goal)
        {
            long items = 0;
            var days = machines[0] - 1;
            while (items < goal)
            {
                items = 0;
                days++;
                for (int i = 0; i < machines.Length; i++)
                {
                    items += days / machines[i];
                }
            }

            return days;
        }

        static int[] breakingRecords(int[] scores)
        {
            var results = new int[2];
            var highestScore = scores[0];
            var minScore = scores[0];

            for (int i = 1; i < scores.Length; i++)
            {
                if (scores[i] < minScore)
                {
                    minScore = scores[i];
                    results[1]++;
                }
                if (scores[i] > highestScore)
                {
                    highestScore = scores[i];
                    results[0]++;
                }
            }

            return results.ToArray();

        }

        static int countApplesAndOranges(int s, int t, int a, int b, int[] apples, int[] oranges)
        {
            var aCount = 0;
            for (int i = 0; i < apples.Length; i++)
            {
                if (a + apples[i] >= s && a + apples[i] <= t)
                    aCount++;
            }

            var oCount = 0;
            for (int i = 0; i < oranges.Length; i++)
            {
                if (b + oranges[i] >= s && b + oranges[i] <= t)
                    oCount++;
            }

            Console.WriteLine(aCount);
            Console.WriteLine(oCount);
            return 0;
        }

        static long largestRectangle(int[] h)
        {
            var largestArea = 0;
            for (int i = 0; i < h.Length; i++)
            {
                var x1 = i - 1;
                while (x1 >= 0 && h[i] <= h[x1])
                    x1--;
                x1++;

                var x2 = i + 1;
                while (x2 < h.Length && h[i] <= h[x2])
                    x2++;
                x2--;
                var w = Math.Abs(x1 - x2) + 1;
                largestArea = Math.Max(largestArea, h[i] * w);
            }

            return largestArea;
        }

        static List<int> freqQuery(List<List<int>> queries)
        {
            var fValues = new Dictionary<int, int>();
            var frequencies = new Dictionary<int, int>();
            var result = new List<int>();

            foreach (var q in queries)
            {
                switch (q[0])
                {
                    case 1:
                        fValues.AddToDictionarySafely(q[1], 1);
                        frequencies.AddToDictionarySafely(fValues[q[1]], 1);
                        break;
                    case 2:
                        if (fValues.ContainsKey(q[1]))
                        {
                            frequencies.RemoveFromDictionarySafely(fValues[q[1]], 1);
                            fValues.RemoveFromDictionarySafely(q[1], 1);
                        }
                        break;
                    case 3:
                        result.Add(frequencies.ContainsKey(q[1]) ? 1 : 0);
                        break;
                    default:
                        break;
                }
            }

            return result;
        }

        private static void AddToDictionarySafely(this Dictionary<int, int> dict, int key, int value)
        {
            if (dict.ContainsKey(key))
                dict[key] += value;
            else
                dict.Add(key, value);
        }

        private static void RemoveFromDictionarySafely(this Dictionary<int, int> dict, int key, int value)
        {
            if (!dict.ContainsKey(key))
                return;
            if (dict[key] > 0)
                dict[key] -= value;
            else
                dict.Remove(key);
        }

        private static int GetLargest1Length(int[][] bitMatrix)
        {
            var fasdf = bitMatrix.Select(b => b.Sum()).Max();
            var max = 0;
            var j = 0;

            for (int i = 0; i < bitMatrix.Length; i++)
            {
                while (j < bitMatrix[i].Length && bitMatrix[i][j] == 1)
                {
                    j++;
                    max++;
                }
            }
            return max;
        }

        private static List<int> PushOrPopList(List<int> numbers, string[] pushesPops)
        {
            var ip = 0;
            var inum = 0;
            while (inum < numbers.Count && ip < pushesPops.Length)
            {
                if (pushesPops[ip] == "push")
                {
                    ip++; inum++;
                    continue;
                }
                if (pushesPops[ip] == "pop" && numbers.Count > 0)
                {
                    var popIndex = numbers.GetRange(0, inum + 1).IndexOf(numbers[inum]);
                    if (popIndex > -1 && popIndex != inum)
                    {
                        numbers.RemoveAt(popIndex);
                        numbers.RemoveAt(inum - 1);
                        inum--;
                    }
                    else
                        numbers.RemoveAt(inum);
                }

                ip++;
            }

            return numbers;

        }

        private static List<int> PushOrPopSkip(int[] numbers, string[] pushesPops)
        {
            var result = new List<int>();
            var i = 0;
            while (i < numbers.Length && i < pushesPops.Length)
            {
                if (pushesPops[i] == "push")
                {
                    result.Add(numbers[i++]);
                    continue;
                }
                if (pushesPops[i] == "pop" && result.Count > 0)
                {
                    var popIndex = result.LastIndexOf(numbers[i]);
                    if (popIndex > -1)
                        result.RemoveAt(popIndex);
                }

                i++;
            }

            return result;

        }

        private static (int, int) PushOrPop(int[] numbers, string[] pushesPops)
        {
            var result = new SortedList<int, int>();
            var i = 0;
            while (i < numbers.Length && i < pushesPops.Length)
            {
                if (pushesPops[i] == "push")
                {
                    result.Add(numbers[i], numbers[i]);
                    i++;
                    continue;
                }
                if (pushesPops[i] == "pop" && result.Count > 0)
                    result.RemoveAt(result.Count - 1);
                i++;
            }
            if (result.Count <= 0)
                return (0, 0);

            var min = result.First().Key;
            var max = result.Last().Key;
            return (min, max);
        }

        static string primality(int n)
        {
            if (n == 1)
                return "Not prime";

            for (int i = 2; i * i <= n; i++)
            {
                if (n % i == 0)
                    return "Not prime";
            }

            return "Prime";
        }

        static bool IsAnagram(string value, string value2)
        {
            if (value.Length != value2.Length)
                return false;

            for (int i = 0; i < value.Length; i++)
            {
                var index = value2.IndexOf(value[i]);
                if (index == -1)
                    return false;
                value2 = value2.Remove(index, 1);
            }
            return value2.Length == 0;
        }

        static bool IsAnagramWithDictionary(string value, string value2)
        {
            if (value.Length != value2.Length)
                return false;

            var dict = new Dictionary<char, int>();
            for (int i = 0; i < value.Length; i++)
            {
                if (dict.ContainsKey(value[i]))
                    dict[value[i]]++;
                else
                    dict.Add(value[i], 1);
            }

            for (int i = 0; i < value2.Length; i++)
            {
                if (dict.ContainsKey(value2[i]) && dict[value2[i]] > 0)
                    dict[value2[i]]--;
                else
                    return false;
            }
            return !dict.Values.Any(d => d != 0);
        }

        static bool IsAnagramWithSort(string value, string value2)
        {
            if (value.Length != value2.Length)
                return false;

            return new string(value.OrderBy(v => v).ToArray()) == new string(value2.OrderBy(v => v).ToArray());

        }

        static string FormatToDecimal(string value)
        {
            var sb = new StringBuilder();
            int i;
            for (i = 0; i < value.Length / 3; i++)
            {
                sb.Insert(0, "," + value.Substring(value.Length - (3 * (i + 1)), 3));
            }

            if (value.Length % 3 == 0)
                sb.Remove(0, 1);
            else
                sb.Insert(0, value.Substring(0, value.Length % 3));

            return sb.ToString();
        }

        public static long pFactor(long n, long p)
        {
            //866421317361600, 26880
            var list = new List<long>();
            var index = 0;
            long i = 1;
            for (i = 1; i * i < n; i++)
            {
                if (n % i == 0)
                {
                    list.Insert(index, i);
                    list.Insert(list.Count - index++, n / i);
                }
            }
            if (i * i == n)
                list.Insert(index, i);
            return list[(int)p - 1];
        }

        public static int solution(int N)
        {
            var result = 0;
            var i = 1;
            while (i * i < N)
            {
                if (N % i == 0)
                {
                    result += 2;
                }
                i++;
            }
            if (i * i == N)
                result++;
            return result;
        }

        public static List<int> kPerson(int k, List<int> p, List<int> q)
        {
            var result = new List<int>(q.Count);
            var pi = 0;
            for (int i = 0; i < q.Count; i++)
            {
                var cap = k;
                if (pi >= p.Count - 1)
                {
                    result.Add(0);
                }
                for (int j = pi; j < p.Count; j++)
                {
                    if (p[j] >= q[i])
                    {
                        cap--;
                    }
                    if (cap == 0)
                    {
                        result.Add(j + 1);
                        pi = j;
                        break;
                    }
                    pi = j;
                }
            }

            return result;
        }

        public static int cleverRobot(List<float> weight)
        {
            var trips = 0;
            var sortedWs = weight.OrderByDescending(w => w).ToList();
            for (int i = 0; i < sortedWs.Count; i++)
            {
                if (sortedWs[i] > 1.99f)
                {
                    trips++;
                    continue;
                }
                if (sortedWs[i] + sortedWs[sortedWs.Count() - 1] <= 3)
                {
                    sortedWs.RemoveAt(sortedWs.Count() - 1);
                }
                trips++;
            }

            return trips;
        }

        public static string biggestPiece(int[] radii, int numberOfGuests)
        {
            decimal result = 0;
            radii = radii.OrderBy(r => r).ToArray();
            var areas = new decimal[radii.Length];
            var cakeSliceSizes = new List<decimal>();

            for (int i = 0; i < radii.Length; i++)
            {
                var rad = (decimal)3.14159265359 * (decimal)radii[i] * (decimal)radii[i];
                areas[i] = rad;
                for (int j = 1; j <= numberOfGuests; j++)
                {
                    cakeSliceSizes.Add(rad / j);
                }

            }

            cakeSliceSizes = cakeSliceSizes.Distinct().OrderByDescending(r => r).ToList();
            var ri = 0;
            var guestsServed = 0;
            for (int i = radii.Length - 1; i >= 0; i--)
            {
                var slices = (int)(areas[i] / cakeSliceSizes[ri]);
                if (slices == 0)
                {
                    ri++;
                    i = radii.Length;
                    guestsServed = 0;
                    continue;
                }

                guestsServed += slices;
                if (guestsServed == numberOfGuests)
                    return cakeSliceSizes[ri].ToString("N" + 4);

            }

            return "Not enough cake";
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
                if (word[i] == word[i + 1])
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

        static List<int> freqQuery2(List<List<int>> queries)
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
