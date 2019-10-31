using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HoaSQLiteApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PagDsHoa : ContentPage
    {
        Database db;
        List <Hoa> dsh;
        public PagDsHoa()
        {
            InitializeComponent();
            db = new Database();
            dsh = db.Selecthoa();
            dshoa.ItemsSource = dsh;
        }
        public PagDsHoa(int typeid)
        {
            InitializeComponent();
            db = new Database();
            dsh = db.Selecthoatheoloaihoa(typeid);
            dshoa.ItemsSource = dsh;
        }
    }
}
