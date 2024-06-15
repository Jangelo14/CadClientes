using MySql.Data.MySqlClient;

public class BancodeDados
{
    private static string connectionString = "Server=localhost; Database=dbclientes;Uid=root;Pwd=;";
    public static MySqlConnection GetConnection()
    {
        return new MySqlConnection(connectionString);
    }
}