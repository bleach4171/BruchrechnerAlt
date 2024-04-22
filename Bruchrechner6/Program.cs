using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bruchrechner 
{
    internal class Program
    {
        static void Main(string[] args) // Abfragen wieviele zahlen dann in Array speichern oder mit Dictionary oder Schleifen aber hauptsache Benutzereingabe
        {
            Console.WriteLine("Willkommen beim Bruchrechner!");

            // Benutzereingabe für den ersten Bruch
            Console.Write("Geben Sie den Zähler des ersten Bruchs ein: ");
            int zaehler1 = Convert.ToInt32(Console.ReadLine());

            Console.Write("Geben Sie den Nenner des ersten Bruchs ein: ");
            int nenner1 = Convert.ToInt32(Console.ReadLine());
            Bruch bruch1 = new Bruch(zaehler1, nenner1);

            // Benutzereingabe für den zweiten Bruch
            Console.Write("Geben Sie den Zähler des zweiten Bruchs ein: ");
            int zaehler2 = Convert.ToInt32(Console.ReadLine());

            Console.Write("Geben Sie den Nenner des zweiten Bruchs ein: ");
            int nenner2 = Convert.ToInt32(Console.ReadLine());
            Bruch bruch2 = new Bruch(zaehler2, nenner2);


            Console.WriteLine("Welche Operation möchten Sie durchführen?");
            Console.WriteLine("1. Addition");
            Console.WriteLine("2. Subtraktion");
            Console.WriteLine("3. Multiplikation");
            Console.WriteLine("4. Division");
            Console.WriteLine("5. Potenzieren");
            Console.WriteLine("6. Wurzel ziehen");


            // Benutzereingabe für die gewünschte Operation
            Console.Write("Geben Sie die Nummer der Operation ein: ");
            int operation = Convert.ToInt32(Console.ReadLine());


            // Ausführen der ausgewählten Operation
            Bruch ergebnis = new Bruch(0, 1); // Standardergebnis initialisieren
            switch (operation)
            {
                case 1:
                    ergebnis = bruch1.Addition(bruch2);
                    break;
                case 2:
                    ergebnis = bruch1.Subtraktion(bruch2);
                    break;
                case 3:
                    ergebnis = bruch1.Multiplikation(bruch2);
                    break;
                case 4:
                    ergebnis = bruch1.Division(bruch2);
                    break;
                case 5:
                    Console.Write("Geben Sie den Exponenten ein: ");
                    int exponent = Convert.ToInt32(Console.ReadLine());
                    ergebnis = bruch1.Potenzieren(exponent);
                    break;
                case 6:
                    ergebnis = bruch1.WurzelZiehen();
                    break;
                default:
                    Console.WriteLine("Ungültige Auswahl!");
                    break;
            }

            // Ausgabe des Ergebnisses
            Console.WriteLine("Das Ergebnis der Operation ist: " + ergebnis);

            Console.ReadLine();
        }
    }

    class Bruch
    {
        private int zaehler;
        private int nenner;

        public Bruch(int zaehler, int nenner)
        {
            this.zaehler = zaehler;
            this.nenner = nenner;
            Kuerzen();
        }

        // Methoden zur Durchführung der Rechenoperationen
        public Bruch Addition(Bruch bruch)
        {
            int neuerNenner = this.nenner * bruch.nenner;
            int neuerZaehler = this.zaehler * bruch.nenner + bruch.zaehler * this.nenner;
            return new Bruch(neuerZaehler, neuerNenner);
        }

        public Bruch Subtraktion(Bruch bruch)
        {
            int neuerNenner = this.nenner * bruch.nenner;
            int neuerZaehler = this.zaehler * bruch.nenner - bruch.zaehler * this.nenner;
            return new Bruch(neuerZaehler, neuerNenner);
        }

        public Bruch Multiplikation(Bruch bruch)
        {
            int neuerZaehler = this.zaehler * bruch.zaehler;
            int neuerNenner = this.nenner * bruch.nenner;
            return new Bruch(neuerZaehler, neuerNenner);
        }

        public Bruch Division(Bruch bruch)
        {
            int neuerZaehler = this.zaehler * bruch.nenner;
            int neuerNenner = this.nenner * bruch.zaehler;
            return new Bruch(neuerZaehler, neuerNenner);
        }

        public Bruch Potenzieren(int exponent)
        {
            int neuerZaehler = (int)Math.Pow(this.zaehler, exponent);
            int neuerNenner = (int)Math.Pow(this.nenner, exponent);
            return new Bruch(neuerZaehler, neuerNenner);
        }

        public Bruch WurzelZiehen()
        {
            int neuerZaehler = (int)Math.Sqrt(this.zaehler);
            int neuerNenner = (int)Math.Sqrt(this.nenner);
            return new Bruch(neuerZaehler, neuerNenner);
        }

        private void Kuerzen()
        {
            int ggt = GGTeuclid(Math.Abs(zaehler), nenner);
            zaehler /= ggt;
            nenner /= ggt;
        }

        private int GGTeuclid(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }

        public override string ToString()
        {
            return zaehler + "/" + nenner;
        }
    }
}
