using Dapper;
using Microsoft.Data.SqlClient;
using Model;
using ServiceLayer.Interface;
using System.Data;

namespace ServiceLayer.Services
{
    public class UserService : ConnectionManager, IUserService
    {
        public UserService(string dbConnection) : base(dbConnection)
        {

        }


        #region User
        public UserDetails AuthenticateUser(string email, string password)
        {
            UserDetails userDetailsModel = new UserDetails();
            var parameter = new DynamicParameters();
            parameter.Add("@Email", email, DbType.String, ParameterDirection.Input);
            parameter.Add("@Password", password, DbType.String, ParameterDirection.Input);

            string storedProcName = "dbo.AuthenticateUser";
            try
            {
                if (!string.IsNullOrEmpty(storedProcName))
                {
                    using (SqlConnection connection = GetSqlConnection())
                    {
                        connection.Open();
                        var obj = connection.Query(storedProcName,
                                 parameter,
                                 commandType: CommandType.StoredProcedure).FirstOrDefault();
                        if (obj != null)
                            userDetailsModel = new UserDetails
                            {
                                UserId = obj.UserId,
                                FirstName = obj.FirstName,
                                LastName = obj.LastName,
                                Email = obj.Email,
                                Phone = obj.Phone,
                                UserType = obj.UserType,
                                IsActive = obj.IsActive,
                                CreatedOn = obj.CreatedOn,
                                ModifiedOn = obj.ModifiedOn
                            };
                    }
                }
            }
            catch (Exception ex)
            {
                //Handle your Exceptiom
            }
            return userDetailsModel;
        }
        public UserDetails AddUserDetails(UserDetails user)
        {
            var parameter = new DynamicParameters();
            string storedProcName = "dbo.AddUser";
            parameter.Add("@UserId", user.UserId, DbType.Int32, ParameterDirection.Input);
            parameter.Add("@FirstName", user.FirstName, DbType.String, ParameterDirection.Input);
            parameter.Add("@LastName", user.LastName, DbType.String, ParameterDirection.Input);
            parameter.Add("@Email", user.Email, DbType.String, ParameterDirection.Input);
            parameter.Add("@Phone", user.Phone, DbType.String, ParameterDirection.Input);
            parameter.Add("@Password", user.Password, DbType.String, ParameterDirection.Input);
            parameter.Add("@UserType", user.UserType, DbType.Int32, ParameterDirection.Input);
            parameter.Add("@retVal", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
            try
            {
                if (!string.IsNullOrEmpty(storedProcName))
                {
                    using (SqlConnection connection = GetSqlConnection())
                    {
                        connection.Open();
                        var obj = connection.ExecuteScalar(storedProcName,
                                 parameter,
                                 commandType: CommandType.StoredProcedure);
                        int id = parameter.Get<Int32>("@retVal");
                        user.UserId = id;
                    }
                }
            }
            catch (Exception ex)
            {
                //Handle your Exceptiom
            }
            return user;
        }
        public UserDetails EditUserDetails(UserDetails user)
        {
            var parameter = new DynamicParameters();
            string storedProcName = "dbo.UpdateUser";
            parameter.Add("@UserId", user.UserId, DbType.Int32, ParameterDirection.Input);
            parameter.Add("@FirstName", user.FirstName, DbType.String, ParameterDirection.Input);
            parameter.Add("@LastName", user.LastName, DbType.String, ParameterDirection.Input);
            parameter.Add("@Phone", user.Phone, DbType.String, ParameterDirection.Input);
            parameter.Add("@UserType", user.UserType, DbType.Int32, ParameterDirection.Input);
            try
            {
                if (!string.IsNullOrEmpty(storedProcName))
                {
                    using (SqlConnection connection = GetSqlConnection())
                    {
                        connection.Open();
                        var obj = connection.ExecuteScalar(storedProcName,
                                 parameter,
                                 commandType: CommandType.StoredProcedure);
                    }
                }
            }
            catch (Exception ex)
            {
                //Handle your Exceptiom
            }
            return user;
        }
        public List<UserDetails> GetUserDetailList()
        {
            List<UserDetails> userDetailsModelList = new List<UserDetails>();
            var parameter = new DynamicParameters();
            string storedProcName = "dbo.GetAllUsers";
            try
            {
                if (!string.IsNullOrEmpty(storedProcName))
                {
                    using (SqlConnection connection = GetSqlConnection())
                    {
                        connection.Open();
                        var obj = connection.Query(storedProcName,
                                 parameter,
                                 commandType: CommandType.StoredProcedure)
                            .Select(u => new UserDetails
                            {
                                UserId = u.UserId,
                                FirstName = u.FirstName,
                                LastName = u.LastName,
                                Email = u.Email,
                                Phone = u.Phone,
                                UserType = u.UserType,
                                IsActive = u.IsActive,
                                CreatedOn = u.CreatedOn,
                                ModifiedOn = u.ModifiedOn
                            }).ToList();
                    }
                }
            }
            catch (Exception ex)
            {
                //Handle your Exceptiom
            }
            return userDetailsModelList;
        }
        public UserDetails GetUserDetailsById(long userId)
        {
            UserDetails userDetailsModel = new UserDetails();
            var parameter = new DynamicParameters();
            string storedProcName = "dbo.GetAllUsers";
            try
            {
                if (!string.IsNullOrEmpty(storedProcName))
                {
                    using (SqlConnection connection = GetSqlConnection())
                    {
                        connection.Open();
                        var obj = connection.Query(storedProcName,
                                 parameter,
                                 commandType: CommandType.StoredProcedure).FirstOrDefault();
                        if(obj != null)
                            userDetailsModel= new UserDetails
                            {
                                UserId = obj.UserId,
                                FirstName = obj.FirstName,
                                LastName = obj.LastName,
                                Email = obj.Email,
                                Phone = obj.Phone,
                                UserType = obj.UserType,
                                IsActive = obj.IsActive,
                                CreatedOn = obj.CreatedOn,
                                ModifiedOn = obj.ModifiedOn
                            };
                    }
                }
            }
            catch (Exception ex)
            {
                //Handle your Exceptiom
            }
            return userDetailsModel;
        }

        #endregion



    }
}
