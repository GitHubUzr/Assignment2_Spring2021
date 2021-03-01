using System;
using System.Collections.Generic;
using System.Linq;
namespace Assignment2_Spring2021
{
    class Program
    {
        static void Main(string[] args)
        {
            //Question1
            //added text for Q1
            Console.WriteLine("Question 1");
            int[] ar1 = { 2, 5, 1, 3, 4, 7 };
            int n1 = 3;
            ShuffleArray(ar1, n1);
            Console.WriteLine("");

            //Question 2 
            Console.WriteLine("Question 2");
            int[] ar2 = { 0, 1, 0, 3, 12 };
            MoveZeroes(ar2);
            Console.WriteLine("");

            //Question3
            Console.WriteLine("Question 3");
            int[] ar3 = { 1, 2, 3, 1, 1, 3 };
            CoolPairs(ar3);
            Console.WriteLine();

            //Question 4
            Console.WriteLine("Question 4");
            int[] ar4 = { 2, 7, 11, 15 };
            int target = 9;
            TwoSum(ar4, target);
            Console.WriteLine();

            //Question 5
            Console.WriteLine("Question 5");
            string s5 = "korfsucy";
            // added calling of method
            int[] indices = { 6, 4, 3, 2, 1, 0, 5, 7 };
            RestoreString(s5, indices);
            Console.WriteLine();

            //Question 6
            Console.WriteLine("Question 6");
            string s61 = "bulls";
            string s62 = "sunny";
            if (Isomorphic(s61, s62))
            {
                Console.WriteLine("Yes the two strings are Isomorphic");
            }
            else
            {
                Console.WriteLine("No, the given strings are not Isomorphic");
            }
            Console.WriteLine();

            //Question 7
            Console.WriteLine("Question 7");
            int[,] scores = { { 1, 91 }, { 1, 92 }, { 2, 93 }, { 2, 97 }, { 1, 60 }, { 2, 77 }, { 1, 65 }, { 1, 87 }, { 1, 100 }, { 2, 100 }, { 2, 76 } };
            HighFive(scores);
            Console.WriteLine();

            //Question 8
            Console.WriteLine("Question 8");
            int n8 = 19;
            if (HappyNumber(n8))
            {
                Console.WriteLine("{0} is a happy number", n8);
            }
            else
            {
                Console.WriteLine("{0} is not a happy number", n8);
            }

            Console.WriteLine();

            //Question 9
            Console.WriteLine("Question 9");
            int[] ar9 = { 7, 1, 5, 3, 6, 4 };
            int profit = Stocks(ar9);
            if (profit == 0)
            {
                Console.WriteLine("No Profit is possible");
            }
            else
            {
                Console.WriteLine("Profit is {0}", profit);
            }
            Console.WriteLine();

            //Question 10
            Console.WriteLine("Question 10");
            int n10 = 3;
            Stairs(n10);
            Console.WriteLine();
        }

        //Question 1
        /// <summary>
        /// Shuffle the input array nums consisting of 2n elements in the form [x1,x2,...,xn,y1,y2,...,yn].
        /// Print the array in the form[x1, y1, x2, y2, ..., xn, yn].
        ///Example 1:
        ///Input: nums = [2,5,1,3,4,7], n = 3
        ///Output: [2,3,5,4,1,7]
        ///  Explanation: Since x1 = 2, x2 = 5, x3 = 1, y1 = 3, y2 = 4, y3 = 7 then the answer is [2,3,5,4,1,7].
        ///Example 2:
        ///Input: nums = [1,2,3,4,4,3,2,1], n = 4
        ///Output: [1,4,2,3,3,2,4,1]
        ///Example 3:
        ///Input: nums = [1,1,2,2], n = 2
        ///Output: [1,2,1,2]
        /// </summary>

