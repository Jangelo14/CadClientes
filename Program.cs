using System;
using System.Collections.Generic;

namespace CadCliente
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Escolha uma opção:");
                Console.WriteLine("1. Adicionar Cliente");
                Console.WriteLine("2. Listar Clientes");
                Console.WriteLine("3. Atualizar Cliente");
                Console.WriteLine("4. Deletar Cliente");
                Console.WriteLine("5. Sair");
                Console.Write("Opção: ");
                var opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        AdicionarCliente();
                        break;
                    case "2":
                        ListarClientes();
                        break;
                    case "3":
                        AtualizarCliente();
                        break;
                    case "4":
                        DeletarCliente();
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }
            }
        }

        static void AdicionarCliente()
        {
            Console.Write("Nome: ");
            string nome = Console.ReadLine();
            Console.Write("Endereço: ");
            string endereco = Console.ReadLine();
            Console.Write("Telefone: ");
            string telefone = Console.ReadLine();
            Console.Write("RG: ");
            string rg = Console.ReadLine();
            Console.Write("CPF: ");
            string cpf = Console.ReadLine();
            Console.Write("Email: ");
            string email = Console.ReadLine();

            var cliente = new Cliente(nome, endereco, telefone, rg, cpf, email);
            cliente.AddCliente();
            Console.WriteLine("Cliente adicionado com sucesso!");
        }

        static void ListarClientes()
        {
            List<Cliente> clientes = Cliente.GetClientes();
            foreach (var c in clientes)
            {
                Console.WriteLine($"ID: {c.ID_Cliente}, Nome: {c.Nome}, Endereço: {c.Endereco}, Telefone: {c.Telefone}, RG: {c.RG}, CPF: {c.CPF}, Email: {c.Email}");
            }
        }

        static void AtualizarCliente()
        {
            Console.Write("ID do Cliente a ser atualizado: ");
            int id = int.Parse(Console.ReadLine());

            var cliente = Cliente.GetClientes().Find(c => c.ID_Cliente == id);
            if (cliente == null)
            {
                Console.WriteLine("Cliente não encontrado.");
                return;
            }

            Console.Write("Novo Nome (deixe vazio para manter o atual): ");
            string nome = Console.ReadLine();
            if (!string.IsNullOrEmpty(nome)) cliente.UpdateDetails(nome, cliente.Endereco, cliente.Telefone, cliente.RG, cliente.CPF, cliente.Email);

            Console.Write("Novo Endereço (deixe vazio para manter o atual): ");
            string endereco = Console.ReadLine();
            if (!string.IsNullOrEmpty(endereco)) cliente.UpdateDetails(cliente.Nome, endereco, cliente.Telefone, cliente.RG, cliente.CPF, cliente.Email);

            Console.Write("Novo Telefone (deixe vazio para manter o atual): ");
            string telefone = Console.ReadLine();
            if (!string.IsNullOrEmpty(telefone)) cliente.UpdateDetails(cliente.Nome, cliente.Endereco, telefone, cliente.RG, cliente.CPF, cliente.Email);

            Console.Write("Novo RG (deixe vazio para manter o atual): ");
            string rg = Console.ReadLine();
            if (!string.IsNullOrEmpty(rg)) cliente.UpdateDetails(cliente.Nome, cliente.Endereco, cliente.Telefone, rg, cliente.CPF, cliente.Email);

            Console.Write("Novo CPF (deixe vazio para manter o atual): ");
            string cpf = Console.ReadLine();
            if (!string.IsNullOrEmpty(cpf)) cliente.UpdateDetails(cliente.Nome, cliente.Endereco, cliente.Telefone, cliente.RG, cpf, cliente.Email);

            Console.Write("Novo Email (deixe vazio para manter o atual): ");
            string email = Console.ReadLine();
            if (!string.IsNullOrEmpty(email)) cliente.UpdateDetails(cliente.Nome, cliente.Endereco, cliente.Telefone, cliente.RG, cliente.CPF, email);

            Cliente.UpdateCliente();
            Console.WriteLine("Cliente atualizado com sucesso!");
        }

        static void DeletarCliente()
        {
            Console.Write("ID do Cliente a ser deletado: ");
            int id = int.Parse(Console.ReadLine());

            Cliente.DeleteCliente(id);
            Console.WriteLine("Cliente deletado com sucesso!");
        }
    }
}