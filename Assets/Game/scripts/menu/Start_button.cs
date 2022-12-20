using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Start_button : MonoBehaviour
{

    public AudioClip din;
    AudioSource audio;

    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    void Update()
    {
     //  if (Input.GetKeyDown(KeyCode.Space)) //здесь задаете  любую кнопку
        //    audio.PlayOneShot(din);
    }

    public void OpenGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

}
