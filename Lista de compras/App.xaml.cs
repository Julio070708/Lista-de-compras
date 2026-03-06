using Lista_de_compras.Helper;

namespace Lista_de_compras
{
    public partial class App : Application
    {
        static SQLiteDatabaseHelpers _db;

        public static SQLiteDatabaseHelpers Db
        {
            get
            {
                if(_db == null)
                {
                    string path = Path.Combine(
                        Environment.GetFolderPath(
                            Environment.SpecialFolder.LocalApplicationData),
                        "banco_sqlite_compras.db3");
                    _db = new SQLiteDatabaseHelpers(".... db3");
                }
                return _db;
                    }
        }
        public App()
        {
            InitializeComponent();
        
           //MainPage = new AppShell();
           MainPage = new NavigationPage(new Views.ListaProduto());
        }
    }
}