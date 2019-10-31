using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
namespace HoaSQLiteApp
{
    public class LoaiHoa
    {   [PrimaryKey,AutoIncrement]
        public int Maloai { get; set; }
        public string TenLoai { get; set; }
    }
}
