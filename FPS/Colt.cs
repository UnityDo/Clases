using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Quiero sea un Arma
//Quiero que pueda disparar
//Que dispare a su manera
public class Colt : Arma
{
    public Transform posDisparo;
    public Transform posCaquillo;

    public LayerMask layerMask;

    public Control_Impactos control_Impactos;
    public Animator animator;

    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //Se sobreescribe el metodo Dispara
    public override void Dispara()
    {
        if (!animator.GetCurrentAnimatorStateInfo(0).IsTag("Idle"))
        {
            return;
        }
        //Me centro en el comportamiento concreto del arma
        print("Dispara Colt");
        animator.SetTrigger("Dispara");
        audioSource.PlayOneShot(dataArma.sonidoDisparo);
        //Disparo por Raycast
        Ray ray = new Ray();
        ray.origin = posDisparo.position;
        ray.direction = posDisparo.forward;
        //Para visualizar rayos
        Debug.DrawRay(ray.origin, ray.direction * dataArma.alcance, Color.red, 3);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, dataArma.alcance, layerMask, QueryTriggerInteraction.Ignore))
        {

            print("Toca " + hit.collider.name);
            if (hit.rigidbody)
            {
                //hit.rigidbody.AddForce(-hit.normal * fuerzaDisparo, ForceMode.Impulse);
                hit.rigidbody.AddForceAtPosition(-hit.normal * dataArma.FuerzaDisparo, hit.point, ForceMode.Impulse);

            }
            //llamo al gestor de impactos
            control_Impactos.PoneImpacto(hit.point, Quaternion.LookRotation(hit.normal), hit.collider.gameObject);
        }
    }

    public override void Recarga()
    {
        if (!enabled)
        {
            return;
        }
        animator.SetTrigger("Recarga");
        audioSource.PlayOneShot(dataArma.sonidoRecarga);
    }
    //Se llama desde la animacion de Disparo
    public void CreaCasquillo()
    {
        //Crear un casquillo,  posCaquillo, rotacioncasquillo -> propio casquillo
      GameObject clonCasquillo=  Instantiate(dataArma.casquillo, posCaquillo.position, dataArma.casquillo.transform.rotation);
        clonCasquillo.GetComponent<Rigidbody>().AddForce((posCaquillo.up + new Vector3(Mathf.Pow(-1,Random.Range(1,3)), 0, 0))*dataArma.fuerzaCasquillo,ForceMode.Impulse);
        clonCasquillo.GetComponent<Rigidbody>().AddRelativeTorque(Random.Range(200, 500), 20, Random.Range(200,800));
    }
}
