using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace firma_zamestnanci
{
    internal class Firma
    {
        public List<Zamestnanec> SeznamZamestnancu = new List<Zamestnanec>();
        public void RegistrujZamestnance(Zamestnanec zamestnanec)
        {
            SeznamZamestnancu.Add(zamestnanec);
           
        }
        public void VypisVsechnyZamestnace()
        {
            Console.WriteLine("Křestní jméno".PadRight(20) + "Příjmení".PadRight(20) + "Pohlaví".PadRight(10) + "Datum narození".PadRight(25) + "Řidičský průkaz".PadRight(20) + "Hrubá mzda".PadRight(15)+"Specifikum".PadRight(15));//TODO dodělat záhlaví tabulky
            foreach (Zamestnanec item in SeznamZamestnancu)
            {
                ZamestnanecITOddeleni zamestnanecIT = item as ZamestnanecITOddeleni;
                if (zamestnanecIT != null)
                {
                    Console.WriteLine(item.KrestniJmeno.PadRight(20) + item.Prijmeni.PadRight(20) + item.Pohlavi.PadRight(10) +
                    (item.DatumNarozeni.Day.ToString() + "." + item.DatumNarozeni.Month.ToString() + "." + item.DatumNarozeni.Year.ToString()).PadRight(25) +//TODO datum bez času, takto mi to přijde dost složité
                    item.RidicskyPrukaz.PadRight(20) + item.HrubaMzda.ToString().PadRight(15));
                }
                ZamestnanecPersonalnihoOddeleni zamestananecPer = item as ZamestnanecPersonalnihoOddeleni;
                if (zamestananecPer != null)
                {
                    Console.WriteLine(item.KrestniJmeno.PadRight(20) + item.Prijmeni.PadRight(20) + item.Pohlavi.PadRight(10) +
                    (item.DatumNarozeni.Day.ToString() + "." + item.DatumNarozeni.Month.ToString() + "." + item.DatumNarozeni.Year.ToString()).PadRight(25) +//TODO datum bez času, takto mi to přijde dost složité
                    item.RidicskyPrukaz.PadRight(20) + item.HrubaMzda.ToString().PadRight(15));
                }


            }
        }
 
        public void OdstranZamestnance(List<Zamestnanec> VyhledaniZamestnanci)
        {
           foreach (var item in VyhledaniZamestnanci)
           {
                Console.WriteLine("");
                Console.WriteLine("Chcete odstranit následujícího zaměstnance? ano/ne ");
                Console.WriteLine("Křestní jméno".PadRight(20) + "Příjmení".PadRight(20) + "Pohlaví".PadRight(10) + "Datum narození".PadRight(25) + "Řidičský průkaz".PadRight(20) + "Hrubá mzda".PadRight(10));
                VypisInformaceOZamestanci(item);
                string spravnyZamestnanec = Console.ReadLine();
                if (spravnyZamestnanec == "ano")
                {
                    SeznamZamestnancu.Remove( item);
                }                
            }
        }
        //public List<Zamestnanec> VyhledejZamestnancePodleKrestnihoJmena(string krestniJmeno)
        //{
        //    List<Zamestnanec> seznamVyhledanychZamestnancu = new List<Zamestnanec>();            
        //    foreach (var item in SeznamZamestnancu)
        //    {
        //        if (item.KrestniJmeno.ToLower().Contains(krestniJmeno.ToLower()))//TODO nechci přesnou shodu dodělat u ostatních možností
        //        {
        //            seznamVyhledanychZamestnancu.Add(item);
                    
        //        }
        //    }
        //    if (seznamVyhledanychZamestnancu.Count>0)
        //    {
        //        Console.WriteLine("Křestní jméno".PadRight(20) + "Příjmení".PadRight(20) + "Pohlaví".PadRight(10) + "Datum narození".PadRight(25) + "Řidičský průkaz".PadRight(20) + "Hrubá mzda".PadRight(10));
        //        foreach (var item in seznamVyhledanychZamestnancu)
        //        {
        //            VypisInformaceOZamestanci(item);
        //        }
        //    }
        //    else
        //    {
        //        Console.WriteLine("Není v seznamu");
        //    }

        //    return seznamVyhledanychZamestnancu;
        //}
        public List<Zamestnanec> VyhledejZamestnance(int cislo)
        {
            Zamestnanec nalezenyZamestnanec = new Zamestnanec();
            List<Zamestnanec> SeznamVyhledanychZamestnancu = new List<Zamestnanec>();
            bool jeVSeznamu = false;
            if (cislo ==1)
            {
                Console.WriteLine("Zadejte hledané křestní jméno: ");
                string krestniJmenoKHledani = Console.ReadLine();
                foreach (var item in SeznamZamestnancu)
                {
                    if (item.KrestniJmeno.ToLower().Contains( krestniJmenoKHledani.ToLower()))//TODO nechci přesnou shodu dodělat u ostatních možností
                    {
                        SeznamVyhledanychZamestnancu.Add(item);
                        jeVSeznamu = true;
                    }
                }
            }
            if (cislo ==2)
            {
                Console.WriteLine("Zadejte hledané příjmení: ");
                string prijmeniKHledani = Console.ReadLine();
                foreach (var item in SeznamZamestnancu)
                {
                    if (item.Prijmeni.ToLower().Contains(prijmeniKHledani.ToLower()))
                    {
                        SeznamVyhledanychZamestnancu.Add(item);
                        jeVSeznamu = true;
                    }
                }                
            }
            if (cislo == 3)
            {
                Console.WriteLine("Zadejte hledané pohlaví zena/muz: ");
                string pohlaviKHledani = Console.ReadLine();
                pohlaviKHledani=Pomocna.KontrolaDvouMoznosti(pohlaviKHledani, "zena", "muz", "Zadejte hledane pohlavi zena/muz: ");
                foreach (var item in SeznamZamestnancu)
                {
                    if (item.Pohlavi == pohlaviKHledani)
                    {
                        SeznamVyhledanychZamestnancu.Add(item);
                        jeVSeznamu = true;
                    }
                }
            }
            if (cislo == 4)
            {   
                int rokKHledani = Pomocna.CtiCeleCisloZKonsole("Zadejte hledaný rok narození: ");
                foreach (var item in SeznamZamestnancu)
                {
                    if (item.DatumNarozeni.Year.ToString() == rokKHledani.ToString())
                    {
                        SeznamVyhledanychZamestnancu.Add(item);
                        jeVSeznamu = true;
                    }
                }
            }
            if (cislo == 5)
            {
                Console.WriteLine("Zadejte zda hledáte ty co mají řidičský průkaz ano/ne: ");
                string vlastnictviRidicskehoPrukazuKHledani = Console.ReadLine();
                vlastnictviRidicskehoPrukazuKHledani = Pomocna.KontrolaDvouMoznosti(vlastnictviRidicskehoPrukazuKHledani, "ano", "ne", "Zadejte zda hledáte ty co mají řidičský průkaz ano/ne: ");
                foreach (var item in SeznamZamestnancu)
                {
                    if (item.RidicskyPrukaz == vlastnictviRidicskehoPrukazuKHledani)
                    {
                        SeznamVyhledanychZamestnancu.Add(item);
                        jeVSeznamu = true;
                    }
                }
            }
            if (jeVSeznamu == true)
            {
                Console.WriteLine("Křestní jméno".PadRight(20) + "Příjmení".PadRight(20) + "Pohlaví".PadRight(10) + "Datum narození".PadRight(25) + "Řidičský průkaz".PadRight(20) + "Hrubá mzda".PadRight(10));
                foreach (var item in SeznamVyhledanychZamestnancu)
                {
                    VypisInformaceOZamestanci(item);
                }
            }
            else
            {
                Console.WriteLine("Není v seznamu");
            }

            return SeznamVyhledanychZamestnancu;
        }
        public void VypisInformaceOZamestanci(Zamestnanec zamestnanecInformace)
        {

            //Console.WriteLine("Křestní jméno".PadRight(20) + "Příjmení".PadRight(20) + "Pohlaví".PadRight(10) + "Datum narození".PadRight(25) + "Řidičský průkaz".PadRight(20) + "Hrubá mzda".PadRight(10));
            Console.WriteLine($"{zamestnanecInformace.KrestniJmeno.PadRight(20)}{zamestnanecInformace.Prijmeni.PadRight(20)}{zamestnanecInformace.Pohlavi.PadRight(10)}" +
                $"{zamestnanecInformace.DatumNarozeni.Day.ToString().PadRight(2)}.{zamestnanecInformace.DatumNarozeni.Month.ToString().PadRight(2)}.{zamestnanecInformace.DatumNarozeni.Year.ToString() .PadRight(19)}"+
                $"{zamestnanecInformace.RidicskyPrukaz.PadRight(20)}{zamestnanecInformace.HrubaMzda.ToString().PadRight(10)}");
        }
   
        public void EditujZamestnance(List<Zamestnanec> EditovaniZamestnanci,  int cislo)
        {
            foreach (var item in EditovaniZamestnanci)
            {
                Console.WriteLine("");
                Console.WriteLine("Chcete editovat následujícího zaměstnance? ano/ne ");
                Console.WriteLine("Křestní jméno".PadRight(20) + "Příjmení".PadRight(20) + "Pohlaví".PadRight(10) + "Datum narození".PadRight(25) + "Řidičský průkaz".PadRight(20) + "Hrubá mzda".PadRight(10));
                VypisInformaceOZamestanci(item);
                string spravnyZamestnanec = Console.ReadLine();
                if (spravnyZamestnanec == "ano")
                {
                    if (cislo == 1)
                    {
                        Console.WriteLine("Zadejte nové křestní jméno: ");
                        string krestniJmenoKEditaci = Console.ReadLine();
                        item.KrestniJmeno = krestniJmenoKEditaci;
                    }
                    if (cislo ==2)
                    {
                        Console.WriteLine("Zadejte nové příjmení: ");
                        string prijmeniJmenoKEditaci = Console.ReadLine();
                        item.Prijmeni = prijmeniJmenoKEditaci;
                    }
                    if (cislo == 3)
                    {
                        Console.WriteLine("Zadejte nové pohlaví: ");
                        string pohlaviKEditaci = Console.ReadLine();
                        item.Pohlavi = pohlaviKEditaci;
                    }
                    if (cislo == 4)
                    {
                        Console.WriteLine("Zadejte nové datum narození: ");
                        string datumNarozeniKEditaciJakoText = Console.ReadLine();
                        DateTime datumNarozeniKEditaci = Pomocna.PrevodRetezceNaDatum(datumNarozeniKEditaciJakoText, "Zadejte správně nové datum narození dd.mm.yyyy: ");
                        item.DatumNarozeni = datumNarozeniKEditaci;
                    }
                    if (cislo == 5)
                    {
                        Console.WriteLine("Zadejte znovu, jestli má řidičský průkaz? ano/ne: ");
                        string ridicskyPrukazKEditaci = Console.ReadLine();
                        item.RidicskyPrukaz = ridicskyPrukazKEditaci;
                    }
                }
            }           
        }
    } 
}

    
