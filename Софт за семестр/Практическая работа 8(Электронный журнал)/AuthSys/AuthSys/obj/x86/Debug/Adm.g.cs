﻿#pragma checksum "C:\Users\Sajeruk\source\repos\AuthSys\AuthSys\Adm.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "5BA70FB4B85A0A028665EBB8033A5ADE"
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
    partial class Adm : 
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
            case 2: // Adm.xaml line 102
                {
                    this.GoMainMenu = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.GoMainMenu).Click += this.GoMainMenu_Click;
                }
                break;
            case 3: // Adm.xaml line 103
                {
                    this.PrintJournal = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.PrintJournal).Click += this.PrintJournal_Click;
                }
                break;
            case 4: // Adm.xaml line 94
                {
                    this.TableUsers = (global::Microsoft.Toolkit.Uwp.UI.Controls.DataGrid)(target);
                }
                break;
            case 5: // Adm.xaml line 88
                {
                    this.ButUserChg = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.ButUserChg).Click += this.ButUserChg_Click;
                }
                break;
            case 6: // Adm.xaml line 89
                {
                    this.ButUserDel = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.ButUserDel).Click += this.ButUserDel_Click;
                }
                break;
            case 7: // Adm.xaml line 69
                {
                    this.GroupsBox = (global::Windows.UI.Xaml.Controls.ListBox)(target);
                }
                break;
            case 8: // Adm.xaml line 58
                {
                    this.ButGroupAdd = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.ButGroupAdd).Click += this.ButGroupAdd_Click;
                }
                break;
            case 9: // Adm.xaml line 59
                {
                    this.ButGroupChg = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.ButGroupChg).Click += this.ButGroupChg_Click;
                }
                break;
            case 10: // Adm.xaml line 60
                {
                    this.ButGroupDel = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.ButGroupDel).Click += this.ButGroupDel_Click;
                }
                break;
            case 11: // Adm.xaml line 38
                {
                    this.SubjectBox = (global::Windows.UI.Xaml.Controls.ListBox)(target);
                }
                break;
            case 12: // Adm.xaml line 28
                {
                    this.ButSubjectAdd = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.ButSubjectAdd).Click += this.ButSubjectAdd_Click;
                }
                break;
            case 13: // Adm.xaml line 29
                {
                    this.ButSubjectChg = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.ButSubjectChg).Click += this.ButSubjectChg_Click;
                }
                break;
            case 14: // Adm.xaml line 30
                {
                    this.ButSubjectDel = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.ButSubjectDel).Click += this.ButSubjectDel_Click;
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

