using System.Collections.Generic;
using System.Linq;
using FomoLib.Error;

namespace FomoLib
{
    public class Ninja
    {
        private readonly IList<IWeapon> _weapons = new List<IWeapon>();

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
                ", ", 
                _weapons.Select(w => w.Hit(target))
                );
        }
    }
}