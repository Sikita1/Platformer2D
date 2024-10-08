using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class TimerVampirism : MonoBehaviour
{
    private Image _image;

    private Coroutine _coroutine;

    public bool TimerFull => _image.fillAmount == 1f;

    private void Awake()
    {
        _image = GetComponent<Image>();
    }

    public void StartTimer(bool working, float target, float speed)
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(Reloading(working, target, speed));
    }

    private IEnumerator Reloading(bool working, float target, float speed)
    {
        while (_image.fillAmount != target && working == true)
        {
            _image.fillAmount = Mathf.MoveTowards(_image.fillAmount, target, speed * Time.deltaTime);

            yield return null;
        }
    }
}
