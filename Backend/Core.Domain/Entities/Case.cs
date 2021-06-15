using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Backend.Core.Domain.Base;
using Backend.Core.Domain.Enums;

namespace Backend.Core.Domain.Entities
{
    public class Case : BaseEntity
    {
        public virtual TeamMember TeamMember { get; protected set; }
        public Guid? TeamMemberId { get; protected set; }
        public virtual Client Client { get; protected set; }
        [Required] public int ClientId { get; protected set; }
        [Required] public Status Status { get; protected set; }
        public Guid? LastMessageId { get; protected set; }
        [Required] public DateTime UpdatedAt { get; protected set; }
        public ICollection<Message> Messages { get; protected set; }

        public Case(int clientId)
        {
            ClientId = clientId;
            Status = Status.Unassigned;
            LastMessageId = null;
            UpdatedAt = DateTime.Now;
        }
        
        protected Case()
        {
        }

        public void AssignTo(Guid teamMemberId)
        {
            TeamMemberId = teamMemberId;
            Status = Status.Open;
            UpdatedAt = DateTime.Now;
        }

        public void UnAssign()
        {
            TeamMemberId = null;
            Status = Status.Unassigned;
            UpdatedAt = DateTime.Now;
        }

        public void Close()
        {
            Status = Status.Closed;
            UpdatedAt = DateTime.Now;
        }
    }
}