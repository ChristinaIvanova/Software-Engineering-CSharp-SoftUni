using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;

namespace MiniORM
{
    public class DbSet<TEnity> : ICollection<TEnity>
        where TEnity : class, new()
    {
        public DbSet(IEnumerable<TEnity> entities)
        {
            this.Entities = entities.ToList();

            this.ChangeTracker = new ChangeTracker<TEnity>(entities);
        }

        internal ChangeTracker<TEnity> ChangeTracker { get; set; }

        internal IList<TEnity> Entities { get; set; }

        public int Count => this.Entities.Count;

        public bool IsReadOnly => this.Entities.IsReadOnly;

        public bool Contains(TEnity item) => this.Entities.Contains(item);

        public void Add(TEnity item)
        {
            if (item == null)
            {
                throw new ArgumentException(nameof(item), "Item cannot be null!");
            }

            this.Entities.Add(item);

            this.ChangeTracker.Add(item);
        }

        public void Clear()
        {
            while (this.Entities.Any())
            {
                var entity = this.Entities.First();
                this.Remove(entity);
                this.ChangeTracker.Remove(entity);
            }
        }

        public bool Remove(TEnity item)
        {
            if (item == null)
            {
                throw new ArgumentException(nameof(item), "Item cannot be null!");
            }

            var removedSuccessfully = this.Entities.Remove(item);
            if (removedSuccessfully)
            {
                this.ChangeTracker.Remove(item);
            }

            return removedSuccessfully;
        }

        public void RemoveRange(IEnumerable<TEnity> entities)
        {
            foreach (var enity in entities.ToArray())
            {
                this.Remove(enity);
            }
        }

        public void CopyTo(TEnity[] array, int arrayIndex) => this.Entities.CopyTo(array, arrayIndex);
        
        public IEnumerator<TEnity> GetEnumerator()
        {
            return this.Entities.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}