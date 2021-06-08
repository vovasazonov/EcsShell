namespace Ecs
{
    public interface IEntityListener
    {
        void Register(IEntity entity);
        void Unregister(IEntity entity);
    }
}