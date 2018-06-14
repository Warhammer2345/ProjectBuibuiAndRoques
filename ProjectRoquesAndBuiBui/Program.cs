using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectRoquesAndBuiBui
{
    class Program
    {
        
         

        static void Main(string[] args)
        {
            Catalogue test = new Catalogue();
            Ville sebastopol = new Ville(5000000, 50, 50, 20,1.5,0.2);
            Thread gestion = new Thread(sebastopol.EvolutionVariablesParTour);

            sebastopol.Map.Carte[5, 5] = new Route("sortie", 0, 1, ConsoleColor.Red, 0, 0, true);


            //gestion.Start();
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
