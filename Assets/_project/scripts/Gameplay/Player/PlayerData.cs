using UnityEngine;
using DG.Tweening;

[CreateAssetMenu(fileName = "PlayerData", menuName = "Data/Player Data", order = 1)]
public class PlayerData : ScriptableObject
{
    [Header("Jump")]
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _jumpDuration;
    [SerializeField] private Ease _jumpEase = 0;
    [Header("Slide")]
    [SerializeField] private float _slideLength;
    [SerializeField] private float _slideDuration;
    [SerializeField] private Ease _slideEase = 0;

    public float JumpFore => _jumpForce;
    public float JumpDuration => _jumpDuration;
    public Ease JumpEase => _jumpEase;
    public float SlideLength => _slideLength;
    public float SlideDuration => _slideDuration;
    public Ease SlideEase => _slideEase;
}
