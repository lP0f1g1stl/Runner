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
        private StateMachineBase _stateMachine;

        private SceneLoadingManager _sceneLoadingManager;
        private IInputHandler _inputHandler;


        [Inject]
        public void Construct(SceneLoadingManager sceneLoadingManager, IInputHandler inputHandler) 
        {
            _sceneLoadingManager = sceneLoadingManager;
            _inputHandler = inputHandler;
        }
        private void Awake()
        {
            _stateMachine = new StateMachineBase(_sceneLoadingManager, _inputHandler);
            DontDestroyOnLoad(gameObject);
        }
        private void Start()
        {
            _stateMachine.EnterIn<LoadingState>();
        }

        private void Update()
        {
            _stateMachine.TickIn();
        }
    }
}
