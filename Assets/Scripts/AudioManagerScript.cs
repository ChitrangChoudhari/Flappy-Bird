using UnityEngine;

public class AudioManagerScript : MonoBehaviour
{
    [Header("-------------Audio Source-----------------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("-------------Audio Clip-----------------")]
    public AudioClip background;
    public AudioClip jump;
    public AudioClip end;
    public AudioClip collide;
    public AudioClip button;

    private void Start()
    {
        musicSource.clip = background;
        musicSource.Play();
    }

    public void PlayButton()
    {
        SFXSource.clip = button;
        SFXSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }

}
