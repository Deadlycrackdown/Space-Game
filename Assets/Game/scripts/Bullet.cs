using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject boomEffect;
    public AudioClip boomSound;
    AudioSource audio;
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "systemcontrol")
        {
            return;
        }


        if (col.tag == "Enemy")  
        {
            Destroy(gameObject);
            audio.PlayOneShot(boomSound);
            Instantiate(boomEffect, transform.position, transform.rotation);

        }
        if (col.tag == "wall")

        {
            Destroy(gameObject);
        }
        //if (col.tag == "bullet")
        //{
        //    Destroy(this.gameObject);
        //   Instantiate(boomEffect, transform.position, transform.rotation);



        //  }
    }
}