        private static void ShuffleArray(int[] nums, int n)
        {
            try
            {
                //method below does not change for large numbers
                //or numbers less than 0
                //as it onlys pulls element from list
                //n, referring to # of x or y elements, should always be >= 0

                //formatting start of output
                Console.Write("[");
                //use indexing to look at x
                for (int i = 0; i < n; i++)
                {
                    // if last x-y combo, then add ending bracket to formatting
                    if (i == n - 1)
                    {
                        //and associated y (i+n spaces ahead)
                        Console.Write("{0}, {1}]", nums[i], nums[i + n]);
                        Console.WriteLine();
                    }
                    // else format just the numbers
                    else
                    {
                        Console.Write("{0}, {1}, ", nums[i], nums[i + n]);
                    }// end of else statement
                }// end of for loop
            }// end of try
            catch (Exception)
            {
                throw;
            }// end of catch
        }// end of method

        //Question 2:
        /// <summary>
        /// Write a method to move all 0's to the end of the given array. You should maintain the relative order of the non-zero elements. 
        /// You must do this in-place without making a copy of the array.
        /// Example:
        ///Input: [0,1,0,3,12]
        /// Output: [1,3,12,0,0]
        /// </summary>

        private static void MoveZeroes(int[] ar2)
        {
            try
            {
                // initial code missed cases with multiple 0s followed by non-zeroes
                // such as [5, 1, 0, 0, 12]
                // has been fixed since
                // checks when i == 0, not when i>0, so it also covers negatives

                //store array length as int, since it's referenced multiple times
                int n = ar2.Length;
                //variable to keep track of index
                int i = 0;
                //variable to keep track of 0s
                int z = 0;

                //Keep looping until there are no 0s left in slice
                //  ar2[..(n-z)] - show me everything in list until index (n-z) (inclusive), reduces each time 0 detected
                //  if there exists an element that equals 0 in selection, condition is true
                //  while true, keep looping
                while (Array.Exists(ar2[..(n - z)], element => element == 0))
                {
                    //if element is 0
                    //move 0 to back and shift list forward by 1
                    if (ar2[i] == 0)
                    {
                        //from current element in list
                        //loop up to penultimate element in list (as we're looking one space ahead)
                        //and shift following elements forward by 1
                        for (int j = i; j < n - 1; j++)
                        {
                            //original list value is replaced with the new value one space ahead
                            //(last item does not need to be replaced since it will be 0)
                            ar2[j] = ar2[j + 1];
                        }
                        //replace last element in list with 0
                        ar2[n - 1] = 0;
                        //increase zero count by 1
                        //so slice looks at a smaller section when checking while loop
                        z++;
                        //decrease i count by 1
                        //after shifting, look at same index item to see if it's zero again
                        i -= 1;
                    }
                    //look at next element in list
                    i++;
                }// end of while loop

                //after looping, print final version of list
                //formatting start of output
                Console.Write("[");
                for (i = 0; i < n; i++)
                {
                    // if last item, then add ending bracket to formatting
                    if (i == n - 1)
                    {
                        Console.Write(ar2[i] + "]" + Environment.NewLine);
                    }
                    // else just print the item
                    else
                    {
                        Console.Write(ar2[i] + ", ");
                    }
                }// end of for loop

            }// end of try
            catch (Exception)
            {
                throw;
            }// end of catch
        }// end of method


        //Question 3
        /// <summary>
        /// For an array of integers - nums
        ///A pair(i, j) is called cool if nums[i] == nums[j] and i<j
        ///Print the number of cool pairs
        ///Example 1
        ///Input: nums = [1,2,3,1,1,3]
        ///Output: 4
        ///Explanation: There are 4 cool pairs (0,3), (0,4), (3,4), (2,5) 
        ///Example 3:
        ///Input: nums = [1, 2, 3]
        ///Output: 0
        ///Constraints: time complexity should be O(n).
        /// </summary>

