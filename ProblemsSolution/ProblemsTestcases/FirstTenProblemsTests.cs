using NUnit.Framework;
using System.Collections.Generic;
using ProblemsSolution;
using ProblemsSolution.Utilities;
using System;

namespace ProblemsTestcases
{
    [TestFixture]
    public class FirstTenProblemsTests
    {
        [TestCase]
        public void ContainsComponentsOf_OneToTen_True()
        {
            int total = 10;
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            bool result = FirstTenProblems.ContainsComponentsOf(numbers, total);

            Assert.AreEqual(true, result);
        }

        [TestCase]
        public void ContainsComponentsOf_MatchRandomOrder_True()
        {
            int total = 15;
            List<int> numbers = new List<int> { 1, 2, 3, 3, 4, 5, 6, 7, 8 };
            List<int> randomNumbers = new List<int>();

            int numberOfElementsInList = numbers.Count;

            for (int i = numberOfElementsInList; i != 0; i--)
            {
                Random random = new Random();
                int index = random.Next(i);

                randomNumbers.Add(numbers[index]);
                numbers.RemoveAt(index);
            }

            bool result = FirstTenProblems.ContainsComponentsOf(randomNumbers, total);

            Assert.AreEqual(0, numbers.Count);
            Assert.AreEqual(numberOfElementsInList, randomNumbers.Count);
            Assert.AreEqual(true, result);
        }

        [TestCase]
        public void ContainsComponentsOf_MatchIsDouble_True()
        {
            int total = 10;
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 5};
            List<int> randomNumbers = new List<int>();

            int numberOfElementsInList = numbers.Count;

            for (int i = numberOfElementsInList; i != 0; i--)
            {
                Random random = new Random();
                int index = random.Next(i);

                randomNumbers.Add(numbers[index]);
                numbers.RemoveAt(index);
            }

            bool result = FirstTenProblems.ContainsComponentsOf(randomNumbers, total);

            Assert.AreEqual(0, numbers.Count);
            Assert.AreEqual(numberOfElementsInList, randomNumbers.Count);
            Assert.AreEqual(true, result);
        }

        [TestCase]
        public void ContainsComponentsOf_EmptyList_False()
        {
            int total = 2;
            List<int> numbers = new List<int> {};

            bool result = FirstTenProblems.ContainsComponentsOf(numbers, total);

            Assert.AreEqual(false, result);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 }, new int[] { 120, 60, 40, 30, 24 })]
        [TestCase(new int[] { 3, 2, 1 }, new int[] { 2, 3, 6 })]
        public void ProductsExcludingElement_GivenExample_AllRight(int[] input, int[] expected)
        {
            int[] output = FirstTenProblems.ProductsExcludingElement(input);

            for (var i = 0; i < input.Length; i++) 
            {
                Assert.AreEqual(expected[i], output[i]);
            }
        }

        [TestCase]
        public void ProductsExcludingElement_ContainsZero_AllRight()
        {
            int[] input = new int[] { 1, 2, 0, 4 };

            int[] output = FirstTenProblems.ProductsExcludingElement(input);

            Assert.AreEqual(0, output[0]);
            Assert.AreEqual(0, output[1]);
            Assert.AreEqual(1 * 2 * 4, output[2]);
            Assert.AreEqual(0, output[3]);
        }

        [TestCase]
        public void SerializeBinaryTree_ExampleTree()
        {
            BinaryTreeNode node = new BinaryTreeNode("root", new BinaryTreeNode("left", new BinaryTreeNode("left.left", null, null), null), new BinaryTreeNode("right", null, null));
            string expected = "root>(left>(left.left>-,-),-),(right>-,-)";

            string serialized = FirstTenProblems.SerializeBinaryTree(node);

            Assert.AreEqual(expected, serialized);
        }

        [TestCase]
        public void DeserializeBinaryTree_ExampleTree()
        {
            string example = "root>(left>(left.left>-,left.left.right>-,-),-),(right>-,-)";
            BinaryTreeNode node = FirstTenProblems.DeserializeBinaryTree(example);

            Assert.AreEqual(node.Value, "root");
            Assert.AreEqual(node.Left.Value, "left");
            Assert.AreEqual(node.Left.Left.Value, "left.left");
            Assert.AreEqual(node.Left.Left.Right.Value, "left.left.right");
            Assert.AreEqual(node.Right.Value, "right");
        }
    }
}
