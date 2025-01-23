using System;

namespace WebApplication3.Models
{
    public class Spell
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Incantation { get; set; }
        public string Effect { get; set; }
        public bool? CanBeVerbal { get; set; }
        public string Type { get; set; }
        public string Light { get; set; }
        public string Creator { get; set; }
    }
} 