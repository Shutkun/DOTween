using DG.Tweening;
using UnityEngine;

public class CubeChangeTransform : MonoBehaviour
{
    [SerializeField] private Vector3[] _waypoints;
    [SerializeField] private Vector3 _rotationVector;
    [SerializeField] private Vector3 _scaleVector;
    [SerializeField] private float _pathDuration;
    [SerializeField] private float _rotationDuration;
    [SerializeField] private float _scaleDuration;
    [SerializeField] private int _repeats;

    private Tween _pathTween;
    private Tween _rotationTween;
    private Tween _scaleTween;

    private void Start()
    {
        StartTransformSequence();
    }

    private void OnDisable()
    {
        _pathTween?.Kill();
        _rotationTween?.Kill();
        _scaleTween?.Kill();
    }

    private void StartTransformSequence()
    {
        _pathTween = transform.DOPath(_waypoints, _pathDuration, PathType.CatmullRom)
            .SetOptions(true)
            .SetLookAt(0.01f)
            .SetLoops(_repeats);

        _rotationTween = transform.DORotate(_rotationVector, _rotationDuration)
            .SetLoops(_repeats, LoopType.Restart);

        _scaleTween = transform.DOScale(_scaleVector, _scaleDuration)
            .SetLoops(_repeats, LoopType.Yoyo);
    }
}
