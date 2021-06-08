namespace Ecs
{
    public interface ILateUpdateSystem : ISystem
    {
        void LateUpdate();
    }
}