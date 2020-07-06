using System;
using System.Collections.Generic;

namespace ConsoleApp1
{

    class Test
    {
        static int[,] Matrix_Three = new int[3, 8];
        static int[,] Matrix_Two = new int[2, 4];
        static int[,] Matrix_One = new int[1, 2];

        static int count, count2, nakopitel = 0, konynk = 0, dezunk = 0, eqivalent = 0, implik = 0;

        static string viragenie;

        static void one()
        {

        }

        static void two()
        {
            if (konynk == 1)
            {

                Console.WriteLine(viragenie.Split('&')[0].Trim(' ') + "  " + viragenie.Split('&')[1].Trim(' ') + "  " + viragenie.Split('&')[0].Trim(' ') + " & " + viragenie.Split('&')[1].Trim(' '));

                for (count = 0; count < 4; count++)
                {
                    Console.WriteLine(Matrix_Two[0, count] + "  " + Matrix_Two[1, count] + "    " + (Matrix_Two[0, count] & Matrix_Two[1, count]));
                }

            }

            if (dezunk == 1)
            {

                Console.WriteLine(viragenie.Split('+')[0].Trim(' ') + "  " + viragenie.Split('+')[1].Trim(' ') + "  " + viragenie.Split('+')[0].Trim(' ') + " + " + viragenie.Split('+')[1].Trim(' '));

                for (count = 0; count < 4; count++)
                {
                    Console.WriteLine(Matrix_Two[0, count] + "  " + Matrix_Two[1, count] + "    " + (Matrix_Two[0, count] | Matrix_Two[1, count]));
                }

            }

            if (eqivalent == 1)
            {

                Console.WriteLine(viragenie.Split('~')[0].Trim(' ') + "  " + viragenie.Split('~')[1].Trim(' ') + "  " + viragenie.Split('~')[0].Trim(' ') + " ~ " + viragenie.Split('~')[1].Trim(' '));

                for (count = 0; count < 4; count++)
                {
                    Console.WriteLine(Matrix_Two[0, count] + "  " + Matrix_Two[1, count] + "    " + Convert.ToInt32(Matrix_Two[0, count] == Matrix_Two[1, count]));
                }

            }

            if (implik == 1)
            {

                Console.WriteLine(viragenie.Split('>')[0].Trim(' ') + "  " + viragenie.Split('>')[1].Trim(' ') + "  " + viragenie.Split('>')[0].Trim(' ') + " > " + viragenie.Split('>')[1].Trim(' '));

                for (count = 0; count < 4; count++)
                {
                    Console.WriteLine(Matrix_Two[0, count] + "  " + Matrix_Two[1, count] + "    " + Convert.ToInt32(!Convert.ToBoolean(Matrix_Two[0, count]) | Convert.ToBoolean(Matrix_Two[1, count])));
                }

            }

        }

