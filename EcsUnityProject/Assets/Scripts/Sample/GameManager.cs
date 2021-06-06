using System;
using System.Diagnostics;
using Ecs.EntitasExtension;
using UnityEngine;
using Debug = UnityEngine.Debug;

namespace Sample
{
    public class GameManager : MonoBehaviour
    {
        private Systems _systems;
        private World _world;

        void Start()
        {
            Application.targetFrameRate = 20;

            var componentsInfo = new ComponentsInfo(new AllComponents());
            _world = new World(componentsInfo);
            _systems = new Systems();
            _systems.Add(new GameSystems(_systems, _world));
            _systems.Initialize();

            // var entitasSystem = new EntitasSystem<TestGameSystems>(new GameSystems(_systems, world));
            // var type = entitasSystem.GetType();
            // Type[] generic = type.GetGenericArguments();
            // Debug.Log($"Contains generic {generic[0].Name}");
        }
        
        // public SystemInfo(ISystem system)
        // {
        //     this._system = system;
        //     this._interfaceFlags = SystemInfo.getInterfaceFlags(system);
        //     DebugSystems debugSystems = system as DebugSystems;
        //     Type type = system.GetType();
        //     Type[] generic = type.GetGenericArguments();
        //     string name = (generic.Length > 0 ? generic[0].Name : type.Name);
        //     this._systemName = ((debugSystems != null) ? debugSystems.name : name.RemoveSystemSuffix());
        //     this.isActive = true;
        // }

        public void Update()
        {
            _systems.Update();
            _systems.LateUpdate();
        }

        public void OnDestroy()
        {
            _systems.Destroy();
        }

        private static void TestEqualsTypes()
        {
            var Helper = typeof(ComponentShell<>);
            var typeTest1 = typeof(TestComponent1);
            var typeTest1WithHelper = typeof(ComponentShell<TestComponent1>);
            var typeTest2 = typeof(TestComponent2);
            var typeTest2WithHelper = typeof(ComponentShell<TestComponent2>);
            Debug.Log($"helper == test1 {Helper == typeTest1}");
            Debug.Log($"helper == test1Helper {Helper == typeTest1WithHelper}");
            Debug.Log($"test1 == test1Helper {typeTest1 == typeTest1WithHelper}");
            Debug.Log($"test1 == test2 {typeTest1 == typeTest2}");
            Debug.Log($"test1 == test2Helper {typeTest1 == typeTest2WithHelper}");
            Debug.Log($"test1Helper == test2Helper {typeTest1WithHelper == typeTest2WithHelper}");
            Debug.Log("-------------");
            Debug.Log($"test1 == test1 {typeTest1 == typeTest1}");
            Debug.Log($"test1Helper == test1Helper {typeTest1WithHelper == typeTest1WithHelper}");
        }

        private static void TestComponentsInfo()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            AllComponents allComponents = new AllComponents();
            var componentsInfo = new ComponentsInfo(allComponents);
            stopwatch.Stop();
            Debug.Log($"time:{stopwatch.ElapsedMilliseconds}");
            Debug.Log(componentsInfo.Total);
            Debug.Log(componentsInfo.Names);
            Debug.Log(componentsInfo.Types);
        }
    }
}