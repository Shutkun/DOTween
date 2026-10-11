using DG.Tweening;
using UnityEngine;

public class CubeMove : MonoBehaviour
{
    [SerializeField] private Vector3 _position;
    [SerializeField] private float _duration;
    [SerializeField] private int _repeats;
    [SerializeField] private LoopType _loopType;

    private Tween _moveTween;

    private void Start()
    {
        AnimateMove();
    }

    private void OnDisable()
    {
        _moveTween?.Kill();
    }

    private void AnimateMove()
    {
        _moveTween = transform.DOMove(_position, _duration)
            .From()
            .SetLoops(_repeats,_loopType);
    }
}
