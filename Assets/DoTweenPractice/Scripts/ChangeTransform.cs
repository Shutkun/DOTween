using DG.Tweening;
using UnityEngine;

public class ChangeTransform : MonoBehaviour
{
    [SerializeField] private Vector3[] _waypoints;
    [SerializeField] private Vector3 _rotationVector;
    [SerializeField] private Vector3 _scaleVector;
    [SerializeField] private float _pathDuration;
    [SerializeField] private float _rotationDuration;
    [SerializeField] private float _scaleDuration;
    [SerializeField] private int _repeats;

    private Sequence _sequence;

    private void Start()
    {
        StartTransformSequence();
    }

    private void OnDisable()
    {
        _sequence?.Kill();
    }

    private void OnDestroy()
    {
        _sequence?.Kill();
    }

    private void StartTransformSequence()
    {
        _sequence = DOTween.Sequence();

        _sequence.Append(transform.DOPath(_waypoints, _pathDuration, PathType.CatmullRom)
            .SetOptions(true)
            .SetLookAt(0.01f)
            .SetLoops(_repeats)
            .SetEase(Ease.Linear));

        _sequence.Insert(0f,transform.DORotate(_rotationVector, _rotationDuration)
            .SetLoops(_repeats, LoopType.Restart));

        _sequence.Insert(0f, transform.DOScale(_scaleVector, _scaleDuration)
            .SetLoops(_repeats, LoopType.Yoyo));
    }
}
