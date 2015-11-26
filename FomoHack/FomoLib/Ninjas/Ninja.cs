using System.Collections.Generic;
using System.Linq;
using FomoLib.Ninjas.Error;

namespace FomoLib.Ninjas
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
                "\n",
                _weapons.Select(w => w.Hit(target))
                );
        }
    }
}