using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Explications ChatGPT : Ce script est utilisé pour contrôler la lecture de sons associés à un objet avec une variation de hauteur (pitch). Le script utilise un délai aléatoire entre les sons, défini par les variables MinSoundDelay et RandomDelay. Lorsque le délai s'écoule, un son est joué à l'aide de l'AudioSource attaché à l'objet. De plus, le script modifie également le pitch du son en utilisant la variable MaxDeltaPitch, ce qui donne une variation aléatoire de hauteur pour chaque son joué. Après avoir joué un son, le script calcule le prochain délai aléatoire et continue le processus.
public class RandomPitchSoundPlayer : MonoBehaviour
{
    public float MinSoundDelay = 1;
    public float RandomDelay = 5;
    private float NextSoundDelay = 0;

    public float MaxDeltaPitch = 0.1f;

    private AudioSource aSource;


    private void computeNextSoundDelay()
    {
        NextSoundDelay = MinSoundDelay + Random.Range(0, RandomDelay);
    }

    void Start()
    {
        aSource = GetComponent<AudioSource>();
        computeNextSoundDelay();
    }

    void Update()
    {
        NextSoundDelay -= Time.deltaTime;
        if (NextSoundDelay <= 0)
        {
            aSource.Play();
            //Variation du pitch entre +MaxDeltaPitch et -MaxDeltaPitch
            aSource.pitch = 1 + Random.Range(0, MaxDeltaPitch) * 2 - MaxDeltaPitch;
            computeNextSoundDelay();
        }
    }
}