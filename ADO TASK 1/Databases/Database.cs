using ADO_TASK_1.Models;
using Microsoft.SqlServer.Server;
using System.Data.SqlClient;
using System.Windows.Documents;

namespace ADO_TASK_1.Databases;

public static class Database
{
    public static List<User> users { get; set; } = new();
    static SqlConnection connection = null;
    static SqlCommand cmd = null;
    static SqlDataReader reader = null;
    static string connectionString = @"Server=(localdb)\MSSQLLocalDB;Database=DBUsers;Integrated Security=SSPI;";

    public static void WriteUsersToDatabase()
    {

        using (connection = new(connectionString))
        {
            connection.Open();
            foreach (var user in users)
            {
                cmd = new(@$"INSERT INTO Users(Name,Surname,Age,Login,Password)
                               VALUES('{user.Name}','{user.Surname}','{user.Age}','{user.Login}','{user.Password}')", connection);
                cmd.ExecuteNonQuery();
            }
        }
    }
    public static void ReadUsersToDatabase()
    {
        using (connection = new(connectionString))
        {
            connection.Open();
            cmd = new("SELECT * FROM Users", connection);
            reader = cmd.ExecuteReader();
            if (reader == null) return;

            while (reader.Read())
            {
                User user = new User();
                user.Name = reader["Name"].ToString();
                user.Surname = reader["Surname"].ToString();
                user.Age = int.Parse(reader["Age"].ToString());
                user.Login = reader["Login"].ToString();
                user.Password = reader["Password"].ToString();


                users.Add(user);
            }


        }
    }

    public static bool CheckLoginPwInUsers(string log, string psw)
    {
        foreach (var user in users)
        {
            if (log == user.Login && psw == user.Password) return true;
        }
        return false;
    }
}
