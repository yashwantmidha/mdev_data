using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using GraphQL.Common.Request;
using GraphQL.Common.Response;
using GraphQL.Client;
using mobiledata.Model;


namespace mobiledata
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var client = new GraphQLClient("https://swapi.apis.guru");

            GraphQLRequest graphQLRequest = new GraphQLRequest
            {
                Query = "query{ allFilms {films { id, title, director } } }"

            };
            GraphQLResponse graphQLResponse = await client.PostAsync(graphQLRequest);

            filmlist.ItemsSource = graphQLResponse.Data.allFilms.films.ToObject<List<films>>();
        }
    }
}
