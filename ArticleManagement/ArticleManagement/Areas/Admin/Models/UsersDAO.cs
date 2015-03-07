using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Data.SqlClient;

namespace ArticleManagement.Areas.Admin.Models
{
    public class UsersDAO
    {
        private static String cs = "Data Source=LOCALHOST; Initial Catalog=AssigmentDB; Integrated Security=True; Pooling=False";
        public List<UsersModel> ListAllUsers(String username = "")
        {
            try
            {
                List<UsersModel> list = new List<UsersModel>();
                String sql = @"SELECT * FROM [dbo].[Users] WHERE username LIKE '%" + username + "%'";
                DataSet ds = new DataSet();
                ds = DB.Query(sql);
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    UsersModel user = new UsersModel();
                    user.Id = (int)ds.Tables[0].Rows[i]["Id"];
                    user.Username = ds.Tables[0].Rows[i]["Username"].ToString();
                    user.Password = ds.Tables[0].Rows[i]["Password"].ToString();
                    user.FirstName = ds.Tables[0].Rows[i]["Firstname"].ToString();
                    user.LastName = ds.Tables[0].Rows[i]["Lastname"].ToString();
                    user.Email = ds.Tables[0].Rows[i]["Email"].ToString();
                    user.Address = ds.Tables[0].Rows[i]["Address"].ToString();
                    list.Add(user);
                }
                return list;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }

        public bool DeleteUser(int id)
        {
            try
            {
                String sql = @"DELETE FROM Users WHERE ID=@p1";
                return DB.Action(sql, id);
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
            return false;
        }

        public bool UpdateUser(UpdateUserModel user)
        {
            try
            {
                String sql = @"UPDATE Users SET Username=@p1, Firstname=@p2, Lastname=@p3,
                               Email=@p4, Address=@p5 WHERE ID=@p6";
                return DB.Action(sql, user.Username,user.FirstName,user.Lastname,user.Email,user.Address,user.Id);
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
            return false;
        }

        public bool CreateUser(CreateUserModel user)
        {
            try
            {
                String sql = @"INSERT INTO Users(Username,Password,Firstname, Lastname,Email,Address) 
                               VALUES(@p1,@p2,@p3,@p4,@p5,@p6)";
                return DB.Action(sql, user.Username, user.Password, user.FirstName, user.Lastname, user.Email, user.Address);
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                return false;
            }
            
        }
        public UsersModel SignIn(SignInModel user)
        {
            try
            {
                String sql = @"SELECT * FROM Users WHERE username=@username AND password=@password";
                using (SqlConnection con = new SqlConnection(cs))
                {
                    using (SqlCommand command = new SqlCommand())
                    {
                        con.Open();
                        command.CommandText = sql;
                        command.Connection = con;

                        command.Parameters.AddWithValue("@username", user.Username);
                        command.Parameters.AddWithValue("@password", user.Password);
                        SqlDataReader dr = command.ExecuteReader();
                        UsersModel userLogin = new UsersModel();
                        while (dr.Read())
                        {
                            userLogin.Id = (int)dr["Id"];
                            userLogin.Username = dr["Username"].ToString();
                            userLogin.FirstName = dr["Firstname"].ToString();
                            userLogin.LastName = dr["Lastname"].ToString();
                            userLogin.Email = dr["Email"].ToString();
                            userLogin.Address = dr["Address"].ToString();
                        }
                        return userLogin;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                return null;
            }
        }

        public bool SignOut()
        {
            return false;
        }

        public bool ChangePassword(ChangePasswordModel user)
        {
            try
            {
                String sql = @"UPDATE Users SET password=@p1 WHERE ID=@p2";
                return DB.Action(sql, user.NewPassword, user.Id);
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                return false;
            }
        }

        public UsersModel GetDetailsUser(int id)
        {
            try
            {
                UsersModel user = new UsersModel();

                String sql = @"SELECT * FROM users WHERE id="+id;
                using (SqlConnection con = new SqlConnection(cs))
                {
                    using (SqlCommand command = new SqlCommand())
                    {
                        con.Open();
                        command.CommandText = sql;
                        command.Connection = con;
                        SqlDataReader dr = command.ExecuteReader();
                        while (dr.Read())
                        {
                            user.Id = id;
                            user.FirstName = dr["Firstname"].ToString();
                            user.LastName = dr["Lastname"].ToString();
                            //user.Photo = dr["Photo"].ToString();
                            user.Username = dr["Username"].ToString();
                            user.Email = dr["Email"].ToString();
                            user.Address = dr["Address"].ToString();
                        }
                        return user;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                return null;
            }
        }
    }
}