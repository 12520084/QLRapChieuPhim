using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public static class GetIndex_DAL
    {
        public static int _index;
        public static int GetIndexNV()
        {
            sqlConnect _sqlConnect = new sqlConnect();
            _sqlConnect.connect();

            SqlDataReader reader = (SqlDataReader)_sqlConnect.executeQuery("GetIndexNV");

            while(reader.Read())
            {
                _index = int.Parse(reader["Id"].ToString());
            }
            
            return _index;
        }

        public static void SetIndexNV(int _index)
        {
            sqlConnect _sqlConnect = new sqlConnect();
            _sqlConnect.connect();

            string updateCommand = "UPDATE IndexNV " +
            "SET Id = " +  _index;

            _sqlConnect.executeNonQuery(updateCommand);
        }

        public static int GetIndexPhim()
        {
            sqlConnect _sqlConnect = new sqlConnect();
            _sqlConnect.connect();

            SqlDataReader reader = (SqlDataReader)_sqlConnect.executeQuery("GetIndexPhim");

            while (reader.Read())
            {
                _index = int.Parse(reader["Id"].ToString());
            }
            reader.Close();
            return _index;
        }

        public static void SetIndexPhim(int _index)
        {
            sqlConnect _sqlConnect = new sqlConnect();
            _sqlConnect.connect();

            string updateCommand = "UPDATE INDEXPHIM " +
            "SET Id = " + _index;

            _sqlConnect.executeNonQuery(updateCommand);
        }

        public static int GetIndexKhuyenMai()
        {
            sqlConnect _sqlConnect = new sqlConnect();
            _sqlConnect.connect();

            //string command = "SELECT * FROM INDEXKM";

            SqlDataReader reader = (SqlDataReader)_sqlConnect.executeQuery("GetIndexKM");

            while (reader.Read())
            {
                _index = int.Parse(reader["Id"].ToString());
            }
            reader.Close();
            return _index;
        }

        public static void SetIndexKhuyenMai(int _index)
        {
            sqlConnect _sqlConnect = new sqlConnect();
            _sqlConnect.connect();

            string updateCommand = "UPDATE INDEXKM " +
            "SET Id = " + _index;

            _sqlConnect.executeNonQuery(updateCommand);
        }

        public static int GetIndexHSKhuyenMai()
        {
            sqlConnect _sqlConnect = new sqlConnect();
            _sqlConnect.connect();

            //string command = "SELECT * FROM INDEXKM";

            SqlDataReader reader = (SqlDataReader)_sqlConnect.executeQuery("GetIndexHSKM");

            while (reader.Read())
            {
                _index = int.Parse(reader["Id"].ToString());
            }
            reader.Close();
            return _index;
        }

        public static void SetIndexHSKhuyenMai(int _index)
        {
            sqlConnect _sqlConnect = new sqlConnect();
            _sqlConnect.connect();

            string updateCommand = "UPDATE INDEXHESOKM " +
            "SET Id = " + _index;

            _sqlConnect.executeNonQuery(updateCommand);
        }

        public static int GetIndexGiaVe()
        {
            sqlConnect _sqlConnect = new sqlConnect();
            _sqlConnect.connect();

            //string command = "SELECT * FROM INDEXKM";

            SqlDataReader reader = (SqlDataReader)_sqlConnect.executeQuery("GetIndexGiaVe");

            while (reader.Read())
            {
                _index = int.Parse(reader["Id"].ToString());
            }
            reader.Close();
            return _index;
        }

        public static void SetIndexGiaVe(int _index)
        {
            sqlConnect _sqlConnect = new sqlConnect();
            _sqlConnect.connect();

            string updateCommand = "UPDATE INDEXGIAVE " +
            "SET Id = " + _index;

            _sqlConnect.executeNonQuery(updateCommand);
        }

        public static int GetIndexSuatChieu()
        {
            sqlConnect _sqlConnect = new sqlConnect();
            _sqlConnect.connect();

            //string command = "SELECT * FROM INDEXKM";

            SqlDataReader reader = (SqlDataReader)_sqlConnect.executeQuery("GetIndexSC");

            while (reader.Read())
            {
                _index = int.Parse(reader["Id"].ToString());
            }
            reader.Close();
            return _index;
        }

        public static void SetIndexSuatChieu(int _index)
        {
            sqlConnect _sqlConnect = new sqlConnect();
            _sqlConnect.connect();

            string updateCommand = "UPDATE INDEXSUATCHIEU " +
            "SET Id = " + _index;

            _sqlConnect.executeNonQuery(updateCommand);
        }

        public static int GetIndexKhachHang()
        {
            sqlConnect _sqlConnect = new sqlConnect();
            _sqlConnect.connect();

            SqlDataReader reader = (SqlDataReader)_sqlConnect.executeQuery("GetIndexKH");

            while (reader.Read())
            {
                _index = int.Parse(reader["Id"].ToString());
            }
            reader.Close();
            return _index;
        }

        public static void SetIndexKhachHang(int _index)
        {
            sqlConnect _sqlConnect = new sqlConnect();
            _sqlConnect.connect();

            string updateCommand = "UPDATE INDEXKHACHHANG " +
            "SET Id = " + _index;

            _sqlConnect.executeNonQuery(updateCommand);
        }

        public static int GetIndexGhe()
        {
            sqlConnect _sqlConnect = new sqlConnect();
            _sqlConnect.connect();

            //string command = "SELECT * FROM INDEXKM";

            SqlDataReader reader = (SqlDataReader)_sqlConnect.executeQuery("GetIndexGhe");

            while (reader.Read())
            {
                _index = int.Parse(reader["Id"].ToString());
            }
            reader.Close();
            return _index;
        }

        public static void SetIndexGhe(int _index)
        {
            sqlConnect _sqlConnect = new sqlConnect();
            _sqlConnect.connect();

            string updateCommand = "UPDATE INDEXGHE " +
            "SET Id = " + _index;

            _sqlConnect.executeNonQuery(updateCommand);
        }

        public static int GetIndexVeBan()
        {
            sqlConnect _sqlConnect = new sqlConnect();
            _sqlConnect.connect();

            SqlDataReader reader = (SqlDataReader)_sqlConnect.executeQuery("GetIndexVeBan");

            while (reader.Read())
            {
                _index = int.Parse(reader["Id"].ToString());
            }
            reader.Close();
            return _index;
        }

        public static void SetIndexVeBan(int _index)
        {
            sqlConnect _sqlConnect = new sqlConnect();
            _sqlConnect.connect();

            string updateCommand = "UPDATE INDEXVEBAN " +
            "SET Id = " + _index;

            _sqlConnect.executeNonQuery(updateCommand);
        }

        public static int GetIndexPDV()
        {
            sqlConnect _sqlConnect = new sqlConnect();
            _sqlConnect.connect();

            SqlDataReader reader = (SqlDataReader)_sqlConnect.executeQuery("GetIndexPDV");

            while (reader.Read())
            {
                _index = int.Parse(reader["Id"].ToString());
            }
            reader.Close();
            return _index;
        }

        public static void SetIndexPDV(int _index)
        {
            sqlConnect _sqlConnect = new sqlConnect();
            _sqlConnect.connect();

            string updateCommand = "UPDATE INDEXPHIEUDATVE " +
            "SET Id = " + _index;

            _sqlConnect.executeNonQuery(updateCommand);
        }

        public static int GetSTT()
        {
            sqlConnect _sqlConnect = new sqlConnect();
            _sqlConnect.connect();

            SqlDataReader reader = (SqlDataReader)_sqlConnect.executeQuery("GetIndexDSBV");

            while (reader.Read())
            {
                _index = int.Parse(reader["Id"].ToString());
            }
            reader.Close();
            return _index;
        }

        public static void SetSTT(int _index)
        {
            sqlConnect _sqlConnect = new sqlConnect();
            _sqlConnect.connect();

            string updateCommand = "UPDATE INDEXDOANHSOBANVE " +
            "SET Id = " + _index;

            _sqlConnect.executeNonQuery(updateCommand);
        }
    }
}
