using ResourceBox.Models;
using ResourceBox.Services.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ResourceBox.Services.Operation
{
    public class SecurityServices
    {
        SecurityDAO daoService = new SecurityDAO();

        public bool Authenticate(User user)
        {
            return daoService.FindByUser(user);
        }
        public string EncryptPassword(string keyNew,string password)
        {
            
            var encryptedPassword = EncryptedSecurity.EncodePassword(password, keyNew);

            return encryptedPassword;
        }
    }
}