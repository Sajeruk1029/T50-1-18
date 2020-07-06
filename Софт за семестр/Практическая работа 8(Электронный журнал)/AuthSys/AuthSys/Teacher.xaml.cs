using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=234238

namespace AuthSys
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class Teacher : Page
    {
        static List<TeacherRecord> listrecords = new List<TeacherRecord>();
        static List<Subjects> listSabjects = new List<Subjects>();
        static List<AuthData> listAuthDatas = new List<AuthData>();
        static List<Groups> listGroups = new List<Groups>();

        public Teacher()
        {
            this.InitializeComponent();

            getter();
            getter_subj();
            getter_auth();
            getter_groups();
        }

        private void GoMainMenu_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }

        private async void ButAddLine_Click(object sender, RoutedEventArgs e)
        {
            ContentDialogResult res;

            StackPanel konteyner = new StackPanel();

            ComboBox ValuesBox = new ComboBox();
            ComboBox SubjectBox = new ComboBox();
            ComboBox StudentBox = new ComboBox();
            ComboBox GroupBox = new ComboBox();

            DatePicker datePicker = new DatePicker();

            datePicker.Date = DateTime.Now;

            ValuesBox.Items.Add(0);
            ValuesBox.Items.Add(2);
            ValuesBox.Items.Add(3);
            ValuesBox.Items.Add(4);
            ValuesBox.Items.Add(5);

            ValuesBox.SelectedIndex = 0;

            if (listSabjects.Count == 0)
            {
                SubjectBox.PlaceholderText = "Subjects are not found!";
            }
            else
            {
                for(int count = 0; count < listSabjects.Count; count++)
                {
                    SubjectBox.Items.Add(listSabjects[count].Name);
                }

                SubjectBox.SelectedIndex = 0;

            }

            for(int count = 0; count < listAuthDatas.Count; count++)
            {
                if(listAuthDatas[count].rol == "Student")
                {
                    StudentBox.Items.Add(listAuthDatas[count].login);
                }

            }



            if (StudentBox.Items.Count == 0)
            {
                StudentBox.PlaceholderText = "Students are not found!";
            }
            else
            {
                StudentBox.SelectedIndex = 0;
            }

            if(listGroups.Count == 0)
            {
                GroupBox.PlaceholderText = "Groups are not found!";
            }
            else
            {
                for (int count = 0; count < listGroups.Count; count++)
                {
                    GroupBox.Items.Add(listGroups[count].Name);
                }

                GroupBox.SelectedIndex = 0;

            }

            konteyner.Children.Add(datePicker);
            konteyner.Children.Add(SubjectBox);
            konteyner.Children.Add(GroupBox);
            konteyner.Children.Add(StudentBox);
            konteyner.Children.Add(ValuesBox);

            ContentDialog dialog = new ContentDialog()
            {
                Title = "Add new record...",
                Content = konteyner,
                PrimaryButtonText = "Create"
            };

            res = await dialog.ShowAsync();

            if (res == ContentDialogResult.Primary)
            {

                if(SubjectBox.Items.Count == 0 || StudentBox.Items.Count == 0 || GroupBox.Items.Count == 0)
                {
                    return;
                }

                changer(datePicker.Date, SubjectBox.SelectedItem.ToString(), GroupBox.SelectedValue.ToString(), StudentBox.SelectedValue.ToString(), Convert.ToInt32(ValuesBox.SelectedItem));
            }
        }

        async void changer(DateTimeOffset dat, string subj, string grp, string name, int val)
        {

            StorageFolder folder = ApplicationData.Current.LocalFolder;

            StorageFile file = await folder.CreateFileAsync("db_TeacherRecords.xml", CreationCollisionOption.ReplaceExisting);

            XmlSerializer serializerSubjects = new XmlSerializer(typeof(List<TeacherRecord>));

            TeacherRecord record = new TeacherRecord()
            {
                data = dat.Date.ToString(),
                subject = subj,
                group = grp,
                student = name,
            };

            if(val == 0)
            {
                record.value = "nb";
            }
            else
            {
                record.value = val.ToString();
            }

            listrecords.Add(record);

            Stream stream = await file.OpenStreamForWriteAsync();

            serializerSubjects.Serialize(stream, listrecords);

            stream.Close();

            ListOfRecords.Items.Add(dat.Date.ToString() + ':' + subj + ':' + grp + ':' + name + ':' + record.value);

        }

        async void getter()
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

            ListOfRecords.Items.Clear();

            for (int count = 0; count < listrecords.Count; count++)
            {
                ListOfRecords.Items.Add(listrecords[count].data+ ':' + listrecords[count].subject + ':' + listrecords[count].group + ':' + listrecords[count].student + ':' + listrecords[count].value);
            }
        }

        async void getter_subj()
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

        }

    }
}
