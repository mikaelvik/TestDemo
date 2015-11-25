using FomoLib.Error;

namespace FomoLib
{
    public class Ninja
    {
        public void Arm(Weapon weapon)
        {
            if (weapon == null)
            {
                throw new DisgruntledNinja("Oh Hell No!!");
            }
        }

        public void Attack(string name)
        {
            
        }
    }
}