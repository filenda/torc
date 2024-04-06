using AutoMapper;
using BookLibraryApi.Features.Books.DTOs;
using BookLibraryApi.Features.Books.Models;

namespace BookLibraryApi.Features.Books.MappingProfiles;

public class BookMappingProfile : Profile
{
  public BookMappingProfile()
  {
    CreateMap<Book, BookDto>().ReverseMap();
  }
}
