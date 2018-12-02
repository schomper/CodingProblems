using NUnit.Framework;
using System.Collections.Generic;
using ProblemsSolution;
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

        
    }
}
