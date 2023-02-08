using App.Models;
using App.ViewModels;
using AutoMapper;

namespace App.AutoMapper
{
    public class CategoriaProfile : Profile
    {
        public CategoriaProfile()
        {
            CreateMap<Categoria, CategoriaViewModel>();
            CreateMap<CategoriaViewModel, Categoria>();
        }
    }
}
