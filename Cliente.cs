using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace CadCliente
{
    public class Cliente
    {
        public int ID_Cliente { get; private set; }
        public string Nome { get; private set; }
        public string Endereco { get; private set; }
        public string Telefone { get; private set; }
        public string RG { get; private set; }
        public string CPF { get; private set; }
        public string Email { get; private set; }
        
        public Cliente(string nome, string endereco, string telefone, string rg, string cpf, string email)
        {
            Nome = nome;
            Endereco = endereco;
            Telefone = telefone;
            RG = rg;
            CPF = cpf;
            Email = email;
        }
        public void SetId(int id)
        {
            ID_Cliente = id;
        }
        public void UpdateDetails(string nome, string endereco, string telefone, string rg, string cpf, string email)
        {
            Nome = nome;
            Endereco = endereco;
            Telefone = telefone;
            RG = rg;
            CPF = cpf;
            Email = email;
        }
        public void AddCliente()
        {
            using (var connection = BancodeDados.GetConnection())
            {
                connection.Open();
                string query = "INSERT INTO Cliente (Nome, Endereco, Telefone, RG, CPF, Email) VALUES (@Nome, @Endereco, @telefone, @RG, @CPF, @Email)";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@Nome", Nome);
                cmd.Parameters.AddWithValue("@Endereco", Endereco);
                cmd.Parameters.AddWithValue("@Telefone", Telefone);
                cmd.Parameters.AddWithValue("@RG", RG);
                cmd.Parameters.AddWithValue("@CPF", CPF);
                cmd.Parameters.AddWithValue("@Email", Email);
                cmd.ExecuteNonQuery();
                SetId((int)cmd.LastInsertedId);
            }
        }
        public static List<Cliente> GetClientes()
        {
            List<Cliente> clientes = new List<Cliente>();
            using (var connection = BancodeDados.GetConnection())
            {
                connection.Open();
                string query = "SELECT * FROM Cliente";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var cliente = new Cliente(
                        reader.GetString("Nome"),
                        reader.GetString("Endereco"),
                        reader.GetString("Telefone"),
                        reader.GetString("RG"),
                        reader.GetString("CPF"),
                        reader.GetString("Email")
                    );
                    cliente.SetId(reader.GetInt32("ID_Cliente"));
                    clientes.Add(cliente);
                }
            }
            return clientes;
        }
        public static void UpdateCliente()
        {
            using (var connection = BancodeDados.GetConnection())
            {
                connection.Open();
                string query = "UPDATE Cliente SET Nome = @Nome, Endereco = @Endereco, Telefone = @Telefone, RG = @RG, CPF = @CPF, Email = @Email WHERE ID_Cliente = @ID_Cliente";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@Nome", Nome);
                cmd.Parameters.AddWithValue("@Endereco", Endereco);
                cmd.Parameters.AddWithValue("@Telefone", Telefone);
                cmd.Parameters.AddWithValue("@RG", RG);
                cmd.Parameters.AddWithValue("@CPF", CPF);
                cmd.Parameters.AddWithValue("@Email", Email);
                cmd.Parameters.AddWithValue("@ID_Cliente", ID_Cliente);
                cmd.ExecuteNonQuery();
            }
        }
        public static void DeleteCliente(int id)
        {
            using (var connection = BancodeDados.GetConnection())
            {
                connection.Open();
                String query = "DELETE FROM Cliente WHERE ID_Cliente = @ID_Cliente";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@ID_Cliente", id);
                cmd.ExecuteNonQuery();
            }
        }
    }
}

