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
        public static List<UserListModel> GetUsersList()
        {
            
            using (UserDataEntities dbmodel = new UserDataEntities())
            {
                var userList = new List<UserListModel>();
                var config = new MapperConfiguration(
                    cfg =>
                    {
                        cfg.CreateMap<WebApp7.Models.UserList_Result, WebApp7.Models.UserListModel>();
                    });
                 IMapper mapper = config.CreateMapper();
                userList = mapper.Map<List<WebApp7.Models.UserList_Result>, List<WebApp7.Models.UserListModel>>(dbmodel.UserList().ToList());
                return userList;
            }

        }
    }
}