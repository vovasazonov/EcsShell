namespace Ecs.EntitasExtension
{
    public interface IComponentsInfo
    {
        bool ContainsIndex<T>() where T : struct;
        int GetIndex<T>() where T : struct;
        int Total { get; }
        string[] Names { get; }
        System.Type[] Types { get; }
    }
}