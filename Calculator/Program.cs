using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu
{
    class Calculator
    {
        static void Main(string[] args)
        {

            Menu class1 = new Menu();
            string m = Console.ReadLine();
            int prior;

            for (int i = 0; i < m.Length; i++)
            {
                int act = class1.AddNumber(m, i);
                if (Char.IsDigit(m[i]))
                {
                    if (class1.AddNumber(m, i) != 0)
                    {
                        class1.numbers.Push(Convert.ToInt32(m.Substring(i, act)));
                        i += act - 1;
                    }
                }
                else
                {
                    prior = class1.Prior(m[i]);
                    if (class1.action.Count == 0)
                    {
                        class1.action.Push(m[i]);
                    }

                    else
                    {
                        if (prior != class1.Prior(class1.action.Peek()))
                        {
                            if (prior > class1.Prior(class1.action.Peek()))
                            {
                                class1.action.Push(m[i]);
                            }
                            else
                            {
                                if (prior < class1.Prior(class1.action.Peek()))
                                {
                                    if (prior == 2)
                                    {
                                        class1.FindBracket();
                                    }

                                    else
                                    {
                                        if (prior == 1)
                                        {
                                            class1.action.Push(m[i]);
                                        }
                                        else
                                        {
                                            while (class1.action.Count != 0 && class1.action.Peek() != '(')
                                            {
                                                class1.Calculation();
                                            }
                                            class1.action.Push(m[i]);

                                        }
                                    }
                                }

                            }
                        }

                        else
                        {
                            while (class1.action.Count != 0 && prior == class1.Prior(class1.action.Peek()))
                            {
                                class1.Calculation();
                            }
                            class1.action.Push(m[i]);
                        }
                    }
                }
            }

            while (class1.action.Count != 0)
            {
                class1.Calculation();
            }
            foreach (int i in class1.numbers)
            {
                Console.WriteLine(i);
            }
            Console.ReadKey();
        }
    }
}
