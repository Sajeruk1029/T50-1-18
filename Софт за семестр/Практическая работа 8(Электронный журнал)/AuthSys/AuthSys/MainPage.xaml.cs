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
using System.Security.Cryptography;
using System.Text;

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x419

namespace AuthSys
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        static List<AuthData> listAuthDatas = new List<AuthData>();

        public MainPage()
        {
            this.InitializeComponent();

            poluchatel();
        }

        private async void ButLogin_Click(object sender, RoutedEventArgs e)
        {

            bool ok = false;
            string passwdcrypt;
            int rez = 0;

            if (AuthLogin.Text == "")
            {
                var msg = await new MessageDialog("Login must not be empty!").ShowAsync();
                return;
            }

            if (AuthPasswd.Password == "")
            {
                var msg = await new MessageDialog("Password must not be empty!").ShowAsync();
                return;
            }

            passwdcrypt = Crypt(AuthPasswd.Password);

            for(int count = 0; count < listAuthDatas.Count; count++)
            {
                if((AuthLogin.Text == listAuthDatas[count].login) && (passwdcrypt == listAuthDatas[count].password))
                {
                    ok = true;
                    rez = count;
                    break;
                }
            }

            if(!ok)
            {
                var msg = await new MessageDialog("Invalid username or password!").ShowAsync();
            }
            else
            {
                var msg = await new MessageDialog("Success!").ShowAsync();

                if(listAuthDatas[rez].rol == "Adm")
                {
                    Frame.Navigate(typeof(Adm));
                }
                else if(listAuthDatas[rez].rol == "Teacher")
                {
                    Frame.Navigate(typeof(Teacher));
                }
                else
                {
                    Frame.Navigate(typeof(Student), listAuthDatas[rez].login);
                }

            }

        }

        private void ButReg_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Reg));
        }

        async void poluchatel()
        {
            AuthData authData = new AuthData();

            StorageFolder folder = ApplicationData.Current.LocalFolder;

            StorageFile file = await folder.CreateFileAsync("db_Auth.xml", CreationCollisionOption.OpenIfExists);

            XmlSerializer serializerAuthData = new XmlSerializer(typeof(List<AuthData>));

            try
            {
                using (Stream stream = await file.OpenStreamForReadAsync())
                {
                    listAuthDatas = (List<AuthData>)serializerAuthData.Deserialize(stream);
                }
            }
            catch
            {

            }


        }

        string Crypt(string password)
        {

            MD5 md5 = MD5.Create();

            byte[] data = md5.ComputeHash(Encoding.UTF8.GetBytes(password));

            StringBuilder LineBuilder = new StringBuilder();

            for (int count = 0; count < data.Length; count++)
            {
                LineBuilder.Append(data[count].ToString("x2"));
            }

            return LineBuilder.ToString();
        }

    }
}
