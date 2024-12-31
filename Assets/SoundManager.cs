using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance { get; set; }

    public AudioSource shootingSound;

    public AudioSource playerChannel;
    public AudioClip playerHurt;
    public AudioClip playerDie;


    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;    
        }
    }
}
