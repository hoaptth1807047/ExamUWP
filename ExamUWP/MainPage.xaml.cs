using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using ExamUWP.Entity;
using ExamUWP.Model;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace ExamUWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private MemberModel noteModel;
        private ObservableCollection<Member> list;
        public MainPage()
        {
            this.InitializeComponent();
            this.noteModel = new MemberModel();
            
        }
        private void ButtonCreateMember_OnClick(object sender, RoutedEventArgs e)
        {
            Member note = new Member
            {
                Name = this.Name.Text,
                Phone = Int32.Parse(this.Phone.Text),
            };
            noteModel.Insert(note);
        }

        private void LoadNote()
        {
            list = new ObservableCollection<Member>();
            list = noteModel.ReadListMembers();
           ListViewMember.ItemsSource = list;
        }
    }
}
