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

    public partial class PageDSloaihoa : ContentPage
    {
        Database db;
        List<LoaiHoa> dsl; 
        LoaiHoa mySelectedFlower;
        public PageDSloaihoa()
        {
            InitializeComponent();
            db = new Database();
            dsl = db.selectLoaiHoa();
            lstdsloai.ItemsSource = dsl;

        }
        async void ListViewItemTapped(object sender, ItemTappedEventArgs e)
        {
            LoaiHoa item = (LoaiHoa)e.Item;
            await Navigation.PushAsync(new PagDsHoa(item.Maloai));
            ((ListView)sender).SelectedItem = null;
        }

    }
}