        private static void CoolPairs(int[] nums)
        {
            try
            {
                // elements in array serve as keys, with total occurences being tracked
                // 0s or negatives should not change this value

                // create new dictionary
                Dictionary<int, int> occurences = new Dictionary<int, int>();
                // create variable to track number of cool pairs
                int cPairs = 0;
                // loop through each value in array
                foreach (int element in nums)
                {
                    // if value already exists in dictionary
                    if (occurences.ContainsKey(element))
                    {
                        // increase # cool pairs by dictionary count
                        cPairs += occurences[element];
                        // dictionary should now have +1 occurences of value
                        // increase dictionary count for next round
                        occurences[element]++;
                    }
                    // if value does not exist in dictionary
                    else
                    {
                        // add it to dictionary with an occurence of 1
                        occurences.Add(element, 1);
                    }
                }// end of for loop

                // print the number of cool pairs
                Console.WriteLine(cPairs);

            }// end of try
            catch (Exception)
            {
                throw;
            }// end of catch
        }// end of method

        //Question 4:
        /// <summary>
        /// Given integer target and an array of integers, print indices of the two numbers such that they add up to the target.
        ///You may assume that each input would have exactly one solution, and you may not use the same element twice.
        /// You can print the answer in any order
        ///Example 1:
        ///Input: nums = [2,7,11,15], target = 9
        /// Output: [0,1]
        ///Output: Because nums[0] + nums[1] == 9, we print [0, 1].
        ///Example 2:
        ///Input: nums = [3,2,4], target = 6
        ///Output: [1,2]
        ///Example 3:
        ///Input: nums = [3,3], target = 6
        ///Output: [0,1]
        ///Constraints: Time complexity should be O(n)
        /// </summary>
        private static void TwoSum(int[] nums, int target)
        {
            try
            {
                // two pointer solution - has O(n) complexity
                // works only in pre-sorted array
                // example 2 shows even though i cannot equal j, nums[i] can equal nums[j]
                // works with zeroes and negatives

                // first pointer, starts at first item in array
                int i = 0;
                // second pointer, starts at end of array
                int j = nums.Length - 1;
                // if i == j, you're looking at the same element
                // similar to binary search, if i > j the pointers have
                // flipped and you've reached the end of your search
                while (i < j)
                {
                    // add the values of each pointer
                    // if sum equals target
                    if (nums[i] + nums[j] == target)
                    {
                        //print where the sum was found (1-indexed)
                        Console.WriteLine("[{0}, {1}]", i + 1, j + 1);
                        // end function
                        return;
                    }
                    // if sum is less than target
                    else if (nums[i] + nums[j] < target)
                    {
                        // move towards higher values by increasing first pointer (i++)
                        i++;
                    }
                    // if sum is greater than target
                    else
                    {
                        // move towards lower values by decreasing second pointer (j--)
                        j--;
                    }
                } // end of while loop

                // if you reach the end of the while loop
                // you've looked at all items in the array without getting the target sum
                Console.WriteLine("No pair found with given sum.");
                // function ends on its own

            }// end of try
            catch (Exception)
            {

                throw;
            }// end of catch

        }// end of method

        //Question 5:
        /// <summary>
        /// Given a string s and an integer array indices of the same length.
        ///The string s will be shuffled such that the character at the ith position moves to indices[i] in the shuffled string.
        ///Print the shuffled string.
        ///Example 1
        ///Input: s = "korfsucy", indices = [6,4,3,2,1,0,5,7]
        ///Output: "usfrocky"
        ///Explanation: As shown in the assignment document, “K” should be at index 6, “O” should be at index 4 and so on. “korfsucy” becomes “usfrocky”
        ///Example 2:
        ///Input: s = "USF", indices = [0,1,2]
        ///Output: "USF"
        ///Explanation: After shuffling, each character remains in its position.
        ///Example 3:
        ///Input: s = "ockry", indices = [1, 2, 3, 0, 4]
        ///Output: "rocky"
        /// </summary>
        private static void RestoreString(string s, int[] indices)
        {
            try
            {
                // create new array of size n
                char[] sArray = new char[s.Length];
                // loop through n times
                for (int i = 0; i < s.Length; i++)
                {
                    // place current string element
                    // in specified position of new array
                    sArray[indices[i]] = s[i];
                }
                // print characters in array
                foreach (char element in sArray)
                {
                    Console.Write(element);
                } // end of for loop
                Console.WriteLine();
            }// end of try
            catch (Exception)
            {
                throw;
            }// end of catch
        }// end of method

