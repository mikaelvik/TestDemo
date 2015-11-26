namespace FomoLib.Ninjas
{
    public class Nunchuck : IWeapon
    {
        public string Hit(string target)
        {
            return $"Missed, and moved {target} to Las Vegas";
        }
    }
}