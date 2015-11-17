using System;

namespace TestDemo.Validators
{
    public class ValuesValidator
    {
        public virtual bool Validate(string value)
        {
            return true;
        }

        public virtual bool DontCallThis(string value)
        {
            throw new NotImplementedException();
        }
    }
}