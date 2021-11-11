using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding
{
    public abstract class BaseHero
    {
        private string _name;
        private int _power;
        
        public BaseHero(string name)
        {
            this.Name = name;
        }

        public virtual string Name
        { 
            get => _name; 
            protected set => _name = value; 
        }
        
        public virtual int Power
        { 
            get => _power; 
            protected set => _power = value; 
        }

        public abstract string CastAbility();
    }
}
