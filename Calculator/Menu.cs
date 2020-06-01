using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu
{
    public class Menu
    {
        public Stack<int> numbers;
        public Stack<char> action;

        public Menu()
        {
            numbers = new Stack<int>();
            action = new Stack<char>();
        }

        public void Calculation()
        {
            int lastnumber1 = numbers.Pop();
            int lastnumber2 = numbers.Pop();

            switch (action.Pop())
            {
                case '*':
                    lastnumber1 = lastnumber2 * lastnumber1;
                    numbers.Push(lastnumber1);
                    break;
                case '/':
                    if (lastnumber1 == 0)
                    {
                        lastnumber1 = 0;
                    }
                    else
                    {
                        lastnumber1 = lastnumber2 / lastnumber1;
                    }
                    numbers.Push(lastnumber1);
                    break;
                case '+':
                    lastnumber1 = lastnumber2 + lastnumber1;
                    numbers.Push(lastnumber1);
                    break;
                case '-':
                    lastnumber1 = lastnumber2 - lastnumber1;
                    numbers.Push(lastnumber1);
                    break;
            }
        }


        public int AddNumber(string stroka, int idx)
        {
            int count = 0;
            if (idx <= stroka.Length - 1)
            {
                if (int.TryParse(stroka[idx].ToString(), out int i))
                {
                    count++;
                    count += AddNumber(stroka, idx + 1);
                }
            }
            return count;
        }


        public void FindBracket()
        {
            if (action.Peek() == '(')
            {
                action.Pop();
            }
            else
            {
                while (action.Peek() != '(')
                {
                    Calculation();
                }
                action.Pop();
            }
        }
        public int Prior(char Input)
        {
            switch (Input)
            {
                case '^': return 6;
                case '*': return 5;
                case '/': return 5;
                case '+': return 4;
                case '-': return 4;
                case ')': return 2;
                case '(': return 1;
                default: return 0;
            }

        }
    }
}
