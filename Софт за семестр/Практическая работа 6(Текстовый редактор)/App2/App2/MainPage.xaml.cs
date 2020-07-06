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

namespace App2
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

        static bool bold = false, italic = false, podcherk = false;

        public MainPage()
        {
            this.InitializeComponent();

            fileOpenPicker.FileTypeFilter.Add(".txt");

            string[] massFonts = Microsoft.Graphics.Canvas.Text.CanvasTextFormat.GetSystemFontFamilies();

            for(int count = 0; count < massFonts.Length; count++)
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

            switch((sender as ComboBox).SelectedIndex)
            {
                case 0:
                    {
                        //Edit.Focus(FocusState.Pointer);
                        //Edit.Document.Selection.SetRange(0, Edit.Document.Selection.EndPosition);
                        Edit.Document.Selection.CharacterFormat.ForegroundColor = Windows.UI.Colors.Black;
                        break;
                    }

                case 1:
                    {
                        //Edit.Focus(FocusState.Pointer);
                        //Edit.Document.Selection.SetRange(0, Edit.Document.Selection.EndPosition);
                        Edit.Document.Selection.CharacterFormat.ForegroundColor = Windows.UI.Colors.White;
                        break;
                    }

                case 2:
                    {
                        //Edit.Focus(FocusState.Pointer);
                        //Edit.Document.Selection.SetRange(0, Edit.Document.Selection.EndPosition);
                        Edit.Document.Selection.CharacterFormat.ForegroundColor = Windows.UI.Colors.Red;
                        break;
                    }

                case 3:
                    {
                        //Edit.Focus(FocusState.Pointer);
                        //Edit.Document.Selection.SetRange(0, Edit.Document.Selection.EndPosition);
                        Edit.Document.Selection.CharacterFormat.ForegroundColor = Windows.UI.Colors.Green;
                        break;
                    }

                case 4:
                    {
                        //Edit.Focus(FocusState.Pointer);
                        //Edit.Document.Selection.SetRange(0, Edit.Document.Selection.EndPosition);
                        //Edit.Document.Selection.CharacterFormat.ForegroundColor = Windows.UI.Color.FromArgb(1, 0, 0, 0);
                        //Edit.Document.Selection.CharacterFormat.ForegroundColor = Windows.UI.Colors.Blue;
                        Edit.TextDocument.Selection.CharacterFormat.ForegroundColor = Windows.UI.Colors.Blue;

                        break;
                    }

                case 5:
                    {
                        //Edit.Focus(FocusState.Pointer);
                        //Edit.Document.Selection.SetRange(0, Edit.Document.Selection.EndPosition);
                        //Edit.Document.Selection.CharacterFormat.ForegroundColor = Windows.UI.Color.FromArgb(1, 0, 0, 0);
                        Edit.Document.Selection.CharacterFormat.ForegroundColor = Windows.UI.Colors.Yellow;
                        break;
                    }
            }

            //Edit.Focus(FocusState.Pointer);
            Edit.Focus(FocusState.Programmatic);

        }

        private void FontsSelect_DropDownClosed(object sender, object e)
        {
            //var msg = await new MessageDialog((FontsSelect.SelectedItem as TextBlock).Text).ShowAsync();
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

        private async void MenuFlyoutItem_Click_Save(object sender, RoutedEventArgs e)
        {
            if(file != null)
            {
                //Edit.Document.SaveToStream(Windows.UI.Text.TextGetOptions.None, await file.OpenAsync(FileAccessMode.ReadWrite));

                if(file != null)
                {

                    Edit.TextDocument.GetText(Windows.UI.Text.TextGetOptions.UseObjectText, out string str);

                    await FileIO.WriteTextAsync(file, str);
                }
            }
        }

        private async void MenuFlyoutItem_Click_Save_as(object sender, RoutedEventArgs e)
        {

            if (file != null)
            {

                saveser.FileTypeChoices.Add("*.txt", new List<string>() { ".txt" });
                saveser.SuggestedFileName = file.DisplayName;

                file = await saveser.PickSaveFileAsync();
            }

            if (file != null)
            {

                Edit.TextDocument.GetText(Windows.UI.Text.TextGetOptions.UseObjectText, out string str);

                await FileIO.WriteTextAsync(file, str);
            }

        }

        private void MenuFlyoutItem_Click_Print(object sender, RoutedEventArgs e)
        {

        }

        private void MenuFlyoutItem_Click_Close(object sender, RoutedEventArgs e)
        {
            if(file != null)
            {
                Edit.Document.SetText(Windows.UI.Text.TextSetOptions.None, "");

                Edit.IsEnabled = false;

                file = null;
            }
        }

        private void MenuFlyoutItem_Click_Back(object sender, RoutedEventArgs e)
        {
            if(Edit.Document.CanUndo())
            {
                Edit.Document.Undo();
            }
        }

        private void MenuFlyoutItem_Click_Cut(object sender, RoutedEventArgs e)
        {
            Edit.Document.Selection.Cut();
        }
        //.......
        private void MenuFlyoutItem_Click_Copy(object sender, RoutedEventArgs e)
        {
            Edit.Document.Selection.Copy();
        }

        private void MenuFlyoutItem_Click_Paste(object sender, RoutedEventArgs e)
        {
            Edit.Document.Selection.Paste(0);
        }

        private void MenuFlyoutItem_Click_Del(object sender, RoutedEventArgs e)
        {
            Edit.Document.Selection.Delete(Windows.UI.Text.TextRangeUnit.Word, Edit.Document.Selection.Text.Length);
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

        private async void MenuFlyoutItem_Help(object sender, RoutedEventArgs e)
        {
            var msg =  await new MessageDialog("Comming soon...").ShowAsync();
        }

        private async void MenuFlyoutItem_AboutProgram(object sender, RoutedEventArgs e)
        {
            var msg = await new MessageDialog("This is a \"word\"").ShowAsync();
        }

        private void MenuFlyoutItem_Click_SelectALL(object sender, RoutedEventArgs e)
        {
            Edit.Focus(FocusState.Pointer);
            Edit.Document.Selection.SetRange(0, Edit.Document.Selection.EndPosition);


        }

        private async void MenuFlyoutItem_Click_Find(object sender, RoutedEventArgs e)
        {

            StackPanel konteyner = new StackPanel();

            int start, end;
            

            konteyner.Children.Add(new TextBox() { PlaceholderText = "Find..." });

            ContentDialog contDial = new ContentDialog()
            {
                Title = "Find",
                Content = konteyner,
                PrimaryButtonText = "Find!"
            };

            ContentDialogResult res = await contDial.ShowAsync();

            if(res == ContentDialogResult.Primary)
            {
                Edit.Focus(FocusState.Pointer);
                Edit.Document.Selection.SetRange(0, Edit.Document.Selection.EndPosition);

                Edit.Document.Selection.FindText((konteyner.Children[0] as TextBox).Text, (konteyner.Children[0] as TextBox).Text.Length, Windows.UI.Text.FindOptions.Case);   
            }




        }

        private async void MenuFlyoutItem_Click_Replace(object sender, RoutedEventArgs e)
        {
            StackPanel konteyner = new StackPanel();


            konteyner.Children.Add(new TextBox() { PlaceholderText = "Find..." });
            konteyner.Children.Add(new TextBox() { PlaceholderText = "Replace..." });

            ContentDialog contDial = new ContentDialog()
            {
                Title = "Replace",
                Content = konteyner,
                PrimaryButtonText = "Replace!"
            };

            ContentDialogResult res = await contDial.ShowAsync();

            if (res == ContentDialogResult.Primary)
            {
                Edit.Focus(FocusState.Pointer);
                Edit.Document.Selection.SetRange(0, Edit.Document.Selection.EndPosition);

                Edit.Document.Selection.GetText(Windows.UI.Text.TextGetOptions.None, out string str);

                Edit.Document.SetText(Windows.UI.Text.TextSetOptions.None, str.Replace((konteyner.Children[0] as TextBox).Text, (konteyner.Children[1] as TextBox).Text));
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
