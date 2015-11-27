using System.Collections.Generic;
using System.Linq;
using FomoLib.Ninjas.Errors;
using FomoLib.Ninjas.Weapons;

namespace FomoLib.Ninjas
{
    public class Ninja : ITarget
    {
        private readonly IList<IWeapon> _weapons = new List<IWeapon>();
        private int _lifeForce;

        public Ninja() : this(100)
        {
        }

        public Ninja(int lifeForce)
        {
            _lifeForce = lifeForce;
        }

        public bool Defend(int damage)
        {
            _lifeForce -= damage;
            return _lifeForce > 0;
        }

        public void Arm(IWeapon weapon)
        {
            if (weapon == null)
            {
                throw new DisgruntledNinja("Oh Hell No!!");
            }
            _weapons.Add(weapon);
        }

        public string Attack(string target)
        {
            return string.Join(
                "\n",
                _weapons.Select(w => w.Hit(target))
                );
        }
    }
}