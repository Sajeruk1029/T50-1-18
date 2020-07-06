using Microsoft.UI.Xaml.Controls;
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

using Windows.Storage;
using System.Xml.Serialization;

/*
 *  На 4:
 * Постановка задачи: При открытии браузера сразу создаеся 1 вкладка-
 * История браузера
 * Закладки - сохранение сайтов (в новой станице)
 * Загрузки - какие файлы качал пользователь
 * Настройки - настройка домашней страницы
 * Поиск - если вводится не ссылка, то ищет по домашней странице
 * Если при загрузке страницы ничего нет, выдать страницу 404
 *  На 5:
 * Возможность авторизации в вк и получение уведомлений о новых сообщениях (vk api.com)
 */

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x419

namespace fugovno
{   
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        static List<History> history;
        static List<Kladka> klad;

        static History zapis;
        static Kladka kladadd;
        static FindSystem findsys;

        static bool check = false;

        public MainPage()
        {
            this.InitializeComponent();

            

            poluchatel();    
        }

        

        private async void poluchatel()
        {
            history = new List<History>();
            klad = new List<Kladka>();

            zapis = new History();
            kladadd = new Kladka();
            findsys = new FindSystem();

            StorageFolder folder = ApplicationData.Current.LocalFolder;
            
            StorageFile file_History = await folder.CreateFileAsync("db_history.xml", CreationCollisionOption.OpenIfExists);
            StorageFile file_Kladka = await folder.CreateFileAsync("db_kladka.xml", CreationCollisionOption.OpenIfExists);
            StorageFile file_FindSys = await folder.CreateFileAsync("db_findsys.xml", CreationCollisionOption.OpenIfExists);

            try
            {
                XmlSerializer xml_deser_history = new XmlSerializer(typeof(List<History>));
                XmlSerializer xml_deser_kladka = new XmlSerializer(typeof(List<Kladka>));
                XmlSerializer xml_deser_findsys = new XmlSerializer(typeof(FindSystem));


                using (Stream stream_deser_history = await file_History.OpenStreamForReadAsync())
                {
                    history = (List<History>)xml_deser_history.Deserialize(stream_deser_history);
                }

                using (Stream stream_deser_kladka = await file_Kladka.OpenStreamForReadAsync())
                {
                    klad = (List<Kladka>)xml_deser_kladka.Deserialize(stream_deser_kladka);
                }

                using (Stream stream_deser_findsys = await file_FindSys.OpenStreamForReadAsync())
                {
                    findsys = (FindSystem)xml_deser_findsys.Deserialize(stream_deser_findsys);
                }

            }
            catch(Exception e)
            {
                var msg = new MessageDialog(e.ToString()).ShowAsync();
                otpravitel_find_sys("https://yandex.ru");
                otpravitel_History();
                otpravitel_kladki();
            }


            TabViewItem tab = new TabViewItem();
            tab.Header = "Новая вкладка";
            WebView web = new WebView();
            tab.Content = web;
            tabView.TabItems.Add(tab);
            web.Navigate(new Uri(findsys.findsystem));
            web.NavigationStarting += Web_SetAdress;
            web.NavigationFailed += Web_Send;
            web.NewWindowRequested += Web_OpenWindow;



        }

        private async void otpravitel_find_sys(string findSyS)
        {
            findsys = new FindSystem
            {
                findsystem = findSyS
            };

            StorageFolder folder = ApplicationData.Current.LocalFolder;

            StorageFile file_FindSys = await folder.CreateFileAsync("db_findsys.xml", CreationCollisionOption.OpenIfExists);

            XmlSerializer xml_ser_findsys = new XmlSerializer(typeof(FindSystem));

            using (Stream stream_ser_findsys = await file_FindSys.OpenStreamForWriteAsync())
            {
                xml_ser_findsys.Serialize(stream_ser_findsys, findsys);
            }

            MessageDialog msg = new MessageDialog(file_FindSys.Path);
            await msg.ShowAsync();
        }

        private async void otpravitel_kladki(string uri = "")
        {
            kladadd = new Kladka
            {
                kladka = uri
            };

            klad.Add(kladadd);

            StorageFolder folder = ApplicationData.Current.LocalFolder;

            StorageFile file_Kladka = await folder.CreateFileAsync("db_kladka.xml", CreationCollisionOption.OpenIfExists);

            XmlSerializer xml_ser_kladka = new XmlSerializer(typeof(List<Kladka>));

            using (Stream stream_ser_kladka = await file_Kladka.OpenStreamForWriteAsync())
            {
                xml_ser_kladka.Serialize(stream_ser_kladka, klad);
            }
        }

        private async void otpravitel_History(string uri = "")
        {
            zapis = new History()
            {
                Uri = uri
            };

            history.Add(zapis);

            StorageFolder folder = ApplicationData.Current.LocalFolder;

            StorageFile file_history = await folder.CreateFileAsync("db_history.xml", CreationCollisionOption.OpenIfExists);

            XmlSerializer xml_ser_history = new XmlSerializer(typeof(List<History>));

            using (Stream stream_ser_history = await file_history.OpenStreamForWriteAsync())
            {
                xml_ser_history.Serialize(stream_ser_history, history);
            }
        }

