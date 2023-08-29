using AutoMapper;
using BookCatalogAPI.Models;
using BookCatalogAPI.Requests.BookRequests;
using BookCatalogAPI.Responses;

namespace BookCatalogAPI.Mappers;

public class BookProfile: Profile
{
    public BookProfile()
    {
        CreateMap<CreateBookRequest, Book>()
            /*.ForMember(
                dest => dest.Id,
                src => src.MapFrom(
                    b => Guid.NewGuid()))
            */.ForMember(
                d => d.CreatedAt,
                src => src.MapFrom(
                    b => DateTime.Now.Date))
            .ForMember(
                d => d.UpdatedAt,
                src => src.MapFrom(
                    b => DateTime.Now.Date))
            .ForMember(
                dest => dest.Status,
                src => src.MapFrom(
                    b => true));

        CreateMap<Book, BookViewModel>();
        CreateMap<UpdateBookRequest, Book>()
            .ForMember(
                dest => dest.UpdatedAt,
                src => src
                .MapFrom(
                    b => DateTime.Now.Date));
    }
}