using AutoMapper;
using LibraryManager.ActionHandlers.Forms;
using LibraryManager.Data.Model.Entity;
using LibraryManager.Shared;
using LibraryManager.Shared.IoC;

namespace LibraryManager.ActionHandlers
{
    public class MapperBootsrapper: IBootsrapper
    {
        public void Execute(IServiceContainer container)
        {
            var mapper = new MapperConfiguration(ConfigureMapper).CreateMapper();
            container.RegisterInstance(mapper);
        }

        private static void ConfigureMapper(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<CreateBookForm, Book>();
            cfg.CreateMap<UpdateBookForm, Book>();

            cfg.CreateMap<CreateLibraryCardForm, LibraryCard>();
            cfg.CreateMap<UpdateLibraryCardForm, LibraryCard>();

            cfg.CreateMap<CreateClientEntryForm, ClientEntry>();
            cfg.CreateMap<UpdateClientEntryForm, ClientEntry>();
        }
    }
}