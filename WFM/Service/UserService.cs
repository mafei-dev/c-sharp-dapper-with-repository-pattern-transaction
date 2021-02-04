using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WFM.Entity;
using WFM.Model;
using WFM.Resources;

namespace WFM.Service
{
    public class UserService
    {
        private Repository.UserRepository _userRepository;
        private Repository.PasswordRepository _passwordRepository;


        public UserService()
        {
            //_connection = new SqlConnection(Helper.GetConnectionString());
        }

        public int AddNewUser(AddUserModel userModel)
        {
            using (DalSession dalSession = new DalSession())
            {
                UnitOfWork unitOfWork = dalSession.UnitOfWork();
                unitOfWork.Begin();
                try
                {
                    _userRepository = new Repository.UserRepository(unitOfWork);
                    _passwordRepository = new Repository.PasswordRepository(unitOfWork);

                    int addedRecords = 0;

                    // user tabale
                    User user = new User();
                    user.id = 11;
                    user.email = userModel.email;
                    user.username = userModel.username;
                    if (_userRepository.AddUser(user) > 0)
                    {
                        addedRecords++;
                    }

                    //password table

                    Password password = new Password();
                    password.password = userModel.password;
                    password.id = 10;
                    password.user = user;

                    if (_passwordRepository.AddPassword(password) > 0)
                    {
                        addedRecords++;
                    }

                    if (addedRecords == 2)
                    {
                        //"Added successfully!";
                        unitOfWork.Commit();
                        return 1;
                    }
                    else
                    {
                        //"Added Falied!";
                        unitOfWork.Rollback();
                        return 0;
                    }
                }
                catch (Exception e)
                {
                    unitOfWork.Rollback();
                    throw;
                }
            }

            
        }
    }
}