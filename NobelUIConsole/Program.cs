// See https://aka.ms/new-console-template for more information
using Refit;
using UILibrary.DataAccess;


Console.WriteLine("Hello, World!");
Console.ReadLine();
var nobelData = RestService.For<INobelData>("https://localhost:7117");
var nobelList = await nobelData.GetAll();

nobelList.ForEach(x => Console.WriteLine(x.Name));


Console.ReadLine();