using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

using Windows.UI.Popups;

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x419

namespace Zachet_3
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        static StorageFile file = null;

        static FileOpenPicker fileOpenPicker = new FileOpenPicker();

        static FileSavePicker saveser = new FileSavePicker();
        static FileSavePicker sever = new FileSavePicker();

        public MainPage()
        {
            this.InitializeComponent();

            fileOpenPicker.FileTypeFilter.Add(".txt");

            string[] massFonts = Microsoft.Graphics.Canvas.Text.CanvasTextFormat.GetSystemFontFamilies();

            for (int count = 0; count < massFonts.Length; count++)
            {
                FontsSelect.Items.Add(massFonts[count]);
            }

            FontsSelect.SelectedIndex = 0;
            SizeText.Text = 14.ToString();

            Edit.FontFamily = new FontFamily(massFonts[0]);
            Edit.FontSize = 14.0;

            FontsSelect.DropDownClosed += FontsSelect_DropDownClosed;

            ColorText.SelectedIndex = 1;

            Edit.IsColorFontEnabled = true;

            ColorText.DropDownClosed += ColorText_DropDownClosed;

            Edit.PreventKeyboardDisplayOnProgrammaticFocus = true;

        }

        private void ColorText_DropDownClosed(object sender, object e)
        {
            Windows.UI.Text.ITextSelection select = Edit.Document.Selection;

            switch ((sender as ComboBox).SelectedIndex)
            {
                case 0:
                    {
                        Edit.Document.Selection.CharacterFormat.ForegroundColor = Windows.UI.Colors.Black;
                        break;
                    }

                case 1:
                    {
                        Edit.Document.Selection.CharacterFormat.ForegroundColor = Windows.UI.Colors.White;
                        break;
                    }

                case 2:
                    {
                        Edit.Document.Selection.CharacterFormat.ForegroundColor = Windows.UI.Colors.Red;
                        break;
                    }

                case 3:
                    {
                        Edit.Document.Selection.CharacterFormat.ForegroundColor = Windows.UI.Colors.Green;
                        break;
                    }

                case 4:
                    {
                        Edit.TextDocument.Selection.CharacterFormat.ForegroundColor = Windows.UI.Colors.Blue;
                        break;
                    }

                case 5:
                    {
                        Edit.Document.Selection.CharacterFormat.ForegroundColor = Windows.UI.Colors.Yellow;
                        break;
                    }
            }
            Edit.Focus(FocusState.Programmatic);

        }

        private void FontsSelect_DropDownClosed(object sender, object e)
        {
            Edit.FontFamily = new FontFamily(FontsSelect.SelectedItem.ToString());
        }

        private async void MenuFlyoutItem_Click_Open(object sender, RoutedEventArgs e)
        {

            if (file == null)
            {

                file = await fileOpenPicker.PickSingleFileAsync();


                if (file != null)
                {
                    Edit.IsEnabled = true;

                    Edit.Document.LoadFromStream(Windows.UI.Text.TextSetOptions.None, await file.OpenAsync(FileAccessMode.Read));
                }
            }
        }

        private void SizeText_TextChanging(TextBox sender, TextBoxTextChangingEventArgs args)
        {
            if (!int.TryParse(SizeText.Text, out int d))
            {
                SizeText.Text = 14.ToString();
            }

            SizeText.Text = Math.Abs(Convert.ToInt32(SizeText.Text)).ToString();

            Edit.FontSize = Convert.ToInt32(SizeText.Text);



        }

        private void BoldText_Click(object sender, RoutedEventArgs e)
        {

            Edit.Document.Selection.CharacterFormat.Bold = Windows.UI.Text.FormatEffect.Toggle;
        }

        private async void OpenFile_Click(object sender, RoutedEventArgs e)
        {
            if (file == null)
            {

                file = await fileOpenPicker.PickSingleFileAsync();


                if (file != null)
                {
                    Edit.IsEnabled = true;

                    Edit.Document.LoadFromStream(Windows.UI.Text.TextSetOptions.None, await file.OpenAsync(FileAccessMode.Read));
                }
            }

        }

        private async void SaveFile_Click(object sender, RoutedEventArgs e)
        {
            if (file != null)
            {

                if (file != null)
                {

                    Edit.TextDocument.GetText(Windows.UI.Text.TextGetOptions.UseObjectText, out string str);

                    await FileIO.WriteTextAsync(file, str);
                }
            }
        }

        private void ItalicText_Click(object sender, RoutedEventArgs e)
        {
            Edit.Document.Selection.CharacterFormat.Italic = Windows.UI.Text.FormatEffect.Toggle;
        }

        private void Podchernutiy_Click(object sender, RoutedEventArgs e)
        {
            Edit.Document.Selection.CharacterFormat.Underline = Windows.UI.Text.UnderlineType.Dash;
        }


    }
}
