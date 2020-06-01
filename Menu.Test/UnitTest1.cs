
using NUnit.Framework;
using System;


namespace Menu.Tests
{

    [TestFixture]
    public class UnitTest1
    {
        [TestCase(1,2,3,'+')]
        [TestCase(5, 2, 3, '-')]
        [TestCase(2, 12, 24, '*')]
        [TestCase(8, 2, 4, '/')]
        public void TestCalculation(int a, int b, int exp, char c)
        {
            Menu Menu = new Menu();

            Menu.numbers.Clear();
            Menu.action.Clear();
            Menu.action.Push(c);
            Menu.numbers.Push(a);
            Menu.numbers.Push(b);
            int expected = exp;
            Menu.Calculation();
            int actual = Menu.numbers.Pop();

            Assert.AreEqual(exp, actual);
        }

        [Test]
        public void TestAddnumber()
        {
            Menu Menu = new Menu();
            Menu.action.Clear();
            Menu.numbers.Clear();
            int act = Menu.AddNumber("2+222*2", 2);
            int exp = 3;
            Assert.AreEqual(exp, act);
        }

        [TestCase('(', 1)]
        [TestCase(')', 2)]
        [TestCase('+', 3)]
        [TestCase('-', 3)]
        [TestCase('*', 4)]
        [TestCase('/', 4)]
        public void TestPrior(char znak, int exp)
        {
            Menu Menu = new Menu();
            Menu.action.Clear();
            Menu.numbers.Clear();
            int act = Menu.Prior(znak);
            Assert.AreEqual(exp, act);

        }
        [Test]

        public void TestBracketOut()
        {
            Menu Menu = new Menu();
            Menu.action.Clear();
            Menu.numbers.Clear();
            Menu.action.Push('+');
            Menu.action.Push('(');
            Menu.FindBracket();
            char exp = '+';
            char act = Menu.action.Pop();
            Assert.AreEqual(exp, act);
        }
    }
}