        //Question 6
        /// <summary>
        /// Determine whether two give strings s1 and s2, are isomorphic.
        ///Two strings are isomorphic if the characters in s1 can be replaced to get s2.
        ///All occurrences of a character must be replaced with another character while preserving the order of characters.
        ///No two characters may map to the same character but a character may map to itself.
        ///Example 1:
        ///Input:s1 = “bulls” s2 = “sunny” 
        ///Output : True
        ///Explanation: ‘b’ can be replaced with ‘s’ and similarly ‘u’ with ‘u’, ‘l’ with ‘n’ and ‘s’ with ‘y’.
        ///Example 2:
        ///Input: s1 = “usf” s2 = “add”
        ///Output : False
        ///Explanation: ‘u’ can be replaced with ‘a’, but ‘s’ and ‘f’ should be replaced with ‘d’ to produce s2, which is not possible. So False.
        ///Example 3:
        ///Input : s1 = “ab” s2 = “aa”
        ///Output: False
        /// </summary>
        private static bool Isomorphic(string s1, string s2)
        {
            try
            {
                // create a dictionary
                Dictionary<char, char> charSwap = new Dictionary<char, char>();
                // create bool
                bool ans = true;
                // go through string1, assigning each character a corresponding
                // value to transform to (can be same character) in order to match string2
                // the value it's changing to will be stored as a key
                // if a key is already being used to transform some other character
                // string1 can't change to string2
                for (int i = 0; i < s1.Length; i++)
                {
                    // if key in dict
                    if (charSwap.ContainsKey(s2[i]))
                    {
                        // if current character is not the same character
                        // as what that key is already transforming
                        if (s1[i] != charSwap[s2[i]])
                        {
                            // answer is false
                            ans = false;
                            // end loop
                            break;
                        }
                    }
                    // if not in dictionary, add key-value pair
                    else
                    {
                        // key is transformed character
                        // which can only be used to switch those same as current s1 character
                        charSwap.Add(s2[i], s1[i]);
                    }// end of else statement
                }// end of for loop

                // return bool value
                return ans;

            }// end of try
            catch (Exception)
            {
                throw;
            }// end of catch
        }// end of method

