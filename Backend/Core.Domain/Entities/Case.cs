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
        public ICollection<Message> Messages { get; protected set; }

        public Case(int clientId)
        {
            ClientId = clientId;
            Status = Status.New;
        }
        
        protected Case()
        {
        }

        public void AssignTo(Guid teamMemberId)
        {
            TeamMemberId = teamMemberId;
            Status = Status.Open;
        }

        public void UnAssign()
        {
            TeamMemberId = null;
        }

        public void Close()
        {
            Status = Status.Closed;
        }
    }
}