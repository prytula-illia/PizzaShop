using AutoMapper;
using PizzaApp.BLL.Models;
using PizzaApp.DAL.Entities;
using System;

namespace PizzaApp.BLL
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Ingridient, IngridientModel>().ReverseMap();

            CreateMap<Pizza, PizzaModel>().ReverseMap();
            
            CreateMap<Payment, PaymentModel>().ReverseMap();
        }
    }
}
