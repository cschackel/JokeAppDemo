using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Jokesdatabase
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddJokePage : ContentPage
    {
        public AddJokePage()
        {
            InitializeComponent();
        }

       

        async void OnSaveClicked(object sender, EventArgs e)
        {
            var newJoke = (Joke)BindingContext;
            await App.Database.SaveItemAsync(newJoke);
            await Navigation.PopAsync();
        }
        /*
        async void OnDeleteClicked(object sender, EventArgs e)
        {
            var todoItem = (Joke)BindingContext;
            await App.Database.DeleteItemAsync(joke);
            await Navigation.PopAsync();
        }
        */

        async void OnCancelClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}