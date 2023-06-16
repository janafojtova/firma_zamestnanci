using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace firma_zamestnanci
{
    internal class Menu
    {
        private readonly Firma firma;
        private UrovenMenu urovenMenu;

        public Menu(Firma firma)
        {
            this.firma = firma;
        }
        public void SpustMenu()
        {

            urovenMenu = UrovenMenu.HlavniNabidka;
            while (true)
            {
                switch (urovenMenu)
                    {
                    case UrovenMenu.HlavniNabidka:
                        StringBuilder stringBuilder = new StringBuilder();
                        stringBuilder.AppendLine();
                        stringBuilder.AppendLine("Aplikace pro personální oddělení");
                        stringBuilder.AppendLine("Vyberte z nabízeného menu číslo Vašeho požadavku.");
                        
                        stringBuilder.AppendLine("1. Vypiš všechny aktivní zaměstnance");
                        stringBuilder.AppendLine("2. Vyhledej zaměstnance");
                        stringBuilder.AppendLine("3. Přidej nového zaměstnance");
                        stringBuilder.AppendLine("4. Edituj zaměstnance");
                        stringBuilder.AppendLine("5. Odstraň zaměstnance");
                        stringBuilder.AppendLine();
                        stringBuilder.AppendLine("0. Ukonči aplikaci");
                        int vyber = Pomocna.VyberPolozkuZMenu(stringBuilder.ToString(), 0, 5);
                        switch (vyber)
                        {
                            case 0:
                                return;
                            case 1:
                                firma.VypisVsechnyZamestnace();
                                break;
                            case 2:
                                urovenMenu = UrovenMenu.VyhledavaniZamestnance;
                                break;
                            case 3:
                                urovenMenu = UrovenMenu.PridaniZamestnance;
                                break;
                            case 4:
                                urovenMenu = UrovenMenu.EditovaniZamestnance;
                                break;
                            case 5:
                                urovenMenu = UrovenMenu.OdstraneniZamestnance;
                                break;                                
                        }
                        break;
                    case UrovenMenu.VyhledavaniZamestnance:
                        //Zamestnanec hledanyZamestnanec = new Zamestnanec();                        
                        StringBuilder stringBuilderVyhledavani = new StringBuilder();
                        stringBuilderVyhledavani.AppendLine();
                        stringBuilderVyhledavani.AppendLine("Vyhledej zaměstnance.");
                        stringBuilderVyhledavani.AppendLine("Vyberte z nabízeného menu číslo Vašeho požadavku.");

                        stringBuilderVyhledavani.AppendLine("1. Vyhledej podle křestního jméno");
                        stringBuilderVyhledavani.AppendLine("2. Vyhledej podle příjmení");
                        stringBuilderVyhledavani.AppendLine("3. Vyhledej podle pohlaví");
                        stringBuilderVyhledavani.AppendLine("4. Vyhledej podle datum narození");
                        stringBuilderVyhledavani.AppendLine("5. Vyhledej podle vlastnictví řidičského průkazu");
                        stringBuilderVyhledavani.AppendLine();
                        stringBuilderVyhledavani.AppendLine("0. Vrať se do hlavní nabídky");
                        int vyberVyhledavani = Pomocna.VyberPolozkuZMenu(stringBuilderVyhledavani.ToString(), 0, 5);
                        switch (vyberVyhledavani)
                        {
                            case 0:
                                urovenMenu = UrovenMenu.HlavniNabidka;
                                break;
                            case 1:
                                firma.VyhledejZamestnance(1);
                                urovenMenu = UrovenMenu.VyhledavaniZamestnance;
                                break;
                            case 2:                                
                                firma.VyhledejZamestnance(2);
                                urovenMenu = UrovenMenu.VyhledavaniZamestnance;
                                break;
                            case 3:
                                firma.VyhledejZamestnance(3);
                                urovenMenu = UrovenMenu.VyhledavaniZamestnance;
                                break;
                            case 4:
                                firma.VyhledejZamestnance(4);
                                urovenMenu = UrovenMenu.VyhledavaniZamestnance;
                                break;
                            case 5:
                                firma.VyhledejZamestnance(5);
                                urovenMenu = UrovenMenu.VyhledavaniZamestnance;
                                break;
                        }
                        break;

                   // case UrovenMenu.VyhledavaniZamestnancePodleKrestnihoJmena:
                       // Console.WriteLine("Zadejte hledané křestní jméno: ");
                       // string krestniJmenoKHledani = Console.ReadLine();
                        //firma.VyhledejZamestnancePodleKrestnihoJmena(krestniJmenoKHledani);
                       // break;
                    case UrovenMenu.PridaniZamestnance:                
                        Console.WriteLine("Na jakém oddělení bude pracovat? per(personální oddělení) it (It oddělení): ");
                        string oddeleni = Console.ReadLine();
                        oddeleni = Pomocna.KontrolaDvouMoznosti(oddeleni, "per", "it", "Zadejte znovu oddělení, na kterém bude pracovat? per(personální oddělení) it (It oddělení): ");
                 
                        if (oddeleni == "per")
                        {
                            Zamestnanec zamestnanecPersonalnihoOddeleni = new ZamestnanecPersonalnihoOddeleni();
                            zamestnanecPersonalnihoOddeleni.NastupZamestnance();

                            firma.RegistrujZamestnance(zamestnanecPersonalnihoOddeleni);
                        }
                        else if (oddeleni == "it")
                        {
                            Zamestnanec zamestnanecITOddeleni = new ZamestnanecITOddeleni();
                            zamestnanecITOddeleni.NastupZamestnance();
                            firma.RegistrujZamestnance(zamestnanecITOddeleni);
                        }

                        urovenMenu = UrovenMenu.HlavniNabidka;
                        break;
                    
                    case UrovenMenu.EditovaniZamestnance:
                        StringBuilder stringBuilderEditovani = new StringBuilder();
                        stringBuilderEditovani.AppendLine();
                        stringBuilderEditovani.AppendLine("Edituj zaměstnance.");
                        stringBuilderEditovani.AppendLine("Vyberte z nabízeného menu číslo Vašeho požadavku.");

                        stringBuilderEditovani.AppendLine("1. Edituj křestní jméno");
                        stringBuilderEditovani.AppendLine("2. Edituj příjmení");
                        stringBuilderEditovani.AppendLine("3. Edituj pohlaví");
                        stringBuilderEditovani.AppendLine("4. Edituj datum narození");
                        stringBuilderEditovani.AppendLine("5. Edituj vlastnictví řidičského průkazu");                        
                        stringBuilderEditovani.AppendLine();
                        stringBuilderEditovani.AppendLine("0. Vrať se do hlavní nabídky");
                        int vyberEditovani = Pomocna.VyberPolozkuZMenu(stringBuilderEditovani.ToString(), 0, 5);
                        switch (vyberEditovani)
                        {
                            case 0:
                                urovenMenu = UrovenMenu.HlavniNabidka;
                                break;
                            case 1:                                
                                List<Zamestnanec> VyhledaniZamestnanci = firma.VyhledejZamestnance(1);
                                firma.EditujZamestnance(VyhledaniZamestnanci, 1);
                                urovenMenu = UrovenMenu.EditovaniZamestnance;
                                break;
                            case 2:
                                VyhledaniZamestnanci = firma.VyhledejZamestnance(2);
                                firma.EditujZamestnance(VyhledaniZamestnanci, 2);
                                urovenMenu = UrovenMenu.EditovaniZamestnance;
                                break;
                            case 3:
                                VyhledaniZamestnanci = firma.VyhledejZamestnance(3);
                                firma.EditujZamestnance(VyhledaniZamestnanci, 3);
                                urovenMenu = UrovenMenu.EditovaniZamestnance;
                                break;
                            case 4:
                                VyhledaniZamestnanci = firma.VyhledejZamestnance(4);
                                firma.EditujZamestnance(VyhledaniZamestnanci, 4);
                                urovenMenu = UrovenMenu.EditovaniZamestnance;
                                break;
                            case 5:
                                VyhledaniZamestnanci = firma.VyhledejZamestnance(5);
                                firma.EditujZamestnance(VyhledaniZamestnanci, 5 );
                                urovenMenu = UrovenMenu.EditovaniZamestnance;
                                break;

                        }                        
                        break;
                        
                    
                    case UrovenMenu.OdstraneniZamestnance:
                        StringBuilder stringBuilderVyhledavaniDva = new StringBuilder();
                        stringBuilderVyhledavaniDva.AppendLine();
                        stringBuilderVyhledavaniDva.AppendLine("Vyhledej zaměstnance pro odstranění.");
                        stringBuilderVyhledavaniDva.AppendLine("Vyberte z nabízeného menu číslo Vašeho požadavku.");

                        stringBuilderVyhledavaniDva.AppendLine("1. Vyhledej podle křestního jméno");
                        stringBuilderVyhledavaniDva.AppendLine("2. Vyhledej podle příjmení");
                        stringBuilderVyhledavaniDva.AppendLine("3. Vyhledej podle pohlaví");
                        stringBuilderVyhledavaniDva.AppendLine("4. Vyhledej podle datum narození");
                        stringBuilderVyhledavaniDva.AppendLine("5. Vyhledej podle vlastnictví řidičského průkazu");
                        stringBuilderVyhledavaniDva.AppendLine();
                        stringBuilderVyhledavaniDva.AppendLine("0. Vrať se do hlavní nabídky");
                        int vyberVyhledavaniDva = Pomocna.VyberPolozkuZMenu(stringBuilderVyhledavaniDva.ToString(), 0, 5);
                        switch (vyberVyhledavaniDva)
                        {
                            case 0:
                                urovenMenu = UrovenMenu.HlavniNabidka;
                                break;
                            case 1:
                                List<Zamestnanec> VyhledaniZamestnanci = firma.VyhledejZamestnance(1); 
                                firma.OdstranZamestnance(VyhledaniZamestnanci);
                                urovenMenu = UrovenMenu.HlavniNabidka;
                                break;
                            case 2:
                                VyhledaniZamestnanci = firma.VyhledejZamestnance(2);
                                firma.OdstranZamestnance(VyhledaniZamestnanci);
                                urovenMenu = UrovenMenu.HlavniNabidka;
                                break;
                            case 3:
                                VyhledaniZamestnanci = firma.VyhledejZamestnance(3);
                                firma.OdstranZamestnance(VyhledaniZamestnanci);
                                urovenMenu = UrovenMenu.HlavniNabidka;
                                break;
                            case 4:
                                VyhledaniZamestnanci = firma.VyhledejZamestnance(4);
                                firma.OdstranZamestnance(VyhledaniZamestnanci);
                                urovenMenu = UrovenMenu.HlavniNabidka;
                                break;
                            case 5:
                                VyhledaniZamestnanci = firma.VyhledejZamestnance(5);
                                firma.OdstranZamestnance(VyhledaniZamestnanci);
                                urovenMenu = UrovenMenu.HlavniNabidka;
                                break;                               
                        }                        
                        break;
                }              
            }
        }
     }
}
