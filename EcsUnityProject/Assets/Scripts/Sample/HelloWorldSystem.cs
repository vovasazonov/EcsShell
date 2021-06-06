using Ecs;
using UnityEngine;

namespace Sample
{
    public sealed class HelloWorldSystem : IInitializeSystem, IUpdateSystem
    {
        private readonly IWorld _world;
        private readonly IFilter _textFilter;

        public HelloWorldSystem(IWorld world)
        {
            _world = world;
            _textFilter = world.GetFilter(match => match.Has<TextComponent>().Has<TestComponent1>().None<TestComponent2>());
        }

        public void Initialize()
        {
            _world.CreateEntity().ReplaceComponent(new TextComponent {Value = "HelloWorld"});
            _world.CreateEntity().ReplaceComponent(new TestComponent1());
        }

        public void Update()
        {
            foreach (var entity in _textFilter)
            {
                Debug.Log(entity.GetComponent<TextComponent>().Value);
            }
        }
    }
}