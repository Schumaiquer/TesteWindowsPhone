﻿using Model;
using Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace Views
{
    public sealed partial class PullRequest : Page
    {
        public PullRequest()
        {
            this.InitializeComponent();
        }
  
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Repositorio result = e.Parameter as Repositorio;
            String url = "https://api.github.com/repos/"+result.owner.login+"/"+result.name+"/pulls";
            loadData(url);
        }
        
        private async void loadData(string url)
        {
            var result = await Client.GetPull(url);
            if (result != null)
            {
                List<Pull> items = result;
                for (int i = 0; i < items.Count; i++)
                {
                    lista2ID.Items.Add(items[i]);
                }
            }
        }

        private async void lista2ID_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                Pull pull = lista2ID.SelectedItem as Pull;       
             Windows.System.Launcher.LaunchUriAsync(new System.Uri(pull.html_url));
            });
        }

    }
}
