using System;
using System.Collections.Generic;

namespace WebApplication3.Models
{
    public class House
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string HouseColours { get; set; }
        public string Founder { get; set; }
        public string Animal { get; set; }
        public string Element { get; set; }
        public string Ghost { get; set; }
        public string CommonRoom { get; set; }
        public List<Head> Heads { get; set; }
        public List<Trait> Traits { get; set; }
    }

    public class Head
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}";
    }

    public class Trait
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
} 