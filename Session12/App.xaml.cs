using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Session12
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static Sessio1Entities db =  new Sessio1Entities();

        public static User User { get; set; }

        public App()
        {
            db.Product.Load();
            db.User.Load();
            db.MeasureUnit.Load();
            db.SupplierCountry.Load();
        }
    }
}
