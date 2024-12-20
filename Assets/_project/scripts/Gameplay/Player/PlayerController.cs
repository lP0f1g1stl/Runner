using UnityEngine;
using Zenject;
using DG.Tweening;
using Core.InputHandling;

namespace Gameplay.Player 
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private PlayerData _playerData;
        [Space]
        [SerializeField] private Transform _playerBase;
        [SerializeField] private Transform _player;

        private IInputHandler _inputHandler;

        private Tween _sideStep;
        private Tween _jump; 

        [Inject]
        public void Construct(IInputHandler inputHandler) 
        {
            _inputHandler = inputHandler;
        }
        private void OnEnable()
        {
            _inputHandler.OnLeftClick += TryToGoLeft;
            _inputHandler.OnRightClick += TryToGoRight;
            _inputHandler.OnJumpClick += TryToJump;
        }
        private void OnDisable()
        {
            _inputHandler.OnLeftClick -= TryToGoLeft;
            _inputHandler.OnRightClick -= TryToGoRight;
            _inputHandler.OnJumpClick -= TryToJump;
        }

        private void TryToGoLeft() 
        {
            if (!_sideStep?.IsActive() ?? false) _sideStep = null;
            if (_sideStep != null || _player.position.x <= -_playerData.SlideLength) return;
            _sideStep = _player.DOLocalMoveX(_player.position.x - _playerData.SlideLength, _playerData.SlideDuration).SetEase(_playerData.SlideEase);
        }
        private void TryToGoRight() 
        {
            if (!_sideStep?.IsActive() ?? false) _sideStep = null;
            if (_sideStep != null || _player.position.x >= _playerData.SlideLength) return;
            _sideStep = _player.DOLocalMoveX(_player.position.x + _playerData.SlideLength, _playerData.SlideDuration).SetEase(_playerData.SlideEase);
        }
        private void TryToJump() 
        {
            if (!_jump?.IsActive() ?? false) _jump = null;
            if (_jump != null) return;
            _jump = _playerBase.DOLocalJump(Vector3.zero, _playerData.JumpFore, 1, _playerData.JumpDuration).SetEase(_playerData.JumpEase);
        }
    }
}
