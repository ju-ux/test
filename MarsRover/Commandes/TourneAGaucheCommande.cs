using System.Numerics;

namespace MarsRover.Commandes
{
    public class TourneAGaucheCommande : IRoverCommande
    {
        /// <inheritdoc />
        public (Orientation Orientation, Point Position, Point? ObstacleEventuel) Traiter(Orientation orientation, Point position, IPlanète _planète)
        {

   
            return (orientation.MouvementSinistrogyre, position, default);
        }
    }
}