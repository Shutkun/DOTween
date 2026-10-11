using DG.Tweening;
using UnityEngine;

public class CapsuleScale : MonoBehaviour
{
    [SerializeField] private Vector3 _scaleVector;
    [SerializeField] private float _duration;

    private Tween _scacleTween;

    private void Start()
    {
        AnimateScale();
    }

    private void OnDisable()
    {
        _scacleTween?.Kill();
    }

    private void AnimateScale()
    {
        _scacleTween = transform.DOScale(_scaleVector, _duration);
    }
}
