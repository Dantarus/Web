using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApp7.Models;
namespace WebApp7.Manager
{
    public class AutoMapperManager
    {
        private NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        public static WebApp7.Models.Table Mapper(WebApp7.Models.InputUserData inputData)
        {
            //lokalizacja mappera
            var config = new MapperConfiguration(
                       cfg =>
                       {
                           cfg.CreateMap<WebApp7.Models.InputUserData, WebApp7.Models.Table>().ForMember(des => des.Id,d =>d.MapFrom(src => src.Id));
                       });

            ////utworznie instancji automapera przy ustawionej konfiguracji
            IMapper mapper = config.CreateMapper();

            //wykonainie mapowania z modelu źródłowego do doceloweego
            var NewEntryBase = mapper.Map<WebApp7.Models.InputUserData, WebApp7.Models.Table>(inputData);

            return NewEntryBase;
        }

    }
}
