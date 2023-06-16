using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace firma_zamestnanci
{
    internal class ZamestnanecITOddeleni:Zamestnanec
    {
        
        public string JazykProVyvoj { get; set; }   
        public ZamestnanecITOddeleni():base()
        {

        }
       // public ZamestnanecITOddeleni(string krestniJmeno, string prijmeni, string pohlavi, DateTime datumNarozeni, string ridicskyPrukaz, int hrubaMazda, string jazykProVyvoj) : base(krestniJmeno, prijmeni, pohlavi, datumNarozeni, ridicskyPrukaz, hrubaMazda)
       // {
       //     JazykProVyvoj = jazykProVyvoj; 
       // }
        public void VyvojSoftwaru()
        {
            Console.WriteLine("Umim vyvijet softwar.");
        }
        public override void NastupZamestnance()
        {
            base.NastupZamestnance();
            Console.WriteLine("Vyplňte jazyk pro vývoj(Java, C#, Java Skript): ");
            this.JazykProVyvoj = Console.ReadLine();
        }
    }
}
//TODO někam přidat jazyk ve kterém vyvíjí JAVA PHP C#
