namespace KissU.Modules.Blogging.Application.Contracts.Tagging.Dtos
{
    public class GetPopularTagsInput
    {
        public int ResultCount { get; set; } = 10;

        public int? MinimumPostCount { get; set; }
    }
}