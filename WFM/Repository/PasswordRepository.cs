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
    public class PasswordRepository
    {
        IUnitOfWork unitOfWork;
        public PasswordRepository(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public int AddPassword(Password password)
        {

            string sql = $@"INSERT INTO [dbo].[Password]
                                       ([id]
                                       ,[password]
                                       ,[passwordStatus]
                                       ,[user_id])
                                 VALUES
                                       (@id
                                       ,@password
                                       ,@passwordStatus
                                       ,{password.user.id})
";

            return unitOfWork.Connection.Execute(sql, password,unitOfWork.Transaction);
        }
    }
}
