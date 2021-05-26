using System;
using System.ComponentModel.DataAnnotations;
using Backend.Core.Domain.Base;

namespace Backend.Core.Domain.Entities
{
    public class Message : BaseEntity
    {
        public virtual Case Case { get; protected set; }
        [Required] public Guid CaseId { get; protected set; }
        [Required] public string Content { get; protected set; }

        public Message(Guid caseId, string content)
        {
            CaseId = caseId;
            Content = content;
        }

        protected Message()
        {
        }
    }
}