        static void three()
        {
            if (konynk == 2)
            {
                Console.WriteLine(viragenie.Split('&')[0].Trim(' ') + "  " + viragenie.Split('&')[1].Trim(' ') + "  " + viragenie.Split('&')[2].Trim(' ') + " " + viragenie.Split('&')[0].Trim(' ') + "&" + viragenie.Split('&')[1].Trim(' ') + " " + viragenie.Split('&')[0].Trim(' ') + "&" + viragenie.Split('&')[1].Trim(' ') + "&" + viragenie.Split('&')[2].Trim(' '));

                for (count = 0; count < 8; count++)
                {
                    Console.WriteLine(Matrix_Three[0, count] + "  " + Matrix_Three[1, count] + "  " + Matrix_Three[2, count] + "  " + Convert.ToInt32(Convert.ToBoolean(Matrix_Three[0, count]) & Convert.ToBoolean(Matrix_Three[1, count])) + "    " + Convert.ToInt32(Convert.ToBoolean(Matrix_Three[0, count]) & Convert.ToBoolean(Matrix_Three[1, count]) & Convert.ToBoolean(Matrix_Three[2, count])));
                }
            }
            else if (dezunk == 2)
            {
                Console.WriteLine(viragenie.Split('+')[0].Trim(' ') + "  " + viragenie.Split('+')[1].Trim(' ') + "  " + viragenie.Split('+')[2].Trim(' ') + " " + viragenie.Split('+')[0].Trim(' ') + "+" + viragenie.Split('+')[1].Trim(' ') + " " + viragenie.Split('+')[0].Trim(' ') + "+" + viragenie.Split('+')[1].Trim(' ') + "+" + viragenie.Split('+')[2].Trim(' '));

                for (count = 0; count < 8; count++)
                {
                    Console.WriteLine(Matrix_Three[0, count] + "  " + Matrix_Three[1, count] + "  " + Matrix_Three[2, count] + "  " + Convert.ToInt32(Convert.ToBoolean(Matrix_Three[0, count]) | Convert.ToBoolean(Matrix_Three[1, count])) + "    " + Convert.ToInt32(Convert.ToBoolean(Matrix_Three[0, count]) | Convert.ToBoolean(Matrix_Three[1, count]) | Convert.ToBoolean(Matrix_Three[2, count])));
                }

            }
            else if (implik == 2)
            {
                Console.WriteLine(viragenie.Split('~')[0].Trim(' ') + "  " + viragenie.Split('~')[1].Trim(' ') + "  " + viragenie.Split('~')[2].Trim(' ') + " " + viragenie.Split('~')[0].Trim(' ') + "~" + viragenie.Split('~')[1].Trim(' ') + " " + viragenie.Split('~')[0].Trim(' ') + "~" + viragenie.Split('~')[1].Trim(' ') + "~" + viragenie.Split('~')[2].Trim(' '));

                for (count = 0; count < 8; count++)
                {
                    Console.WriteLine(Matrix_Three[0, count] + "  " + Matrix_Three[1, count] + "  " + Matrix_Three[2, count] + "  " + Convert.ToInt32(Convert.ToBoolean(Matrix_Three[0, count]) == Convert.ToBoolean(Matrix_Three[1, count])) + "    " + Convert.ToInt32((Convert.ToBoolean(Matrix_Three[0, count]) == Convert.ToBoolean(Matrix_Three[1, count])) == Convert.ToBoolean(Matrix_Three[2, count])));
                }
            }
            else if (eqivalent == 2)
            {
                Console.WriteLine(viragenie.Split('>')[0].Trim(' ') + "  " + viragenie.Split('>')[1].Trim(' ') + "  " + viragenie.Split('>')[2].Trim(' ') + " " + viragenie.Split('>')[0].Trim(' ') + ">" + viragenie.Split('>')[1].Trim(' ') + " " + viragenie.Split('>')[0].Trim(' ') + ">" + viragenie.Split('>')[1].Trim(' ') + ">" + viragenie.Split('>')[2].Trim(' '));

                for (count = 0; count < 8; count++)
                {
                    Console.WriteLine(Matrix_Three[0, count] + "  " + Matrix_Three[1, count] + "  " + Matrix_Three[2, count] + "  " + Convert.ToInt32(!Convert.ToBoolean(Matrix_Three[0, count]) | Convert.ToBoolean(Matrix_Three[1, count])) + "    " + Convert.ToInt32((!(!Convert.ToBoolean(Matrix_Three[0, count]) | Convert.ToBoolean(Matrix_Three[1, count])) | Convert.ToBoolean(Matrix_Three[2, count]))));
                }
            }
            else
            {
                if ((viragenie[1] == '&') && (viragenie[3] == '+'))
                {
                    Console.WriteLine(viragenie.Split('&')[0].Trim(' ') + "  " + viragenie.Split('&')[1].Trim(' ')[0] + "  " + viragenie.Split('+')[1].Trim(' ') + " " + viragenie.Split('&')[0].Trim(' ') + "&" + viragenie.Split('&')[1].Trim(' ')[0] + " " + viragenie.Split('&')[0].Trim(' ') + "&" + viragenie.Split('&')[1].Trim(' ')[0] + "+" + viragenie.Split('+')[1].Trim(' '));

                    for (count = 0; count < 8; count++)
                    {
                        Console.WriteLine(Matrix_Three[0, count] + "  " + Matrix_Three[1, count] + "  " + Matrix_Three[2, count] + "  " + Convert.ToInt32(Convert.ToBoolean(Matrix_Three[0, count]) & Convert.ToBoolean(Matrix_Three[1, count])) + "    " + Convert.ToInt32((Convert.ToBoolean(Matrix_Three[0, count]) & Convert.ToBoolean(Matrix_Three[1, count])) | Convert.ToBoolean(Matrix_Three[2, count])));
                    }


                }

                if ((viragenie[1] == '+') && (viragenie[3] == '&'))
                {
                    Console.WriteLine(viragenie.Split('&')[0].Trim(' ')[0] + "  " + viragenie.Split('+')[1].Trim(' ')[0] + "  " + viragenie.Split('&')[1].Trim(' ')[0] + " " + viragenie.Split('+')[1].Trim(' ')[0] + "&" + viragenie.Split('&')[1].Trim(' ')[0] + " " + viragenie.Split('&')[0].Trim(' ')[0] + "+" + viragenie.Split('+')[1].Trim(' ')[0] + "&" + viragenie.Split('&')[1].Trim(' ')[0]);

                    for (count = 0; count < 8; count++)
                    {
                        Console.WriteLine(Matrix_Three[0, count] + "  " + Matrix_Three[1, count] + "  " + Matrix_Three[2, count] + "  " + Convert.ToInt32(Convert.ToBoolean(Matrix_Three[1, count]) & Convert.ToBoolean(Matrix_Three[2, count])) + "    " + Convert.ToInt32((Convert.ToBoolean(Matrix_Three[1, count]) & Convert.ToBoolean(Matrix_Three[2, count])) | Convert.ToBoolean(Matrix_Three[0, count])));
                    }

                }

                if ((viragenie[1] == '&') && (viragenie[3] == '>'))
                {
                    Console.WriteLine(viragenie.Split('&')[0].Trim(' ') + "  " + viragenie.Split('&')[1].Trim(' ')[0] + "  " + viragenie.Split('>')[1].Trim(' ') + " " + viragenie.Split('&')[0].Trim(' ') + "&" + viragenie.Split('&')[1].Trim(' ')[0] + " " + viragenie.Split('&')[0].Trim(' ') + "&" + viragenie.Split('&')[1].Trim(' ')[0] + ">" + viragenie.Split('>')[1].Trim(' '));

                    for (count = 0; count < 8; count++)
                    {
                        Console.WriteLine(Matrix_Three[0, count] + "  " + Matrix_Three[1, count] + "  " + Matrix_Three[2, count] + "  " + Convert.ToInt32(Convert.ToBoolean(Matrix_Three[0, count]) & Convert.ToBoolean(Matrix_Three[1, count])) + "    " + Convert.ToInt32(!(Convert.ToBoolean(Matrix_Three[0, count]) & Convert.ToBoolean(Matrix_Three[1, count])) | Convert.ToBoolean(Matrix_Three[2, count])));
                    }
                }

                if ((viragenie[1] == '>') && (viragenie[3] == '&'))
                {
                    Console.WriteLine(viragenie.Split('&')[0].Trim(' ')[0] + "  " + viragenie.Split('>')[1].Trim(' ')[0] + "  " + viragenie.Split('&')[1].Trim(' ')[0] + " " + viragenie.Split('>')[1].Trim(' ')[0] + "&" + viragenie.Split('&')[1].Trim(' ')[0] + " " + viragenie.Split('&')[0].Trim(' ')[0] + ">" + viragenie.Split('>')[1].Trim(' ')[0] + "&" + viragenie.Split('&')[1].Trim(' ')[0]);

                    for (count = 0; count < 8; count++)
                    {
                        Console.WriteLine(Matrix_Three[0, count] + "  " + Matrix_Three[1, count] + "  " + Matrix_Three[2, count] + "  " + Convert.ToInt32(Convert.ToBoolean(Matrix_Three[1, count]) & Convert.ToBoolean(Matrix_Three[2, count])) + "    " + Convert.ToInt32(!(Convert.ToBoolean(Matrix_Three[1, count]) & Convert.ToBoolean(Matrix_Three[2, count])) | Convert.ToBoolean(Matrix_Three[0, count])));
                    }
                }

                if ((viragenie[1] == '&') && (viragenie[3] == '~'))
                {
                    Console.WriteLine(viragenie.Split('&')[0].Trim(' ') + "  " + viragenie.Split('&')[1].Trim(' ')[0] + "  " + viragenie.Split('~')[1].Trim(' ') + " " + viragenie.Split('&')[0].Trim(' ') + "&" + viragenie.Split('&')[1].Trim(' ')[0] + " " + viragenie.Split('&')[0].Trim(' ') + "&" + viragenie.Split('&')[1].Trim(' ')[0] + "~" + viragenie.Split('~')[1].Trim(' '));

                    for (count = 0; count < 8; count++)
                    {
                        Console.WriteLine(Matrix_Three[0, count] + "  " + Matrix_Three[1, count] + "  " + Matrix_Three[2, count] + "  " + Convert.ToInt32(Convert.ToBoolean(Matrix_Three[0, count]) & Convert.ToBoolean(Matrix_Three[1, count])) + "    " + Convert.ToInt32((Convert.ToBoolean(Matrix_Three[0, count]) & Convert.ToBoolean(Matrix_Three[1, count])) == Convert.ToBoolean(Matrix_Three[2, count])));
                    }
                }

                if ((viragenie[1] == '~') && (viragenie[3] == '&'))
                {
                    Console.WriteLine(viragenie.Split('&')[0].Trim(' ')[0] + "  " + viragenie.Split('~')[1].Trim(' ')[0] + "  " + viragenie.Split('&')[1].Trim(' ')[0] + " " + viragenie.Split('~')[1].Trim(' ')[0] + "&" + viragenie.Split('&')[1].Trim(' ')[0] + " " + viragenie.Split('&')[0].Trim(' ')[0] + "~" + viragenie.Split('~')[1].Trim(' ')[0] + "&" + viragenie.Split('&')[1].Trim(' ')[0]);

                    for (count = 0; count < 8; count++)
                    {
                        Console.WriteLine(Matrix_Three[0, count] + "  " + Matrix_Three[1, count] + "  " + Matrix_Three[2, count] + "  " + Convert.ToInt32(Convert.ToBoolean(Matrix_Three[1, count]) & Convert.ToBoolean(Matrix_Three[2, count])) + "    " + Convert.ToInt32((Convert.ToBoolean(Matrix_Three[1, count]) & Convert.ToBoolean(Matrix_Three[2, count])) == Convert.ToBoolean(Matrix_Three[0, count])));
                    }
                }
                //------------------------------------------------------

                if ((viragenie[1] == '+') && (viragenie[3] == '~'))
                {
                    Console.WriteLine(viragenie.Split('+')[0].Trim(' ') + "  " + viragenie.Split('+')[1].Trim(' ')[0] + "  " + viragenie.Split('~')[1].Trim(' ') + " " + viragenie.Split('+')[0].Trim(' ') + "+" + viragenie.Split('+')[1].Trim(' ')[0] + " " + viragenie.Split('+')[0].Trim(' ') + "+" + viragenie.Split('+')[1].Trim(' ')[0] + "~" + viragenie.Split('~')[1].Trim(' '));

                    for (count = 0; count < 8; count++)
                    {
                        Console.WriteLine(Matrix_Three[0, count] + "  " + Matrix_Three[1, count] + "  " + Matrix_Three[2, count] + "  " + Convert.ToInt32(Convert.ToBoolean(Matrix_Three[0, count]) | Convert.ToBoolean(Matrix_Three[1, count])) + "    " + Convert.ToInt32((Convert.ToBoolean(Matrix_Three[0, count]) | Convert.ToBoolean(Matrix_Three[1, count])) == Convert.ToBoolean(Matrix_Three[2, count])));
                    }


                }

                if ((viragenie[1] == '~') && (viragenie[3] == '+'))
                {
                    Console.WriteLine(viragenie.Split('+')[0].Trim(' ')[0] + "  " + viragenie.Split('~')[1].Trim(' ')[0] + "  " + viragenie.Split('+')[1].Trim(' ')[0] + " " + viragenie.Split('~')[1].Trim(' ')[0] + "+" + viragenie.Split('+')[1].Trim(' ')[0] + " " + viragenie.Split('+')[0].Trim(' ')[0] + "~" + viragenie.Split('~')[1].Trim(' ')[0] + "+" + viragenie.Split('+')[1].Trim(' ')[0]);

                    for (count = 0; count < 8; count++)
                    {
                        Console.WriteLine(Matrix_Three[0, count] + "  " + Matrix_Three[1, count] + "  " + Matrix_Three[2, count] + "  " + Convert.ToInt32(Convert.ToBoolean(Matrix_Three[1, count]) | Convert.ToBoolean(Matrix_Three[2, count])) + "    " + Convert.ToInt32((Convert.ToBoolean(Matrix_Three[1, count]) | Convert.ToBoolean(Matrix_Three[2, count])) == Convert.ToBoolean(Matrix_Three[0, count])));
                    }

                }

                //

                if ((viragenie[1] == '+') && (viragenie[3] == '>'))
                {
                    Console.WriteLine(viragenie.Split('+')[0].Trim(' ') + "  " + viragenie.Split('+')[1].Trim(' ')[0] + "  " + viragenie.Split('>')[1].Trim(' ') + " " + viragenie.Split('+')[0].Trim(' ') + "+" + viragenie.Split('+')[1].Trim(' ')[0] + " " + viragenie.Split('+')[0].Trim(' ') + "+" + viragenie.Split('+')[1].Trim(' ')[0] + ">" + viragenie.Split('>')[1].Trim(' '));

                    for (count = 0; count < 8; count++)
                    {
                        Console.WriteLine(Matrix_Three[0, count] + "  " + Matrix_Three[1, count] + "  " + Matrix_Three[2, count] + "  " + Convert.ToInt32(Convert.ToBoolean(Matrix_Three[0, count]) | Convert.ToBoolean(Matrix_Three[1, count])) + "    " + Convert.ToInt32(!(Convert.ToBoolean(Matrix_Three[0, count]) | Convert.ToBoolean(Matrix_Three[1, count])) | Convert.ToBoolean(Matrix_Three[2, count])));
                    }


                }

                if ((viragenie[1] == '>') && (viragenie[3] == '+'))
                {
                    Console.WriteLine(viragenie.Split('+')[0].Trim(' ')[0] + "  " + viragenie.Split('>')[1].Trim(' ')[0] + "  " + viragenie.Split('+')[1].Trim(' ')[0] + " " + viragenie.Split('>')[1].Trim(' ')[0] + "+" + viragenie.Split('+')[1].Trim(' ')[0] + " " + viragenie.Split('+')[0].Trim(' ')[0] + ">" + viragenie.Split('>')[1].Trim(' ')[0] + "+" + viragenie.Split('+')[1].Trim(' ')[0]);

                    for (count = 0; count < 8; count++)
                    {
                        Console.WriteLine(Matrix_Three[0, count] + "  " + Matrix_Three[1, count] + "  " + Matrix_Three[2, count] + "  " + Convert.ToInt32(Convert.ToBoolean(Matrix_Three[1, count]) | Convert.ToBoolean(Matrix_Three[2, count])) + "    " + Convert.ToInt32(!(Convert.ToBoolean(Matrix_Three[1, count]) | Convert.ToBoolean(Matrix_Three[2, count])) | Convert.ToBoolean(Matrix_Three[0, count])));
                    }

                }

                //

                if ((viragenie[1] == '>') && (viragenie[3] == '~'))
                {
                    Console.WriteLine(viragenie.Split('>')[0].Trim(' ') + "  " + viragenie.Split('>')[1].Trim(' ')[0] + "  " + viragenie.Split('~')[1].Trim(' ') + " " + viragenie.Split('>')[0].Trim(' ') + ">" + viragenie.Split('>')[1].Trim(' ')[0] + " " + viragenie.Split('>')[0].Trim(' ') + ">" + viragenie.Split('>')[1].Trim(' ')[0] + "~" + viragenie.Split('~')[1].Trim(' '));

                    for (count = 0; count < 8; count++)
                    {
                        Console.WriteLine(Matrix_Three[0, count] + "  " + Matrix_Three[1, count] + "  " + Matrix_Three[2, count] + "  " + Convert.ToInt32(!Convert.ToBoolean(Matrix_Three[0, count]) | Convert.ToBoolean(Matrix_Three[1, count])) + "    " + Convert.ToInt32(!(Convert.ToBoolean(Matrix_Three[0, count]) | Convert.ToBoolean(Matrix_Three[1, count])) == Convert.ToBoolean(Matrix_Three[2, count])));
                    }


                }

                if ((viragenie[1] == '~') && (viragenie[3] == '>'))
                {
                    Console.WriteLine(viragenie.Split('>')[0].Trim(' ')[0] + "  " + viragenie.Split('~')[1].Trim(' ')[0] + "  " + viragenie.Split('>')[1].Trim(' ')[0] + " " + viragenie.Split('~')[1].Trim(' ')[0] + ">" + viragenie.Split('>')[1].Trim(' ')[0] + " " + viragenie.Split('>')[0].Trim(' ')[0] + "~" + viragenie.Split('~')[1].Trim(' ')[0] + ">" + viragenie.Split('>')[1].Trim(' ')[0]);

                    for (count = 0; count < 8; count++)
                    {
                        Console.WriteLine(Matrix_Three[0, count] + "  " + Matrix_Three[1, count] + "  " + Matrix_Three[2, count] + "  " + Convert.ToInt32(!Convert.ToBoolean(Matrix_Three[1, count]) | Convert.ToBoolean(Matrix_Three[2, count])) + "    " + Convert.ToInt32(!(Convert.ToBoolean(Matrix_Three[1, count]) | Convert.ToBoolean(Matrix_Three[2, count])) == Convert.ToBoolean(Matrix_Three[0, count])));
                    }

                }

                //& -- коньюнкция
                //+ -- дезьюнкция
                //~ -- эквивалентность
                //> -- импликация

                //Инверсия(отрицание);
                //Конъюнкция(логическое умножение);
                //Дизъюнкция и строгая дизъюнкция(логическое сложение);
                //Импликация(следствие);
                //Эквивалентность(тождество).
            }
        }

