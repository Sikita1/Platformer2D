using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SmoothHealthBar : SliderView
{
    private Coroutine _coroutine;
    private WaitForSeconds _wait;

    private float _delay = 0.02f;
    private float _maxDelta = 0.5f;

    protected override void OnHealthChanged(float health)
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(SmoothSliderChange(health));
    }

    private IEnumerator SmoothSliderChange(float health)
    {
        _wait = new WaitForSeconds(_delay);

        while (Slider.value != health)
        {
            Slider.value = Mathf.MoveTowards(Slider.value, health, _maxDelta);
            yield return _wait;
        }
    }
}
