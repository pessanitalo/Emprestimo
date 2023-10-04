using AutoMapper;
using CredEmprestimo.Business.Models;
using CredEmprestimoApi.ViewlModews;

namespace CredEmprestimoApi.Configurations
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig()
        {
            CreateMap<Cliente, ClienteViewModel>().ReverseMap();
            CreateMap<Emprestimo, EmprestimoViewModel>().ReverseMap();
            CreateMap<BoletoEmprestimo, BoletoViewModel>().ReverseMap();
        }
    }
}
