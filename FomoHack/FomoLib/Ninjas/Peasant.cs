namespace FomoLib.Ninjas
{
    public class Peasant : ITarget
    {
        private int _lifeForce;

        public Peasant(int lifeForce)
        {
            _lifeForce = lifeForce;
        }

        public bool Defend(int damage)
        {
            _lifeForce -= damage;
            return _lifeForce > 0;
        }
    }
}