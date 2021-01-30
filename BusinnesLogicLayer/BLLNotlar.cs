using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
using FacadeLayer;

namespace BusinnesLogicLayer
{
    public class BLLNotlar
    {
        public static bool GUNCELLE(EntityNotlar deger)
        {
            if(deger.OGRID!=null && deger.OGRID>0 && deger.ORTALAMA!=null && deger.ORTALAMA>=0 && deger.ORTALAMA<=100 && deger.SINAV1!=null
                && deger.SINAV1>=0 && deger.SINAV1<=100 && deger.SINAV2!=null && deger.SINAV2>=0 && deger.SINAV2<=100 && deger.SINAV3!=null
                && deger.SINAV3>=0 && deger.SINAV3<=100 && deger.PROJE!=null && deger.PROJE>=0 && deger.PROJE<=100 && deger.DURUM!=null)
            {
                return FacadeNotlar.GUNCELLE(deger);
            }
            return false;
        }
        public static List<EntityNotlar> LISTELE()
        {
            return FacadeNotlar.LISTELE();
        }
    }
}
