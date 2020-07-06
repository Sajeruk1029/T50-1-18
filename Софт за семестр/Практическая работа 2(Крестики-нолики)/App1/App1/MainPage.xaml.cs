using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Popups;
using System.Collections.Generic;

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x419

namespace App1
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        static int countx = 0, counto = 0;
        static List<Button> buts;

        static bool mayatnik = true;

        static bool win = false;

        //static MessageDialog dialog_win_x = new MessageDialog("Победил игрок X.");
        //static MessageDialog dialog_win_o = new MessageDialog("Победил игрок O.");
        //static MessageDialog dialog_win_n = new MessageDialog("Ничья.");

        static Random rand = new Random();

        public MainPage()
        {
            this.InitializeComponent();

            but10.Visibility = Visibility.Collapsed;
            
            count_x.Text = "Счет X: " + countx;
            count_o.Text = "Счет O: " + counto;

            but0.Click += but0_Click;
            but1.Click += but1_Click;
            but2.Click += but2_Click;
            but3.Click += but3_Click;
            but4.Click += but4_Click;
            but5.Click += but5_Click;
            but6.Click += but6_Click;
            but7.Click += but7_Click;
            but8.Click += but8_Click;
            but9.Click += but9_Click;
            but10.Click += but10_Click;

            but1.IsEnabled = false;
            but2.IsEnabled = false;
            but3.IsEnabled = false;
            but4.IsEnabled = false;
            but5.IsEnabled = false;
            but6.IsEnabled = false;
            but7.IsEnabled = false;
            but8.IsEnabled = false;
            but9.IsEnabled = false;

        }

        private void but0_Click(object sender, RoutedEventArgs e)
        {
            int count;

            but10.Visibility = Visibility.Visible;
            but0.Visibility = Visibility.Collapsed;

            but1.IsEnabled = true;
            but2.IsEnabled = true;
            but3.IsEnabled = true;
            but4.IsEnabled = true;
            but5.IsEnabled = true;
            but6.IsEnabled = true;
            but7.IsEnabled = true;
            but8.IsEnabled = true;
            but9.IsEnabled = true;

            player_type.IsEnabled = false;


        }

        private void but1_Click(object sender, RoutedEventArgs e)
        {
            bool empty = false;

            if (player_type.IsChecked.Value)
            {
                if (mayatnik)
                {
                    but1.Content = "X";
                }
                else
                {
                    but1.Content = "O";
                }

                but1.IsEnabled = false;

                mayatnik = !mayatnik;

                check();
            }
            else
            {
                but1.Content = "X";

                but1.IsEnabled = false;

                mayatnik = !mayatnik;

                check();

                if(win)
                {
                    return;
                }

                while (!empty)
                {

                    switch (rand.Next(1, 9))
                    {
                        case 1:
                            {
                                continue;
                                break;
                            }

                        case 2:
                            {
                                if(but2.IsEnabled)
                                {
                                    but2.Content = "O";
                                    but2.IsEnabled = false;

                                    mayatnik = !mayatnik;

                                    empty = true;
                                }

                                break;
                            }

                        case 3:
                            {
                                if (but3.IsEnabled)
                                {
                                    but3.Content = "O";
                                    but3.IsEnabled = false;

                                    mayatnik = !mayatnik;

                                    empty = true;
                                }


                                break;
                            }

                        case 4:
                            {
                                if (but4.IsEnabled)
                                {
                                    but4.Content = "O";
                                    but4.IsEnabled = false;

                                    mayatnik = !mayatnik;

                                    empty = true;
                                }


                                break;
                            }

                        case 5:
                            {
                                if (but5.IsEnabled)
                                {
                                    but5.Content = "O";
                                    but5.IsEnabled = false;

                                    mayatnik = !mayatnik;

                                    empty = true;
                                }


                                break;
                            }

                        case 6:
                            {
                                if (but6.IsEnabled)
                                {
                                    but6.Content = "O";
                                    but6.IsEnabled = false;

                                    mayatnik = !mayatnik;

                                    empty = true;
                                }


                                break;
                            }

                        case 7:
                            {
                                if (but7.IsEnabled)
                                {
                                    but7.Content = "O";
                                    but7.IsEnabled = false;

                                    mayatnik = !mayatnik;

                                    empty = true;
                                }


                                break;
                            }

                        case 8:
                            {
                                if (but8.IsEnabled)
                                {
                                    but8.Content = "O";
                                    but8.IsEnabled = false;

                                    mayatnik = !mayatnik;

                                    empty = true;
                                }


                                break;
                            }

                        case 9:
                            {
                                if (but9.IsEnabled)
                                {
                                    but9.Content = "O";
                                    but9.IsEnabled = false;

                                    mayatnik = !mayatnik;

                                    empty = true;
                                }


                                break;
                            }
                    }

                }

                check();

            }
        }

        private void but2_Click(object sender, RoutedEventArgs e)
        {
            bool empty = false;

            if (player_type.IsChecked.Value)
            {

                if (mayatnik)
                {
                    but2.Content = "X";
                }
                else
                {
                    but2.Content = "O";
                }

                but2.IsEnabled = false;

                mayatnik = !mayatnik;

                check();

            }
            else
            {
                but2.Content = "X";

                but2.IsEnabled = false;

                mayatnik = !mayatnik;

                check();

                if (win)
                {
                    return;
                }

                while (!empty)
                {

                    switch (rand.Next(1, 9))
                    {
                        case 1:
                            {
                                if (but1.IsEnabled)
                                {
                                    but1.Content = "O";
                                    but1.IsEnabled = false;

                                    mayatnik = !mayatnik;

                                    empty = true;
                                }
                                break;
                            }

                        case 2:
                            {
                                continue;
                                break;
                            }

                        case 3:
                            {
                                if (but3.IsEnabled)
                                {
                                    but3.Content = "O";
                                    but3.IsEnabled = false;

                                    mayatnik = !mayatnik;

                                    empty = true;
                                }


                                break;
                            }

                        case 4:
                            {
                                if (but4.IsEnabled)
                                {
                                    but4.Content = "O";
                                    but4.IsEnabled = false;

                                    mayatnik = !mayatnik;

                                    empty = true;
                                }


                                break;
                            }

                        case 5:
                            {
                                if (but5.IsEnabled)
                                {
                                    but5.Content = "O";
                                    but5.IsEnabled = false;

                                    mayatnik = !mayatnik;

                                    empty = true;
                                }


                                break;
                            }

                        case 6:
                            {
                                if (but6.IsEnabled)
                                {
                                    but6.Content = "O";
                                    but6.IsEnabled = false;

                                    mayatnik = !mayatnik;

                                    empty = true;
                                }


                                break;
                            }

                        case 7:
                            {
                                if (but7.IsEnabled)
                                {
                                    but7.Content = "O";
                                    but7.IsEnabled = false;

                                    mayatnik = !mayatnik;

                                    empty = true;
                                }


                                break;
                            }

                        case 8:
                            {
                                if (but8.IsEnabled)
                                {
                                    but8.Content = "O";
                                    but8.IsEnabled = false;

                                    mayatnik = !mayatnik;

                                    empty = true;
                                }


                                break;
                            }

                        case 9:
                            {
                                if (but9.IsEnabled)
                                {
                                    but9.Content = "O";
                                    but9.IsEnabled = false;

                                    mayatnik = !mayatnik;

                                    empty = true;
                                }


                                break;
                            }
                    }

                }

                check();

            }
        }

        private void but3_Click(object sender, RoutedEventArgs e)
        {
            bool empty = false;

            if (player_type.IsChecked.Value)
            {

                if (mayatnik)
                {
                    but3.Content = "X";
                }
                else
                {
                    but3.Content = "O";
                }

                but3.IsEnabled = false;

                mayatnik = !mayatnik;

                check();

            }
            else
            {
                but3.Content = "X";

                but3.IsEnabled = false;

                mayatnik = !mayatnik;

                check();

                if (win)
                {
                    return;
                }

                while (!empty)
                {

                    switch (rand.Next(1, 9))
                    {
                        case 1:
                            {
                                if (but1.IsEnabled)
                                {
                                    but1.Content = "O";
                                    but1.IsEnabled = false;

                                    mayatnik = !mayatnik;

                                    empty = true;
                                }
                                break;
                            }

                        case 2:
                            {
                                if (but2.IsEnabled)
                                {
                                    but2.Content = "O";
                                    but2.IsEnabled = false;

                                    mayatnik = !mayatnik;

                                    empty = true;
                                }


                                break;
                            }

                        case 3:
                            {
                                continue;
                                break;
                            }

                        case 4:
                            {
                                if (but4.IsEnabled)
                                {
                                    but4.Content = "O";
                                    but4.IsEnabled = false;

                                    mayatnik = !mayatnik;

                                    empty = true;
                                }


                                break;
                            }

                        case 5:
                            {
                                if (but5.IsEnabled)
                                {
                                    but5.Content = "O";
                                    but5.IsEnabled = false;

                                    mayatnik = !mayatnik;

                                    empty = true;
                                }


                                break;
                            }

                        case 6:
                            {
                                if (but6.IsEnabled)
                                {
                                    but6.Content = "O";
                                    but6.IsEnabled = false;

                                    mayatnik = !mayatnik;

                                    empty = true;
                                }


                                break;
                            }

                        case 7:
                            {
                                if (but7.IsEnabled)
                                {
                                    but7.Content = "O";
                                    but7.IsEnabled = false;

                                    mayatnik = !mayatnik;

                                    empty = true;
                                }


                                break;
                            }

                        case 8:
                            {
                                if (but8.IsEnabled)
                                {
                                    but8.Content = "O";
                                    but8.IsEnabled = false;

                                    mayatnik = !mayatnik;

                                    empty = true;
                                }


                                break;
                            }

                        case 9:
                            {
                                if (but9.IsEnabled)
                                {
                                    but9.Content = "O";
                                    but9.IsEnabled = false;

                                    mayatnik = !mayatnik;

                                    empty = true;
                                }


                                break;
                            }
                    }

                }

                check();

            }
        }

        private void but4_Click(object sender, RoutedEventArgs e)
        {
            bool empty = false;

            if (player_type.IsChecked.Value)
            {

                if (mayatnik)
                {
                    but4.Content = "X";
                }
                else
                {
                    but4.Content = "O";
                }

                but4.IsEnabled = false;

                mayatnik = !mayatnik;

                check();

            }
            else
            {
                but4.Content = "X";

                but4.IsEnabled = false;

                mayatnik = !mayatnik;

                check();

                if (win)
                {
                    return;
                }

                while (!empty)
                {

                    switch (rand.Next(1, 9))
                    {
                        case 1:
                            {
                                if (but1.IsEnabled)
                                {
                                    but1.Content = "O";
                                    but1.IsEnabled = false;

                                    mayatnik = !mayatnik;

                                    empty = true;
                                }
                                break;
                            }

                        case 2:
                            {
                                if (but2.IsEnabled)
                                {
                                    but2.Content = "O";
                                    but2.IsEnabled = false;

                                    mayatnik = !mayatnik;

                                    empty = true;
                                }


                                break;
                            }

                        case 3:
                            {
                                if (but3.IsEnabled)
                                {
                                    but3.Content = "O";
                                    but3.IsEnabled = false;

                                    mayatnik = !mayatnik;

                                    empty = true;
                                }


                                break;
                            }

                        case 4:
                            {
                                continue;
                                break;
                            }

                        case 5:
                            {
                                if (but5.IsEnabled)
                                {
                                    but5.Content = "O";
                                    but5.IsEnabled = false;

                                    mayatnik = !mayatnik;

                                    empty = true;
                                }


                                break;
                            }

                        case 6:
                            {
                                if (but6.IsEnabled)
                                {
                                    but6.Content = "O";
                                    but6.IsEnabled = false;

                                    mayatnik = !mayatnik;

                                    empty = true;
                                }


                                break;
                            }

                        case 7:
                            {
                                if (but7.IsEnabled)
                                {
                                    but7.Content = "O";
                                    but7.IsEnabled = false;

                                    mayatnik = !mayatnik;

                                    empty = true;
                                }


                                break;
                            }

                        case 8:
                            {
                                if (but8.IsEnabled)
                                {
                                    but8.Content = "O";
                                    but8.IsEnabled = false;

                                    mayatnik = !mayatnik;

                                    empty = true;
                                }


                                break;
                            }

                        case 9:
                            {
                                if (but9.IsEnabled)
                                {
                                    but9.Content = "O";
                                    but9.IsEnabled = false;

                                    mayatnik = !mayatnik;

                                    empty = true;
                                }


                                break;
                            }
                    }

                }

                check();

            }
        }

        private void but5_Click(object sender, RoutedEventArgs e)
        {
            bool empty = false;

            if (player_type.IsChecked.Value)
            {

                
                if (mayatnik)
                {
                    but5.Content = "X";
                }
                else
                {
                    but5.Content = "O";
                }

                but5.IsEnabled = false;

                mayatnik = !mayatnik;

                check();

            }
            else
            {
                but5.Content = "X";

                but5.IsEnabled = false;

                mayatnik = !mayatnik;

                check();

                if (win)
                {
                    return;
                }

                while (!empty)
                {

                    switch (rand.Next(1, 9))
                    {
                        case 1:
                            {
                                if (but1.IsEnabled)
                                {
                                    but1.Content = "O";
                                    but1.IsEnabled = false;

                                    mayatnik = !mayatnik;

                                    empty = true;
                                }
                                break;
                            }

                        case 2:
                            {
                                if (but2.IsEnabled)
                                {
                                    but2.Content = "O";
                                    but2.IsEnabled = false;

                                    mayatnik = !mayatnik;

                                    empty = true;
                                }


                                break;
                            }

                        case 3:
                            {
                                if (but3.IsEnabled)
                                {
                                    but3.Content = "O";
                                    but3.IsEnabled = false;

                                    mayatnik = !mayatnik;

                                    empty = true;
                                }


                                break;
                            }

                        case 4:
                            {
                                if (but4.IsEnabled)
                                {
                                    but4.Content = "O";
                                    but4.IsEnabled = false;

                                    mayatnik = !mayatnik;

                                    empty = true;
                                }


                                break;
                            }

                        case 5:
                            {
                                continue;
                                break;
                            }

                        case 6:
                            {
                                if (but6.IsEnabled)
                                {
                                    but6.Content = "O";
                                    but6.IsEnabled = false;

                                    mayatnik = !mayatnik;

                                    empty = true;
                                }


                                break;
                            }

                        case 7:
                            {
                                if (but7.IsEnabled)
                                {
                                    but7.Content = "O";
                                    but7.IsEnabled = false;

                                    mayatnik = !mayatnik;

                                    empty = true;
                                }


                                break;
                            }

                        case 8:
                            {
                                if (but8.IsEnabled)
                                {
                                    but8.Content = "O";
                                    but8.IsEnabled = false;

                                    mayatnik = !mayatnik;

                                    empty = true;
                                }


                                break;
                            }

                        case 9:
                            {
                                if (but9.IsEnabled)
                                {
                                    but9.Content = "O";
                                    but9.IsEnabled = false;

                                    mayatnik = !mayatnik;
                                    
                                    empty = true;
                                }


                                break;
                            }
                    }

                }

                check();

            }
        }

        private void but6_Click(object sender, RoutedEventArgs e)
        {
            bool empty = false;

            if (player_type.IsChecked.Value)
            {

                if (mayatnik)
                {
                    but6.Content = "X";
                }
                else
                {
                    but6.Content = "O";
                }

                but6.IsEnabled = false;

                mayatnik = !mayatnik;

                check();

            }
            else
            {
                but6.Content = "X";

                but6.IsEnabled = false;

                mayatnik = !mayatnik;

                check();

                if (win)
                {
                    return;
                }

                while (!empty)
                {

                    switch (rand.Next(1, 9))
                    {
                        case 1:
                            {
                                if (but1.IsEnabled)
                                {
                                    but1.Content = "O";
                                    but1.IsEnabled = false;

                                    mayatnik = !mayatnik;

                                    empty = true;
                                }
                                break;
                            }

                        case 2:
                            {
                                if (but2.IsEnabled)
                                {
                                    but2.Content = "O";
                                    but2.IsEnabled = false;

                                    mayatnik = !mayatnik;

                                    empty = true;
                                }


                                break;
                            }

                        case 3:
                            {
                                if (but3.IsEnabled)
                                {
                                    but3.Content = "O";
                                    but3.IsEnabled = false;

                                    mayatnik = !mayatnik;

                                    empty = true;
                                }


                                break;
                            }

                        case 4:
                            {
                                if (but4.IsEnabled)
                                {
                                    but4.Content = "O";
                                    but4.IsEnabled = false;

                                    mayatnik = !mayatnik;

                                    empty = true;
                                }


                                break;
                            }

                        case 5:
                            {
                                if (but5.IsEnabled)
                                {
                                    but5.Content = "O";
                                    but5.IsEnabled = false;

                                    mayatnik = !mayatnik;

                                    empty = true;
                                }


                                break;
                            }

                        case 6:
                            {
                                continue;
                                break;
                            }

                        case 7:
                            {
                                if (but7.IsEnabled)
                                {
                                    but7.Content = "O";
                                    but7.IsEnabled = false;

                                    mayatnik = !mayatnik;

                                    empty = true;
                                }


                                break;
                            }

                        case 8:
                            {
                                if (but8.IsEnabled)
                                {
                                    but8.Content = "O";
                                    but8.IsEnabled = false;

                                    mayatnik = !mayatnik;

                                    empty = true;
                                }


                                break;
                            }

                        case 9:
                            {
                                if (but9.IsEnabled)
                                {
                                    but9.Content = "O";
                                    but9.IsEnabled = false;

                                    mayatnik = !mayatnik;

                                    empty = true;
                                }


                                break;
                            }
                    }

                }

                check();

            }
        }

        private void but7_Click(object sender, RoutedEventArgs e)
        {
            bool empty = false;

            if (player_type.IsChecked.Value)
            {

                if (mayatnik)
                {
                    but7.Content = "X";
                }
                else
                {
                    but7.Content = "O";
                }

                but7.IsEnabled = false;

                mayatnik = !mayatnik;

                check();

            }
            else
            {
                but7.Content = "X";

                but7.IsEnabled = false;

                mayatnik = !mayatnik;

                check();

                if (win)
                {
                    return;
                }

                while (!empty)
                {

                    switch (rand.Next(1, 9))
                    {
                        case 1:
                            {
                                if (but1.IsEnabled)
                                {
                                    but1.Content = "O";
                                    but1.IsEnabled = false;

                                    mayatnik = !mayatnik;

                                    empty = true;
                                }
                                break;
                            }

                        case 2:
                            {
                                if (but2.IsEnabled)
                                {
                                    but2.Content = "O";
                                    but2.IsEnabled = false;

                                    mayatnik = !mayatnik;

                                    empty = true;
                                }


                                break;
                            }

                        case 3:
                            {
                                if (but3.IsEnabled)
                                {
                                    but3.Content = "O";
                                    but3.IsEnabled = false;

                                    mayatnik = !mayatnik;

                                    empty = true;
                                }


                                break;
                            }

                        case 4:
                            {
                                if (but4.IsEnabled)
                                {
                                    but4.Content = "O";
                                    but4.IsEnabled = false;

                                    mayatnik = !mayatnik;

                                    empty = true;
                                }


                                break;
                            }

                        case 5:
                            {
                                if (but5.IsEnabled)
                                {
                                    but5.Content = "O";
                                    but5.IsEnabled = false;

                                    mayatnik = !mayatnik;

                                    empty = true;
                                }


                                break;
                            }

                        case 6:
                            {
                                if (but6.IsEnabled)
                                {
                                    but6.Content = "O";
                                    but6.IsEnabled = false;

                                    mayatnik = !mayatnik;

                                    empty = true;
                                }


                                break;
                            }

                        case 7:
                            {
                                continue;
                                break;
                            }

                        case 8:
                            {
                                if (but8.IsEnabled)
                                {
                                    but8.Content = "O";
                                    but8.IsEnabled = false;

                                    mayatnik = !mayatnik;

                                    empty = true;
                                }


                                break;
                            }

                        case 9:
                            {
                                if (but9.IsEnabled)
                                {
                                    but9.Content = "O";
                                    but9.IsEnabled = false;

                                    mayatnik = !mayatnik;

                                    empty = true;
                                }


                                break;
                            }
                    }

                }

                check();

            }
        }

        private void but8_Click(object sender, RoutedEventArgs e)
        {
            bool empty = false;

            if (player_type.IsChecked.Value)
            {

                if (mayatnik)
                {
                    but8.Content = "X";
                }
                else
                {
                    but8.Content = "O";
                }

                but8.IsEnabled = false;

                mayatnik = !mayatnik;

                check();

            }
            else
            {
                but8.Content = "X";

                but8.IsEnabled = false;

                mayatnik = !mayatnik;

                check();

                if (win)
                {
                    return;
                }

                while (!empty)
                {

                    switch (rand.Next(1, 9))
                    {
                        case 1:
                            {
                                if (but1.IsEnabled)
                                {
                                    but1.Content = "O";
                                    but1.IsEnabled = false;

                                    mayatnik = !mayatnik;

                                    empty = true;
                                }
                                break;
                            }

                        case 2:
                            {
                                if (but2.IsEnabled)
                                {
                                    but2.Content = "O";
                                    but2.IsEnabled = false;

                                    mayatnik = !mayatnik;

                                    empty = true;
                                }


                                break;
                            }

                        case 3:
                            {
                                if (but3.IsEnabled)
                                {
                                    but3.Content = "O";
                                    but3.IsEnabled = false;

                                    mayatnik = !mayatnik;

                                    empty = true;
                                }


                                break;
                            }

                        case 4:
                            {
                                if (but4.IsEnabled)
                                {
                                    but4.Content = "O";
                                    but4.IsEnabled = false;

                                    mayatnik = !mayatnik;

                                    empty = true;
                                }


                                break;
                            }

                        case 5:
                            {
                                if (but5.IsEnabled)
                                {
                                    but5.Content = "O";
                                    but5.IsEnabled = false;

                                    mayatnik = !mayatnik;

                                    empty = true;
                                }


                                break;
                            }

                        case 6:
                            {
                                if (but6.IsEnabled)
                                {
                                    but6.Content = "O";
                                    but6.IsEnabled = false;

                                    mayatnik = !mayatnik;

                                    empty = true;
                                }


                                break;
                            }

                        case 7:
                            {
                                if (but7.IsEnabled)
                                {
                                    but7.Content = "O";
                                    but7.IsEnabled = false;

                                    mayatnik = !mayatnik;

                                    empty = true;
                                }


                                break;
                            }

                        case 8:
                            {
                                continue;
                                break;
                            }

                        case 9:
                            {
                                if (but9.IsEnabled)
                                {
                                    but9.Content = "O";
                                    but9.IsEnabled = false;

                                    mayatnik = !mayatnik;

                                    empty = true;
                                }


                                break;
                            }
                    }

                }

                check();

            }
        }

        private void but9_Click(object sender, RoutedEventArgs e)
        {
            bool empty = false;

            if (player_type.IsChecked.Value)
            {

                if (mayatnik)
                {
                    but9.Content = "X";
                }
                else
                {
                    but9.Content = "O";
                }

                but9.IsEnabled = false;

                mayatnik = !mayatnik;

                check();

            }
            else
            {
                but9.Content = "X";

                but9.IsEnabled = false;

                mayatnik = !mayatnik;

                check();

                if (win)
                {
                    return;
                }

                while (!empty)
                {

                    switch (rand.Next(1, 9))
                    {
                        case 1:
                            {
                                if (but1.IsEnabled)
                                {
                                    but1.Content = "O";
                                    but1.IsEnabled = false;

                                    mayatnik = !mayatnik;

                                    empty = true;
                                }
                                break;
                            }

                        case 2:
                            {
                                if (but2.IsEnabled)
                                {
                                    but2.Content = "O";
                                    but2.IsEnabled = false;

                                    mayatnik = !mayatnik;

                                    empty = true;
                                }


                                break;
                            }

                        case 3:
                            {
                                if (but3.IsEnabled)
                                {
                                    but3.Content = "O";
                                    but3.IsEnabled = false;

                                    mayatnik = !mayatnik;

                                    empty = true;
                                }


                                break;
                            }

                        case 4:
                            {
                                if (but4.IsEnabled)
                                {
                                    but4.Content = "O";
                                    but4.IsEnabled = false;

                                    mayatnik = !mayatnik;

                                    empty = true;
                                }


                                break;
                            }

                        case 5:
                            {
                                if (but5.IsEnabled)
                                {
                                    but5.Content = "O";
                                    but5.IsEnabled = false;

                                    mayatnik = !mayatnik;

                                    empty = true;
                                }


                                break;
                            }

                        case 6:
                            {
                                if (but6.IsEnabled)
                                {
                                    but6.Content = "O";
                                    but6.IsEnabled = false;

                                    mayatnik = !mayatnik;

                                    empty = true;
                                }


                                break;
                            }

                        case 7:
                            {
                                if (but7.IsEnabled)
                                {
                                    but7.Content = "O";
                                    but7.IsEnabled = false;

                                    mayatnik = !mayatnik;

                                    empty = true;
                                }


                                break;
                            }

                        case 8:
                            {
                                if (but8.IsEnabled)
                                {
                                    but8.Content = "O";
                                    but8.IsEnabled = false;

                                    mayatnik = !mayatnik;

                                    empty = true;
                                }


                                break;
                            }

                        case 9:
                            {
                                continue;
                                break;
                            }
                    }

                }

                check();

            }

        }

        private void but10_Click(object sender, RoutedEventArgs e)
        {
            but1.Content = "";
            but2.Content = "";
            but3.Content = "";
            but4.Content = "";
            but5.Content = "";
            but6.Content = "";
            but7.Content = "";
            but8.Content = "";
            but9.Content = "";

            but10.Visibility = Visibility.Collapsed;
            but0.Visibility = Visibility.Visible;

            player_type.IsEnabled = true;

            win = false;
            mayatnik = true;

        }

        private void TextBlock_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }

        async void check()
        {

            if ((but1.Content.ToString() == "X") && (but2.Content.ToString() == "X") && (but3.Content.ToString() == "X"))
            {
                //await dialog_win_x.ShowAsync();
                var dialog_win_x = new MessageDialog("Победил игрок X.").ShowAsync();
                win = true;

                countx++;
                count_x.Text = "Счет X: " + countx;
            }
            else if ((but4.Content.ToString() == "X") && (but5.Content.ToString() == "X") && (but6.Content.ToString() == "X"))
            {
                var dialog_win_x = new MessageDialog("Победил игрок X.").ShowAsync();
                win = true;

                countx++;
                count_x.Text = "Счет X: " + countx;
            }
            else if ((but7.Content.ToString() == "X") && (but8.Content.ToString() == "X") && (but9.Content.ToString() == "X"))
            {
                var dialog_win_x = new MessageDialog("Победил игрок X.").ShowAsync();
                win = true;

                countx++;
                count_x.Text = "Счет X: " + countx;
            }
            else if ((but1.Content.ToString() == "X") && (but5.Content.ToString() == "X") && (but9.Content.ToString() == "X"))
            {
                var dialog_win_x = new MessageDialog("Победил игрок X.").ShowAsync();
                win = true;

                countx++;
                count_x.Text = "Счет X: " + countx;
            }
            else if ((but3.Content.ToString() == "X") && (but5.Content.ToString() == "X") && (but7.Content.ToString() == "X"))
            {
                var dialog_win_x = new MessageDialog("Победил игрок X.").ShowAsync();
                win = true;

                countx++;
                count_x.Text = "Счет X: " + countx;
            }
            else if ((but1.Content.ToString() == "X") && (but4.Content.ToString() == "X") && (but7.Content.ToString() == "X"))
            {
                var dialog_win_x = new MessageDialog("Победил игрок X.").ShowAsync();
                win = true;

                countx++;
                count_x.Text = "Счет X: " + countx;
            }
            else if ((but2.Content.ToString() == "X") && (but5.Content.ToString() == "X") && (but8.Content.ToString() == "X"))
            {
                var dialog_win_x = new MessageDialog("Победил игрок X.").ShowAsync();
                win = true;

                countx++;
                count_x.Text = "Счет X: " + countx;
            }
            else if ((but3.Content.ToString() == "X") && (but6.Content.ToString() == "X") && (but9.Content.ToString() == "X"))
            {
                var dialog_win_x = new MessageDialog("Победил игрок X.").ShowAsync();
                win = true;

                countx++;
                count_x.Text = "Счет X: " + countx;
            }


            else if ((but1.Content.ToString() == "O") && (but2.Content.ToString() == "O") && (but3.Content.ToString() == "O"))
            {
                var dialog_win_o = new MessageDialog("Победил игрок O.").ShowAsync();
                win = true;

                counto++;
                count_o.Text = "Счет O: " + counto;
            }
            else if ((but4.Content.ToString() == "O") && (but5.Content.ToString() == "O") && (but6.Content.ToString() == "O"))
            {
                var dialog_win_o = new MessageDialog("Победил игрок O.").ShowAsync();
                win = true;

                counto++;
                count_o.Text = "Счет O: " + counto;
            }
            else if ((but7.Content.ToString() == "O") && (but8.Content.ToString() == "O") && (but9.Content.ToString() == "O"))
            {
                var dialog_win_o = new MessageDialog("Победил игрок O.").ShowAsync();
                win = true;

                counto++;
                count_o.Text = "Счет O: " + counto;
            }
            else if ((but1.Content.ToString() == "O") && (but5.Content.ToString() == "O") && (but9.Content.ToString() == "O"))
            {
                var dialog_win_o = new MessageDialog("Победил игрок O.").ShowAsync();
                win = true;

                counto++;
                count_o.Text = "Счет O: " + counto;
            }
            else if ((but3.Content.ToString() == "O") && (but5.Content.ToString() == "O") && (but7.Content.ToString() == "O"))
            {
                var dialog_win_o = new MessageDialog("Победил игрок O.").ShowAsync();
                win = true;

                counto++;
                count_o.Text = "Счет O: " + counto;
            }
            else if ((but1.Content.ToString() == "O") && (but4.Content.ToString() == "O") && (but7.Content.ToString() == "O"))
            {
                var dialog_win_o = new MessageDialog("Победил игрок O.").ShowAsync();
                win = true;

                counto++;
                count_o.Text = "Счет O: " + counto;
            }
            else if ((but2.Content.ToString() == "O") && (but5.Content.ToString() == "O") && (but8.Content.ToString() == "O"))
            {
                var dialog_win_o = new MessageDialog("Победил игрок O.").ShowAsync();
                win = true;

                counto++;
                count_o.Text = "Счет O: " + counto;
            }
            else if ((but3.Content.ToString() == "O") && (but6.Content.ToString() == "O") && (but9.Content.ToString() == "O"))
            {
                var dialog_win_o = new MessageDialog("Победил игрок O.").ShowAsync();
                win = true;

                counto++;
                count_o.Text = "Счет O: " + counto;
            }

            else
            {
                if ((!win) && (!but1.IsEnabled) && (!but2.IsEnabled) && (!but3.IsEnabled) && (!but4.IsEnabled) && (!but5.IsEnabled) && (!but6.IsEnabled) && (!but7.IsEnabled) && (!but8.IsEnabled) && (!but9.IsEnabled))
                {
                    var dialog_win_n = new MessageDialog("Ничья.").ShowAsync();
                }

                return;

            }

            but1.IsEnabled = false;
            but2.IsEnabled = false;
            but3.IsEnabled = false;
            but4.IsEnabled = false;
            but5.IsEnabled = false;
            but6.IsEnabled = false;
            but7.IsEnabled = false;
            but8.IsEnabled = false;
            but9.IsEnabled = false;

        }

    }
}
