using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WFM.Entity;
using WFM.Service;

namespace WFM.Repository
{
    //database tablename
    public class UserRepository
    {

        IUnitOfWork unitOfWork;
        public UserRepository(IUnitOfWork unitOfWork)
        {

            this.unitOfWork = unitOfWork;
        }

        public int AddUser(User user)
        {
            string sql = $@"INSERT INTO [dbo].[User]
                                       ([id]
                                       ,[username]
                                       ,[email])
                                 VALUES
                                       (@id,
                                        @username, 
                                        @email
                                        )";

            return unitOfWork.Connection.Execute(sql, user,unitOfWork.Transaction);
        }
    }
}
