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

    public partial class PagThemLoaiHoa : ContentPage
    {
        public PagThemLoaiHoa()
        {
            InitializeComponent();
        }

        private void Cmdghi_Clicked(object sender, EventArgs e)
        {
            Database db = new Database();
            LoaiHoa l = new LoaiHoa { TenLoai = txttenloai.Text };
            if (db.InsertLoaihoa(l) == true)
            {
                DisplayAlert("Thông Báo", "Thêm loại hoa thành công", "OK");
            }
            else
                DisplayAlert("Thông Báo", "Thêm loại hoa Lỗi", "OK");

        }
    }
}