using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System.Reflection;
using TaskMonopoly.Application;
using TaskMonopoly.Application.Common.Interfaces;
using TaskMonopoly.Application.Common.Mapping;
using TaskMonopoly.Application.Pallets.Commands.CreatePallets;
using TaskMonopoly.Application.Pallets.Queries.GetPalletList;
using TaskMonopoly.Application.Pallets.Queries.GetPalletsWithLongestExpirationDate;
using TaskMonopoly.Application.Pallets.Queries.GetSortedPalletsGroupedByExpirationDate;
using TaskMonopoly.Application.Pallets.Queries.ViewModels;
using TaskMonopoly.Persistence;

try
{
    IServiceCollection services = new ServiceCollection();
    ConfigureServices(services);
    var serviceProvider = services.BuildServiceProvider();

    var json = await File.ReadAllTextAsync("PalletsSample.json");
    var palletService = serviceProvider.GetRequiredService<IPalletService>();
    var mediator = serviceProvider.GetRequiredService<IMediator>();

    await PutPalletsAsync(json, mediator, palletService);

    var result_1 = await GetSortedPalletsGroupedByExpirationDateAsync(mediator);
    var result_2 = await GetPalletsWithLongestExpirationDateAsync(mediator);

    var writeResult_1Task = File.WriteAllTextAsync("Result1.json", JsonConvert.SerializeObject(result_1));
    var writeResult_2Task = File.WriteAllTextAsync("Result2.json", JsonConvert.SerializeObject(result_2));

    ShowResult_1InConsole(result_1);
    Console.WriteLine();
    Console.WriteLine(new string('-', Console.WindowWidth));
    Console.WriteLine();
    ShowResult_2InConsole(result_2);

    Task.WaitAll(writeResult_1Task, writeResult_2Task);

}
catch (Exception ex)
{
    Console.WriteLine($"Произошло исключение - {ex.Message}");
}

Console.WriteLine();
Console.WriteLine("Press any key to close this window . . .");
Console.ReadKey();


static void ShowResult_1InConsole(GroupListVm result)
{
    Console.WriteLine("- Сгруппировать все паллеты по сроку годности, отсортировать по возрастанию срока годности, в каждой группе отсортировать паллеты по весу.");
    Console.WriteLine();

    foreach (var group in result.Groups)
    {
        Console.WriteLine($"Группа - {group.ExpirationDate}");
        Console.WriteLine("Паллеты в группе:");
        foreach (var palletVm in group.Pallets)
        {
            Console.WriteLine($"Id - {palletVm.Id}      Вес - {palletVm.Weight}");
        }

        Console.WriteLine();
    }
}

static void ShowResult_2InConsole(IEnumerable<PalletVm> result)
{
    Console.WriteLine("- 3 паллеты, которые содержат коробки с наибольшим сроком годности, отсортированные по возрастанию объема.");
    Console.WriteLine();

    foreach (var palletVm in result)
    {
        Console.WriteLine($"Паллета - {palletVm.Id}");
        Console.WriteLine("Коробки в паллете:");
        foreach (var boxVm in palletVm.Boxes)
        {
            Console.WriteLine($"Id - {boxVm.Id}      Срок годности - {boxVm.ExpirationDate}      Объем - {boxVm.Volume}");
        }

        Console.WriteLine();
    }
}

static async Task<IEnumerable<PalletVm>> GetPalletsWithLongestExpirationDateAsync(IMediator mediator)
{
    var query = new GetPalletsWithLongestExpirationDateQuery();
    return await mediator.Send(query);
}

static async Task<GroupListVm> GetSortedPalletsGroupedByExpirationDateAsync(IMediator mediator)
{
    var query = new GetSortedPalletsGroupedByExpirationDateQuery();
    return await mediator.Send(query);
}

static async Task<IEnumerable<Guid>> PutPalletsAsync(string json, IMediator mediator, IPalletService palletService)
{
    var pallets = palletService.ParsePallets(json);
    var command = new CreatePalletsCommand()
    {
        Json = pallets
    };
    return await mediator.Send(command);
}

static void ConfigureServices(IServiceCollection services)
{
    services.AddAutoMapper(config =>
    {
        config.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
        config.AddProfile(new AssemblyMappingProfile(typeof(IApplicationDbContext).Assembly)); //Добавление профилей маппинга из TaskMonopoly.Application
    });

    services.AddApplication();
    services.AddPersistence();
}