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

using System.Net;
using System.Net.Mail;
using Windows.Storage;
using System.Xml.Serialization;


// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x419

namespace Zachet_4
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        public List<DataStruct> dataStructs = new List<DataStruct>();

        public MainPage()
        {
            this.InitializeComponent();

            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

            getter();

        }

        async void getter()
        {
            StorageFolder folder = ApplicationData.Current.LocalFolder;

            StorageFile file = await folder.CreateFileAsync("db_data.xml", CreationCollisionOption.OpenIfExists);

            XmlSerializer serializer = new XmlSerializer(typeof(List<DataStruct>));

            try
            {
                using (Stream stream = await file.OpenStreamForReadAsync())
                {
                    dataStructs = (List<DataStruct>)serializer.Deserialize(stream);
                }
            }
            catch
            {

            }

            if(dataStructs.Count > 0)
            {
                LineSenderAdress.Text = dataStructs[dataStructs.Count - 1].SenderAddres;
                LineNameSender.Text = dataStructs[dataStructs.Count - 1].NameSender;
                LineReceiverAdress.Text = dataStructs[dataStructs.Count - 1].RecivierAddres;
                Message.Text = dataStructs[dataStructs.Count - 1].TextMessage;
                Passwd.Password = dataStructs[dataStructs.Count - 1].Password;
            }

        }

        async void setter()
        {
            StorageFolder folder = ApplicationData.Current.LocalFolder;

            StorageFile file = await folder.CreateFileAsync("db_data.xml", CreationCollisionOption.ReplaceExisting);

            XmlSerializer serializer = new XmlSerializer(typeof(List<DataStruct>));

            DataStruct dataStruct = new DataStruct()
            {
                SenderAddres = LineSenderAdress.Text,
                NameSender = LineNameSender.Text,
                RecivierAddres = LineReceiverAdress.Text,
                TextMessage = Message.Text,
                Password = Passwd.Password
            };

            dataStructs.Add(dataStruct);

            Stream stream = await file.OpenStreamForWriteAsync();

            serializer.Serialize(stream, dataStructs);

            stream.Close();

        
        }

        private void ButSender_Click(object sender, RoutedEventArgs e)
        {
            if (LineSenderAdress.Text == "")
            {
                StateOfSendeMessage.Text = "The sender's address cannot be empty!";
                return;
            }

            if (LineNameSender.Text == "")
            {
                StateOfSendeMessage.Text = "The sender's name cannot be empty!";
                return;
            }

            if (LineReceiverAdress.Text == "")
            {
                StateOfSendeMessage.Text = "The recipient's address cannot be empty!";
                return;
            }

            if (Message.Text == "")
            {
                StateOfSendeMessage.Text = "The message text cannot be empty!";
                return;
            }

            if (Passwd.Password == "")
            {
                StateOfSendeMessage.Text = "The password cannot be empty!";
                return;
            }

            MailAddress SenderMail = new MailAddress(LineSenderAdress.Text, LineNameSender.Text);
            MailAddress ReceiverMail = new MailAddress(LineReceiverAdress.Text);

            MailMessage message = new MailMessage(SenderMail, ReceiverMail);
            message.Subject = Message.Text;
            message.IsBodyHtml = false;

            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.UseDefaultCredentials = false;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Credentials = new NetworkCredential(LineSenderAdress.Text, Passwd.Password);
            smtp.EnableSsl = true;

            try
            {
                smtp.Send(message);
            }
            catch (Exception ex)
            {
                StateOfSendeMessage.Text = ex.Message;
                return;
            }
            
            StateOfSendeMessage.Text = "Successfully!";
            setter();
            
        }


    }
}
