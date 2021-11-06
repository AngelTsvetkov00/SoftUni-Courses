using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    public class Robot : ICheckable
    {
        private string _model;
        private string _id;

        public Robot(string model, string id)
        {
            this.Model = model;
            this.Id = id;
        }

        public string Model { get => _model; private set => _model = value; }
        public string Id { get => _id; private set => _id = value; }

        public void CheckID(string checker)
        {
           if(this.Id.EndsWith(checker))
            {
                Console.WriteLine(this.Id);
            }
        }
    }
}
