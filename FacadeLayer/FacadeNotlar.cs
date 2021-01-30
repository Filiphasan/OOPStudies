using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using EntityLayer;

namespace FacadeLayer
{
    public class FacadeNotlar
    {
        public static bool GUNCELLE(EntityNotlar deger)
        {
            SqlCommand komut = new SqlCommand("NotGuncelle",SQLBaglantisi.baglanti);
            komut.CommandType = CommandType.StoredProcedure;
            if (komut.Connection.State != ConnectionState.Open)
            {
                komut.Connection.Open();
            }
            komut.Parameters.AddWithValue("Sinav1",deger.SINAV1);
            komut.Parameters.AddWithValue("Sinav2",deger.SINAV2);
            komut.Parameters.AddWithValue("Sinav3",deger.SINAV3);
            komut.Parameters.AddWithValue("Proje",deger.PROJE);
            komut.Parameters.AddWithValue("Ortalama",deger.ORTALAMA);
            komut.Parameters.AddWithValue("Durum",deger.DURUM);
            komut.Parameters.AddWithValue("OgrId",deger.OGRID);
            return komut.ExecuteNonQuery() > 0;
        }
        public static List<EntityNotlar> LISTELE()
        {
            List<EntityNotlar> degerler = new List<EntityNotlar>();
            SqlCommand komut = new SqlCommand("NotListesi",SQLBaglantisi.baglanti);
            komut.CommandType = CommandType.StoredProcedure;
            if (komut.Connection.State != ConnectionState.Open)
            {
                komut.Connection.Open();
            }
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                EntityNotlar ent = new EntityNotlar();
                ent.OGRID = Convert.ToInt32(dr["OgrId"]);
                ent.AD = dr["Ad"].ToString();
                ent.SOYAD = dr["Soyad"].ToString();
                ent.SINAV1 = Convert.ToInt32(dr["Sinav1"]);
                ent.SINAV2 = Convert.ToInt32(dr["Sinav2"]);
                ent.SINAV3 = Convert.ToInt32(dr["Sinav3"]);
                ent.PROJE = Convert.ToInt32(dr["Proje"]);
                ent.ORTALAMA = Convert.ToDouble(dr["Ortalama"]);
                ent.DURUM = dr["Durum"].ToString();
                degerler.Add(ent);
            }
            dr.Close();
            return degerler;
        }
    }
}
