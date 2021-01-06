using AutoMapper;
using CONBook.Application.DTOs.RequestDTOs;
using CONBook.Application.DTOs.ResponseDTOs;
using CONBook.Domain.Entities;

namespace CONBook.Application.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Book, GetAllBooksDTO>();
            CreateMap<Book, GetBookDTO>();

            CreateMap<AddBookDTO, Book>();
            CreateMap<UpdateBookDTO, Book>();
        }
    }
}
