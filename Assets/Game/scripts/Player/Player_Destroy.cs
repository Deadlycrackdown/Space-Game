using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Player_Destroy : MonoBehaviour
{

    public GameObject boomEffect;
    public SkippableAd ad; //

    void Start()
    {
        
    }


    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Destroy(this.gameObject);
            SceneManager.LoadScene("Menu");
            ad.ShowAd();
        }
        if (other.gameObject.tag == "enemy_bullet")
        {
            Destroy(this.gameObject);
            Instantiate(boomEffect, transform.position, transform.rotation);
            SceneManager.LoadScene("Menu");
            ad.ShowAd();
        }

    }

}

