using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApp7.Models;

namespace WebApp7.Manager
{
    public class UserPanelMenager
    {
        public static List<UserList> GetUsersList()
        {
            using (UserDataEntities db = new UserDataEntities())
            {
                var config = new MapperConfiguration(
                    cfg =>
                    {
                        cfg.CreateMap<IEnumerable<UserListing_Result>, List<UserList>>();
                    });
                IMapper mapper = config.CreateMapper();
                List<UserList> userList = mapper.Map<IEnumerable<UserListing_Result>, List<UserList>>(db.UserListing().ToList());
                return userList;
            }

        }
    }
}