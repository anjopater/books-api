using System;
using System.ComponentModel.DataAnnotations;

namespace Books.Domain
{
    public abstract class Entity
    {
        [Key]
        public Guid Id { get; set; }
    }
}
