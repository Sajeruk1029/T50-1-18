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

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=234238

namespace AuthSys
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    /// 
    
    public sealed partial class Reg : Page
    {

        static List<AuthData> listAuthDatas = new List<AuthData>();
        static List<Groups> listGroups = new List<Groups>();

        public Reg()
        {
            this.InitializeComponent();

            AuthRol.Items.Add("Adm");
            AuthRol.Items.Add("Teacher");
            AuthRol.Items.Add("Student");

            AuthRol.SelectedIndex = 0;

            poluchatel();
            getter_groups();

        }

        private async void ButReg_Click(object sender, RoutedEventArgs e)
        {
            if(AuthLogin.Text == "")
            {
                var msg = await new MessageDialog("Login must not be empty!").ShowAsync();
                return;
            }

            if (AuthPasswd.Password == "")
            {
                var msg = await new MessageDialog("Password must not be empty!").ShowAsync();
                return;
            }

            if(AuthGroup.SelectedIndex < 0 &&  AuthRol.SelectedItem.ToString() == "Student")
            {
                var msg = await new MessageDialog("Group must not be empty!").ShowAsync();
                return;
            }

            if(AuthRol.SelectedItem.ToString() == "Student")
            {
                otpravitel(AuthLogin.Text, AuthPasswd.Password, AuthRol.SelectedItem.ToString(), AuthGroup.SelectedItem.ToString());
            }
            else
            {
                otpravitel(AuthLogin.Text, AuthPasswd.Password, AuthRol.SelectedItem.ToString(), "null");
            }
            

        }

        private void GoMainMenu_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
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

        async void getter_groups()
        {
            Groups groups = new Groups();

            StorageFolder folder = ApplicationData.Current.LocalFolder;

            StorageFile file = await folder.CreateFileAsync("db_Groups.xml", CreationCollisionOption.OpenIfExists);

            XmlSerializer serializerAuthData = new XmlSerializer(typeof(List<Groups>));

            try
            {
                using (Stream stream = await file.OpenStreamForReadAsync())
                {
                    listGroups = (List<Groups>)serializerAuthData.Deserialize(stream);
                }
            }
            catch
            {

            }

            if (listGroups.Count == 0)
            {
                AuthGroup.PlaceholderText = "Groups are not found!";
            }
            else
            {
                for (int count = 0; count < listGroups.Count; count++)
                {
                    AuthGroup.Items.Add(listGroups[count].Name);
                }

                AuthGroup.SelectedIndex = 0;
            }

        }

        async void otpravitel(string login, string password, string rol, string group)
        {

            StorageFolder folder = ApplicationData.Current.LocalFolder;

            StorageFile file = await folder.CreateFileAsync("db_Auth.xml", CreationCollisionOption.OpenIfExists);

            XmlSerializer serializerAuthData = new XmlSerializer(typeof(List<AuthData>));

            AuthData authData = new AuthData()
            {
                login = login,
                password = Crypt(password),
                rol = rol,
                group = group
            };

            listAuthDatas.Add(authData);

            Stream stream = await file.OpenStreamForWriteAsync();

            serializerAuthData.Serialize(stream, listAuthDatas);

            stream.Close();

            var msg = new MessageDialog("Success!").ShowAsync();


        }

        string Crypt(string password)
        {

            MD5 md5 = MD5.Create();

            byte[] data = md5.ComputeHash(Encoding.UTF8.GetBytes(password));

            StringBuilder LineBuilder = new StringBuilder();

            for(int count = 0; count < data.Length; count++)
            {
                LineBuilder.Append(data[count].ToString("x2"));
            }

            return LineBuilder.ToString();
        }

        private void AuthRol_DropDownClosed(object sender, object e)
        {
            if (AuthRol.SelectedItem.ToString() == "Student")
            {
                AuthGroup.IsEnabled = true;
            }
            else
            {
                AuthGroup.IsEnabled = false;
            }
        }
    }
}
