using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Backend.Core.Domain.Entities
{
    public class Client
    {
        [Required] public int Id { get; protected set; }
        [Required] public string FirstName { get; protected set; }
        public string LastName { get; protected set; }
        public ICollection<Case> Cases { get; protected set; }

        public Client(int id, string firstName, string lastName)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
        }

        protected Client()
        {
        }
    }
}