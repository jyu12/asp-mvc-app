using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using AutoMapper;
using Newbly.Dtos;
using Newbly.Models;

namespace Newbly.App_Start
{
    /*
     * Example configuring AutoMapper
     * Convention base mapping tool
     * 
     * AutoMapper uses reflection to find their properties base on name and map them
     * 
     * AutoMapper Profile needs to be added in Global.ascx
     * */
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Generic method that takes source and target
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<CustomerDto, Customer>()
                .ForMember(c => c.Id, opt => opt.Ignore()); 

            Mapper.CreateMap<MembershipType, MembershipTypeDto>();

            Mapper.CreateMap<Movie, MovieDto>();
            Mapper.CreateMap<MovieDto, Movie>()
                .ForMember(c => c.Id, opt => opt.Ignore());

            Mapper.CreateMap<Genre, GenreDto>();

            Mapper.CreateMap<Rental, RentalDto>();
            Mapper.CreateMap<RentalDto, Rental>()
                .ForMember(c => c.Id, opt => opt.Ignore());
        }
    }
}