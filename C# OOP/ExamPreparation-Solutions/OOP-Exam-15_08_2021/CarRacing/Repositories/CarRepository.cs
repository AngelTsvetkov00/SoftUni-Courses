using CarRacing.Models.Cars;
using CarRacing.Models.Cars.Contracts;
using CarRacing.Repositories.Contracts;
using CarRacing.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarRacing.Repositories
{
    public class CarRepository : IRepository<ICar>
    {
        private List<ICar> models = new List<ICar>();

        public IReadOnlyCollection<ICar> Models
        {
            get => models.AsReadOnly();
        }

        public void Add(ICar model)
        {
            if(model == null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidAddCarRepository);
            }


            models.Add(model);

        }

        public ICar FindBy(string property)
        {
            return models.FirstOrDefault(x => x.VIN == property);
        }

        public bool Remove(ICar model)
        {
            return models.Remove(model);
        }

        internal bool Any(Func<object, object> p)
        {
            throw new NotImplementedException();
        }
    }
}
