namespace Ecs
{
    public interface  ISystems : IInitializeSystem, IUpdateSystem, ILateUpdateSystem, IDestroySystem
    {
        void Add<TSystem>(TSystem system) where TSystem : ISystem;
    }
}