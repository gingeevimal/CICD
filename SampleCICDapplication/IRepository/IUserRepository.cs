using SampleCICDapplication.Models;
using System.Collections.Generic;

namespace SampleCICDapplication.IRepository
{
    public interface IUserRepository
    {
        List<UserListDTO> GetUserList();
        void InitializeException();
    }
}
