﻿#pragma checksum "C:\Users\Sajeruk\source\repos\AuthSys\AuthSys\Reg.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "268002EF0700BF701B9EF4ACF714AAB9"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AuthSys
{
    partial class Reg : 
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
            case 2: // Reg.xaml line 39
                {
                    this.GoMainMenu = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.GoMainMenu).Click += this.GoMainMenu_Click;
                }
                break;
            case 3: // Reg.xaml line 34
                {
                    this.ButReg = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.ButReg).Click += this.ButReg_Click;
                }
                break;
            case 4: // Reg.xaml line 30
                {
                    this.AuthGroup = (global::Windows.UI.Xaml.Controls.ComboBox)(target);
                }
                break;
            case 5: // Reg.xaml line 26
                {
                    this.AuthRol = (global::Windows.UI.Xaml.Controls.ComboBox)(target);
                    ((global::Windows.UI.Xaml.Controls.ComboBox)this.AuthRol).DropDownClosed += this.AuthRol_DropDownClosed;
                }
                break;
            case 6: // Reg.xaml line 22
                {
                    this.AuthPasswd = (global::Windows.UI.Xaml.Controls.PasswordBox)(target);
                }
                break;
            case 7: // Reg.xaml line 18
                {
                    this.AuthLogin = (global::Windows.UI.Xaml.Controls.TextBox)(target);
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

