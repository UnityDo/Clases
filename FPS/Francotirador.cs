using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Francotirador : Arma
{
    public Transform posDisparo;
    public Transform posCaquillo;

    public LayerMask layerMask;

    public Control_Impactos control_Impactos;
    public Animator animator;

    public AudioSource audioSource;

   public bool puedeDisparar = true;
  
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void Dispara()
    {
      
        if (!puedeDisparar)
        {
            //no hago nada
            return;
        }
        //1 Control de la cadencia de disparo con Temporizador
        StopCoroutine(Contador());
        StartCoroutine(Contador());
        //2 Control de la cadencia de disparo con el animator



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
        animator.SetTrigger("Recarga");
        audioSource.PlayOneShot(dataArma.sonidoRecarga);
    }
    //Se llama desde la animacion de Disparo
    public void CreaCasquillo()
    {
        //Crear un casquillo,  posCaquillo, rotacioncasquillo -> propio casquillo
        GameObject clonCasquillo = Instantiate(dataArma.casquillo, posCaquillo.position, dataArma.casquillo.transform.rotation);
        clonCasquillo.GetComponent<Rigidbody>().AddForce((posCaquillo.right) * dataArma.fuerzaCasquillo, ForceMode.Impulse);
        clonCasquillo.GetComponent<Rigidbody>().AddRelativeTorque(Random.Range(200, 500), 20, Random.Range(200, 800));
    }
    IEnumerator Contador()
    {
        puedeDisparar = false;
        yield return new WaitForSeconds(1.38f);
        puedeDisparar = true;
    }
}
