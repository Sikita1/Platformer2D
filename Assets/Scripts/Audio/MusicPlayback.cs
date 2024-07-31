using UnityEngine;

public class MusicPlayback : MonoBehaviour
{
    [SerializeField] private AudioSource _audio;
    [SerializeField] private AudioClip _audioClip;

    public void Play() =>
        _audio.PlayOneShot(_audioClip);
}
