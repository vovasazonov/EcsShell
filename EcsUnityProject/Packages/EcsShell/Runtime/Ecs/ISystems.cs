namespace Ecs
{
    public interface ISystems : IInitializeSystem, IUpdateSystem, ILateUpdateSystem, IDestroySystem
    {
        void Add<T>(T system) where T : ISystem;
    }
}