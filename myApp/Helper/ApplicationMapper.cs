using AutoMapper;
using myApp.Data;
using myApp.Model;

namespace myApp.Helper
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper() { 
        CreateMap<Book,BookModel>().ReverseMap();
        }  
    }
}
