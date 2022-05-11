using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    NavMeshAgent navMeshAgent;
    public Transform posDestino;
    Camera cameraJugador;
    public float offY;
    public LayerMask layerMask;
    public LayerMask layerGeneral;
    float distancia = 5000;
    Animator animator;
    int IDAnimaAtaque;
    bool atacando = false;
    ControlGiro controlGiro;
    bool girando = false;
    Transform posGiro = null;
    [Header("Para el arco")]
    public Transform posDisparo;
    ControlArmas controlArmas;
    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        cameraJugador = Camera.main;
        IDAnimaAtaque = Animator.StringToHash("Atacando");
        controlArmas = GetComponent<ControlArmas>();



    }

    // Update is called once per frame
    void Update()
    {
        if (atacando)
        {
            return;
        }
        if (posGiro != null)
        {
          //  controlGiro.RotateTowards(posGiro);
        }
     
        navMeshAgent.SetDestination(posDestino.position);
    }
    //se llama desde el PlayerInput
    void OnPulsa()
    {
        print("Has pulsado");
        atacando = false;
        animator.SetBool(IDAnimaAtaque, atacando);
        //Lanzamos un Raycast desde las posicion de la camara
        Ray ray = cameraJugador.ScreenPointToRay(Mouse.current.position.ReadValue());

       
        if (Physics.Raycast(ray,out RaycastHit hit, distancia, layerMask))
        {
            print(hit.collider.name);
            posDestino.position = hit.point+new Vector3(0,offY);
            girando = true;
            transform.LookAt(hit.transform, transform.up);
          
        }

       

        //TODO controlar doble click
        //Se pone a correr
    }
    void OnAtaque()
    {
      
        Ray ray = cameraJugador.ScreenPointToRay(Mouse.current.position.ReadValue());
        if (Physics.Raycast(ray, out RaycastHit hit2, distancia, layerGeneral))
        {
            if (hit2.collider.CompareTag("Enemigo"))
            {
                animator.SetBool(IDAnimaAtaque, true);
                transform.LookAt(hit2.transform,transform.up);
                
                     atacando = true;
                girando = true;
                //si tengo un arma, y ese arma es un Arco
                if (controlArmas.armaActual != null)
                {
                    if(controlArmas.armaActual is Arcos)
                    {
                        if(controlArmas.armaActual is ArcoLargo)
                        {
                           
                            ArcoLargo arcoLargo = controlArmas.armaActual as ArcoLargo;
                          GameObject clonFlecha=  Instantiate(arcoLargo.flecha_larga, posDisparo.position, posDisparo.rotation);
                            clonFlecha.GetComponent<Rigidbody>().AddForce(posDisparo.forward.normalized * arcoLargo.fuerzaDisparo, ForceMode.Impulse);
                        }
                    }
                }
            }
        }
    }
   
 
}
