using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlaySoundInAnimation : MonoBehaviour
{
    public AudioClip sound;
    AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {
        audioSrc =GetComponent<AudioSource>();  
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaySound()
    {
        audioSrc.Play();
    }
}

