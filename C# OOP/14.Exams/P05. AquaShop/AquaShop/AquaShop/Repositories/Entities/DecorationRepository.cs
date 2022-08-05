using AquaShop.Models.Decorations.Contracts;
using AquaShop.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Repositories.Entities
{
    public class DecorationRepository : IRepository<IDecoration>
    {
        private readonly IList<IDecoration> models;

        public DecorationRepository()
        {
            this.models = new List<IDecoration>();
        }

        public IReadOnlyCollection<IDecoration> Models => this.models.ToList();

        public void Add(IDecoration model)
        {
            this.models.Add(model);
        }

        public IDecoration FindByType(string type)
        {
            IDecoration decoration = null;

            foreach (var model in this.models)
            {
                if (model.GetType().Name == type)
                {
                    decoration = model;
                }
            }

            return decoration;
        }


        public bool Remove(IDecoration model)
        {
            if (this.Models.Contains(model))
            {
                this.models.Remove(model);

                return true;
            }

            return false;
        }
    }
}
