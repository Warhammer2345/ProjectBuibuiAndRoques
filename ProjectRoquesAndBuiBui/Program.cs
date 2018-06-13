using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRoquesAndBuiBui
{
    class Program
    {
        
         

        static void Main(string[] args)
        {
            Catalogue test = new Catalogue();
            Ville sebastopol = new Ville(5000000, 0, 0, 20,1.5,0.2);


            while (true)
            {
                Console.Clear();
                Console.WriteLine("Que voulez vous faire Mr le Président ?");
                Console.WriteLine("1 : Observer la carte");
                Console.WriteLine("2 : Placer un batiment");
                Console.WriteLine("3 : Modifier Impots");
                ConsoleKey key = Console.ReadKey(true).Key;

                if (key == ConsoleKey.NumPad1)
                {
                   sebastopol.ObserverLaCarte();
                }
                if (key == ConsoleKey.NumPad2)
                {
                    sebastopol.PlacerUnAmenagement();
                }
                if(key == ConsoleKey.NumPad3)
                {
                    sebastopol.ModifierImpots();
                }
            }
            
        }

        
    }
}
