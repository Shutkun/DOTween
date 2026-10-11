using DG.Tweening;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private float _duration;
    [SerializeField] private Color _targetColor;

    private Tween _colorTween;

    private void Start()
    {
        AnimateColor();
    }

    private void OnDisable()
    {
        _colorTween?.Kill();
    }

    private void AnimateColor()
    {
        _colorTween = _spriteRenderer.DOColor(_targetColor, _duration);
    }
}
