using System;
using System.Collections.Generic;

namespace WebApplication3.Models
{
    public class Wizard
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<Elixir> Elixirs { get; set; }

        public string FullName => string.IsNullOrEmpty(FirstName) 
            ? LastName 
            : $"{FirstName} {LastName}";
    }
} 