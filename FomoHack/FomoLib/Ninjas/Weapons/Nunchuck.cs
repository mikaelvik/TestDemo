using System.Collections.Generic;

namespace FomoLib.Ninjas.Weapons
{
    public class Nunchuck : IWeapon
    {
        private readonly IDictionary<string, string> _locations = new Dictionary<string, string>
        {
            {"sindre", "Las Vegas"},
            {"anders", "Nordpolen"}
        };

        public string Hit(string target)
        {
            var tl = target.ToLower();
            var location = _locations.ContainsKey(tl) ? _locations[tl] : "Nowhere";
            return $"Missed, and moved {target} to {location}";
        }
    }
}