using EntityFramework.Data;
using EntityFramework.Models;
using Microsoft.EntityFrameworkCore;

class Program
{
    static void Main(string[] args)
    {
        // Configurar manualmente as opções do DbContext
        var optionsBuilder = new DbContextOptionsBuilder<DataContext>();
        optionsBuilder.UseSqlite("Data Source=C:\\Users\\gustavo.tanaka\\source\\repos\\EntityFramework\\people.db");

        // Instanciar o DbContext com as opções configuradas
        using var context = new DataContext(optionsBuilder.Options);

        // Solicitar entrada do usuário
        Console.Write("Digite o nome da pessoa: ");
        string name = Console.ReadLine();
        while (String.IsNullOrEmpty(name))
        {
            Console.Write("Nome inválido. Digite novamente: "); 
            name = Console.ReadLine();
        }

        Console.Write("Digite a idade da pessoa: ");
        int age;
        while (!int.TryParse(Console.ReadLine(), out age))
        {
            Console.Write("Idade inválido. Digite novamente: ");
        }

        // Adicionar dados no banco
        context.People.Add(new PersonModel { Name = name, Age = age });
        context.SaveChanges();

        // Listar dados no banco
        var produtos = context.People.ToList();
        foreach (var produto in produtos)
        {
            Console.WriteLine($"{produto.Id}: {produto.Name} - {produto.Age} anos");
        }
    }
}