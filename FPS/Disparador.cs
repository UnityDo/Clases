using Cinemachine;
using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
[RequireComponent(typeof(PlayerInput))]
public class Disparador : MonoBehaviour
{
    public GameObject bala;
    public Transform posDisaparo;
    public CinemachineVirtualCamera camaraJugador;
    float FOVApuntando = 30, FOVNormal = 60;
    Animator animatorCamara;
    //Para el Arma
    public Animator panzerAnimator;
    public AudioClip sonidoDisparo, sonidoRecarga;
    AudioSource audioSource;
  // Mouse mouse1;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        //mouse1 = Mouse.current;
        animatorCamara = camaraJugador.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
      /*
      //Presiona el boton izquierdo
       if(mouse1.leftButton.wasPressedThisFrame)
        {
          
        }
      */

    }
    //Se llama desde el PlayerInput OnFire
    public void OnFire()
    {
        if (!enabled)
        {
            return;
        }
        print("Dispara");
        GameObject clonBala = Instantiate(bala, posDisaparo.transform.position, posDisaparo.transform.rotation);
        panzerAnimator.SetTrigger("Dispara");
        audioSource.PlayOneShot(sonidoDisparo);
    }
    public void OnApuntarPress()
    {
        if (!enabled)
        {
            return;
        }
        print("Apuntar");
        // camaraJugador.m_Lens.FieldOfView = 30;
        animatorCamara.SetBool("Apuntando", true);
    }
    public void OnApuntarRelease()
    {
        if (!enabled)
        {
            return;
        }
        print("Apuntar");
        //camaraJugador.m_Lens.FieldOfView = 60;
        animatorCamara.SetBool("Apuntando", false);
      
    }
    public void OnRecarga()
    {
        if (!enabled)
        {
            return;
        }
        panzerAnimator.SetTrigger("Recarga");
        audioSource.PlayOneShot(sonidoRecarga);

    }



}
