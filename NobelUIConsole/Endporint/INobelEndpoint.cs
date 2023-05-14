namespace NobelUIConsole.Endporint;

public interface INobelEndpoint
{
    Task Create();
    Task Delete();
    Task Read();
    Task Update();
}