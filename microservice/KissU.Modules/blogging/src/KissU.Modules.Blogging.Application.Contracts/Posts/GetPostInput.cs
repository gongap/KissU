 using System;

 namespace KissU.Modules.Blogging.Application.Contracts.Posts
{
    public class GetPostInput
    {
        public string Url { get; set; }

        public Guid BlogId { get; set; }
    }
}