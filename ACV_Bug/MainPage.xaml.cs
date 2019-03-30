using ACV_Bug.ViewModels;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace ACV_Bug
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainViewModel ViewModel { get; }
        public MainPage()
        {
            InitializeComponent();
            ViewModel = new MainViewModel();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            ViewModel.FillPeople();
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(MyListView.SelectedIndex == 0)
            {
                ViewModel.SelectedPeopleList = ViewModel.People;
            }
            else if (MyListView.SelectedIndex == 1)
            {
                ViewModel.SelectedPeopleList = ViewModel.Kids;
            }
            else
            {
                ViewModel.SelectedPeopleList = ViewModel.All;
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            MyListView.SelectedIndex = 0;
        }
    }
}
