namespace Ecs
{
    public interface IEntity
    {
        TComponent Get<TComponent>() where TComponent : struct;
        void Replace<TComponent>(TComponent component) where TComponent : struct;
        void Remove<TComponent>() where TComponent : struct;
        bool Contains<TComponent>() where TComponent : struct;
        void RegisterListener<TComponent>(IComponentListener<TComponent> listener) where TComponent : struct;
        void UnregisterListener<TComponent>(IComponentListener<TComponent> listener) where TComponent : struct;
        void Destroy();
    }
}