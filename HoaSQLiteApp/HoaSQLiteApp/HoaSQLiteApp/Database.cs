using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HoaSQLiteApp
{
    public class Database
    {
        string folder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
        public bool createDatabase()
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder
                    , "qlhoa.db"))) 
                {
                    connection.CreateTable<LoaiHoa>();
                    connection.CreateTable<Hoa>();
                    return true;
                }
            } 
            catch (SQLiteException ex)
            {
                return false;
            }

        }
        public bool InsertLoaihoa(LoaiHoa loai)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder
                             , "qlhoa.db")))
                {
                    connection.Insert(loai);
                    return true;

                }
            }
            catch (SQLiteException ex)
            {
                return false;
            }
        }
        public bool UpdateLoaihoa(LoaiHoa loai)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder
                             , "qlhoa.db")))
                {
                    connection.Update(loai);
                    return true;

                }
            }
            catch (SQLiteException ex)
            {
                return false;
            }
        }
        public bool DeleteLoaihoa(LoaiHoa loai)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder
                             , "qlhoa.db")))
                {
                    connection.Delete(loai);
                    return true;

                }
            }
            catch (SQLiteException ex)
            {
                return false;
            }
        }
        public List<LoaiHoa> selectLoaiHoa()
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder
                             , "qlhoa.db")))
                {
                    return connection.Table<LoaiHoa>().ToList();
                }
            }catch (SQLiteException ex)
            {
                return null;
            }
        }
        public LoaiHoa selectLoaihoaByid(int id)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder
                             , "qlhoa.db")))
                {
                    var lh = from l in connection.Table<LoaiHoa>().ToList()
                             where l.Maloai == id
                             select l;
                    return lh.ToList().FirstOrDefault();
                }
            }
            catch (SQLiteException ex)
            {
                return null;
            }
        }
        public List<Hoa> selectTheoLoai(int maloai)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder
                             , "qlhoa.db")))
                {
                    var dsh = from lhs in connection.Table<Hoa>().ToList()
                             where lhs.Maloai == maloai
                             select lhs;
                    return dsh.ToList<Hoa>();
                }
            }
            catch (SQLiteException ex)
            {
                return null;
            }
        }

        public List<object> selecthoa1(int maloai)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder
                             , "qlhoa.db")))
                {
                    var Banghoa = connection.Table<Hoa>();
                    var bangloai = connection.Table<LoaiHoa>();
                    var kq = from h in Banghoa
                             join lh in bangloai on h.Maloai equals lh.Maloai
                             select new { h.Mahoa, h.Tenhoa, h.Hinh, h.Gia, h.Maloai, h.Mota, lh.TenLoai };
                    return kq.ToList<object>();
                }
            }
            catch (SQLiteException ex)
            {
                return null;
            }
        }
        public List<object> selectLoaihoa1(int maloai)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder
                             , "qlhoa.db")))
                {
                    var Banghoa = connection.Table<Hoa>();
                    var bangloai = connection.Table<LoaiHoa>();
                    var lh1 = from h in Banghoa
                              group h by h.Maloai into kq
                              select new { Maloai = kq.Key, Tongsohoa = kq.Count() };
                    var lh2 = from lh in bangloai
                              join l1 in lh1 on lh.Maloai equals l1.Maloai

                              select new { lh.Maloai, lh.TenLoai, l1.Tongsohoa };
                    return lh2.ToList<object>();
                }
            }
            catch (SQLiteException ex)
            {
                return null;
            }
        }
        public bool Inserthoa(Hoa Hoa)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "qlhoa.db")))
                {
                    connection.Insert(Hoa);
                    return true;
                }
            }
            catch (SQLiteException)
            {
                return false;
            }
        }
        public List<Hoa> Selecthoa()
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "qlhoa.db")))
                {
                    return connection.Table<Hoa>().ToList();
                }
            }
            catch (SQLiteException)
            {
                return null;
            }
        }
        public List<Hoa> Selecthoatheoloaihoa(int id)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "qlhoa.db")))
                {
                    return connection.Query<Hoa>("SELECT * FROM Hoa WHERE Maloai = ?", id);
                }
            }
            catch (SQLiteException)
            {
                return null;
            }
        }

    }
}
    
    

 
  

