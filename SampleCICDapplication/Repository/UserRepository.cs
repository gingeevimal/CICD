using SampleCICDapplication.IRepository;
using SampleCICDapplication.Models;
using System;
using System.Collections.Generic;

namespace SampleCICDapplication.Repository
{
    public class UserRepository : IUserRepository
    {
        bool _isInitialized;

        public void InitializeException()
        {
            // Initialize hardware interface
            _isInitialized = true;
        }
        public List<UserListDTO> GetUserList()
        {
            try
            {
                if (_isInitialized)
                {
                    throw new InvalidOperationException("Dummy Exception");
                }
                else
                {
                    List<UserListDTO> userlist = new List<UserListDTO>()
                    { new UserListDTO { Id = 1, Name = "UserOne", Email = "userone@gmail.com", Address = "XXX,YYYY", Number = "0123654789"},
                      new UserListDTO { Id = 2, Name = "UserTwo", Email = "usertwo@gmail.com", Address = "XXX,YYYY", Number = "0123654789"},
                      new UserListDTO { Id = 3, Name = "UserThree", Email = "userthree@gmail.com", Address = "XXX,YYYY", Number = "0123654789"},
                      new UserListDTO { Id = 4, Name = "UserFour", Email = "userfour@gmail.com", Address = "XXX,YYYY", Number = "0123654789"},
                      new UserListDTO { Id = 5, Name = "UserFive", Email = "userfive@gmail.com", Address = "XXX,YYYY", Number = "0123654789"},
                    };

                    return userlist;
                }

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
