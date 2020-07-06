using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Xml.Serialization;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x419

namespace Zachet_5
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        public List<Texts> ListTexts = new List<Texts>();

        public MainPage()
        {
            this.InitializeComponent();

            getter();
        
        }

        private void AddBut_Click(object sender, RoutedEventArgs e)
        {
            setter_add();
        }

        private void RefreshBut_Click(object sender, RoutedEventArgs e)
        {
            setter_refr();
        }

        private void DeleteBut_Click(object sender, RoutedEventArgs e)
        {
            setter_del();
        }

        async void getter()
        {
            StorageFolder folder = ApplicationData.Current.LocalFolder;

            StorageFile file = await folder.CreateFileAsync("db_texts.xml", CreationCollisionOption.OpenIfExists);

            XmlSerializer serializer = new XmlSerializer(typeof(List<Texts>));

            try
            {
                using (Stream stream = await file.OpenStreamForReadAsync())
                {
                    ListTexts = (List<Texts>)serializer.Deserialize(stream);
                }
            }
            catch
            {

            }

            for(int count = 0; count < ListTexts.Count; count++)
            {
                ListOfTexts.Items.Add((ListTexts[count].Header + ':' + ListTexts[count].Text).ToString());
            }
        }

        async void setter_refr()
        {

            StorageFolder folder = ApplicationData.Current.LocalFolder;

            StorageFile file = await folder.CreateFileAsync("db_texts.xml", CreationCollisionOption.ReplaceExisting);

            XmlSerializer serializer = new XmlSerializer(typeof(List<Texts>));

            StackPanel konteyner = new StackPanel();

            konteyner.Children.Add(new TextBox() { PlaceholderText = "Name..." });
            konteyner.Children.Add(new TextBox() { PlaceholderText = "New Name..." });
            konteyner.Children.Add(new TextBox() { PlaceholderText = "New text..." });

            ContentDialogResult res;

            ContentDialog dialog = new ContentDialog()
            {
                Title = "Change",
                Content = konteyner,
                PrimaryButtonText = "Refresh"
            };

            res = await dialog.ShowAsync();

            if (res == ContentDialogResult.Primary)
            {
                for(int count = 0; count < ListTexts.Count; count++)
                {
                    if(ListTexts[count].Header == (konteyner.Children[0] as TextBox).Text)
                    {
                        ListTexts[count].Header = (konteyner.Children[1] as TextBox).Text;
                        ListTexts[count].Text = (konteyner.Children[2] as TextBox).Text;
                    }
                }

                ListOfTexts.Items.Clear();

                for (int count = 0; count < ListTexts.Count; count++)
                {
                    ListOfTexts.Items.Add((ListTexts[count].Header + ':' + ListTexts[count].Text).ToString());
                }

                try
                {
                    using (Stream stream = await file.OpenStreamForWriteAsync())
                    {
                        serializer.Serialize(stream, ListTexts);
                    }
                }
                catch
                {

                }

            }
        }

        async void setter_del()
        {
            ContentDialogResult res;

            Texts texts = new Texts();

            StorageFolder folder = ApplicationData.Current.LocalFolder;

            StorageFile file = await folder.CreateFileAsync("db_texts.xml", CreationCollisionOption.ReplaceExisting);

            XmlSerializer serializer = new XmlSerializer(typeof(List<Texts>));

            ContentDialog dialog = new ContentDialog()
            {
                Title = "Delete",
                Content = new TextBox() { PlaceholderText = "Name..." },
                PrimaryButtonText = "Delete"
            };

            res = await dialog.ShowAsync();

            if (res == ContentDialogResult.Primary)
            {
                for(int count = 0; count < ListTexts.Count; count++)
                {
                    if(ListTexts[count].Header == (dialog.Content as TextBox).Text)
                    {
                        ListTexts.RemoveAt(count);
                        break;
                    }
                }

                ListOfTexts.Items.Clear();

                for (int count = 0; count < ListTexts.Count; count++)
                {
                    ListOfTexts.Items.Add((ListTexts[count].Header + ':' + ListTexts[count].Text).ToString());
                }

                try
                {
                    using (Stream stream = await file.OpenStreamForWriteAsync())
                    {
                        serializer.Serialize(stream, ListTexts);
                    }
                }
                catch
                {

                }

            }
        }

        async void setter_add()
        {
            StackPanel konteyner = new StackPanel();

            StorageFolder folder = ApplicationData.Current.LocalFolder;

            StorageFile file = await folder.CreateFileAsync("db_texts.xml", CreationCollisionOption.ReplaceExisting);

            XmlSerializer serializer = new XmlSerializer(typeof(List<Texts>));

            konteyner.Children.Add(new TextBox() { PlaceholderText = "Name..." });
            konteyner.Children.Add(new TextBox() { PlaceholderText = "Text..." });

            ContentDialogResult res;

            Texts texts = new Texts();

            ContentDialog dialog = new ContentDialog()
            {
                Title = "New",
                Content = konteyner,
                PrimaryButtonText = "Add"
            };

            res = await dialog.ShowAsync();

            if(res == ContentDialogResult.Primary)
            {
                texts.Header = (konteyner.Children[0] as TextBox).Text;
                texts.Text = (konteyner.Children[1] as TextBox).Text;

                ListTexts.Add(texts);

                ListOfTexts.Items.Clear();

                for (int count = 0; count < ListTexts.Count; count++)
                {
                    ListOfTexts.Items.Add((ListTexts[count].Header + ':' + ListTexts[count].Text).ToString());
                }

                try
                {
                    using (Stream stream = await file.OpenStreamForWriteAsync())
                    {
                        serializer.Serialize(stream, ListTexts);
                    }
                }
                catch
                {

                }

            }

        }

    }
}
