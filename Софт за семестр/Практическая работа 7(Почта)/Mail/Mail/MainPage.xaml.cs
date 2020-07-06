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

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x419

namespace Mail
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

        }

        private void ButSender_Click(object sender, RoutedEventArgs e)
        {
            if(LineSenderAdress.Text == "")
            {
                StateOfSendeMessage.Text = "The sender's address cannot be empty!";
                return;
            }

            if(LineNameSender.Text == "")
            {
                StateOfSendeMessage.Text = "The sender's name cannot be empty!";
                return;
            }

            if(LineReceiverAdress.Text == "")
            {
                StateOfSendeMessage.Text = "The recipient's address cannot be empty!";
                return;
            }

            if(Message.Text == "")
            {
                StateOfSendeMessage.Text = "The message text cannot be empty!";
                return;
            }

            if(Passwd.Password == "")
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
            catch(Exception ex)
            {
                StateOfSendeMessage.Text = ex.Message;
            }
            finally
            {
                StateOfSendeMessage.Text = "Successfully!";
            }

            //smtp.Dispose();
            //message.Dispose();
        }

        private void ButCheckMail_Click(object sender, RoutedEventArgs e)
        {
            ListMessages.Items.Clear();

            if(LineMailAdress.Text == "")
            {
                StateOfCheckMessage.Text = "Mail can't be empty!";
                return;
            }

            if(PasswdMail.Password == "")
            {
                StateOfCheckMessage.Text = "The password cannot be empty!";
                return;
            }

            try
            {

                AE.Net.Mail.ImapClient imap = new AE.Net.Mail.ImapClient("imap.gmail.com", LineMailAdress.Text, PasswdMail.Password, AE.Net.Mail.AuthMethods.Login, 993, true);

                imap.SelectMailbox(MailPartitions.SelectedItem.ToString());

                AE.Net.Mail.MailMessage[] Messages = imap.GetMessages(0, imap.GetMessageCount());

                foreach (AE.Net.Mail.MailMessage message in Messages)
                {
                    ListMessages.Items.Add(message.Subject);
                }

                imap.Dispose();

            }
            catch(Exception ex)
            {
                StateOfCheckMessage.Text = ex.Message;
                return;
            }
            finally
            {
                StateOfCheckMessage.Text = "Successfully!";
            }
            

        }

        private void ButGetMailFolders_Click(object sender, RoutedEventArgs e)
        {

            if (LineMailAdress.Text == "")
            {
                StateOfCheckMessage.Text = "Mail can't be empty!";
                return;
            }

            if (PasswdMail.Password == "")
            {
                StateOfCheckMessage.Text = "The password cannot be empty!";
                return;
            }

            try
            {
                AE.Net.Mail.ImapClient imap = new AE.Net.Mail.ImapClient("imap.gmail.com", LineMailAdress.Text, PasswdMail.Password, AE.Net.Mail.AuthMethods.Login, 993, true);

                var list = imap.ListMailboxes(string.Empty, "*");

                for (int count = 0; count < list.Length; count++)
                {
                    MailPartitions.Items.Add(list[count].Name);
                }

            }
            catch(Exception ex)
            {
                StateOfCheckMessage.Text = ex.Message;
                return;
            }
            finally
            {
                StateOfCheckMessage.Text = "Seccessfully!";
            }
            

            

            MailPartitions.SelectedIndex = 0;

            if (MailPartitions.Items.Count != 0)
            {
                ButCheckMail.IsEnabled = true;
            }
        }
    }
}
