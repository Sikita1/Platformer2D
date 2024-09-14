using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class SliderView : HealthDisplay
{
    protected Slider Slider;

    private void Awake()
    {
        Slider = GetComponent<Slider>();
    }
}
