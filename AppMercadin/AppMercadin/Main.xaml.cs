using System;
using Xamarin.Forms;
using AppMercadin.Helper; 
using System.IO; 


namespace AppMercadin
{
    public partial class Main : Application
    {

        static SQLiteDatabaseHelper database;


        public static SQLiteDatabaseHelper Database
        {
            get
            {

                if (database == null)
                {

                    string path = Path.Combine(
                        Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                        "arquivo.db3"
                    );

                    database = new SQLiteDatabaseHelper(path);
                }

                return database;
            }
        }

        public Main()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new View.Listagem());
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