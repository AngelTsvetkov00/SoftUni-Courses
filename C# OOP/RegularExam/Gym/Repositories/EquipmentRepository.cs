﻿using Gym.Models.Equipment.Contracts;
using Gym.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gym.Repositories
{
    public class EquipmentRepository : IRepository<IEquipment>
    {
        private List<IEquipment> equipment = new List<IEquipment>();

        public IReadOnlyCollection<IEquipment> Models => equipment.AsReadOnly();

        public void Add(IEquipment model)
        {
            equipment.Add(model);
        }

        public IEquipment FindByType(string type) => Models.FirstOrDefault(x => x.GetType().Name == type);

        public bool Remove(IEquipment model) => equipment.Remove(model);
    }
}