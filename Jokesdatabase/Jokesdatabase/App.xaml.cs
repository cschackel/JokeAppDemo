using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Jokesdatabase
{
    public partial class App : Application
    {
        static JokeDatabase database;

        public App()
        {
            InitializeComponent();

            var nav = new NavigationPage(new MainPage());
            nav.BarBackgroundColor = (Color)App.Current.Resources["primary"];
            nav.BarTextColor = Color.White;

            MainPage = nav;
        }

        public static JokeDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new JokeDatabase();
                }
                return database;
            }
        }

        protected override void OnStart()
        {

        }

        protected override void OnSleep()
        {

        }

        protected override void OnResume()
        {

        }
        }
    }
