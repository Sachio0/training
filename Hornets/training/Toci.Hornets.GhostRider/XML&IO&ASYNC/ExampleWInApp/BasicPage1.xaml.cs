﻿using ExampleWInApp.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234237

namespace ExampleWInApp
{
    /// <summary>
    /// A basic page that provides characteristics common to most applications.
    /// </summary>
    public sealed partial class BasicPage1 : Page
    {

        private NavigationHelper navigationHelper;
        private ObservableDictionary defaultViewModel = new ObservableDictionary();

        /// <summary>
        /// This can be changed to a strongly typed view model.
        /// </summary>
        public ObservableDictionary DefaultViewModel
        {
            get { return this.defaultViewModel; }
        }

        /// <summary>
        /// NavigationHelper is used on each page to aid in navigation and 
        /// process lifetime management
        /// </summary>
        public NavigationHelper NavigationHelper
        {
            get { return this.navigationHelper; }
        }


        public BasicPage1()
        {
            this.InitializeComponent();
            this.navigationHelper = new NavigationHelper(this);
            this.navigationHelper.LoadState += navigationHelper_LoadState;
            this.navigationHelper.SaveState += navigationHelper_SaveState;
        }

        /// <summary>
        /// Populates the page with content passed during navigation. Any saved state is also
        /// provided when recreating a page from a prior session.
        /// </summary>
        /// <param name="sender">
        /// The source of the event; typically <see cref="Common.NavigationHelper"/>
        /// </param>
        /// <param name="e">Event data that provides both the navigation parameter passed to
        /// <see cref="Frame.Navigate(Type, Object)"/> when this page was initially requested and
        /// a dictionary of state preserved by this page during an earlier
        /// session. The state will be null the first time a page is visited.</param>
        private void navigationHelper_LoadState(object sender, LoadStateEventArgs e)
        {
        }

        /// <summary>
        /// Preserves state associated with this page in case the application is suspended or the
        /// page is discarded from the navigation cache.  Values must conform to the serialization
        /// requirements of <see cref="Common.SuspensionManager.SessionState"/>.
        /// </summary>
        /// <param name="sender">The source of the event; typically <see cref="Common.NavigationHelper"/></param>
        /// <param name="e">Event data that provides an empty dictionary to be populated with
        /// serializable state.</param>
        private void navigationHelper_SaveState(object sender, SaveStateEventArgs e)
        {
        }

        #region NavigationHelper registration

        /// The methods provided in this section are simply used to allow
        /// NavigationHelper to respond to the page's navigation methods.
        /// 
        /// Page specific logic should be placed in event handlers for the  
        /// <see cref="Common.NavigationHelper.LoadState"/>
        /// and <see cref="Common.NavigationHelper.SaveState"/>.
        /// The navigation parameter is available in the LoadState method 
        /// in addition to page state preserved during an earlier session.

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            navigationHelper.OnNavigatedTo(e);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            navigationHelper.OnNavigatedFrom(e);
        }

        #endregion
        private bool textChanged = false;
        private bool loading = false;
        private IStorageFile saveFile = null;



        private void TextBox_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            if (loading)
            {
                loading = false;
                return;
            }
            if (!textChanged)
            {
                filename.Text += "*";
                textChanged = true;
                saveButton.IsEnabled = true;
            }
        }

        private async void openButton_Click(object sender, RoutedEventArgs e)
        {
            if (textChanged)
            {
                MessageDialog overwriteDialog = new MessageDialog("Plik został zmieniony. Napewno chcesz wczytać nowy plik?");
                overwriteDialog.Commands.Add(new UICommand("Tak"));
                overwriteDialog.Commands.Add(new UICommand("Nie"));
                overwriteDialog.DefaultCommandIndex = 1;
                UICommand result = await overwriteDialog.ShowAsync() as UICommand;

                if (result != null && result.Label == "Nie")
                {
                    return;
                }

            }
            OpenFile();
        }

        private async void OpenFile()
        {
            FileOpenPicker picker = new FileOpenPicker { ViewMode = PickerViewMode.List, SuggestedStartLocation = PickerLocationId.ComputerFolder };
            picker.FileTypeFilter.Add(".txt");
            picker.FileTypeFilter.Add(".xml");
            picker.FileTypeFilter.Add(".xaml");
            IStorageFile file = await picker.PickSingleFileAsync();
            if (file != null)
            {
                string fileContent = await FileIO.ReadTextAsync(file);
                loading = true;
                text.Text = fileContent;
                textChanged = false;
                filename.Text = file.Name;
                saveFile = file;
            }
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            SaveFile();
        }

        private async void SaveFile()
        {
            if (saveFile == null)
            {
                FileSavePicker picker = new FileSavePicker { SuggestedStartLocation = PickerLocationId.ComputerFolder, DefaultFileExtension = ".txt" };
                picker.FileTypeChoices.Add("Plik tekstowy", new List<string>() { ".txt" });
                picker.FileTypeChoices.Add("Plik XML", new List<string>() { ".xml", ".xaml" });
                saveFile = await picker.PickSaveFileAsync();
                if (saveFile == null)
                    return;
            }
            await FileIO.WriteTextAsync(saveFile, text.Text);
            await new MessageDialog("Zapisano plik " + saveFile.Name).ShowAsync();
            textChanged = false;
            filename.Text = saveFile.Name;


        }
    }
}
