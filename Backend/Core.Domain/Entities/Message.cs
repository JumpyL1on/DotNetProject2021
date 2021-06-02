using System;
using System.ComponentModel.DataAnnotations;
using Backend.Core.Domain.Base;
using Type = Backend.Core.Domain.Enums.Type;

namespace Backend.Core.Domain.Entities
{
    public class Message : BaseEntity
    {
        public virtual Case Case { get; protected set; }
        [Required] public Guid CaseId { get; protected set; }
        [Required] public Type Type { get; protected set; }
        [Required] public string Text { get; protected set; }
        [Required] public bool Reply { get; protected set; }
        [Required] public DateTime CreatedAt { get; protected set; }

        public Message(Guid caseId, string text, bool reply, DateTime createdAt)
        {
            CaseId = caseId;
            Type = Type.Text;
            Text = text;
            Reply = reply;
            CreatedAt = createdAt;
        }

        protected Message()
        {
        }
    }
}