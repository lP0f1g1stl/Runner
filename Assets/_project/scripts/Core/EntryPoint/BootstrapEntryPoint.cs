using UnityEngine;
using Core.StateMachine;
using Core.StateMachine.States;
using Core.Loading;
using Zenject;

namespace Core.EntryPoint
{
    public class BootstrapEntryPoint : MonoBehaviour
    {
        private StateMachineBase stateMachine;

        private SceneLoadingManager sceneLoadingManager;


        [Inject]
        public void Construct(SceneLoadingManager sceneLoadingManager) 
        {
            this.sceneLoadingManager = sceneLoadingManager;
        }
        private void Awake()
        {
            stateMachine = new StateMachineBase(sceneLoadingManager);
            DontDestroyOnLoad(gameObject);
        }
        private void Start()
        {
            stateMachine.EnterIn<LoadingState>();
        }

        private void Update()
        {
            stateMachine.TickIn();
        }

    }
}
