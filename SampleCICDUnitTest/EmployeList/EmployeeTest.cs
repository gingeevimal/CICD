using Moq;
using Newtonsoft.Json;
using SampleCICDapplication.IRepository;
using SampleCICDapplication.Models;
using SampleCICDapplication.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Xunit;

namespace SampleCICDUnitTest.EmployeList
{
    [TestCaseOrderer("SampleCICDUnitTest.PriorityOrderer", "SampleCICDUnitTest")]
    public class EmployeeTest
    {
        public Mock<IUserRepository> mock = new Mock<IUserRepository>();
        private IUserRepository _userRepositoryMock;

        internal void Initialize()
        {
            _userRepositoryMock = new UserRepository();
        }

        [Fact, TestPriority(0)]
        public void GetEmployeeDetailsPositiveCase()
        {
            this.Initialize();

            var CurrentDirectory = Directory.GetCurrentDirectory();
            var directory = CurrentDirectory.Split("bin");
            var path = directory[0] + "Employee_Details.json";
            List<UserListDTO> userListDTOs = JsonConvert.DeserializeObject<List<UserListDTO>>(File.ReadAllText(path));
            List<UserListDTO> result = _userRepositoryMock.GetUserList();

            Assert.Equal(userListDTOs.Count, result.Count);
            Assert.NotNull(result);
            Assert.True(result.Count > 0);
        }

        [Fact, TestPriority(1)]
        public void GetEmployeeDetailsNegativeCase()
        {
            this.Initialize();

            List<UserListDTO> userListDTOs = null;
            List<UserListDTO> result = _userRepositoryMock.GetUserList();

            Assert.NotEqual(result, userListDTOs);
            Assert.Null(userListDTOs);
            Assert.True(userListDTOs == null);
        }

        [Fact, TestPriority(2)]
        public void GetEmployeeDetailsThrowException()
        {
            this.Initialize();
            _userRepositoryMock.InitializeException();

            Action act = () => _userRepositoryMock.GetUserList();
            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(act);

            Assert.Equal("Dummy Exception", exception.Message);
        }
    }
}
