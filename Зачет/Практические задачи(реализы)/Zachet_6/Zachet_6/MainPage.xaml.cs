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
using System.Text.RegularExpressions;
using Windows.UI.Xaml.Shapes;
using Windows.Devices.Geolocation;
using Windows.Storage;
using System.Xml.Serialization;

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x419

namespace Zachet_6
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        public static List<Data> datas = new List<Data>();

        public MainPage()
        {
            this.InitializeComponent();

            getter();
        }

        async void getter()
        {
            StorageFolder folder = ApplicationData.Current.LocalFolder;

            StorageFile file = await folder.CreateFileAsync("db_datas.xml", CreationCollisionOption.OpenIfExists);

            XmlSerializer serializer = new XmlSerializer(typeof(List<Data>));

            try
            {
                using (Stream stream = await file.OpenStreamForReadAsync())
                {
                    datas = (List<Data>)serializer.Deserialize(stream);
                }
            }
            catch
            {

            }
        }

        async void setter(string NAME, string PHONE, string EMAIL, string COMMENT)
        {
            StorageFolder folder = ApplicationData.Current.LocalFolder;

            StorageFile file = await folder.CreateFileAsync("db_datas.xml", CreationCollisionOption.ReplaceExisting);

            XmlSerializer serializer = new XmlSerializer(typeof(List<Data>));

            Data data = new Data()
            { 
                Name = NAME,
                Phone = PHONE,
                Email = EMAIL,
                Comment = COMMENT
            };

            datas.Add(data);

            try
            {
                using (Stream stream = await file.OpenStreamForWriteAsync())
                {
                    serializer.Serialize(stream, datas);
                }
            }
            catch
            {

            }
        }

        private async void SendData_Click(object sender, RoutedEventArgs e)
        {

            string pattern = "[.\\-_a-z0-9]+@([a-z0-9][\\-a-z0-9]+\\.)+[a-z]{2,6}";

            if (LineName.Text == "")
            {
                var msg = await new MessageDialog("Поле с именем не должно быть пустым!").ShowAsync();
                return;
            }

            if (LinePhone.Text == "")
            {
                var msg = await new MessageDialog("Поле с номером не должно быть пустым!").ShowAsync();
                return;
            }

            if (LineEmail.Text == "")
            {
                var msg = await new MessageDialog("Поле с почтой не должно быть пустым!").ShowAsync();
                return;
            }

            if (LineComments.Text == "")
            {
                var msg = await new MessageDialog("Поле с коментом не должно быть пустым!").ShowAsync();
                return;
            }

            if (LinePhone.Text.Length > 11 || LinePhone.Text.Length < 11)
            {
                var msg = await new MessageDialog("Номер некорректный!").ShowAsync();
                return;
            }

            if (!long.TryParse(LinePhone.Text, out long number))
            {
                var msg = await new MessageDialog("Номер некорректный!").ShowAsync();
                return;
            }
                
            Match isMatch = Regex.Match(LineEmail.Text, pattern, RegexOptions.IgnoreCase);
            
            if(!isMatch.Success)
            {
                var msg = await new MessageDialog("Почта некорректна!").ShowAsync();
                return;
            }

            setter(LineName.Text, LinePhone.Text, LineEmail.Text, LineComments.Text);

            var msg1 = await new MessageDialog("Успех!").ShowAsync();
            var msg2 = await new MessageDialog(ApplicationData.Current.LocalFolder.Path).ShowAsync();


        }
    }
}
