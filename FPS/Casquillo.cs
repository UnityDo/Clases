using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Casquillo : MonoBehaviour
{
    //Cada vez que necesite datos del Arma pues uso DataArma
    public DataArma dataArma;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //Ejecutar los sonidos
    //Cuando haya una colision
    private void OnCollisionEnter(Collision collision)
    {
        //Eligir un sonido aleatorio desde dataArma
     AudioClip audioClip=   dataArma.CasquilloSonidos[Random.Range(0, dataArma.CasquilloSonidos.Length)];
        //Carga el sonido al audioSource
        //Play
        //Sino esta sonando suena
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(audioClip);
        }
        Destroy(gameObject, 20);
       
    }
}
