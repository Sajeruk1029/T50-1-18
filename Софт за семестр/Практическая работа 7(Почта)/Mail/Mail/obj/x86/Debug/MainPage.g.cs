﻿#pragma checksum "C:\Users\Sajeruk\source\repos\Mail\Mail\MainPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "E8BD3DF5105375BD19FF36CEF906E834"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Mail
{
    partial class MainPage : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.18362.1")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 2: // MainPage.xaml line 25
                {
                    this.HelpSendMessages = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 3: // MainPage.xaml line 26
                {
                    this.HelpListMessages = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 4: // MainPage.xaml line 39
                {
                    this.StateOfSendeMessage = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 5: // MainPage.xaml line 52
                {
                    this.ListMessages = (global::Windows.UI.Xaml.Controls.ListBox)(target);
                }
                break;
            case 6: // MainPage.xaml line 54
                {
                    this.StateOfCheckMessage = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 7: // MainPage.xaml line 43
                {
                    this.LineMailAdress = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 8: // MainPage.xaml line 44
                {
                    this.PasswdMail = (global::Windows.UI.Xaml.Controls.PasswordBox)(target);
                }
                break;
            case 9: // MainPage.xaml line 45
                {
                    this.ButGetMailFolders = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.ButGetMailFolders).Click += this.ButGetMailFolders_Click;
                }
                break;
            case 10: // MainPage.xaml line 46
                {
                    this.MailPartitions = (global::Windows.UI.Xaml.Controls.ComboBox)(target);
                }
                break;
            case 11: // MainPage.xaml line 48
                {
                    this.ButCheckMail = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.ButCheckMail).Click += this.ButCheckMail_Click;
                }
                break;
            case 12: // MainPage.xaml line 29
                {
                    this.LineSenderAdress = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 13: // MainPage.xaml line 30
                {
                    this.LineNameSender = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 14: // MainPage.xaml line 31
                {
                    this.LineReceiverAdress = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 15: // MainPage.xaml line 32
                {
                    this.Message = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 16: // MainPage.xaml line 33
                {
                    this.Passwd = (global::Windows.UI.Xaml.Controls.PasswordBox)(target);
                }
                break;
            case 17: // MainPage.xaml line 35
                {
                    this.ButSender = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.ButSender).Click += this.ButSender_Click;
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        /// <summary>
        /// GetBindingConnector(int connectionId, object target)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.18362.1")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}

