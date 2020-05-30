﻿using System;
using Volo.Abp.Domain.Entities;

namespace KissU.Modules.IdentityServer.Domain.Grants
{
    public class PersistedGrant : AggregateRoot<Guid>
    {
        public virtual string Key { get; set; }

        public virtual string Type { get; set; }

        public virtual string SubjectId { get; set; }

        public virtual string ClientId { get; set; }

        public virtual DateTime CreationTime { get; set; }

        public virtual DateTime? Expiration { get; set; }

        public virtual string Data { get; set; }

        protected PersistedGrant()
        {
            
        }

        public PersistedGrant(Guid id)
        {
            Id = id;
        }
    }
}