using DG.Tweening;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    [SerializeField] private Vector3 _rotationVector;
    [SerializeField] private float _duration;
    [SerializeField] private int _repeats;

    private Tween _rotationTween;

    private void Start()
    {
        AnimateRotation();
    }

    private void OnDisable()
    {
        _rotationTween?.Kill();
    }

    private void OnDestroy()
    {
        _rotationTween?.Kill();
    }

    private void AnimateRotation()
    {
        _rotationTween = transform.DORotate(_rotationVector, _duration)
             .SetLoops(_repeats, LoopType.Yoyo);
    }
}
