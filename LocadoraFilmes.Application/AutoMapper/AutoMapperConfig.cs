using AutoMapper;

namespace LocadoraFilmes.Application.AutoMapper
{
    public static class AutoMapperConfig
    {
        public static MapperConfiguration RegisterMappings()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.AllowNullDestinationValues = true;
                cfg.AllowNullCollections = true;

                cfg.DisableConstructorMapping();

                cfg.AddProfile(new DomainToResponseMap());
                cfg.AddProfile(new RequestToDomainMap());
            });
        }
    }
}
