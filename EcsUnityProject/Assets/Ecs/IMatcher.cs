namespace Ecs
{
    public interface IMatcher
    {
        IMatcher Has<T>() where T : struct;
        IMatcher None<T>() where T : struct;
    }
}