using System;

namespace FomoLib.Error
{
    public class DisgruntledNinja : Exception
    {
        public DisgruntledNinja(string message) : base(message)
        {
        }
    }
}