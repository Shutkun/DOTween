using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class ChangeText : MonoBehaviour
{
    [SerializeField] private Text _text;

    private float _duration = 3;
    private Sequence _sequence;

    private void Start()
    {
        StartSequence();
    }

    private void OnDisable()
    {
        _sequence?.Kill();
    }

    private void OnDestroy()
    {
        _sequence?.Kill();
    }

    private void StartSequence()
    {
        _sequence = DOTween.Sequence();

        _sequence.Append(_text.DOText("Замена", _duration));
        _sequence.Append(_text.DOText(",  дополнение", _duration).SetRelative());
        _sequence.Append(_text.DOText("Взлом", _duration, true, ScrambleMode.All));
    }
}
