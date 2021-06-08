namespace Ecs.EntitasExtension
{
    public interface IComponentsInfo
    {
        int GetIndex<T>() where T : struct;
        int Total { get; }
        string[] Names { get; }
        System.Type[] Types { get; }
    }
}