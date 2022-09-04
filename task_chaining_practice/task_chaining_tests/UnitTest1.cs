using NUnit.Framework;
using System;
using System.Linq;
using task_chaining_practice;

namespace task_chaining_tests
{
    public class Tests
    {

        [Test]
        public void GenerateArrayTest()
        {
            var actual = Program.GenerateArray();
            Assert.That(actual, Is.Not.Null, "Result must be not NULL");

            Assert.That(actual.GetType().IsArray, "Result must be array");

            Assert.That(actual.GetType().GetElementType() == typeof(int), "Elements of array must be integer");

            Assert.That(actual.Length == 10, "Result array lenght must be equals 10");
        }

        [Test]
        public void MultiplyArrayTest()
        {
            var startArray = new[] { 4, 10, 25, 1, 34, 11, 9, 6, 21, 44 };

            var actual = Program.MultiplyArray(startArray);

            int[] checkArray = new int[10];

            for (int i = 0; i < startArray.Length; i++)
            {
                checkArray[i] = actual[i] / startArray[i];
            }
            var tmp = checkArray[0];
            bool condition = checkArray.Skip(1).All(s => s == tmp);
            Assert.That(condition);
        }
        [Test]
        public void MultiplyArrayTestNullException()
        {
            Assert.Throws<ArgumentNullException>(() => Program.MultiplyArray(null));
        }

        [Test]
        public void AscendingArraySortTest()
        {
            var expected = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var actualArray = Program.AscendingArraySort(new[] { 10, 3, 5, 2, 4, 1, 6, 7, 9, 8 });
            bool condition = true;
            for(int i = 0; i < expected.Length; i++)
            {
                if(expected[i] != actualArray[i])
                {
                    condition = false;
                    break;
                }
            }
            Assert.That(condition, Is.True);
        }
        [Test]
        public void AscendingArraySortTestNullArgument()
        {
            Assert.Throws<ArgumentNullException>(() => Program.AscendingArraySort(null));
        }
        [Test]
        public void CalculateAverageTest()
        {
            var testArray = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var expectedValue = 5;
            var actualAverage = Program.CalculateAverage(testArray);
            Assert.That(actualAverage == expectedValue, Is.True);
        }
        [Test]
        public void CalculateAverageTestNullArgument()
        {
            Assert.Throws<ArgumentNullException>(() => Program.CalculateAverage(null));
        }
    }
}