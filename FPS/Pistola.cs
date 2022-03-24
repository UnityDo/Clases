using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistola : MonoBehaviour
{
    public Transform posDisparo;
    public float alcance;
    public LayerMask layerMask;
    public float fuerzaDisparo;
    public Control_Impactos control_Impactos;
    public Animator animator;
    public AudioClip sonidoRecarga;
    public AudioClip sonidoDisparo;
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
    //Se llama desde el InputSystem
    public void OnFire()
    {
        if (!enabled)
        {
            return;
        }

        animator.SetTrigger("Dispara");
        audioSource.PlayOneShot(sonidoDisparo);
        //Disparo por Raycast
        Ray ray = new Ray();
        ray.origin = posDisparo.position;
        ray.direction = posDisparo.forward;
        //Para visualizar rayos
        Debug.DrawRay(ray.origin, ray.direction*alcance, Color.red, 3);
        RaycastHit hit;
      if(Physics.Raycast(ray,out hit, alcance, layerMask,QueryTriggerInteraction.Ignore))
        {

            print("Toca " + hit.collider.name);
            if (hit.rigidbody)
            {
                //hit.rigidbody.AddForce(-hit.normal * fuerzaDisparo, ForceMode.Impulse);
                hit.rigidbody.AddForceAtPosition(-hit.normal * fuerzaDisparo, hit.point, ForceMode.Impulse);
                
            }
            //llamo al gestor de impactos
            control_Impactos.PoneImpacto(hit.point, Quaternion.LookRotation(hit.normal), hit.collider.gameObject);
        }

    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        //  Gizmos.DrawSphere(transform.position, radio);
        /*
        Ray ray = new Ray();
        ray.origin = posDisparo.position;
        ray.direction = posDisparo.forward;
        Gizmos.DrawRay(ray);*/
    }
    public void OnRecarga()
    {
        if (!enabled)
        {
            return;
        }
        animator.SetTrigger("Recarga");
        audioSource.PlayOneShot(sonidoRecarga);

    }
}
