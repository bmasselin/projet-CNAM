using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleWand : MonoBehaviour
{
    public AudioClip spellSound;
    public AudioClip shootSound;
    private AudioSource audioSource;
    private Animator animator;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            audioSource.PlayOneShot(spellSound);
            animator.SetTrigger("WandCastSpell");
        }

        if (Input.GetButtonDown("Fire1"))
        {
            audioSource.PlayOneShot(shootSound);
            animator.SetTrigger("WandShoot");
        }
    }
}










