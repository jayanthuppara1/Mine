using System;
using System.Collections.Generic;
using System.Text;

namespace ISM6225_Spring_2024_Assignment_2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Question 1: Remove Duplicates from Sorted Array
            Console.WriteLine("Question 1 and Output2:");
            int[] nums1_1 = { 0, 0, 1, 1, 1, 2, 2, 3, 3, 4 };
            int numberOfUniqueNumbers = RemoveDuplicates(nums1_1);
            Console.WriteLine(numberOfUniqueNumbers);

            // Example 1.2
            Console.WriteLine("Question 1 and Output1:");
            int[] nums1_2 = { 1, 1, 2 };
            int numberUniqueNumbers = RemoveDuplicates(nums1_2);
            Console.WriteLine(numberUniqueNumbers);


            // Question 2: Move Zeroes
            Console.WriteLine("Question 2 and Output1:");
            int[] nums2_1 = { 0, 1, 0, 3, 12 };
            IList<int> resultAfterMovingZero = MoveZeroes(nums2_1);
            string combinationsString = ConvertIListToArray(resultAfterMovingZero);
            Console.WriteLine(combinationsString);

            // Example 2.2 :
            Console.WriteLine("Question 2 and Output2:");
            int[] nums2_2 = { 0 };
            IList<int> AfterMovingZero = MoveZeroes(nums2_2);
            string combinationString = ConvertIListToArray(AfterMovingZero);
            Console.WriteLine(combinationString);

            // Question 3: 3Sum
            Console.WriteLine("Question 3 and Output1:");
            int[] nums3 = { -1, 0, 1, 2, -1, -4 };
            IList<IList<int>> triplets = ThreeSum(nums3);
            string tripletResult = ConvertIListToNestedList(triplets);
            Console.WriteLine(tripletResult);

            // Example 3.2 :
            Console.WriteLine("Question 3 and output2:");
            int[] nums3_1 = { 0, 1, 1 };
            IList<IList<int>> triplet = ThreeSum(nums3_1);
            string tripletsResult = ConvertIListToNestedList(triplet);
            Console.WriteLine(tripletsResult);

            // Question 4: Max Consecutive Ones
            Console.WriteLine("Question 4 and Output1:");
            int[] nums4 = { 1, 1, 0, 1, 1, 1 };
            int maxOnes = FindMaxConsecutiveOnes(nums4);
            Console.WriteLine(maxOnes);

            // Example 4.2:
            Console.WriteLine("Question 4 and Output2:");
            int[] nums4_2 = { 1, 0, 1, 1, 0, 1 };
            int maxOne = FindMaxConsecutiveOnes(nums4_2);
            Console.WriteLine(maxOne);

            // Question 5: Binary to Decimal Conversion
            Console.WriteLine("Question 5 and Output1:");
            int binaryInput = 101010;
            int decimalResult = BinaryToDecimal(binaryInput);
            Console.WriteLine(decimalResult);

            // Question 6: Maximum Gap
            Console.WriteLine("Question 6 and Output1:");
            int[] nums5 = { 3, 6, 9, 1 };
            int maxGap = MaximumGap(nums5);
            Console.WriteLine(maxGap);

            // Example 6.2:
            Console.WriteLine("Question 6 and Output2:");
            int[] nums5_1 = { 10 };
            int maxGapp = MaximumGap(nums5_1);
            Console.WriteLine(maxGapp);

            // Question 7: Largest Perimeter Triangle
            Console.WriteLine("Question 7 and Output1:");
            int[] nums6 = { 2, 1, 2 };
            int largestPerimeterResult = LargestPerimeter(nums6);
            Console.WriteLine(largestPerimeterResult);

            // Example 7.2:
            Console.WriteLine("Question 7 and Output2:");
            int[] nums6_2 = { 1, 2, 1, 10 };
            int largestPeriResult = LargestPerimeter(nums6_2);
            Console.WriteLine(largestPeriResult);

            // Question 8: Remove Occurrences of a Substring
            Console.WriteLine("Question 8 and Output1:");
            string result = RemoveOccurrences("daabcbaabcbc", "abc");
            Console.WriteLine(result);

            // Example 8.2:
            Console.WriteLine("Question 8 and Output2:");
            string r = RemoveOccurrences("axxxxyyyyb", "xy");
            Console.WriteLine(r);
        }

        // Question 1: Remove Duplicates from Sorted Array
        // Self-Reflection: As a newcomer to C#, I learned about array manipulation and conditional statements.
        public static int RemoveDuplicates(int[] nums)
        {
            try
            {
                // Check if the array is empty
                if (nums.Length == 0) return 0;

                int index = 0;
                for (int i = 1; i < nums.Length; i++)
                {
                    // If current element is different from previous, increment index and replace value
                    if (nums[i] != nums[index])
                    {
                        index++;
                        nums[index] = nums[i];
                    }
                }
                // Return length of unique numbers
                return index + 1;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 2: Move Zeroes
        // Self-Reflection: This exercise helped me understand loop structures and basic array manipulation.
        public static IList<int> MoveZeroes(int[] nums)
        {
            try
            {
                if (nums == null || nums.Length == 0)
                    return new List<int>();

                int zeroCount = 0;

                for (int i = 0; i < nums.Length; i++)
                {
                    if (nums[i] == 0)
                    {
                        zeroCount++;
                    }
                    else if (zeroCount > 0)
                    {
                        nums[i - zeroCount] = nums[i];
                        nums[i] = 0;
                    }
                }

                return nums;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 3: 3Sum
        // Self-Reflection: This problem enhanced my understanding of array manipulation and nested loops.
        public static IList<IList<int>> ThreeSum(int[] nums)
        {
            Array.Sort(nums);
            List<IList<int>> result = new List<IList<int>>();

            for (int i = 0; i < nums.Length - 2; i++)
            {
                if (i > 0 && nums[i] == nums[i - 1]) continue;
                int left = i + 1, right = nums.Length - 1;
                while (left < right)
                {
                    int sum = nums[i] + nums[left] + nums[right];
                    if (sum == 0)
                    {
                        result.Add(new List<int> { nums[i], nums[left], nums[right] });
                        while (left < right && nums[left] == nums[left + 1]) left++;
                        while (left < right && nums[right] == nums[right - 1]) right--;
                        left++;
                        right--;
                    }
                    else if (sum < 0)
                        left++;
                    else
                        right--;
                }
            }

            return result;
        }

        // Question 4: Max Consecutive Ones
        // Self-Reflection: This task improved my understanding of loops and conditional statements.
        public static int FindMaxConsecutiveOnes(int[] nums)
        {
            try
            {
                if (nums == null || nums.Length == 0)
                    return 0;

                int maxCount = 0;
                int count = 0;
                foreach (var num in nums)
                {
                    if (num == 1)
                    {
                        count++;
                        maxCount = Math.Max(maxCount, count);
                    }
                    else
                        count = 0;
                }
                return maxCount;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 5: Binary to Decimal Conversion
        // Self-Reflection: This problem deepened my understanding of arithmetic operations.
        public static int BinaryToDecimal(int binary)
        {
            try
            {
                int decimalNumber = 0;
                int baseValue = 1;
                while (binary > 0)
                {
                    int remainder = binary % 10;
                    decimalNumber += remainder * baseValue;
                    binary /= 10;
                    baseValue *= 2;
                }
                return decimalNumber;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 6: Maximum Gap
        // Self-Reflection: This exercise expanded my knowledge of array sorting and manipulation.
        public static int MaximumGap(int[] nums)
        {
            try
            {
                if (nums == null || nums.Length < 2)
                    return 0;

                Array.Sort(nums);
                int maxGap = 0;
                for (int i = 0; i < nums.Length - 1; i++)
                {
                    maxGap = Math.Max(maxGap, nums[i + 1] - nums[i]);
                }
                return maxGap;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 7: Largest Perimeter Triangle
        // Self-Reflection: This task improved my understanding of loop structures and conditionals.
        public static int LargestPerimeter(int[] nums)
        {
            try
            {
                if (nums == null || nums.Length < 3)
                    return 0;

                Array.Sort(nums);
                for (int i = nums.Length - 1; i >= 2; i--)
                {
                    if (nums[i - 2] + nums[i - 1] > nums[i])
                        return nums[i - 2] + nums[i - 1] + nums[i];
                }
                return 0;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 8: Remove Occurrences of a Substring
        // Self-Reflection: This problem enhanced my understanding of string manipulation and indexing.
        public static string RemoveOccurrences(string s, string part)
        {
            try
            {
                while (s.Contains(part))
                {
                    int index = s.IndexOf(part);
                    s = s.Remove(index, part.Length);
                }
                return s;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /* Inbuilt Functions - Don't Change the below functions */
        static string ConvertIListToNestedList(IList<IList<int>> input)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("["); // Add the opening square bracket for the outer list

            for (int i = 0; i < input.Count; i++)
            {
                IList<int> innerList = input[i];
                sb.Append("[" + string.Join(",", innerList) + "]");

                // Add a comma unless it's the last inner list
                if (i < input.Count - 1)
                {
                    sb.Append(",");
                }
            }

            sb.Append("]"); // Add the closing square bracket for the outer list

            return sb.ToString();
        }

        static string ConvertIListToArray(IList<int> input)
        {
            // Create an array to hold the strings in input
            string[] strArray = new string[input.Count];

            for (int i = 0; i < input.Count; i++)
            {
                strArray[i] = "" + input[i] + ""; // Enclose each string in double quotes
            }

            // Join the strings in strArray with commas and enclose them in square brackets
            string result = "[" + string.Join(",", strArray) + "]";

            return result;
        }
    }
}




// NOTE: I have added second test case for every problem at the main method to check the outputs. I have also Included self-reflection for each problem at its respective meathod.s