        static void Main(string[] args)
        {

            Matrix_Three[0, 0] = 0;
            Matrix_Three[0, 1] = 0;
            Matrix_Three[0, 2] = 0;
            Matrix_Three[0, 3] = 0;
            Matrix_Three[0, 4] = 1;
            Matrix_Three[0, 5] = 1;
            Matrix_Three[0, 6] = 1;
            Matrix_Three[0, 7] = 1;

            Matrix_Three[1, 0] = 0;
            Matrix_Three[1, 1] = 0;
            Matrix_Three[1, 2] = 1;
            Matrix_Three[1, 3] = 1;
            Matrix_Three[1, 4] = 0;
            Matrix_Three[1, 5] = 0;
            Matrix_Three[1, 6] = 1;
            Matrix_Three[1, 7] = 1;

            Matrix_Three[2, 0] = 0;
            Matrix_Three[2, 1] = 1;
            Matrix_Three[2, 2] = 0;
            Matrix_Three[2, 3] = 1;
            Matrix_Three[2, 4] = 0;
            Matrix_Three[2, 5] = 1;
            Matrix_Three[2, 6] = 0;
            Matrix_Three[2, 7] = 1;

            //----------------------------

            Matrix_Two[0, 0] = 0;
            Matrix_Two[0, 1] = 0;
            Matrix_Two[0, 2] = 1;
            Matrix_Two[0, 3] = 1;

            Matrix_Two[1, 0] = 0;
            Matrix_Two[1, 1] = 1;
            Matrix_Two[1, 2] = 0;
            Matrix_Two[1, 3] = 1;

            //---------------------------

            Matrix_One[0, 0] = 0;
            Matrix_One[0, 1] = 1;

            //----------------------------

            Console.WriteLine("Введите выражение...");

            //Console.WriteLine((int)'a' + " " + (int)'z');
            //65 -- 90 . 97 -- 122

            viragenie = Console.ReadLine();

            Console.Clear();

            for (count = 0; count < viragenie.Length; count++)
            {
                if ((((int)viragenie[count] >= 65) && ((int)viragenie[count] <= 90) || ((int)viragenie[count] >= 97) && ((int)viragenie[count] <= 122)))
                {
                    nakopitel++;

                    if (((int)viragenie[count] >= 97) && ((int)viragenie[count] <= 122))
                    {
                        switch (nakopitel)
                        {
                            case 1:
                                {
                                    Matrix_Three[0, 0] = 1;
                                    Matrix_Three[0, 1] = 1;
                                    Matrix_Three[0, 2] = 1;
                                    Matrix_Three[0, 3] = 1;
                                    Matrix_Three[0, 4] = 0;
                                    Matrix_Three[0, 5] = 0;
                                    Matrix_Three[0, 6] = 0;
                                    Matrix_Three[0, 7] = 0;

                                    Matrix_Two[0, 0] = 1;
                                    Matrix_Two[0, 1] = 1;
                                    Matrix_Two[0, 2] = 0;
                                    Matrix_Two[0, 3] = 0;

                                    Matrix_One[0, 0] = 1;
                                    Matrix_One[0, 1] = 0;


                                    break;
                                }

                            case 2:
                                {
                                    Matrix_Three[1, 0] = 1;
                                    Matrix_Three[1, 1] = 1;
                                    Matrix_Three[1, 2] = 0;
                                    Matrix_Three[1, 3] = 0;
                                    Matrix_Three[1, 4] = 1;
                                    Matrix_Three[1, 5] = 1;
                                    Matrix_Three[1, 6] = 0;
                                    Matrix_Three[1, 7] = 0;

                                    Matrix_Two[1, 0] = 1;
                                    Matrix_Two[1, 1] = 0;
                                    Matrix_Two[1, 2] = 1;
                                    Matrix_Two[1, 3] = 0;


                                    break;
                                }

                            case 3:
                                {
                                    Matrix_Three[2, 0] = 1;
                                    Matrix_Three[2, 1] = 0;
                                    Matrix_Three[2, 2] = 1;
                                    Matrix_Three[2, 3] = 0;
                                    Matrix_Three[2, 4] = 1;
                                    Matrix_Three[2, 5] = 0;
                                    Matrix_Three[2, 6] = 1;
                                    Matrix_Three[2, 7] = 0;

                                    break;
                                }


                        }
                    }

                }

                if (viragenie[count] == '&')
                {
                    konynk++;
                }

                if (viragenie[count] == '+')
                {
                    dezunk++;
                }

                if (viragenie[count] == '>')
                {
                    eqivalent++;
                }

                if (viragenie[count] == '~')
                {
                    implik++;
                }


            }

            //Console.WriteLine(nakopitel);
            //Console.ReadKey();

            switch (nakopitel)
            {
                case 1:
                    {
                        break;
                    }

                case 2:
                    {
                        two();
                        break;
                    }

                case 3:
                    {
                        three();
                        break;
                    }

                default:
                    {
                        Console.WriteLine("Слишком много переменных!");
                        break;
                    }
            }





        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Test testovik = new Test();
        }

    }
}
