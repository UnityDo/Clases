using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{
    
   AudioSource audioSource;
    public AudioClip[] ClipsLoose;
    public AudioClip[] ClipsWin;
    public AudioClip[] ClipsClick;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayLoose()
    {
        //elegir una pista un clip aleatoria
        int alea = Random.Range(0, ClipsLoose.Length);
        //cargar el clip al AudioSource
        audioSource.clip = ClipsLoose[alea];
        //hacer play
        audioSource.Play();
    }
    public void PlayWin()
    {
        //elegir una pista un clip aleatoria
        int alea = Random.Range(0, ClipsWin.Length);
        //cargar el clip al AudioSource
        audioSource.clip = ClipsWin[alea];
        //hacer play
        audioSource.Play();
    }
    public void PlayClick()
    {
        //elegir una pista un clip aleatoria
        int alea = Random.Range(0, ClipsClick.Length);
        //cargar el clip al AudioSource
        audioSource.clip = ClipsClick[alea];
        //hacer play
        audioSource.Play();
    }
}
