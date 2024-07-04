using UnityEngine;
using DG.Tweening;

public class Levitation : MonoBehaviour
{
    private Tween _tween;
    private float _upperBoundary;
    private float _speed = 2f;
    private float _heightPosition = 1f;

    private void Start()
    {
        _upperBoundary = gameObject.transform.position.y - _heightPosition;
        _tween = transform.DOMoveY(_upperBoundary, _speed).SetEase(Ease.Linear).SetLoops(-1, LoopType.Yoyo);
    }

    private void OnDestroy()
    {
        _tween.Kill();
    }
}
