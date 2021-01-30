using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
using FacadeLayer;

namespace BusinnesLogicLayer
{
    public class BLLOgrenci
    {
        public static int EKLE(EntityOgrenci deger)
        {
            if(deger.AD!=null && deger.SOYAD!=null && deger.KULUPID>0 && deger.FOTOGRAF!=null && deger.KULUPID > 0)
            {
                return FacadeOgrenci.EKLE(deger);
            }
            return -1;
        }
        public static bool GUNCELLE(EntityOgrenci deger)
        {
            if(deger.ID>0 && deger.AD!=null && deger.SOYAD!=null && deger.FOTOGRAF!=null && deger.KULUPID>0 && deger.KULUPID > 0)
            {
                return FacadeOgrenci.GUNCELLE(deger);
            }
            return false;
        }
        public static bool SIL(int deger)
        {
            if (deger >0 && deger>0)
            {
                return FacadeOgrenci.SIL(deger);
            }
            return false;
        }
        public static List<EntityOgrenci> LISTELE()
        {
            return FacadeOgrenci.LISTELE();
        }
    }
}
