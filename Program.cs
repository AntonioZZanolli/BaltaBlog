using Blog.Models;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

class Program
{
    static void Main(string[] args)
    {
        //ReadUsers();
        // ReadUser();
        // CreateUser();
        // UpdateUser();
        DeleteUser();
    }
    private const string CONNECTION_STRING = @"Server=localhost,1433;Database=Blog;User ID=sa;Password=1q2w3e4r@#$;TrustServerCertificate=True";
    public static void ReadUsers()
    {
        using (var connection = new SqlConnection(CONNECTION_STRING))
        {
            var users = connection.GetAll<User>();

            foreach (var user in users)
            {
                Console.WriteLine(user.Name);
            }
        }
    }

    public static void ReadUser()
    {
        using (var connection = new SqlConnection(CONNECTION_STRING))
        {
            var user = connection.Get<User>(1);

            Console.WriteLine(user.Name);
        }
    }

    public static void CreateUser()
    {
        var user = new User()
        {
            Bio = "Equipe Balta.io",
            Email = "hello@gmail.com",
            Image = "https://....",
            Name = "Equipe Balta.io",
            PasswordHash = "HASH",
            Slug = "equipe-balta"
        };
        using (var connection = new SqlConnection(CONNECTION_STRING))
        {
            connection.Insert<User>(user);

            Console.WriteLine("Cadastro realizado com sucesso");
        }
    }

    public static void UpdateUser()
    {
        var user = new User()
        {
            Id = 2,
            Bio = "Equipe | Balta.io",
            Email = "suporte@balta.com",
            Image = "https://....",
            Name = "Equipe Balta.io",
            PasswordHash = "HASH",
            Slug = "equipe-balta"
        };
        using (var connection = new SqlConnection(CONNECTION_STRING))
        {
            connection.Update<User>(user);

            Console.WriteLine("Atualização realizada com sucesso");
        }
    }

    public static void DeleteUser()
    {
        using (var connection = new SqlConnection(CONNECTION_STRING))
        {
            var user = connection.Get<User>(2);
            connection.Delete<User>(user);
            Console.WriteLine("Exclusão realizada com sucesso");
        }
    }
}