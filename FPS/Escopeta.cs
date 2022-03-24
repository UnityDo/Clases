using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escopeta : Arma
{
    public Transform posDisparo;
    public Transform posCaquillo;

    public LayerMask layerMask;

    public Control_Impactos control_Impactos;
    public Animator animator;

    public AudioSource audioSource;

    //Municion
    int municionActual;
    //Municion Inicial
    int municionInicial;
    //El numero de cargadores que llevas
    int municionTotal;
    // Start is called before the first frame update
    void Start()
    {
        municionActual = dataArma.BalasXCargador;
        municionTotal = dataArma.BalasXCargador * dataArma.CargadoresInicial;

        Control_UI.instancia.SetMunicionActual(municionActual);
        Control_UI.instancia.SetMunicionTotal(municionTotal);
        animator.SetInteger("Balas", municionActual);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void Dispara()
    {
        if (!animator.GetCurrentAnimatorStateInfo(0).IsTag("Idle"))
        {
            return;
        }

        //Comprobar la municion
        if (municionActual >= 1)
        {
         
            animator.SetTrigger("Dispara");
        audioSource.PlayOneShot(dataArma.sonidoDisparo);
        for(int i = 0; i < 12; i++)
        {

      
        //Disparo por Raycast
        Ray ray = new Ray();
        ray.origin = posDisparo.position;
            //variar la direccion del disparo
            Vector3 direccionAleatoria = new Vector3(Random.insideUnitCircle.x, Random.insideUnitCircle.y, 0);
        ray.direction = posDisparo.forward+ direccionAleatoria*0.5f;
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

            municionActual--;
            //mostrar el cambio
            Control_UI.instancia.SetMunicionActual(municionActual);
            animator.SetInteger("Balas", municionActual);
            if (municionTotal==0)
            {
                animator.SetBool("SinBalas", true);
            }
        }
        else
        {
            //Sacar algun mensaje
            print("Sin municion");
          
        }
    }

    public override void Recarga()
    {
        if (!enabled)
        {
            return;
        }
        if (municionTotal >= 1)
        {
            animator.SetTrigger("Recarga");
       
        //Comprobar que tiene balas de la municionTotal
        
          
        }
        else
        {
            //Q se muestra sino puede recargar
        }


    }
    public void CreaCasquillo()
    {
        //Crear un casquillo,  posCaquillo, rotacioncasquillo -> propio casquillo
        GameObject clonCasquillo = Instantiate(dataArma.casquillo, posCaquillo.position, dataArma.casquillo.transform.rotation);
        clonCasquillo.GetComponent<Rigidbody>().AddForce((posCaquillo.up + new Vector3(Mathf.Pow(-1, Random.Range(1, 3)), 0, 0)) * dataArma.fuerzaCasquillo, ForceMode.Impulse);
        clonCasquillo.GetComponent<Rigidbody>().AddRelativeTorque(Random.Range(200, 500), 20, Random.Range(200, 800));
    }
    //Se llama desde la animacion

    public void CargaBala()
    {
        if (municionTotal >= 1)
        {
            municionActual++;
            municionTotal--;
            Control_UI.instancia.SetMunicionActual(municionActual);
            Control_UI.instancia.SetMunicionTotal(municionTotal);
            animator.SetInteger("Balas", municionActual);
            audioSource.PlayOneShot(dataArma.sonidoRecarga);
        }
        if (municionTotal == 0)
        {
            animator.SetBool("SinBalas", true);
        }
    }
}
