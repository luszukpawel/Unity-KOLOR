using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    [SerializeField]
    private AnimationClip BasicAttack;

 
    public AnimationClip Idle;

    private Animation anim;

    void Start()
    {
        // przypisanie zmiennej anim komponentu Animation 
        anim = GetComponent<Animation>();
        // początkowe przypisanie aktualnej animacji jako idle 
        anim.clip = Idle;

        // UWAGA : animacja idle w inspektorze właściwość Wrap Mode ma zaznaczone jako loop -> dzięki temu wykonuje się w kółko
        // rozpoczęcie animacji 
        anim.Play();
    }

    void Update()
    {
        // jeśli gracz nacisnal LPM
        if (Input.GetMouseButtonDown(0))
        {
            // przypisanie aktualnej animacji jako basic attack
            anim.clip = BasicAttack;
            // rozpoczęcie animacji
            anim.Play();
            // zakolejkowanie kolejnej animacji jako idle
            anim.PlayQueued(Idle.name);
        }

        // jeśli gracz nacisnal PPM
        if (Input.GetMouseButtonDown(1))
        {
            // dodać animacje silego ataku
        }
    }
}
