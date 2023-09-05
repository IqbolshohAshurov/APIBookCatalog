using AutoMapper;
using BookCatalogAPI.Models;
using BookCatalogAPI.Requests.BookRequests;
using BookCatalogAPI.Responses;

namespace BookCatalogAPI.Mappers;

public class BookProfile : Profile
{
    public BookProfile()
    {
        CreateMap<CreateBookRequest, Book>()
            .ForMember(dest => dest.PublishingId, src => src
                .MapFrom(b => b.PuId))
            .ForMember(dest => dest.SubjectId, src => src
                .MapFrom(b => b.SuId));

        CreateMap<Book, BookViewModel>()
            .ForMember(dest => dest.PublishingName, src => src.MapFrom(b => b.Publishing.Name))
            .ForMember(dest => dest.SubjectName, src => src.MapFrom(b => b.Subject.Title));
        //.ForMember(dest => dest.AuthorFullName, src => src.MapFrom(b => b.Authors.First().FirstName + " " + b.Authors.First().LastName));
        CreateMap<UpdateBookRequest, Book>();
    }
}