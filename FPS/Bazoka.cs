using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class Bazoka : Arma
{
    public GameObject bala;
    public Transform posDisaparo;
    public CinemachineVirtualCamera camaraJugador;
    float FOVApuntando = 30, FOVNormal = 60;
    Animator animatorCamara;
    //Para el Arma
    public Animator panzerAnimator;
    public AudioClip sonidoDisparo, sonidoRecarga;
    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
       
        //mouse1 = Mouse.current;
        animatorCamara = camaraJugador.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void Dispara()
    {
        GameObject clonBala = Instantiate(bala, posDisaparo.transform.position, posDisaparo.transform.rotation);
        panzerAnimator.SetTrigger("Dispara");
        audioSource.PlayOneShot(sonidoDisparo);
    }

    public override void Recarga()
    {
        panzerAnimator.SetTrigger("Recarga");
        audioSource.PlayOneShot(sonidoRecarga);

    }
}
