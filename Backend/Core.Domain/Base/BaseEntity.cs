using System;
using System.ComponentModel.DataAnnotations;

namespace Backend.Core.Domain.Base
{
    public abstract class BaseEntity
    {
        [Required] public Guid Id { get; protected set; }

        protected BaseEntity()
        {
        }
    }
}