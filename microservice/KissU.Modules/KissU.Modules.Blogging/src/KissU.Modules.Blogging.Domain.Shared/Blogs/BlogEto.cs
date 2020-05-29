using System;
using JetBrains.Annotations;

namespace KissU.Modules.Blogging.Domain.Shared.Blogs
{
    [Serializable]
    public class BlogEto
    {
        public Guid Id { get; set; }

        [NotNull]
        public string Name { get; set; }

        [NotNull]
        public string ShortName { get; set; }

        [CanBeNull]
        public string Description { get; set; }
    }
}