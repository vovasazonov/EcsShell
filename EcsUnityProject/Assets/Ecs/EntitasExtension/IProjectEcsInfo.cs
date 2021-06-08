namespace Ecs.EntitasExtension
{
    public interface IProjectEcsInfo
    {
        void InitEventSystems(IWorld world, ISystems systems);
        IComponentsInfo ComponentsInfo { get; }
    }
}