using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
using System.Data;
using System.Data.SqlClient;

namespace FacadeLayer
{
    public class FacadeKulup
    {
        public static int EKLE(EntityKulup deger)
        {
            SqlCommand komut = new SqlCommand("KulupEkle",SQLBaglantisi.baglanti);
            komut.CommandType = CommandType.StoredProcedure;

            if (komut.Connection.State != ConnectionState.Open)
            {
                komut.Connection.Open();
            }
            komut.Parameters.AddWithValue("KulupAd", deger.KULUPAD);
            return komut.ExecuteNonQuery();
        }
        public static bool SIL(int deger)
        {
            SqlCommand komut = new SqlCommand("KulupSil",SQLBaglantisi.baglanti);
            komut.CommandType = CommandType.StoredProcedure;
            if (komut.Connection.State != ConnectionState.Open)
            {
                komut.Connection.Open();
            }
            komut.Parameters.AddWithValue("KulupId",deger);
            return komut.ExecuteNonQuery() > 0;
        }
        public static bool GUNCELLE(EntityKulup deger)
        {
            SqlCommand komut = new SqlCommand("KulupGuncelle",SQLBaglantisi.baglanti);
            komut.CommandType = CommandType.StoredProcedure;
            if (komut.Connection.State != ConnectionState.Open)
            {
                komut.Connection.Open();
            }
            komut.Parameters.AddWithValue("KulupAd",deger.KULUPAD);
            komut.Parameters.AddWithValue("KulupId",deger.KULUPID);
            return komut.ExecuteNonQuery() > 0;
        }
        public static List<EntityKulup> LISTELE()
        {
            List<EntityKulup> degerler = new List<EntityKulup>();
            SqlCommand komut = new SqlCommand("KulupListesi",SQLBaglantisi.baglanti);
            komut.CommandType = CommandType.StoredProcedure;
            if (komut.Connection.State != ConnectionState.Open)
            {
                komut.Connection.Open();
            }
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                EntityKulup ent = new EntityKulup();
                ent.KULUPID =Convert.ToInt32(dr["KulupId"]);
                ent.KULUPAD = dr["KulupAd"].ToString();
                degerler.Add(ent);
            }
            dr.Close();
            return degerler;
        }
    }
}
