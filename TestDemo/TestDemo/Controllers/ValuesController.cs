using System.Collections.Generic;
using System.Web.Http;
using TestDemo.Validators;

namespace TestDemo.Controllers
{
    public class ValuesController : ApiController
    {
        private readonly IList<string> _values = new List<string>();

        // TODO: dependency injection?
        public ValuesValidator ValuesValidator = new ValuesValidator();

        public ValuesController()
        {
        }

        public ValuesController(ValuesValidator valuesValidator)
        {
            ValuesValidator = valuesValidator;
        }

        // GET api/values
        public IEnumerable<string> Get()
        {
            return _values;
        }

        // GET api/values/5
        public string Get(int id)
        {
            return _values[id];
        }

        // POST api/values
        public void Post([FromBody] string value)
        {
            if (ValuesValidator.Validate(value))
            {
                _values.Add(value);
            }
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
            _values[id] = value;
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
            _values.RemoveAt(id);
        }
    }
}