using AutoMapper;
using KissU.Modules.QuickStart.Books;

namespace KissU.Modules.QuickStart
{
    public class QuickStartApplicationAutoMapperProfile : Profile
    {
        public QuickStartApplicationAutoMapperProfile()
        {
            /* You can configure your AutoMapper mapping configuration here.
             * Alternatively, you can split your mapping configurations
             * into multiple profile classes for a better organization. */

            CreateMap<Book, BookDto>();
            CreateMap<CreateUpdateBookDto, Book>(MemberList.Source);
        }
    }
}