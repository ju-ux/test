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
               .SurUnePlanète(planète => planète.ToriqueDeTailleX(4).AyantUnObstacle(0, 2))
               .Orienté(Orientation.Nord)
               .Positionné(0, 0)
               .Build();
        Console.WriteLine("Entrez plusieurs directions à la suite entre 'a', 'g', 'd'");
        String commandLine = Console.ReadLine();
        char[] commandsToChars = commandLine.ToCharArray();
        Point positionActuelle = new Point(0, 0);

        for(int i = 0;i< commandsToChars.Length;i++)
        {
            if (commandsToChars[i].ToString().ToLower().Equals("a"))
            {
                positionActuelle = rover.Traiter(new AvancerCommande()).Position;
                if (positionActuelle != rover.Traiter(new AvancerCommande()).Position)
                {
                    Console.WriteLine("ma position est : " + rover.Traiter(new AvancerCommande()).Position);
                    continue;
                }
                else
                {
                    Console.WriteLine("Je suis face à un obstacle position actuelle : " + positionActuelle);
                    break;
                }
            }
            if (commandsToChars[i].ToString().ToLower().Equals("g"))
            {
                positionActuelle = rover.Traiter(new TourneAGaucheCommande()).Position;
                if (positionActuelle != rover.Traiter(new TourneAGaucheCommande()).Position)
                {
                    Console.WriteLine("ma position est : " + rover.Traiter(new TourneAGaucheCommande()).Position);
                    continue;
                }
                else
                {
                    Console.WriteLine("Je suis face à un obstacle position actuelle : " + positionActuelle);
                    break;
                }
            }
            if (commandsToChars[i].ToString().ToLower().Equals("d"))
            {
                positionActuelle = rover.Traiter(new TournerADroiteCommande()).Position;
                if (positionActuelle != rover.Traiter(new TournerADroiteCommande()).Position)
                {
                    Console.WriteLine("ma position est : " + rover.Traiter(new TournerADroiteCommande()).Position);
                    continue;
                }
                else
                {
                    Console.WriteLine("Je suis face à un obstacle position actuelle : " + positionActuelle);
                    break;
                }
            }
        }

        
       
        Console.ReadKey();
    }
   

}