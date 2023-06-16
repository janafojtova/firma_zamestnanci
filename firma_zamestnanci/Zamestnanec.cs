using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace firma_zamestnanci
{
    internal class Zamestnanec:Firma
    {
        private string krestniJmeno;
        public string KrestniJmeno
        {
            get => krestniJmeno;
            set//nemůže být private, protože potom nejde editovat údaj
            {
                if (string.IsNullOrEmpty(value))
                {
                    krestniJmeno = "nevyplněno";
                }
                else
                {
                    krestniJmeno = value;
                }
            }
        }
        private string prijmeni;
        public string Prijmeni
        {
            get => prijmeni;
            set//nemůže být private, protože potom nejde editovat údaj
            {
                if (string.IsNullOrEmpty(value))
                {
                    prijmeni = "nevyplněno";
                }
                else
                {
                    prijmeni = value;
                }
            }
        }

        public string Jmeno;
        public string Pohlavi;
        public DateTime DatumNarozeni;
        public string RidicskyPrukaz;
       
        public int HrubaMzda;
     
       

        public Zamestnanec()
        {
        }
        //public Zamestnanec(string krestniJmeno, string prijmeni, string pohlavi, DateTime datumNarozeni, string ridicskyPrukaz, int hrubaMazda)
        //{
         //   KrestniJmeno = krestniJmeno;
          //  Prijmeni = prijmeni;
          //  Pohlavi = pohlavi;
          //  DatumNarozeni = datumNarozeni;
          //  RidicskyPrukaz = ridicskyPrukaz;
          //  HrubaMzda = hrubaMazda;
      //  }

        public virtual void NastupZamestnance()
        {         
            Console.WriteLine("Vyplňte křestní jméno: ");//TODO problém s diakritikou i tady? nebo jen u muž a žena
            this.KrestniJmeno = Console.ReadLine();

            Console.WriteLine("Vyplňte příjmeni: ");
            this.Prijmeni = Console.ReadLine();

           // this.Jmeno = (KrestniJmeno + " " + Prijmeni);

            Console.WriteLine("Vyplňte pohlaví zena/muz: ");
            this.Pohlavi = Console.ReadLine();
            this.Pohlavi = Pomocna.KontrolaDvouMoznosti(Pohlavi, "zena", "muz", "Vyplňte pohlaví zena/muz: ");

            Console.WriteLine("Vyplňte datum narození ve formátu dd.mm.yyyy: ");
            string datum = Console.ReadLine();
            this.DatumNarozeni = new DateTime();
            this.DatumNarozeni = Pomocna.PrevodRetezceNaDatum(datum, "Zadejte datum narození ve správném formátu dd.mm.yyyy: ");

            Console.WriteLine("Má řidičský průkaz ano/ne: ");
            this.RidicskyPrukaz = Console.ReadLine();
            this.RidicskyPrukaz = Pomocna.KontrolaDvouMoznosti(RidicskyPrukaz, "ano", "ne", "Má řidičský průkaz ano/ne: ");
                     
            
            HrubaMzda = Pomocna.CtiCeleCisloZKonsole( "Zadejte měsíční hrubou mzdu: ");            
        }



        




    }
}

