using UnityEngine;
using Zenject;
using DG.Tweening;
using Core.InputHandling;

namespace Gameplay.Player 
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private PlayerData playerData;
        [Space]
        [SerializeField] private Transform playerBase;
        [SerializeField] private Transform player;

        private IInputHandler inputHandler;

        private Tween sideStep;
        private Tween jump; 

        [Inject]
        public void Construct(IInputHandler inputHandler) 
        {
            this.inputHandler = inputHandler;
        }
        private void OnEnable()
        {
            inputHandler.OnLeftClick += TryToGoLeft;
            inputHandler.OnRightClick += TryToGoRight;
            inputHandler.OnJumpClick += TryToJump;
        }
        private void OnDisable()
        {
            inputHandler.OnLeftClick -= TryToGoLeft;
            inputHandler.OnRightClick -= TryToGoRight;
            inputHandler.OnJumpClick -= TryToJump;
        }

        private void TryToGoLeft() 
        {
            if (!sideStep?.IsActive() ?? false) sideStep = null;
            if (sideStep != null || player.position.x <= -playerData.SlideLength) return;
            sideStep = player.DOLocalMoveX(player.position.x - playerData.SlideLength, playerData.SlideDuration).SetEase(playerData.SlideEase);
        }
        private void TryToGoRight() 
        {
            if (!sideStep?.IsActive() ?? false) sideStep = null;
            if (sideStep != null || player.position.x >= playerData.SlideLength) return;
            sideStep = player.DOLocalMoveX(player.position.x + playerData.SlideLength, playerData.SlideDuration).SetEase(playerData.SlideEase);
        }
        private void TryToJump() 
        {
            if (!jump?.IsActive() ?? false) jump = null;
            if (jump != null) return;
            jump = playerBase.DOLocalJump(Vector3.zero, playerData.JumpFore, 1, playerData.JumpDuration).SetEase(playerData.JumpEase);
        }
    }
}
