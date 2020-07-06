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

using Windows.Storage;
using System.Xml.Serialization;
using Windows.UI.Popups;
using Windows.Storage.Pickers;
using Windows.Storage.Streams;

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x419

namespace Player
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    /// 

    [Serializable]
    public class Files_Struct
    {
        public string name;
        public List<String> musics = new List<string>();
    }

    public sealed partial class MainPage : Page
    {

        static StorageFile file;

        static FileOpenPicker fileOpenPicker;

        static ComboBox ComboBox;

        static List<Files_Struct> files_structs_list;

        string path;

        public MainPage()
        {
            this.InitializeComponent();

            //pred_start();

            fileOpenPicker = new FileOpenPicker();

            fileOpenPicker.CommitButtonText = "Открыть";
            fileOpenPicker.FileTypeFilter.Add(".mp3");

            Player.Volume = 1;

            VolumeProgress.Value = Player.Volume * 100f;

        }

        private async void File_Click(object sender, RoutedEventArgs e)
        {
                
            ScrollPlaylist.Visibility = Visibility.Collapsed;

            file = await fileOpenPicker.PickSingleFileAsync();

            if (file == null)
            {
                return;
            }

            NameMusic.Text = "Name music: " + file.Name;
        }

        private async void Play_Click(object sender, RoutedEventArgs e)
        {
            if ((sender as Button).Content.ToString() == "Play")
            {
                if (NameMusic.Text == "Name music: ")
                {
                    var msg1 = new MessageDialog("The file was not selected.").ShowAsync();
                    return;
                }

                (sender as Button).Content = "Pause";

                if(Player.CurrentState == MediaElementState.Stopped || Player.CurrentState == MediaElementState.Closed)
                {
                    Player.SetSource(await file.OpenReadAsync(), "");
                }

                Player.Play();
            }
            else
            {
                (sender as Button).Content = "Play";

                Player.Pause();
            }
        }

        private void VolumeProgress_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            if(VolumeProgress.IsLoaded)
            {
                Player.Volume = VolumeProgress.Value / 100f;

            }
            
        }

        private void Player_MediaEnded(object sender, RoutedEventArgs e)
        {
            NameMusic.Text = "Name music: ";
            Play.Content = "Play";
        }

        private async void Playlists_Click(object sender, RoutedEventArgs e)
        {
            ScrollPlaylist.Visibility = Visibility.Visible;

            path = ApplicationData.Current.LocalFolder.Path;

            var list = await ApplicationData.Current.LocalFolder.GetFoldersAsync();

            Playlist.Items.Clear();

            for(int count = 0; count < list.Count; count++)
            {
                Playlist.Items.Add(new Button() { Content = list[count].Name, Height = 50, Width = 500 } ) ;
                (Playlist.Items[count] as Button).Click += MainPage_Click;
            }

            if(list.Count == 0)
            {
                var msg = new MessageDialog("Playlists are not found!").ShowAsync();
            }

        }

        private async void MainPage_Click(object sender, RoutedEventArgs e)
        {
            //var msg = new MessageDialog(ApplicationData.Current.LocalFolder.Path + @"\" + (sender as Button).Content).ShowAsync();
            Playlist.Items.Clear();

            int gruzik = 0;
            
            var list = await StorageFolder.GetFolderFromPathAsync(ApplicationData.Current.LocalFolder.Path + @"\" + (sender as Button).Content);

            path = path + @"\" + (sender as Button).Content;

            var list_f = await list.GetFilesAsync();

            for (int count = 0; count < list_f.Count; count++)
            {
                if (list_f[count].FileType == ".mp3")
                {
                    Playlist.Items.Add(new Button() { Content = list_f[count].Name, Height = 50, Width = 500 });
                    (Playlist.Items[count - gruzik] as Button).Click += MainPage_Click1;

                }
                else
                {
                    gruzik++;
                }

            }

            if (list_f.Count == 0)
            {
                var msg = new MessageDialog("Audio are not found!").ShowAsync();
            }
            

        }

        private async void MainPage_Click1(object sender, RoutedEventArgs e)
        {
            //var msg = new MessageDialog(path + @"\" + (sender as Button).Content).ShowAsync();

            Player.Stop();

            Play.Content = "Play";


            file = await StorageFile.GetFileFromPathAsync(path + @"\" + (sender as Button).Content);
            NameMusic.Text = "Name music: " + file.Name;

        }

        /*
        async void pred_start()
        {
            files_structs_list = new List<Files_Struct>();

            Files_Struct files_Struct = new Files_Struct();

            StorageFolder folder = ApplicationData.Current.LocalFolder;

            StorageFile file = await folder.CreateFileAsync("db_playlists.xml", CreationCollisionOption.OpenIfExists);

            try
            {
                XmlSerializer xml_deser_playlists = new XmlSerializer(typeof(List<Files_Struct>));

                using (Stream stream_deser_playlists = await file.OpenStreamForReadAsync())
                {
                    files_structs_list = (List<Files_Struct>)xml_deser_playlists.Deserialize(stream_deser_playlists);
                }

            }
            catch
            {
                    
            }

        }
        */
        /*
        async void send(string name_)
        {
            StorageFolder folder = ApplicationData.Current.LocalFolder;

            //Files_Struct structor = new Files_Struct()
            //{
               // name = name_,
            //};

            //structor.musics.Add("C:/C/first.exe");

            //files_structs_list.Add(structor);

            StorageFile file = await folder.CreateFileAsync("db_playlists.xml", CreationCollisionOption.OpenIfExists);

            XmlSerializer xml_serial_playlist = new XmlSerializer(typeof(List<Files_Struct>));

            using (Stream stream_xml_ser_playlist = await file.OpenStreamForWriteAsync())
            {
                xml_serial_playlist.Serialize(stream_xml_ser_playlist, files_structs_list);
            }

        }
        */

    }
}
