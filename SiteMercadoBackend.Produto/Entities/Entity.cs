using System;

namespace SiteMercadoBackend.Produto.Entities
{
    public abstract class Entity: IEquatable<Entity> {
        public Entity()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; private set; }

        public bool Equals(Entity other)
        {
            return Id == other.Id;
        }
    }
    
}