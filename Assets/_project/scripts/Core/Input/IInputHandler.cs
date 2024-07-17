using System;

namespace Core.InputHandling
{
    public interface IInputHandler
    {
        public event Action OnEscBtnClick;

        public event Action OnLeftClick;
        public event Action OnRightClick;
        public event Action OnJumpClick;

        public void CheckInputLoop();
    }
}
