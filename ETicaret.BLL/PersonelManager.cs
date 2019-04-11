using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETicaret.DLL;

namespace ETicaret.BLL
{
   public  class PersonelManager
    {
        Repository<Personeller> repPers = new Repository<Personeller>();

        public Personeller Giris(string kullanici_Adi,string sifre)
        {
            //var giris1 = repPers.ListeFiltre(k => (k.KAdi == kullanici_Adi || k.EMail == kullanici_Adi) && k.KSifre == sifre);
            //int p_ID = giris1.FirstOrDefault().PersonellerID;

            var giris2 = repPers.VeriBul(k => (k.KAdi == kullanici_Adi || k.EMail == kullanici_Adi) && k.KSifre == sifre);
            //aşağıdaki Id yapısı ile VeriBul metodunun içinde FirstOrDefault() olmasından dolayı alabildik.Aynı iişlemi ListeFiltre() metodu ile almak için giris1.FirstOrDefault() dedikten sonra almamız lazım. Hangisi kolayınız gelirse yapınız.
            //int PersId = giris2.PersonellerID;

            return giris2;
        }

        public List<Personeller> PersonelListesi()
        {
            return repPers.Liste();
        }

        public int PersSil(int pID)
        {
            Personeller sil = repPers.VeriBul(l => l.PersonellerID == pID);

            if (sil!=null)
            {
                if (repPers.Delete(sil)>0)
                {
                    return 1;
                }
            }
            return 0;

        }
    }
}
