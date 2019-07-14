using _05BorderControl.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace _05BorderControl
{
    public class Robot : IIdentifiable
    {
        private string model;

        public Robot(string model, string id)
        {
            this.model = model;
            this.Id = id;
        }

        public string Id { get; private set; }

        public override string ToString()
        {
            return $"{this.Id}";
        }
    }
}
