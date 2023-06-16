using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace firma_zamestnanci
{
    internal class ZamestnanecPersonalnihoOddeleni:Zamestnanec
    {
      
        public string Cinnost { get; private set; }

        public ZamestnanecPersonalnihoOddeleni():base()
        {

        }
        public void RegistraceNovehoZamestnance()
        {
            Console.WriteLine("Mohu registrovat noveho zamestnance.");
        }
        public override void NastupZamestnance()
        {
            base.NastupZamestnance();
            Console.WriteLine("Vyplňte přiřazené činnosti (administrativa, skoleni, nabor,anaylza, benefity):  ");
            this.Cinnost = Console.ReadLine();
        }
    }
}
