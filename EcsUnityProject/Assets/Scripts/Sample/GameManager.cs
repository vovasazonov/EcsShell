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
        }
        
        public void Update()
        {
            _systems.Update();
            _systems.LateUpdate();
        }

        public void OnDestroy()
        {
            _systems.Destroy();
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