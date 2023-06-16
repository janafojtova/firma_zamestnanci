using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace firma_zamestnanci
{
    internal static class Pomocna
    {
        public static int CtiCeleCisloZKonsole( string otazka)
        {
            int cislo;
            Console.WriteLine(otazka);
            string cisloJakoText = Console.ReadLine();
            while (!int.TryParse(cisloJakoText, out cislo))
            {
                Console.WriteLine("Nebylo zadáno číslo");
                Console.Write(otazka);
                cisloJakoText = Console.ReadLine();
            }
            return cislo;
        }
        //public static bool CtiAnoNeZKonsole(string otazka) TODO


        public static int VyberPolozkuZMenu(string otazka, int prvniPolozka, int posledniPolozka)
        {
            int cislo = CtiCeleCisloZKonsole( otazka);
            while (cislo<prvniPolozka || cislo >posledniPolozka)
            {
                Console.WriteLine("Nevybrali jste z nabízených možností");
                cislo = CtiCeleCisloZKonsole( otazka);
            }
            return cislo;
        }


        public static DateTime PrevodRetezceNaDatum(string datumJakoText, string otazka)
        {
            DateTime datum;

            while (!DateTime.TryParseExact(datumJakoText, "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out datum))
            {
                Console.WriteLine(otazka);
                datumJakoText = Console.ReadLine();
            }
            TimeSpan vek = DateTime.Now - datum;


            while (!((datum.Year > DateTime.Now.Year - 100) && (datum < DateTime.Now.AddYears(-18))))//zaměstnanec může mít maximálně cca 100 let a minimálně 18
            {
                //TODO složitá podmínka ve while upravit takto mi to nefunguje
                Console.WriteLine("Zaměstnanci nemůže mít méně než 18 let a více než 100 let.");
                Console.WriteLine(otazka);
                
                datumJakoText = Console.ReadLine();

                while (!DateTime.TryParseExact(datumJakoText, "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out datum))
                {
                    
                    Console.WriteLine(otazka);
                    datumJakoText = Console.ReadLine();
                }
                vek = DateTime.Now - datum;

            }
            return datum;
        }

        public static string KontrolaDvouMoznosti(string zadanaVarianta, string prvniMoznost, string druhaMoznost, string otazka)
        {
            while (!(zadanaVarianta == prvniMoznost || zadanaVarianta == druhaMoznost))
            {
                Console.WriteLine(otazka);
                zadanaVarianta = Console.ReadLine();
            }
            return zadanaVarianta;

        }
    }
}
