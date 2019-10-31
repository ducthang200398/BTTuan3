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
    public partial class PagThemHoa : ContentPage
    {

   




        Database db;
        List<LoaiHoa> dsl1;
        LoaiHoa mySelectedFlower;

        public PagThemHoa()
        {
            InitializeComponent();
            db = new Database();
            dsl1 = db.selectLoaiHoa();
            pickerFlowerType.ItemsSource = dsl1;
        }
        public PagThemHoa(int id)
        {
            InitializeComponent();
            db = new Database();
            dsl1 = db.selectLoaiHoa();
            pickerFlowerType.ItemsSource = dsl1;

            DisplayAlert("Notice", "Edit " + id + "Flower Successful!", "OK");
        }
        public void OnPickerSelectedIndexChanged(object sender, EventArgs e)
        {
            Picker picker = sender as Picker;
            var selectedItem = picker.SelectedItem;

            mySelectedFlower = (LoaiHoa)selectedItem;
        }
        private void Button_Clicked(object sender, EventArgs e)
        {
            Database db = new Database();
            Hoa Hoa = new Hoa
            {
                Maloai = mySelectedFlower.Maloai,
                Tenhoa= txttenhoa.Text,
                Hinh = txthinh.Text,
                Mota = txtmota.Text,
                Gia = Convert.ToInt32(txtgia.Text),
            };
            if (db.Inserthoa(Hoa))
            {
                DisplayAlert("Notice", "Add Flower Successful!", "OK");
            }
            else
            {
                DisplayAlert("Notice", "Add Flower Failed!", "OK");
            }
        }


    }
}