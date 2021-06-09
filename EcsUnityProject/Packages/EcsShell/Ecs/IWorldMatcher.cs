namespace Ecs
{
    public interface IWorldMatcher
    {
        IMatcher Has<TComponent>() where TComponent : struct;
    }
}