        //Question 7
        /// <summary>
        /// Given a list of the scores of different students, items, where items[i] = [IDi, scorei] represents one score from a student with IDi, calculate each student's top five average.
        /// Print the answer as an array of pairs result, where result[j] = [IDj, topFiveAveragej] represents the student with IDj and their top five average.Sort result by IDj in increasing order.
        /// A student's top five average is calculated by taking the sum of their top five scores and dividing it by 5 using integer division.
        /// Example 1:
        /// Input: items = [[1, 91], [1,92], [2,93], [2,97], [1,60], [2,77], [1,65], [1,87], [1,100], [2,100], [2,76]]
        /// Output: [[1,87],[2,88]]
        /// Explanation: 
        /// The student with ID = 1 got scores 91, 92, 60, 65, 87, and 100. Their top five average is (100 + 92 + 91 + 87 + 65) / 5 = 87.
        /// The student with ID = 2 got scores 93, 97, 77, 100, and 76. Their top five average is (100 + 97 + 93 + 77 + 76) / 5 = 88.6, but with integer division their average converts to 88.
        /// Example 2:
        /// Input: items = [[1,100],[7,100],[1,100],[7,100],[1,100],[7,100],[1,100],[7,100],[1,100],[7,100]]
        /// Output: [[1,100],[7,100]]
        /// Constraints:
        /// 1 <= items.length <= 1000
        /// items[i].length == 2
        /// 1 <= IDi <= 1000
        /// 0 <= scorei <= 100
        /// For each IDi, there will be at least five scores.
        /// </summary>
        private static void HighFive(int[,] items)
        {
            try
            {
                // create a dictionary to collect values for each id
                Dictionary<int, List<int>> studentScores = new Dictionary<int, List<int>>();
                // length finds length of array in all dimensions (starting with 0)
                // GetUpperBound finds length of specified dimension, specifically, index of last element in dimension
                // which can be visualized as length of dimension with x + 1
                // use GetUpperBound to find # elements in 1st dimension of items array (# scores to collect)
                int itemsDim0 = items.GetUpperBound(0) + 1;
                // for every score listed...
                for (int i = 0; i < itemsDim0; i++)
                {
                    // set student and score into variables
                    int student = items[i, 0];
                    int score = items[i, 1];
                    // if student already in dictionary...
                    if (studentScores.ContainsKey(student))
                    {
                        // if # scores stored is less than 5
                        if (studentScores[student].Count < 5)
                        {
                            // add score to list
                            studentScores[student].Add(score);
                            // sort list so smallest in front
                            studentScores[student].Sort();
                        }
                        // if student already has 5 scores
                        else
                        {
                            // add score only if it's greater than smallest in list (which should be listed 1st)
                            if (score > studentScores[student][0])
                            {
                                // add score to list
                                studentScores[student].Add(score);
                                // sort again so smallest in front, in case another possible score shows
                                studentScores[student].Sort();
                            }
                        }
                    }
                    // if not in dictionary, add student
                    else
                    {
                        // create list of scores for that student, starting with first score shown
                        List<int> scoresList = new List<int>() { score };
                        studentScores.Add(student, scoresList);
                    }// end of else statement
                }// end of for loop

                //// look at current dictionary
                //foreach (KeyValuePair<int, List<int>> kvp in studentScores)
                //{
                //    Console.WriteLine("student = {0}", kvp.Key);
                //    foreach (var i in kvp.Value)
                //    {
                //        Console.Write(i + " ");
                //    }
                //    Console.WriteLine();
                //}

                // loop through dictionary to get average of each student (integer division by default)
                // replace score list with average for each student
                for (int i = 0; i < studentScores.Count; i++)
                {
                    int avg = studentScores.ElementAt(i).Value.Sum() / 5;
                    int student = studentScores.ElementAt(i).Key;
                    studentScores[student] = new List<int>() { avg };
                }

                // order by id, ascending
                // in case ids were not given in ascending order
                var sortedDict = studentScores.OrderBy(x => x.Key);

                // print output
                int count = 0;
                // formatting start of output
                Console.Write("[");
                // print each key-value pair in the sorted dictionary
                foreach (KeyValuePair<int, List<int>> kvp in sortedDict)
                {
                    // if last item in dictionary, add ending bracket to formatting
                    if (count == studentScores.Count - 1)
                    {
                        Console.Write("[{0}, {1}]", kvp.Key, kvp.Value[0]);
                    }
                    // else print key-value pair only
                    else
                    {
                        Console.Write("[{0}, {1}], ", kvp.Key, kvp.Value[0]);
                    }
                    count++;
                }
                // format final bracket of 2d array
                Console.Write("]"+Environment.NewLine);

            }// end of try
            catch (Exception)
            {
                throw;

            }// end of catch
        }// end of method

        //Question 8
        /// <summary>
        /// Write an algorithm to determine if a number n is happy.
        ///A happy number is a number defined by the following process:
        ///•	Starting with any positive integer, replace the number by the sum of the squares of its digits.
        ///•	Repeat the process until the number equals 1 (where it will stay), or it loops endlessly in a cycle which does not include 1.
        ///•	Those numbers for which this process ends in 1 are happy.
        ///Return true if n is a happy number, and false if not.
        ///Example 1:
        ///Input: n = 19
        ///Output: true
        ///Explanation:
        ///12 + 92 = 82
        ///82 + 22 = 68
        ///62 + 82 = 100
        ///12 + 02 + 02 = 1
        ///Example 2:
        ///Input: n = 2
        ///Output: false
        ///Constraints:
        ///1 <= n <= 231 - 1
        /// </summary>

