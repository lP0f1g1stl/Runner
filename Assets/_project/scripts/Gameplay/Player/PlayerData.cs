using UnityEngine;
using DG.Tweening;

[CreateAssetMenu(fileName = "PlayerData", menuName = "Data/Player Data", order = 1)]
public class PlayerData : ScriptableObject
{
    [Header("Jump")]
    [SerializeField] private float jumpForce;
    [SerializeField] private float jumpDuration;
    [SerializeField] private Ease jumpEase = 0;
    [Header("Slide")]
    [SerializeField] private float slideLength;
    [SerializeField] private float slideDuration;
    [SerializeField] private Ease slideEase = 0;

    public float JumpFore => jumpForce;
    public float JumpDuration => jumpDuration;
    public Ease JumpEase => jumpEase;
    public float SlideLength => slideLength;
    public float SlideDuration => slideDuration;
    public Ease SlideEase => slideEase;
}
