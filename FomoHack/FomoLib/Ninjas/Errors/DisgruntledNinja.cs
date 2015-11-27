using System;

namespace FomoLib.Ninjas.Errors
{
    public class DisgruntledNinja : Exception
    {
        public DisgruntledNinja(string message) : base(message)
        {
        }
    }
}