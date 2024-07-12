using UnityEngine;
using Core.StateMachine;

namespace Core.EntryPoint
{
    public class BootstrapEntryPoint : MonoBehaviour
    {
        private StateMachineBase stateMachine;

        private void Awake()
        {
            stateMachine = new StateMachineBase();
        }

    }
}
