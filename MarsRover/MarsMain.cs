using MarsRover;
using MarsRover.Commandes;
using MarsRover.Test.Utilities;
using System.Xml.Serialization;
using System.Collections;
class MarsMain
{
    static void Main(string[] args)
    {
        Rover rover = new RoverBuilder()
               .SurUnePlanète(planète => planète.ToriqueDeTailleX(4).AyantUnObstacle(0, 3))
               .Orienté(Orientation.Nord)
               .Positionné(0, 0)
               .Build();

        Console.WriteLine("Entrez plusieurs directions à la suite entre 'a', 'g', 'd'");
        String commandLine = Console.ReadLine();
        //tableau des directions
        char[] tableauCommandes = commandLine.ToCharArray();
        Point positionActuelle = new Point(0, 0);

        //pour passer dans le tableau des directions
        for(int i = 0; i < tableauCommandes.Length; i++)
        {
            //pour avancer
            if (tableauCommandes[i].ToString().ToLower().Equals("a"))
            {
                positionActuelle = rover.Traiter(new AvancerCommande()).Position;
                if (positionActuelle != rover.Traiter(new AvancerCommande()).Position)
                {
                    Console.WriteLine("Ma position est : " + rover.Traiter(new AvancerCommande()).Position);
                    continue;
                }
                else
                {
                    Console.WriteLine("Je suis face à un obstacle position actuelle : " + positionActuelle);
                    break;
                }
            }
            //pour aller à gauche
            if (tableauCommandes[i].ToString().ToLower().Equals("g"))
            {
                positionActuelle = rover.Traiter(new TourneAGaucheCommande()).Position;
                if (positionActuelle != rover.Traiter(new TourneAGaucheCommande()).Position)
                {
                    Console.WriteLine("Ma position est : " + rover.Traiter(new TourneAGaucheCommande()).Position);
                    continue;
                }
                else
                {
                    Console.WriteLine("Je suis face à un obstacle position actuelle : " + positionActuelle);
                    break;
                }
            }
            //pour aller à droite
            if (tableauCommandes[i].ToString().ToLower().Equals("d"))
            {
                positionActuelle = rover.Traiter(new TournerADroiteCommande()).Position;
                if (positionActuelle != rover.Traiter(new TournerADroiteCommande()).Position)
                {
                    Console.WriteLine("Ma position est : " + rover.Traiter(new TournerADroiteCommande()).Position);
                    continue;
                }
                else
                {
                    Console.WriteLine("Je suis face à un obstacle position actuelle : " + positionActuelle);
                    break;
                }
            }
            //si c'est une mauvaise direction
            else
            {
                Console.WriteLine("La direction demandée n'est pas correcte");
            }
        }
        Console.ReadKey();
    }
}