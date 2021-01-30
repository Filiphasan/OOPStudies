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
    public class FacadeOgrenci
    {
        public static int EKLE(EntityOgrenci deger)
        {
            SqlCommand komut = new SqlCommand("OgrenciEkle",SQLBaglantisi.baglanti);
            komut.CommandType = CommandType.StoredProcedure;
            if (komut.Connection.State != ConnectionState.Open)
            {
                komut.Connection.Open();
            }
            komut.Parameters.AddWithValue("Ad", deger.AD);
            komut.Parameters.AddWithValue("Soyad",deger.SOYAD);
            komut.Parameters.AddWithValue("Fotograf",deger.FOTOGRAF);
            komut.Parameters.AddWithValue("KulupId",deger.KULUPID);
            return komut.ExecuteNonQuery();
            
        }
        public static bool SIL(int deger) 
        {
            SqlCommand komut = new SqlCommand("OgrenciSil",SQLBaglantisi.baglanti);
            komut.CommandType = CommandType.StoredProcedure;
            if (komut.Connection.State != ConnectionState.Open)
            {
                komut.Connection.Open();
            }
            komut.Parameters.AddWithValue("Id",deger);
            return komut.ExecuteNonQuery() > 0;
        }
        public static bool GUNCELLE(EntityOgrenci deger)
        {
            SqlCommand komut = new SqlCommand("OgrenciGuncelle",SQLBaglantisi.baglanti);
            komut.CommandType = CommandType.StoredProcedure;
            if (komut.Connection.State != ConnectionState.Open)
            {
                komut.Connection.Open();

            }
            komut.Parameters.AddWithValue("Ad",deger.AD);
            komut.Parameters.AddWithValue("Soyad",deger.SOYAD);
            komut.Parameters.AddWithValue("Fotograf",deger.FOTOGRAF);
            komut.Parameters.AddWithValue("KulupId",deger.KULUPID);
            komut.Parameters.AddWithValue("Id",deger.ID);
            return komut.ExecuteNonQuery() > 0;
           
        }
        public static List<EntityOgrenci> LISTELE()
        {
            List<EntityOgrenci> degerler = new List<EntityOgrenci>();
            SqlCommand komut = new SqlCommand("OgrenciListesi",SQLBaglantisi.baglanti);
            komut.CommandType = CommandType.StoredProcedure;
            if (komut.Connection.State!=ConnectionState.Open)
            {
                komut.Connection.Open();
            }
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                EntityOgrenci ent = new EntityOgrenci();
                ent.ID = Convert.ToInt32(dr["Id"]);
                ent.AD = dr["Ad"].ToString();
                ent.SOYAD = dr["Soyad"].ToString();
                ent.FOTOGRAF = dr["Fotograf"].ToString();
                ent.KULUPID = Convert.ToInt32(dr["KulupId"]);
                degerler.Add(ent);
            }
            dr.Close();
            return degerler;
        }
    }
}
