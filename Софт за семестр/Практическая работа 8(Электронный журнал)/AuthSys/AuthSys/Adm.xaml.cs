using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Cryptography;
using System.Text;
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
using Windows.UI.Notifications;

using OfficeOpenXml;
using Windows.Storage.Pickers;
using System.Threading;
using Windows.UI.Popups;

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=234238

namespace AuthSys
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class Adm : Page
    {

        static List<Subjects> listSabjects = new List<Subjects>();
        static List<Groups> listGroups = new List<Groups>();
        static List<AuthData> listAuthDatas = new List<AuthData>();
        static List<TeacherRecord> listrecords = new List<TeacherRecord>();

        static ComboBox groupsbox = new ComboBox();

        public Adm()
        {
            this.InitializeComponent();

            getter();
            getter_groups();
            getter_auth();
            getter_reconds();

            TableUsers.ItemsSource = listAuthDatas;

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

        }

        private void GoMainMenu_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }

        private async void ButSubjectAdd_Click(object sender, RoutedEventArgs e)
        {
            ContentDialogResult res;

            ContentDialog dialog = new ContentDialog()
            {
                Title = "Set name for new subject",
                Content = new TextBox() { PlaceholderText = "Name of subject..." },
                PrimaryButtonText = "Create"
            };

            res = await dialog.ShowAsync();

            if (res == ContentDialogResult.Primary)
            {
                changer((dialog.Content as TextBox).Text);
            }

        }

        private async void ButSubjectChg_Click(object sender, RoutedEventArgs e)
        {

            ContentDialogResult res;

            StackPanel konteyner = new StackPanel();

            konteyner.Children.Add(new TextBox() { PlaceholderText = "Name of subject..." });
            konteyner.Children.Add(new TextBox() { PlaceholderText = "New name of subject..." });

            ContentDialog dialog = new ContentDialog()
            {
                Title = "Set new name for subject",
                Content = konteyner,
                PrimaryButtonText = "Change"
            };

            res = await dialog.ShowAsync();

            if (res == ContentDialogResult.Primary)
            {
                changer(((konteyner.Children[0]) as TextBox).Text, ((konteyner.Children[1]) as TextBox).Text);
            }
        }

        private async void ButSubjectDel_Click(object sender, RoutedEventArgs e)
        {
            ContentDialogResult res;

            ContentDialog dialog = new ContentDialog()
            {
                Title = "Delete subject",
                Content = new TextBox() { PlaceholderText = "Name of subject for delete..." },
                PrimaryButtonText = "Delete"
            };

            res = await dialog.ShowAsync();

            if (res == ContentDialogResult.Primary)
            {
                changer_del((dialog.Content as TextBox).Text);
            }
        }

        async void getter()
        {
            Subjects subjects = new Subjects();

            StorageFolder folder = ApplicationData.Current.LocalFolder;

            StorageFile file = await folder.CreateFileAsync("db_Subjects.xml", CreationCollisionOption.OpenIfExists);

            XmlSerializer serializerSubjects = new XmlSerializer(typeof(List<Subjects>));

            try
            {
                using (Stream stream = await file.OpenStreamForReadAsync())
                {
                    listSabjects = (List<Subjects>)serializerSubjects.Deserialize(stream);
                }
            }
            catch
            {

            }

            SubjectBox.Items.Clear();

            for (int count = 0; count < listSabjects.Count; count++)
            {
                SubjectBox.Items.Add(listSabjects[count].Name);
            }

        }

        async void getter_groups()
        {
            Groups groups = new Groups();

            StorageFolder folder = ApplicationData.Current.LocalFolder;

            StorageFile file = await folder.CreateFileAsync("db_Groups.xml", CreationCollisionOption.OpenIfExists);

            XmlSerializer serializerGroups = new XmlSerializer(typeof(List<Groups>));

            try
            {
                using (Stream stream = await file.OpenStreamForReadAsync())
                {
                    listGroups = (List<Groups>)serializerGroups.Deserialize(stream);
                }
            }
            catch
            {

            }

            GroupsBox.Items.Clear();

            for (int count = 0; count < listGroups.Count; count++)
            {
                GroupsBox.Items.Add(listGroups[count].Name);
            }

        }

        async void getter_auth()
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

            TableUsers.ItemsSource = listAuthDatas;


        }

        async void changer(string name)
        {
            
            StorageFolder folder = ApplicationData.Current.LocalFolder;

            StorageFile file = await folder.CreateFileAsync("db_Subjects.xml", CreationCollisionOption.ReplaceExisting);

            XmlSerializer serializerSubjects = new XmlSerializer(typeof(List<Subjects>));

            
            if(name == "")
            {
                return;
            }

            Subjects subject = new Subjects()
            {
                Name = name
            };

            listSabjects.Add(subject);

            Stream stream = await file.OpenStreamForWriteAsync();

            serializerSubjects.Serialize(stream, listSabjects);

            stream.Close();

            SubjectBox.Items.Add(name);

        }

        async void changer_del(string name)
        {

            StorageFolder folder = ApplicationData.Current.LocalFolder;

            StorageFile file = await folder.CreateFileAsync("db_Subjects.xml", CreationCollisionOption.ReplaceExisting);

            XmlSerializer serializerSubjects = new XmlSerializer(typeof(List<Subjects>));


            if (name == "")
            {
                return;
            }

            for (int count = 0; count < listSabjects.Count; count++)
            {
                if (listSabjects[count].Name == name)
                {
                    listSabjects.RemoveAt(count);
                    break;
                }
            }

            Stream stream = await file.OpenStreamForWriteAsync();

            serializerSubjects.Serialize(stream, listSabjects);

            stream.Close();

            SubjectBox.Items.Clear();

            for(int count = 0; count < listSabjects.Count; count++)
            {
                SubjectBox.Items.Add(listSabjects[count].Name);
            }

        }

        async void changer(string name, string new_name)
        {

            StorageFolder folder = ApplicationData.Current.LocalFolder;

            StorageFile file = await folder.CreateFileAsync("db_Subjects.xml", CreationCollisionOption.OpenIfExists);

            XmlSerializer serializerSubjects = new XmlSerializer(typeof(List<Subjects>));

            if (name == "" || new_name == "")
            {
                return;
            }

            for(int count = 0; count < listSabjects.Count; count++)
            {
                if(listSabjects[count].Name == name)
                {
                    listSabjects[count].Name = new_name;
                }
            }

            Stream stream = await file.OpenStreamForWriteAsync();

            serializerSubjects.Serialize(stream, listSabjects);

            stream.Close();

            SubjectBox.Items.Clear();

            for (int count = 0; count < listSabjects.Count; count++)
            {
                SubjectBox.Items.Add(listSabjects[count].Name);
            }

        }


        async void changer_groups(string name)
        {

            StorageFolder folder = ApplicationData.Current.LocalFolder;

            StorageFile file = await folder.CreateFileAsync("db_Groups.xml", CreationCollisionOption.ReplaceExisting);

            XmlSerializer serializerGroups = new XmlSerializer(typeof(List<Groups>));


            if (name == "")
            {
                return;
            }

            Groups groups = new Groups()
            {
                Name = name
            };

            listGroups.Add(groups);

            Stream stream = await file.OpenStreamForWriteAsync();

            serializerGroups.Serialize(stream, listGroups);

            stream.Close();

            GroupsBox.Items.Add(name);

        }

        async void changer_groups_del(string name)
        {

            StorageFolder folder = ApplicationData.Current.LocalFolder;

            StorageFile file = await folder.CreateFileAsync("db_Groups.xml", CreationCollisionOption.ReplaceExisting);

            XmlSerializer serializerGroups = new XmlSerializer(typeof(List<Groups>));


            if (name == "")
            {
                return;
            }

            for (int count = 0; count < listGroups.Count; count++)
            {
                if (listGroups[count].Name == name)
                {
                    listGroups.RemoveAt(count);
                    break;
                }
            }

            Stream stream = await file.OpenStreamForWriteAsync();

            serializerGroups.Serialize(stream, listGroups);

            stream.Close();

            GroupsBox.Items.Clear();

            for (int count = 0; count < listGroups.Count; count++)
            {
                GroupsBox.Items.Add(listGroups[count].Name);
            }

        }

        async void changer_groups(string name, string new_name)
        {

            StorageFolder folder = ApplicationData.Current.LocalFolder;

            StorageFile file = await folder.CreateFileAsync("db_Groups.xml", CreationCollisionOption.OpenIfExists);

            XmlSerializer serializerGroups = new XmlSerializer(typeof(List<Groups>));

            if (name == "" || new_name == "")
            {
                return;
            }

            for (int count = 0; count < listGroups.Count; count++)
            {
                if (listGroups[count].Name == name)
                {
                    listGroups[count].Name = new_name;
                }
            }

            Stream stream = await file.OpenStreamForWriteAsync();

            serializerGroups.Serialize(stream, listGroups);

            stream.Close();

            GroupsBox.Items.Clear();

            for (int count = 0; count < listGroups.Count; count++)
            {
                GroupsBox.Items.Add(listGroups[count].Name);
            }

        }

        async void changer_users(string login, string new_login, string new_password, string new_rol, string new_group)
        {

            StorageFolder folder = ApplicationData.Current.LocalFolder;

            StorageFile file = await folder.CreateFileAsync("db_Auth.xml", CreationCollisionOption.ReplaceExisting);

            XmlSerializer serializerAuthData = new XmlSerializer(typeof(List<AuthData>));

            if (login == "" || new_login == "")
            {
                return;
            }

            for (int count = 0; count < listAuthDatas.Count; count++)
            {
                if (listAuthDatas[count].login == login)
                {
                    listAuthDatas[count].login = new_login;
                    listAuthDatas[count].password = new_password;
                    listAuthDatas[count].rol = new_rol;
                    listAuthDatas[count].group = new_group;

                }
            }

            Stream stream = await file.OpenStreamForWriteAsync();

            serializerAuthData.Serialize(stream, listAuthDatas);

            stream.Close();

            //TableUsers.ItemsSource = null;
            TableUsers.ItemsSource = listAuthDatas;

        }

        async void changer_users_del(string login)
        {

            StorageFolder folder = ApplicationData.Current.LocalFolder;

            StorageFile file = await folder.CreateFileAsync("db_Auth.xml", CreationCollisionOption.ReplaceExisting);

            XmlSerializer serializerAuthData = new XmlSerializer(typeof(List<AuthData>));


            if (login == "")
            {
                return;
            }

            for (int count = 0; count < listAuthDatas.Count; count++)
            {
                if (listAuthDatas[count].login == login)
                {
                    listAuthDatas.RemoveAt(count);
                    break;
                }
            }

            Stream stream = await file.OpenStreamForWriteAsync();

            serializerAuthData.Serialize(stream, listAuthDatas);

            stream.Close();

            //TableUsers.ItemsSource = null;
            TableUsers.ItemsSource = listAuthDatas;

        }

        private async void ButUserDel_Click(object sender, RoutedEventArgs e)
        {
            ContentDialogResult res;

            ContentDialog dialog = new ContentDialog()
            {
                Title = "Delete user",
                Content = new TextBox() { PlaceholderText = "Login of user for delete..." },
                PrimaryButtonText = "Delete"
            };

            res = await dialog.ShowAsync();

            if (res == ContentDialogResult.Primary)
            {
                changer_users_del((dialog.Content as TextBox).Text);
            }
        }

        private async void ButUserChg_Click(object sender, RoutedEventArgs e)
        {
            ContentDialogResult res;

            StackPanel konteyner = new StackPanel();

            groupsbox = new ComboBox();
            ComboBox typeuser = new ComboBox();

            konteyner.Children.Add(new TextBox() { PlaceholderText = "Login of user..." });
            konteyner.Children.Add(new TextBox() { PlaceholderText = "New login of user..." });
            konteyner.Children.Add(new TextBox() { PlaceholderText = "New password of user..." });
            konteyner.Children.Add(typeuser);
            konteyner.Children.Add(groupsbox);

            groupsbox.Items.Clear();
            groupsbox.IsEnabled = false;

            if (listGroups.Count > 0)
            {
                for(int count = 0; count < listGroups.Count; count++)
                {
                    groupsbox.Items.Add(listGroups[count].Name);
                }

                groupsbox.SelectedIndex = 0;
            }
            else
            {
                groupsbox.PlaceholderText = "Groups are not found!";
            }

            typeuser.Items.Add("Adm");
            typeuser.Items.Add("Teacher");
            typeuser.Items.Add("Student");

            typeuser.SelectedIndex = 0;

            typeuser.DropDownClosed += Typeuser_DropDownClosed;

            ContentDialog dialog = new ContentDialog()
            {
                Title = "Change user data",
                Content = konteyner,
                PrimaryButtonText = "Change"
            };

            res = await dialog.ShowAsync();

            if (res == ContentDialogResult.Primary)
            {
                if (typeuser.SelectedItem.ToString() == "Student")
                {
                    changer_users(((konteyner.Children[0]) as TextBox).Text, ((konteyner.Children[1]) as TextBox).Text, Crypt(((konteyner.Children[2]) as TextBox).Text), ((konteyner.Children[3]) as ComboBox).SelectedItem.ToString(), ((konteyner.Children[4]) as ComboBox).SelectedItem.ToString());
                }
                else
                {
                    changer_users(((konteyner.Children[0]) as TextBox).Text, ((konteyner.Children[1]) as TextBox).Text, Crypt(((konteyner.Children[2]) as TextBox).Text), ((konteyner.Children[3]) as ComboBox).SelectedItem.ToString(), "null");
                }


                
            }
        }

        private void Typeuser_DropDownClosed(object sender, object e)
        {
            if((sender as ComboBox).SelectedItem.ToString() == "Student")
            {
                groupsbox.IsEnabled = true;
            }
            else
            {
                groupsbox.IsEnabled = false;
            }
        }

        private async void ButGroupDel_Click(object sender, RoutedEventArgs e)
        {
            ContentDialogResult res;

            ContentDialog dialog = new ContentDialog()
            {
                Title = "Delete group",
                Content = new TextBox() { PlaceholderText = "Name of group for delete..." },
                PrimaryButtonText = "Delete"
            };

            res = await dialog.ShowAsync();

            if (res == ContentDialogResult.Primary)
            {
                changer_groups_del((dialog.Content as TextBox).Text);
            }
        }

        private async void ButGroupChg_Click(object sender, RoutedEventArgs e)
        {
            ContentDialogResult res;

            StackPanel konteyner = new StackPanel();

            konteyner.Children.Add(new TextBox() { PlaceholderText = "Name of group..." });
            konteyner.Children.Add(new TextBox() { PlaceholderText = "New name of group..." });

            ContentDialog dialog = new ContentDialog()
            {
                Title = "Set new name for group",
                Content = konteyner,
                PrimaryButtonText = "Change"
            };

            res = await dialog.ShowAsync();

            if (res == ContentDialogResult.Primary)
            {
                changer_groups(((konteyner.Children[0]) as TextBox).Text, ((konteyner.Children[1]) as TextBox).Text);
            }
        }

        private async void ButGroupAdd_Click(object sender, RoutedEventArgs e)
        {
            ContentDialogResult res;

            ContentDialog dialog = new ContentDialog()
            {
                Title = "Set name for new group",
                Content = new TextBox() { PlaceholderText = "Name of group..." },
                PrimaryButtonText = "Create"
            };

            res = await dialog.ShowAsync();

            if (res == ContentDialogResult.Primary)
            {
                changer_groups((dialog.Content as TextBox).Text);
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


        async void getter_reconds()
        {
            TeacherRecord record = new TeacherRecord();

            StorageFolder folder = ApplicationData.Current.LocalFolder;

            StorageFile file = await folder.CreateFileAsync("db_TeacherRecords.xml", CreationCollisionOption.OpenIfExists);

            XmlSerializer serializerRecords = new XmlSerializer(typeof(List<TeacherRecord>));

            try
            {
                using (Stream stream = await file.OpenStreamForReadAsync())
                {
                    listrecords = (List<TeacherRecord>)serializerRecords.Deserialize(stream);
                }
            }
            catch
            {

            }

        }

        private async void PrintJournal_Click(object sender, RoutedEventArgs e)
        {

            ToastNotifier toast = ToastNotificationManager.CreateToastNotifier();

            Windows.Data.Xml.Dom.XmlDocument toastxml = ToastNotificationManager.GetTemplateContent(ToastTemplateType.ToastImageAndText02);

            Windows.Data.Xml.Dom.XmlNodeList toastnodelist = toastxml.GetElementsByTagName("text");

            ToastNotification toastNotification;

            ComboBox gBox = new ComboBox();

            int kol = 0;

            FileInfo fi;

            List<TeacherRecord> records = new List<TeacherRecord>();

            ContentDialog dialog = new ContentDialog()
            {
                Title = "Export data",
                Content = gBox,
                PrimaryButtonText = "Export"
            };

            for (int count = 0; count < listGroups.Count; count++)
            {
                gBox.Items.Add(listGroups[count].Name);
            }
            
            if(gBox.Items.Count > 0)
            {
                gBox.SelectedIndex = 0;
            }
            else
            {
                gBox.PlaceholderText = "Groups are not found!";   
            }
            

            ContentDialogResult res = await dialog.ShowAsync();

            if (res == ContentDialogResult.Primary)
            {

                if(gBox.Items.Count == 0)
                {
                    return;
                }

                using (ExcelPackage excel = new ExcelPackage())
                {
                    excel.Workbook.Properties.Title = "Export";

                    ExcelWorksheet worksheet = excel.Workbook.Worksheets.Add(gBox.SelectedItem.ToString());

                    for (int count = 0; count < listrecords.Count; count++)
                    {
                        if (listrecords[count].group == gBox.SelectedItem.ToString())
                        {
                            records.Add(listrecords[count]);
                        }
                    }

                    for (int count = 0; count < records.Count; count++)
                    {
                        {
                            for (int count2 = 0; count2 < 5; count2++)
                            {
                                switch (count2)
                                {
                                    case 0:
                                        {
                                            worksheet.Cells[count + 1, count2 + 1].Value = listrecords[count].data;
                                            break;
                                        }

                                    case 1:
                                        {
                                            worksheet.Cells[count + 1, count2 + 1].Value = listrecords[count].subject;
                                            break;
                                        }

                                    case 2:
                                        {
                                            worksheet.Cells[count + 1, count2 + 1].Value = listrecords[count].group;
                                            break;
                                        }

                                    case 3:
                                        {
                                            worksheet.Cells[count + 1, count2 + 1].Value = listrecords[count].student;
                                            break;
                                        }

                                    case 4:
                                        {
                                            worksheet.Cells[count + 1, count2 + 1].Value = listrecords[count].value;
                                            break;
                                        }

                                }

                                kol++;

                            }
                        }

                    }
                        if(kol == 0)
                        {
                            worksheet.Cells[1, 1].Value = "Records are not found!";

                        }

                    fi = new FileInfo(ApplicationData.Current.LocalFolder.Path + @"\" + "Export" + " group " + gBox.SelectedItem.ToString() + ".xlsx");


                    try
                    {
                        excel.SaveAs(fi);
                    }
                    catch(Exception ex)
                    {
                        toastnodelist.Item(0).AppendChild(toastxml.CreateTextNode("Exception!"));
                        toastnodelist.Item(1).AppendChild(toastxml.CreateTextNode(e.ToString()));

                        toastNotification = new ToastNotification(toastxml);
                        toastNotification.ExpirationTime = DateTime.Now.AddSeconds(4);

                        toast.Show(toastNotification);

                        return;
                    }
                    finally
                    {
                        toastnodelist.Item(0).AppendChild(toastxml.CreateTextNode("Success!"));
                        toastnodelist.Item(1).AppendChild(toastxml.CreateTextNode(ApplicationData.Current.LocalFolder.Path + @"\" + "Export" + " group " + gBox.SelectedItem.ToString() + ".xlsx"));

                        toastNotification = new ToastNotification(toastxml);
                        toastNotification.ExpirationTime = DateTime.Now.AddSeconds(4);

                        toast.Show(toastNotification);
                    }

                    //var msg = await new MessageDialog(ApplicationData.Current.LocalFolder.Path + @"\" + "Export" + " group " + gBox.SelectedItem.ToString() + ".xlsx").ShowAsync();
                }


            }

            }

            }
}