        private void TabView_AddTabButtonClick_1(Microsoft.UI.Xaml.Controls.TabView sender, object args)
        {
            TabViewItem tab = new TabViewItem();
            tab.Header = "Новая вкладка";
            WebView web = new WebView();
            tab.Content = web;
            sender.TabItems.Add(tab);
            web.Navigate(new Uri(findsys.findsystem));
            web.NavigationStarting += Web_SetAdress;
            web.NavigationFailed += Web_Send;
            web.NewWindowRequested += Web_OpenWindow;
        }

        private void Web_OpenWindow(WebView sender, WebViewNewWindowRequestedEventArgs args)
        {
            adress.Text = args.Uri.AbsoluteUri;
            sender.Navigate(args.Uri);

            otpravitel_History(args.Uri.AbsoluteUri);

            args.Handled = true;
        }

        private void Web_Send(object sender, WebViewNavigationFailedEventArgs args)
        {
            //adress.Text = args.Uri.AbsoluteUri;
        }

        private void Web_SetAdress(WebView sender, WebViewNavigationStartingEventArgs args)
        {
            adress.Text = args.Uri.AbsoluteUri;
        }

        private void Web_NavigationStarting(WebView sender, WebViewNavigationStartingEventArgs args)
        {
            //throw new NotImplementedException();
        }

        private void TabView_TabCloseRequested(Microsoft.UI.Xaml.Controls.TabView sender, Microsoft.UI.Xaml.Controls.TabViewTabCloseRequestedEventArgs args)
        {
            sender.TabItems.Remove(args.Tab);
            if (sender.TabItems.Count == 0)
                Application.Current.Exit();
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (((tabView.TabItems[tabView.SelectedIndex] as TabViewItem).Content as WebView).CanGoBack)
                ((tabView.TabItems[tabView.SelectedIndex] as TabViewItem).Content as WebView).GoBack();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (((tabView.TabItems[tabView.SelectedIndex] as TabViewItem).Content as WebView).CanGoForward)
                ((tabView.TabItems[tabView.SelectedIndex] as TabViewItem).Content as WebView).GoForward();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            ((tabView.TabItems[tabView.SelectedIndex] as TabViewItem).Content as WebView).Refresh();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            ((tabView.TabItems[tabView.SelectedIndex] as TabViewItem).Content as WebView).Navigate(new Uri(findsys.findsystem));
        }

        private void TextBox_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.Enter)
            {
                if ((sender as TextBox).Text.Contains("https://www"))
                {
                    ((tabView.TabItems[tabView.SelectedIndex] as TabViewItem).Content as WebView).Navigate(new Uri((sender as TextBox).Text));
                }
                else
                {
                    if(findsys.findsystem.Contains("yandex"))
                    {
                        ((tabView.TabItems[tabView.SelectedIndex] as TabViewItem).Content as WebView).Navigate(new Uri("https://yandex.ru/search/touch/?text=" + (sender as TextBox).Text));
                        (sender as TextBox).Text = "https://www.yandex.ru/search/touch/?text=" + (sender as TextBox).Text;
                    }
                    else
                    {
                        ((tabView.TabItems[tabView.SelectedIndex] as TabViewItem).Content as WebView).Navigate(new Uri("https://www.google.ru/search?q=" + (sender as TextBox).Text));
                        (sender as TextBox).Text = "https://www.google.ru/search?q=" + (sender as TextBox).Text;
                    }

                }



            }
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            otpravitel_kladki(adress.Text);
        }

        private async void ButPoisk_Click(object sender, RoutedEventArgs e)
        {
            ContentDialog poisk = new ContentDialog()
            {
                Title = "Выбор поисковой системы",
                Content = "Какую поисковую систему вы хотете использовать?",
                PrimaryButtonText = "Yandex.ru",
                SecondaryButtonText = "Google.ru"
            };

            ContentDialogResult result = await poisk.ShowAsync();

            if(result == ContentDialogResult.Primary)
            {
                findsys.findsystem = "https://yandex.ru";
                otpravitel_find_sys("https://yandex.ru");

            }
            else
            {
                findsys.findsystem = "https://www.google.ru";
                otpravitel_find_sys("https://www.google.ru");
            }

        }

        private async void ButZakladki_Click(object sender, RoutedEventArgs e)
        {

            StackPanel konteyner = new StackPanel();

            for(int count = 0; count < klad.Count; count++)
            {
                if(klad[count].kladka != "")
                {
                    konteyner.Children.Add(new TextBox() { Text = klad[count].kladka });
                }
            }

            ScrollViewer scrollViewer = new ScrollViewer();

            scrollViewer.Content = konteyner;

            ContentDialog contentDialog = new ContentDialog()
            {
                Title = "Закладки",
                Content = scrollViewer,
                PrimaryButtonText = "Закрыть"
            };

            await contentDialog.ShowAsync();

        }

        private async void ButHistory_Click(object sender, RoutedEventArgs e)
        {
            StackPanel konteyner = new StackPanel();

            for (int count = 0; count < history.Count; count++)
            {
                if (history[count].Uri != "")
                {
                    konteyner.Children.Add(new TextBox() { Text = history[count].Uri });
                }
            }

            ScrollViewer scrollViewer = new ScrollViewer();

            scrollViewer.Content = konteyner;

            ContentDialog contentDialog = new ContentDialog()
            {
                 Title = "История",
                Content = scrollViewer,
                PrimaryButtonText = "Закрыть"
            };

            await contentDialog.ShowAsync();
        }
    }
}
