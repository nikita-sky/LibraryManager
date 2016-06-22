using AutoMapper;
using LibraryManager.ActionHandlers.Forms;
using LibraryManager.Data.Model.Entity;
using LibraryManager.Shared;
using LightInject;

namespace LibraryManager.ActionHandlers
{
    public class MapperBootsrapper: IBootsrapper
    {
        public void Execute(IServiceContainer container)
        {
            var mapper = new MapperConfiguration(ConfigureMapper).CreateMapper();
            container.RegisterInstance(mapper);
        }

        private static void ConfigureMapper(IMapperConfiguration cfg)
        {
            cfg.CreateMap<CreateBookForm, Book>();
        }
    }
}