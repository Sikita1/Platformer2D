using UnityEngine;
using UnityEngine.Audio;

public class AllMusic : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup _mixerGroup;
    [SerializeField] private string _name;

    private bool _isButtonPressed;
    private float _minValue = -80f;
    private float _maxValue = 0f;

    public void Mute()
    {
        if (GetButtonPressed())
            AssignValue(_minValue);
        else
            AssignValue(_maxValue);
    }

    public void ChangeVolume(float volume) =>
        AssignValue(Mathf.Lerp(_minValue, _maxValue, volume));

    private void AssignValue(float value) =>
        _mixerGroup.audioMixer.SetFloat(_name, value);

    private bool GetButtonPressed() =>
        _isButtonPressed = !_isButtonPressed;
}