        private static bool HappyNumber(int n)
        {
            try
            {
                //Read each digit

                //// casting method - a little slower
                //string nStr = Convert.ToString(n);
                //foreach (char digit in nStr)
                //{
                //    Console.Write(Char.GetNumericValue(digit) + " ");
                //}
                //Console.WriteLine();

                // recursive method
                List<int> digits = new List<int>();
                separateDigits(n, digits);

                // create list of sums
                List<int> allSums = new List<int>();
                // set sum as 0 for 1st round
                int sum = 0;
                // while process does not end in 1
                // (while number is not happy)
                while (sum != 1)
                {
                    // reset sum to 0
                    sum = 0;
                    // look at each digit
                    foreach (int d in digits)
                    {
                        // take the square of each digit and add it to the sum
                        sum += Convert.ToInt32(Math.Pow(d, 2));
                    }
                    // if sum has already been recorded, stop
                    if (allSums.Contains(sum))
                    {
                        // you're back to where you once were
                        // and will start looping endlessly
                        // instead stop function and return false
                        return false;
                    }
                    // if it's a new sum, add to list and continue
                    else
                    {
                        allSums.Add(sum);
                    }
                    // reset list of digits
                    digits = new List<int>();
                    // use recursion to find new list of digits for current sum
                    separateDigits(sum, digits);
                }
                // if you exit the while loop (that is, sum equals 0)
                // return true since number is happy
                return true;
            }// end of try
            catch (Exception)
            {

                throw;
            }// end of catch
        }// end of method

        // recursive method to find number of digits
        private static void separateDigits(int m, List<int> mList)
        {
            // if a single digit
            if (m < 10)
            {
                // return the digit and end method
                mList.Add(m);
                return;
            }
            // reduce by 10 and repeat
            separateDigits(m / 10, mList);
            // return last digit
            mList.Add(m % 10);
        }// end of method

        //Question 9
        /// <summary>
        /// Professor Manish is planning to invest in stocks. He has the data of the price of a stock for the next n days.  
        /// Tell him the maximum profit he can earn from the given stock prices.Choose a single day to buy a stock and choose another day in the future to sell the stock for a profit
        /// If you cannot achieve any profit return 0.
        /// Example 1:
        /// Input: prices = [7,1,5,3,6,4]
        /// Output: 5
        /// Explanation: Buy on day 2 (price = 1) and sell on day 5 (price = 6), profit = 6-1 = 5.
        /// Note that buying on day 2 and selling on day 1 is not allowed because you must buy before you sell.
        /// Example 2:
        /// Input: prices = [7,6,4,3,1]
        /// Output: 0
        ///Explanation: In this case, no transactions are done and the max profit = 0.
        ///Try to solve it in O(n) time complexity.
        /// </summary>

        private static int Stocks(int[] prices)
        {
            try
            {
                //write your code here.
                return 0;
            }
            catch (Exception)
            {

                throw;
            }
        }

        //Question 10
        /// <summary>
        /// Professor Clinton is climbing the stairs in the Muma College of Business. He generally takes one or two steps at a time.
        /// One day he came across an idea and wanted to find the total number of unique ways that he can climb the stairs. Help Professor Clinton.
        /// Print the number of unique ways. 
        /// Example 1:
        ///Input: n = 2
        ///Output: 2
        ///Explanation: There are two ways to climb to the top.
        ///1. 1 step + 1 step
        ///2. 2 steps
        ///Example 2:
        ///Input: n = 3
        ///Output: 3
        ///Explanation: There are three ways to climb to the top.
        ///1. 1 step + 1 step + 1 step
        ///2. 1 step + 2 steps
        ///3. 2 steps + 1 step
        ///Hint : Use the concept of Fibonacci series.
        /// </summary>

        private static void Stairs(int steps)
        {
            try
            {
                //write your code here.

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
