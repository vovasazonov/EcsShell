namespace Ecs
{
    public interface IMatcher
    {
        IMatcher Has<TComponent>() where TComponent : struct;
        IMatcher None<TComponent>() where TComponent : struct;
    }
}