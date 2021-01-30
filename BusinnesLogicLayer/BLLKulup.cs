using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using EntityLayer;
using FacadeLayer;

namespace BusinnesLogicLayer
{
    public class BLLKulup
    {
        public static int EKLE(EntityKulup deger)
        {
            if (deger.KULUPAD != null)
            {
                return FacadeKulup.EKLE(deger);
            }
            return -1;
        }
        public static bool GUNCELLE(EntityKulup deger)
        {
            if(deger.KULUPAD!=null && deger.KULUPID != null)
            {
                return FacadeKulup.GUNCELLE(deger);
            }
            return false;
        }
        public static bool SIL(int deger)
        {
            if (deger != null)
            {
                return FacadeKulup.SIL(deger);
            }
            return false;
        }
        public static List<EntityKulup> LISTELE()
        {
            return FacadeKulup.LISTELE();
        }
    }
}
