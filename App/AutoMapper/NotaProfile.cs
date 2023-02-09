using App.Models;
using App.ViewModels;
using AutoMapper;

namespace App.AutoMapper
{
    public class NotaProfile : Profile
    {
        public NotaProfile()
        {
            CreateMap<Nota, NotaViewModel>();
            CreateMap<NotaViewModel, Nota>();
        }
    }
}
