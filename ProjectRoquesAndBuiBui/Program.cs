using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRoquesAndBuiBui
{
    class Program
    {
        static int posX = 0;
        static int posY = 0;
        static Terrain t;
        static Ville sebastopol;

        static void Main(string[] args)
        {
            

            Catalogue test = new Catalogue();
            sebastopol = new Ville(5000000, 0, 0, 20,1.5,0.2);
            t = sebastopol.Map;

            //Test route sortie

            
            t.Carte[0, 0] = new Route("route", 1, 1, ConsoleColor.DarkGray, 0, 0, true);

            //


            while (true)
            {
                Console.Clear();
                Console.WriteLine("Que voulez vous faire Mr le Président ?");
                Console.WriteLine("1 : Observer la carte");
                Console.WriteLine("2 : Placer un batiment");
                ConsoleKey key = Console.ReadKey(true).Key;

                if (key == ConsoleKey.NumPad1)
                {
                    ObserverLaCarte();
                }
                if (key == ConsoleKey.NumPad2)
                {
                    PlacerUnBatiment(sebastopol.SelectionnerAmenagement());
                }
                if(key == ConsoleKey.P)
                {
                    Route r = (Route)t.Carte[2, 2];
                    if(r != null)
                    {
                        Queue<Route> q = new Queue<Route>();
                        q.Enqueue(r);

                        bool trouve = PathFinding(new List<Route>(), q);
                        Console.WriteLine();
                    }
                    
                }
            }
            
        }

        static void PlacerUnBatiment(Amenagement a)
        {
            bool continuer = true;
            posX = 0;
            posY = 0;

            Console.Clear();
            t.AfficherTerrain();

            while (continuer)
            {

                Amenagement temp = (Amenagement)a.Clone();

                Console.SetCursorPosition(posX, posY);
                bool dispo = VerifierPlace(a, t);
                AfficherPlace(a, t, dispo);

                ConsoleKey key = Console.ReadKey(true).Key;
                DeplacementCurseur(key);

                if (key == ConsoleKey.Enter)
                {
                    if (dispo)
                    {
                        PoserAmenagement(temp, t);
                        Console.Clear();
                        t.AfficherTerrain();
                        sebastopol.AjoutAmenagement(temp);
                        if (temp is Route)
                        {
                            (temp as Route).X = posX;
                            (temp as Route).Y = posY;
                        }
                    }

                }
                if (key == ConsoleKey.Escape)
                {
                    continuer = false;
                }

                Console.Clear();
                t.AfficherTerrain();

            }
        }

        static bool VerifierPlace(Amenagement a, Terrain t)
        {
            if (posY + a.Taille > t.Taille || posX + a.Taille > t.Taille) return false;
            for (int i = posY; i < posY + a.Taille; i++)
            {
                for (int j = posX; j < posX + a.Taille; j++)
                {
                    if (t.Carte[i, j] != null) return false;
                }
            }
            return true;
        }

        static void AfficherPlace(Amenagement a, Terrain t, bool disponible)
        {
            Console.BackgroundColor = (disponible) ? ConsoleColor.Green : ConsoleColor.Red;

            for (int i = posY; i < Math.Min(posY + a.Taille, t.Taille); i++)
            {
                for (int j = posX; j < Math.Min(posX + a.Taille, t.Taille); j++)
                {
                    Console.SetCursorPosition(j, i);
                    if (t.Carte[i, j] != null)
                    {
                        Console.ForegroundColor = t.Carte[i, j].Couleur;
                        Console.Write("V");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.Write("O");
                    }
                }
            }
            Console.SetCursorPosition(posX, posY);
            Console.BackgroundColor = ConsoleColor.Black;
        }

        static void PoserAmenagement(Amenagement a, Terrain t)
        {
            for (int i = posY; i < posY + a.Taille; i++)
            {
                for (int j = posX; j < posX + a.Taille; j++)
                {
                    t.Carte[i, j] = a;
                }
            }
        }

        static void DeplacementCurseur(ConsoleKey key)
        {
            if (key == ConsoleKey.Z || key == ConsoleKey.UpArrow)
            {
                posY -= 1;
                if (posY < 0) posY = 0;
            }
            if (key == ConsoleKey.Q || key == ConsoleKey.LeftArrow)
            {
                posX -= 1;
                if (posX < 0) posX = 0;
            }
            if (key == ConsoleKey.S || key == ConsoleKey.DownArrow)
            {
                posY += 1;
                if (posY > t.Taille - 1) posY = t.Taille - 1;
            }
            if (key == ConsoleKey.D || key == ConsoleKey.RightArrow)
            {
                posX += 1;
                if (posX > t.Taille - 1) posX = t.Taille - 1;
            }
        }

        static void ObserverLaCarte()
        {
            bool continuer = true;
            posX = 0;
            posY = 0;
            Console.Clear();
            t.AfficherTerrain();
            AfficherInfoAmenagement();

            while (continuer)
            {
                Console.SetCursorPosition(posX, posY);
                ConsoleKey key = Console.ReadKey(true).Key;

                DeplacementCurseur(key);

                Console.Clear();
                t.AfficherTerrain();
                AfficherInfoAmenagement();

                if (key == ConsoleKey.Delete)
                {
                    SupprimerBatiment();
                    Console.Clear();
                    t.AfficherTerrain();
                }
                if (key == ConsoleKey.Escape)
                {
                    continuer = false;
                }


            }


        }

        static void SupprimerBatiment()
        {
            Amenagement a = t.Carte[posY, posX];
            if (a != null)
            {
                int id = a.IdAmenagement;

                for (int i = Math.Max(0, posY - a.Taille); i < Math.Min(t.Taille, posY + a.Taille); i++)
                {
                    for (int j = Math.Max(0, posX - a.Taille); j < Math.Min(t.Taille, posX + a.Taille); j++)
                    {
                        if (t.Carte[i, j] != null && t.Carte[i, j].IdAmenagement == id) t.Carte[i, j] = null;
                    }
                }
            }
        }

        static void AfficherInfoAmenagement()
        {
            Console.SetCursorPosition(0, 25);
            if (t.Carte[posY, posX] != null)
            {
                Console.WriteLine(t.Carte[posY, posX]);
            }
            else
            {
                Console.WriteLine("Aucun Amenagement à cet emplacement");
            }
            Console.SetCursorPosition(posX, posY);
        }

        static bool PathFinding(List<Route> routesbloquees, Queue<Route> routesachercher)
        {
            Route actuel = routesachercher.Dequeue();

            if (actuel.EstSortie) return true;

            foreach (Route r in AjoutRoutesAdjacentes(routesbloquees, actuel))
            {
                routesachercher.Enqueue(r);
            }
            routesbloquees.Add(actuel);

            if (routesachercher.Count == 0) return false;
            else return PathFinding(routesbloquees, routesachercher);
        }

        static List<Route> AjoutRoutesAdjacentes(List<Route> routesbloquees, Route r)
        {
            List<Route> temp = new List<Route>();
            if (r.X > 0 && t.Carte[r.Y, r.X - 1] is Route && !routesbloquees.Contains(t.Carte[r.Y, r.X - 1] as Route)) temp.Add(t.Carte[r.Y, r.X - 1] as Route);
            if (r.Y > 0 && t.Carte[r.Y - 1, r.X] is Route && !routesbloquees.Contains(t.Carte[r.Y - 1, r.X] as Route)) temp.Add(t.Carte[r.Y - 1, r.X] as Route);
            if (r.X < t.Taille - 1 && t.Carte[r.Y, r.X + 1] is Route && !routesbloquees.Contains(t.Carte[r.Y, r.X + 1] as Route)) temp.Add(t.Carte[r.Y, r.X + 1] as Route);
            if (r.Y < t.Taille - 1 && t.Carte[r.Y + 1, r.X] is Route && !routesbloquees.Contains(t.Carte[r.Y + 1, r.X] as Route)) temp.Add(t.Carte[r.Y + 1, r.X] as Route);

            return temp;
        }
    }
}
