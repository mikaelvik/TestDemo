namespace FomoLib.Ninjas
{
    public class Sword : IWeapon
    {
        public string Hit(string target)
        {
            return $"Slice {target} in half!!";
        }
    }
}