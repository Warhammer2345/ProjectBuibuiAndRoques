using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRoquesAndBuiBui
{
    class Terrain
    {
        Amenagement[,] carte;
        int taille;
        static int posX = 0;
        static int posY = 0;

        public Terrain(int taille)
        {
            this.taille = taille;
            carte = new Amenagement[taille, taille];
        }

        public void AfficherTerrain()
        {
            for (int i = 0; i < taille; i++)
            {
                for (int j = 0; j < taille; j++)
                {
                    if (carte[i, j] != null)
                    {
                        Console.ForegroundColor = carte[i, j].Couleur;
                        Console.Write("V");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.Write("O");
                    }
                }
                Console.WriteLine();
            }
        }

        public int Taille
        {
            get { return taille; }
        }

        public Amenagement[,] Carte
        {
            get { return carte; }
        }

        public void PlacerUnBatiment(Amenagement a, Ville v)
        {
            bool continuer = true;
            posX = 0;
            posY = 0;

            Console.Clear();
            AfficherTerrain();

            while (continuer)
            {

                Amenagement temp = (Amenagement)a.Clone();

                Console.SetCursorPosition(posX, posY);
                bool dispo = VerifierPlace(a);
                AfficherPlace(a, dispo);

                ConsoleKey key = Console.ReadKey(true).Key;
                DeplacementCurseur(key);

                if (key == ConsoleKey.Enter)
                {
                    if (dispo)
                    {
                        if (v.PeutAjouterAmenagement(temp))
                        {
                            PoserAmenagement(temp);
                            Console.Clear();
                            AfficherTerrain();

                            temp.PosX = posX;
                            temp.PosY = posY;

                            if (temp is Logement)
                            {
                                v.AjoutLogement((temp as Logement));
                            }
                            if (temp is Route)
                            {
                                VerifierConnectionToutLesBatiments(v.Amenagements);
                            }
                            else
                            {
                                VerifierConnectionBatiment(temp);
                            }
                        }
                        
                    }

                }
                if (key == ConsoleKey.Escape)
                {
                    continuer = false;
                }

                Console.Clear();
                AfficherTerrain();

            }
        }

        bool VerifierPlace(Amenagement a)
        {
            if (posY + a.Taille > taille || posX + a.Taille > taille) return false;
            for (int i = posY; i < posY + a.Taille; i++)
            {
                for (int j = posX; j < posX + a.Taille; j++)
                {
                    if (carte[i, j] != null) return false;
                }
            }
            return true;
        }

        void AfficherPlace(Amenagement a, bool disponible)
        {
            Console.BackgroundColor = (disponible) ? ConsoleColor.Green : ConsoleColor.Red;

            for (int i = posY; i < Math.Min(posY + a.Taille, taille); i++)
            {
                for (int j = posX; j < Math.Min(posX + a.Taille, taille); j++)
                {
                    Console.SetCursorPosition(j, i);
                    if (carte[i, j] != null)
                    {
                        Console.ForegroundColor = carte[i, j].Couleur;
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

        void PoserAmenagement(Amenagement a)
        {
            for (int i = posY; i < posY + a.Taille; i++)
            {
                for (int j = posX; j < posX + a.Taille; j++)
                {
                    carte[i, j] = a;
                }
            }
        }

        void DeplacementCurseur(ConsoleKey key)
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
                if (posY > taille - 1) posY = taille - 1;
            }
            if (key == ConsoleKey.D || key == ConsoleKey.RightArrow)
            {
                posX += 1;
                if (posX > taille - 1) posX = taille - 1;
            }
        }

        public void ObserverLaCarte(Ville v)
        {
            bool continuer = true;
            posX = 0;
            posY = 0;
            Console.Clear();
            AfficherTerrain();
            AfficherInfoAmenagement();

            while (continuer)
            {
                Console.SetCursorPosition(posX, posY);
                ConsoleKey key = Console.ReadKey(true).Key;

                DeplacementCurseur(key);

                Console.Clear();
                AfficherTerrain();
                AfficherInfoAmenagement();

                if (key == ConsoleKey.Delete)
                {
                    Amenagement a = SupprimerBatiment();
                    if (a != null) v.SupprimerAmenagement(a);
                    Console.Clear();
                    AfficherTerrain();
                    VerifierConnectionToutLesBatiments(v.Amenagements);
                }
                if(key == ConsoleKey.Enter)
                {
                    Amenagement a = carte[posY, posX];
                    if(a != null)
                    {
                        if(a is IParametrable)
                        {
                            (a as IParametrable).ModifierParametre();
                        }
                    }
                }
                if (key == ConsoleKey.Escape)
                {
                    continuer = false;
                }


            }


        }

        Amenagement SupprimerBatiment()
        {
            Amenagement a = carte[posY, posX];
            if (a != null)
            {
                int id = a.IdAmenagement;

                for (int i = Math.Max(0, posY - a.Taille); i < Math.Min(taille, posY + a.Taille); i++)
                {
                    for (int j = Math.Max(0, posX - a.Taille); j < Math.Min(taille, posX + a.Taille); j++)
                    {
                        if (carte[i, j] != null && carte[i, j].IdAmenagement == id) carte[i, j] = null;
                    }
                }
            }
            return a;
        }

        void AfficherInfoAmenagement()
        {
            Console.SetCursorPosition(0, 32);
            if (carte[posY, posX] != null)
            {
                Console.WriteLine(carte[posY, posX]);
            }
            else
            {
                Console.WriteLine("Aucun Amenagement à cet emplacement");
            }
            Console.SetCursorPosition(posX, posY);
        }

        bool VerifierConnectionBatiment(Amenagement a)
        {
            int gauche = Math.Max(a.PosX - 1, 0);
            int droite = Math.Min(a.PosX + a.Taille, taille - 1);
            int haut = Math.Max(a.PosY - 1, 0);
            int bas = Math.Min(a.PosY + a.Taille, taille - 1);
            for (int i = gauche; i <= droite; i++)
            {
                for(int j = haut; j <= bas; j++)
                {
                    if(!(j == a.PosX - 1 && i == a.PosY + a.Taille) && !(j == a.PosX - 1 && i == a.PosY - 1) && !(j == a.PosX + a.Taille && i == a.PosY + a.Taille) && !(j == a.PosX + a.Taille && i == a.PosY - 1))                  
                    {
                        if(carte[i, j] != null && carte[i, j] is Route)
                        {
                            Amenagement t = carte[i, j];
                            bool connecte = PathFinding(new List<Route>(), new Queue<Route> ( new[]{(t as Route) }));
                            if (connecte)
                            {
                                return true;
                            }
                            
                        }
                    }
                }
            }

            return false;
            
        }

        void VerifierConnectionToutLesBatiments(List<Amenagement> amenagements) {
            foreach(Amenagement a in amenagements)
            {
                if((a is Batiment))
                {
                    (a as Batiment).EstConnecte = VerifierConnectionBatiment(a); 
                }
            }
        }

        bool PathFinding(List<Route> routesbloquees, Queue<Route> routesachercher)
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

        List<Route> AjoutRoutesAdjacentes(List<Route> routesbloquees, Route r)
        {
            List<Route> temp = new List<Route>();
            if (r.PosX > 0 && carte[r.PosY, r.PosX - 1] is Route && !routesbloquees.Contains(carte[r.PosY, r.PosX - 1] as Route)) temp.Add(carte[r.PosY, r.PosX - 1] as Route);
            if (r.PosY > 0 && carte[r.PosY - 1, r.PosX] is Route && !routesbloquees.Contains(carte[r.PosY - 1, r.PosX] as Route)) temp.Add(carte[r.PosY - 1, r.PosX] as Route);
            if (r.PosX < taille - 1 && carte[r.PosY, r.PosX + 1] is Route && !routesbloquees.Contains(carte[r.PosY, r.PosX + 1] as Route)) temp.Add(carte[r.PosY, r.PosX + 1] as Route);
            if (r.PosY < taille - 1 && carte[r.PosY + 1, r.PosX] is Route && !routesbloquees.Contains(carte[r.PosY + 1, r.PosX] as Route)) temp.Add(carte[r.PosY + 1, r.PosX] as Route);

            return temp;
        }

    }
}
