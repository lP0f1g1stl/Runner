using UnityEngine;
using Core.StateMachine;
using Core.StateMachine.States;
using Core.Loading;
using Core.InputHandling;
using Zenject;

namespace Core.EntryPoint
{
    public class BootstrapEntryPoint : MonoBehaviour
    {
        private StateMachineBase stateMachine;

        private SceneLoadingManager sceneLoadingManager;
        private IInputHandler inputHandler;


        [Inject]
        public void Construct(SceneLoadingManager sceneLoadingManager, IInputHandler inputHandler) 
        {
            this.sceneLoadingManager = sceneLoadingManager;
            this.inputHandler = inputHandler;
        }
        private void Awake()
        {
            stateMachine = new StateMachineBase(sceneLoadingManager, inputHandler);
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
