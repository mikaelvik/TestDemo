namespace FomoLib.Ninjas
{
    public class Shuriken : IWeapon
    {
        public string Hit(string target)
        {
            return $"Swoosh, Baaam, Kill!! {target} suffers.";
        }
    }
}