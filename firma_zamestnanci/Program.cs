using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace firma_zamestnanci
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Firma firmaJedna = new Firma();
            Menu menuJedna = new Menu(firmaJedna);
            menuJedna.SpustMenu();
        }
    }
}
