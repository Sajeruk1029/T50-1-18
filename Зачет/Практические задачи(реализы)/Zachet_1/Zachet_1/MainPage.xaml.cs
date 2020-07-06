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

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x419

namespace Zachet_1
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            TabViewItem tab = new TabViewItem();
            tab.Header = "Новая вкладка";
            WebView web = new WebView();
            tab.Content = web;
            tabView.TabItems.Add(tab);
            web.Navigate(new Uri("https://yandex.ru"));
            web.NewWindowRequested += Web_NewWindowRequested;

        }

        private void Web_NewWindowRequested(WebView sender, WebViewNewWindowRequestedEventArgs args)
        {
            Addres.Text = args.Uri.AbsoluteUri;
            sender.Navigate(args.Uri);
            args.Handled = true;

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
                        ((tabView.TabItems[tabView.SelectedIndex] as TabViewItem).Content as WebView).Navigate(new Uri("https://yandex.ru/search/touch/?text=" + (sender as TextBox).Text));
                        (sender as TextBox).Text = "https://www.yandex.ru/search/touch/?text=" + (sender as TextBox).Text;
                    
                }
            }
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

        private void TabView_TabCloseRequested(Microsoft.UI.Xaml.Controls.TabView sender, Microsoft.UI.Xaml.Controls.TabViewTabCloseRequestedEventArgs args)
        {
            sender.TabItems.Remove(args.Tab);
            if (sender.TabItems.Count == 0)
                Application.Current.Exit();
        }


    }
}
