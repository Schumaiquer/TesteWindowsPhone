using Model;
using Service;
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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Tela2 : Page
    {

        string url = "https://api.github.com/search/repositories?q=language:";
        public Tela2()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
                   url = url + e.Parameter.ToString() + "&sort=stars&page=1";
                  loadData();

        }

        public async void loadData()
        {

            var response = await Client.GetRepositorio(url);
            if (response != null)
            {

                List<Repositorio> lista = response;
                for (int i = 0; i < lista.Count; i++)
                {
                    listaID.Items.Add(lista[i]);
                }
            }
        }

        private void listaID_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectIten = listaID.SelectedItem as Repositorio;
            Frame.Navigate(typeof(Tela3), selectIten);
        }
     
    }
}
