using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PUBLIC
{
    public static class StaticMethod
    {
        /*private static byte[] encryptData(string data)
        {
            System.Security.Cryptography.MD5CryptoServiceProvider md5Hasher = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] hashedBytes;
            System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();
            hashedBytes = md5Hasher.ComputeHash(encoder.GetBytes(data));
            return hashedBytes;
        }

        public static string md5(string data)
        {
            return BitConverter.ToString(encryptData(data)).Replace("-", "").ToLower();
        }*/

        public static string SetGender(bool _info)
        {
            if (_info)
                return "Nam";
            else
                return "Nữ";
        }

        public static string GetMaNVFromIndex(int _index)
        {
            if(_index <= 9)
                return "NV000" + _index;
            else if(_index > 9 && _index <= 99)
                return "NV00" + _index;
            else if(_index > 99 && _index <= 999)
                return "NV0" + _index;

            return "NV" + _index;
        }

        public static string DanhDauChamChoTien(float _input)
        {
            return _input.ToString("N0", System.Globalization.CultureInfo.GetCultureInfo("de"));
        }
    }
}
