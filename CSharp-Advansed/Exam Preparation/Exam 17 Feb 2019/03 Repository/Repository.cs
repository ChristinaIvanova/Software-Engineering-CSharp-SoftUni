using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository
{
    public class Repository
    {
        private Dictionary<int, Person> data;
        private int id;

        public Repository()
        {
            this.data = new Dictionary<int, Person>();
        }

        public int Count
        {
            get
            {
              return this.data.Count;
            }
        }

        public void Add(Person person)
        {
            this.data.Add(id, person);
            id++;
        }

        public Person Get(int id)
        {
            if (this.data.ContainsKey(id))
            {
                return this.data[id];
            }

            return null;
        }

        public bool Update(int id, Person newPerson)
        {
            if (this.data.ContainsKey(id))
            {
                this.data[id] = newPerson;
                return true;
            }

            return false;
        }

        public bool Delete(int id)
        {
            if (this.data.ContainsKey(id))
            {
                this.data.Remove(id);
                return true;
            }

            return false;

        }
    }
}
