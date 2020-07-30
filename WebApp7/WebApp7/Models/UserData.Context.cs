﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApp7.Models
{
    using System;
    using System.Data.Entity.Core.Objects;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class UserDataEntities : DbContext
    {
        public UserDataEntities()
            : base("name=UserDataEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<UserRoleMapping> UserRoleMapping { get; set; }
        public virtual DbSet<Users> Users { get; set; }
    
        public virtual ObjectResult<Nullable<int>> Check_Login(string lOGINNAME)
        {
            var lOGINNAMEParameter = lOGINNAME != null ?
                new ObjectParameter("LOGINNAME", lOGINNAME) :
                new ObjectParameter("LOGINNAME", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("Check_Login", lOGINNAMEParameter);
        }
    
        public virtual int DeleteUser(string login)
        {
            var loginParameter = login != null ?
                new ObjectParameter("Login", login) :
                new ObjectParameter("Login", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("DeleteUser", loginParameter);
        }
    
        public virtual ObjectResult<string> GetRole(string email)
        {
            var emailParameter = email != null ?
                new ObjectParameter("Email", email) :
                new ObjectParameter("Email", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("GetRole", emailParameter);
        }
    
        public virtual int InsertData(string login, string password, string email)
        {
            var loginParameter = login != null ?
                new ObjectParameter("Login", login) :
                new ObjectParameter("Login", typeof(string));
    
            var passwordParameter = password != null ?
                new ObjectParameter("Password", password) :
                new ObjectParameter("Password", typeof(string));
    
            var emailParameter = email != null ?
                new ObjectParameter("Email", email) :
                new ObjectParameter("Email", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("InsertData", loginParameter, passwordParameter, emailParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> isEmailExist(string email)
        {
            var emailParameter = email != null ?
                new ObjectParameter("Email", email) :
                new ObjectParameter("Email", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("isEmailExist", emailParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> isLoginExist(string login)
        {
            var loginParameter = login != null ?
                new ObjectParameter("Login", login) :
                new ObjectParameter("Login", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("isLoginExist", loginParameter);
        }
    
        public virtual ObjectResult<Nullable<int>> isPasswordExist(string password)
        {
            var passwordParameter = password != null ?
                new ObjectParameter("Password", password) :
                new ObjectParameter("Password", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("isPasswordExist", passwordParameter);
        }
    
        public virtual int SetRole(string login, string role)
        {
            var loginParameter = login != null ?
                new ObjectParameter("Login", login) :
                new ObjectParameter("Login", typeof(string));
    
            var roleParameter = role != null ?
                new ObjectParameter("Role", role) :
                new ObjectParameter("Role", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SetRole", loginParameter, roleParameter);
        }
    
        public virtual ObjectResult<User_RoleData_Result1> User_RoleData(string login)
        {
            var loginParameter = login != null ?
                new ObjectParameter("Login", login) :
                new ObjectParameter("Login", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<User_RoleData_Result1>("User_RoleData", loginParameter);
        }
    
        public virtual ObjectResult<UserList_Result> UserList()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<UserList_Result>("UserList");
        }
    
        public virtual ObjectResult<Nullable<int>> UpdateData(string updateText, Nullable<int> updateOption, string login)
        {
            var updateTextParameter = updateText != null ?
                new ObjectParameter("UpdateText", updateText) :
                new ObjectParameter("UpdateText", typeof(string));
    
            var updateOptionParameter = updateOption.HasValue ?
                new ObjectParameter("UpdateOption", updateOption) :
                new ObjectParameter("UpdateOption", typeof(int));
    
            var loginParameter = login != null ?
                new ObjectParameter("Login", login) :
                new ObjectParameter("Login", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("UpdateData", updateTextParameter, updateOptionParameter, loginParameter);
        }
    
        public virtual ObjectResult<string> GetEmail(string login)
        {
            var loginParameter = login != null ?
                new ObjectParameter("Login", login) :
                new ObjectParameter("Login", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("GetEmail", loginParameter);
        }
    
        public virtual ObjectResult<string> GetLogin(string email)
        {
            var emailParameter = email != null ?
                new ObjectParameter("Email", email) :
                new ObjectParameter("Email", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("GetLogin", emailParameter);
        }
    }
}
