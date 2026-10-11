using DG.Tweening;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ChangeText : MonoBehaviour
{
    [SerializeField] private Text _text;

    private float _duration = 3;
    private float _delay = 4;
    private Coroutine _coroutine;
    private Tween _textTween;

    private void OnEnable()
    {
        _coroutine = StartCoroutine(PlayTextSequence());
    }

    private void OnDisable()
    {
        StopCoroutine();
        _textTween?.Kill();
    }

    private IEnumerator PlayTextSequence()
    {
        WaitForSeconds wait = new WaitForSeconds(_delay);
        WaitForSeconds firstWait = new WaitForSeconds(_delay - 2f);

        _textTween?.Kill();
        yield return firstWait;
        _textTween = _text.DOText("Замена", _duration);
        
        yield return wait;
        _textTween?.Kill();
        _textTween = _text.DOText(",  дополнение", _duration).SetRelative();

        yield return wait;
        _textTween?.Kill();
        _textTween = _text.DOText("Взлом", _duration, true, ScrambleMode.All);

    }

    private void StopCoroutine()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }
    }
}
