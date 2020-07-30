using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApp7.Models;
using WebApp7.Manager;
namespace WebApp7.Manager
{
    public class AutoMapperManager
    {
        private NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        public static Users Mapper(InputDataUser inputData)
        {
            try
            {
                var config = new MapperConfiguration(
                       cfg =>
                       {
                           cfg.CreateMap<InputDataUser, Users>().ForMember(des => des.Id, d => d.MapFrom(src => src.Id));
                       });

                IMapper mapper = config.CreateMapper();
                var NewEntryBase = mapper.Map<InputDataUser, Users>(inputData);
                ErrorSuccessInfoMessage.SuccessMessage(19);//automapper zadziałał prawidłowo
                return NewEntryBase;
            }
            catch(Exception exp)
            {
                ErrorSuccessInfoMessage.ErrorMessage(19, exp);//w bloku automapper powstał błąd
                return null;
            }
            
        }

    }
}
