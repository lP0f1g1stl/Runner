using System;
using UnityEngine;

namespace Core.InputHandling
{
    public class InputHandlerKeboard : IInputHandler
    {
        public event Action OnEscBtnClick;

        public event Action OnLeftClick;
        public event Action OnRightClick;
        public event Action OnJumpClick;

        public void CheckInputLoop()
        {
            if (Input.GetKeyDown(KeyCode.Escape)) Debug.Log("Exit");

            if (Input.GetKeyDown(KeyCode.Escape)) OnEscBtnClick?.Invoke();
            if (Input.GetKeyDown(KeyCode.A)) OnLeftClick?.Invoke();
            if (Input.GetKeyDown(KeyCode.D)) OnRightClick?.Invoke();
            if (Input.GetKeyDown(KeyCode.Space)) OnJumpClick?.Invoke();
        }
    }
}
