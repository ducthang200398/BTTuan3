using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace HoaSQLiteApp
{
    public class Hoa
    {
        [PrimaryKey,AutoIncrement]
        public int Mahoa { get; set; }
        public int Maloai { get; set; }
        public string Tenhoa { get; set; }
        public string Hinh { get; set; }
        public string Mota { get; set; }
        public int Gia { get; set; }

    }
}
