using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Bookish.Dtos;
using Bookish.Models;

namespace Bookish.App_Start
{
    public class MappingProfile : Profile
    {
        //AutoMapper: Convention Based Mapping Tool.
        //PM> instal-package AutoMapper -version:4.1
        public MappingProfile()
        {
            //To create mapping configuration between two types
            //AutoMapper uses reflection to scan these types, it finds their properties and match them based on names.
            //Domain to Dto
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<Book, BookDto>();
            Mapper.CreateMap<MembershipType, MembershipTypeDto>();
            Mapper.CreateMap<Genre, GenreDto>();
            Mapper.CreateMap<Format, FormatDto>();

            //Dto to Domain
            Mapper.CreateMap<CustomerDto, Customer>()
                .ForMember(c=>c.Id,opt=>opt.Ignore());

            Mapper.CreateMap<BookDto, Book>()
                .ForMember(b => b.Id, opt => opt.Ignore());
        }
    }
}