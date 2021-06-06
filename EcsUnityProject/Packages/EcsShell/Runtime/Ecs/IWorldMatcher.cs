namespace Ecs
{
    public interface IWorldMatcher
    {
        IMatcher Has<T>() where T : struct;
    }
}