using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class odio : MonoBehaviour
{
    [SerializeField] AudioSource Music;
    [SerializeField] AudioSource SFX;

    public AudioClip background;
    public AudioClip idle;
    public AudioClip bite;
    public AudioClip walk;

    private void Start()
    {
       Music.clip = background;
        Music.Play();
    }
    public void PlaySFX(AudioClip clip)
    {
        SFX.PlayOneShot(clip);
    }
}
