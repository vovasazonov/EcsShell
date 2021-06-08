namespace Ecs
{
    public interface IComponentListener<TComponent> where TComponent : struct
    {
        void OnChanged(IEntity entity, TComponent component);
    }
}