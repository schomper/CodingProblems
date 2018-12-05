using ProblemsSolution.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProblemsSolution
{
    public static class FirstTenProblems
    {
        /// <summary>
        /// Given a list of numbers and a number k, return whether any two numbers from the list add up to k.
        /// For example, given[10, 15, 3, 7] and k of 17, return true since 10 + 7 is 17.
        ///
        /// Bonus: Can you do this in one pass?
        /// </summary>
        public static bool ContainsComponentsOf(List<int> numbers, int total)
        {
            HashSet<int> requiredComplements = new HashSet<int>();

            foreach(var number in numbers)
            {
                if (requiredComplements.Contains(number))
                {
                    return true;
                }
                else
                {
                    requiredComplements.Add(total - number);
                }
            }

            return false;
        }

        /// <summary>
        /// Given an array of integers, return a new array such that each element at index i of the new array is the product of all the numbers in the original array except the one at i.
        /// For example, if our input was[1, 2, 3, 4, 5], the expected output would be[120, 60, 40, 30, 24]. If our input was[3, 2, 1], the expected output would be[2, 3, 6].
        ///
        /// Follow-up: what if you can't use division?
        /// </summary>
        /// <param name="numbers">The array of integers to use</param>
        /// <returns></returns>
        public static int[] ProductsExcludingElement(int[] numbers)
        {
            int[] solution = new int[numbers.Length];
            Queue<int> queue = new Queue<int>(numbers);

            for (int i = 0; i < numbers.Length; i++)
            {
                int element = queue.Dequeue();
                solution[i] = queue.Aggregate(1, (total, next) => total = total * next);

                queue.Enqueue(element);
            }

            return solution;
        }

        /// <summary>
        /// Given the root to a binary tree, implement serialize(root), which serializes the tree into a string, and deserialize(s), which deserializes the string back into the tree.
        /// </summary>
        /// <param name="root">The root node of a binary tree</param>
        /// <returns></returns>
        public static string SerializeBinaryTree(BinaryTreeNode root)
        {
            string treeRepresentation = $"{root.Value}>";

            if (root == null)
            {
                return treeRepresentation;
            }

            if (root.Left == null)
            {
                treeRepresentation += "-";
            }
            else
            {
                string leftNodeRepresentation = SerializeBinaryTree(root.Left);
                treeRepresentation += $"({leftNodeRepresentation})";
            }

            treeRepresentation += ",";

            if (root.Right == null)
            {
                treeRepresentation += "-";
            }
            else
            {
                string rightNodeRepresentation = SerializeBinaryTree(root.Right);
                treeRepresentation += $"({rightNodeRepresentation})";
            }

            return treeRepresentation;
        }

        /// <summary>
        /// Given the root to a binary tree, implement serialize(root), which serializes the tree into a string, and deserialize(s), which deserializes the string back into the tree.
        /// </summary>
        /// <param name="root">The root node of a binary tree</param>
        /// <returns></returns>
        /// "root>(left>(left.left>-,-),-),(right>-,-)";
        public static BinaryTreeNode DeserializeBinaryTree(string treeRepresentation)
        {
            if (treeRepresentation == "-")
            {
                return null;
            }

            string[] split = treeRepresentation.Split('>', 2);
            string value = split[0];
            string subtree = split[1];

            (string left, string right) = GetLeftAndRight(subtree);

            BinaryTreeNode leftNode = DeserializeBinaryTree(left);
            BinaryTreeNode rightNode = DeserializeBinaryTree(right);

            return new BinaryTreeNode(value, leftNode, rightNode);
        }

        private static (string, string) GetLeftAndRight(string treeRepresentation)
        {
            int bracketCount = 0;
            int splitIndex = -1;

            for (int i = 0; i < treeRepresentation.Length; i++)
            {
                if (treeRepresentation[i] == '(')
                {
                    bracketCount++;
                }
                else if (treeRepresentation[i] == ')')
                {
                    bracketCount--;
                }
                else if (treeRepresentation[i] == ',' && bracketCount == 0)
                {
                    splitIndex = i;
                    break;
                }
            }

            string left = treeRepresentation.Substring(0, splitIndex);
            string right = treeRepresentation.Substring(splitIndex+1);

            return (left.Trim(new char[] { '(', ')' }), right.Trim(new char[] { '(', ')' }));
        }

        /// <summary>
        /// Given an array of integers, find the first missing positive integer in linear 
        /// time and constant space. In other words, find the lowest positive integer that 
        /// does not exist in the array. The array can contain duplicates and negative 
        /// numbers as well.
        /// </summary>
        /// <param name="input">The array of integers</param>
        /// <returns></returns>
        public static int GetLowestMissingInt(int[] input)
        {
            int positiveArrayZero = SeparateNegatives(input);

            for (int i = positiveArrayZero; i < input.Length; i++)
            {
                int indexValue = positiveArrayZero + Math.Abs(input[i]) - 1;

                if (indexValue <= input.Length - 1)
                {
                    input[indexValue] = -input[indexValue];
                }
            }

            for (int i = positiveArrayZero; i < input.Length; i++)
            {
                if (input[i] > 0)
                {
                    return i + 1 - positiveArrayZero;
                }
            }

            return input.Length + 1 - positiveArrayZero;
        }

        /// <summary>
        /// Move all the numbers less than 1 to one side of the array and 
        /// return the index of the first number equal or larger than 1 
        /// </summary>
        /// <param name="input">The input array</param>
        /// <returns>The index of the first non negative or non zero number</returns>
        private static int SeparateNegatives(int[] input)
        {
            int lastPositive = 0;

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] <= 0)
                {
                    int temp = input[lastPositive];
                    input[lastPositive] = input[i];
                    input[i] = temp;
                    lastPositive++;
                }
            }

            return lastPositive;
        }
    }
}
