using System;

namespace FomoLib.Ninjas.Error
{
    public class DisgruntledNinja : Exception
    {
        public DisgruntledNinja(string message) : base(message)
        {
        }
    }
}