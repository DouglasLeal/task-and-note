using App.Models;
using App.ViewModels;
using AutoMapper;

namespace App.AutoMapper
{
    public class TarefaProfile : Profile
    {
        public TarefaProfile()
        {
            CreateMap<Tarefa, TarefaViewModel>();
            CreateMap<TarefaViewModel, Tarefa>();
        }
    }
}
