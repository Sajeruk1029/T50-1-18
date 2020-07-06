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

using Windows.Storage.Pickers;
using Windows.UI.Popups;
using Windows.Storage;
using Windows.Storage.Streams;

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x419

namespace Zacher2
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        static StorageFile file;

        static FileOpenPicker fileOpenPicker;

        public MainPage()
        {
            this.InitializeComponent();

            fileOpenPicker = new FileOpenPicker();

            fileOpenPicker.CommitButtonText = "Открыть";
            fileOpenPicker.FileTypeFilter.Add(".mp3");

            Player.Volume = 1;

            VolumeProgress.Value = Player.Volume * 100f;

        }

        private async void File_Click(object sender, RoutedEventArgs e)
        {

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

                if (Player.CurrentState == MediaElementState.Stopped || Player.CurrentState == MediaElementState.Closed)
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
            if (VolumeProgress.IsLoaded)
            {
                Player.Volume = VolumeProgress.Value / 100f;

            }

        }

        private void Player_MediaEnded(object sender, RoutedEventArgs e)
        {
            NameMusic.Text = "Name music: ";
            Play.Content = "Play";
        }


    }
}
