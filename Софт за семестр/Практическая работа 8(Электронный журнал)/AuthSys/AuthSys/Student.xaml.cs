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

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=234238

namespace AuthSys
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class Student : Page
    {
        static string login;
        static List<TeacherRecord> records = new List<TeacherRecord>();
        static List<TeacherRecord> listrecords = new List<TeacherRecord>();
        static List<Subjects> listSabjects = new List<Subjects>();

        public Student()
        {
            this.InitializeComponent();

            getter_reconds();
            getter_subj();

        }

        private void GoMainMenu_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            login = e.Parameter.ToString();
            StudentName.Text = login;
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

            for(int count = 0; count < listrecords.Count; count++)
            {
                if(listrecords[count].student == login)
                {
                    records.Add(listrecords[count]);
                }
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

        private async void ButShowRec_Click(object sender, RoutedEventArgs e)
        {

            ComboBox sabjBox = new ComboBox();

            ContentDialog dialog = new ContentDialog()
            {
                Title = "Show estimations",
                Content = sabjBox,
                PrimaryButtonText = "Show"
            };

            for(int count = 0; count < listSabjects.Count; count++)
            {
                sabjBox.Items.Add(listSabjects[count].Name);
            }

            sabjBox.Items.Add("All");

            sabjBox.SelectedIndex = 0;

            ContentDialogResult res = await dialog.ShowAsync();

            if(res == ContentDialogResult.Primary)
            {

                RecordsBox.Items.Clear();

                if(sabjBox.SelectedItem.ToString() == "All")
                {
                    for(int count = 0; count < records.Count; count++)
                    {
                        RecordsBox.Items.Add(records[count].data + ':' + records[count].subject + ':' + records[count].group + ':' + records[count].student + ':' + records[count].value);
                    }
                }
                else
                {
                    for (int count = 0; count < records.Count; count++)
                    {
                        if(records[count].subject == sabjBox.SelectedItem.ToString())
                        {
                            RecordsBox.Items.Add(records[count].data + ':' + records[count].subject + ':' + records[count].group + ':' + records[count].student + ':' + records[count].value);
                        }

                        
                    }
                }
            }


        }
    }
}
