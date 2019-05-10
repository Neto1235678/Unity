using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletRandomSound : MonoBehaviour
{
    public AudioClip[] Clips;

    AudioSource sound;


    private void Awake()
    {
        sound = gameObject.AddComponent<AudioSource>();
    }



    public void Play()
    {
        int rnd = Random.Range(0, Clips.Length);
        sound.PlayOneShot(Clips[rnd], 1f);
    }
}
