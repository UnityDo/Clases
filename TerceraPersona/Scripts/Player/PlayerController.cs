using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour,IDaniable
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
    int IDMuerte;
    bool atacando = false;
    ControlGiro controlGiro;
    bool girando = false;
    Transform posGiro = null;
    [Header("Para el arco")]
    public Transform posDisparo;
    ControlArmas controlArmas;
    //
    float vidaActual;
    float magiaActual;
    public Atributos atributosBase;
    public bool inventarioAbierto = false;
    Inventario inventario;

    //TODO quitar de publica
    public int vidaJugador;

    public Transform Armadura, Guantes, Botas, Cinturon, Collar, Casco, Arma, Escudo;
    // Start is called before the first frame update
    void Start()
    {
        //El jugador lleva la mochila para guardar los objetos que es el inventario
        inventario = GetComponent<Inventario>();
        vidaJugador = atributosBase.VidaBase;
        Init();

    }

    private void Init()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        animator.enabled = true;
        cameraJugador = Camera.main;
        IDAnimaAtaque = Animator.StringToHash("Atacando");
        IDMuerte = Animator.StringToHash("Muere");
        controlArmas = GetComponent<ControlArmas>();

        vidaActual = atributosBase.VidaBase;
        magiaActual = atributosBase.MagiaBase;
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
        if (inventarioAbierto)
        {
            return;
        }
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

            if (hit2.collider.CompareTag("Objeto"))
            {
                print("Es un objeto");
                //Como se recoje el objeto
                if(hit2.collider.TryGetComponent(out Objeto objeto))
                {
                    print(objeto.item.nombre);
                    //meto en el inventario
                   if(inventario.TryAddItem(objeto.item))
                    {
                        print("Añade el objeto");
                        Destroy(hit2.collider.gameObject);
                    }
                    else
                    {
                        print("No añade el objeto");
                    }
                }
                else
                {
                    print("No tiene el componente objeto");
                }
            }
        }
    }
    //Ejecuta el input del inventario
    public void OnInventario() {
        // actualizo los atributos
        Control_UI.instancia.PintarAtributos(atributosBase);
          inventarioAbierto = !inventarioAbierto;
        //abrir el inventario
        Control_UI.instancia.control_Atributos.ActivaYDesactivaPanelAtributos(inventarioAbierto);
    }

    public void RecibeDanio(float danio)
    {
        vidaActual -= danio;
        Control_UI.instancia.controlVida.SetVida(vidaActual/atributosBase.VidaBase);
        if (vidaActual <= 0)
        {
            print("Muere");
            animator.SetTrigger(IDMuerte);
            //Sacar el panel game over
            //Evitar que siga comprobando
            this.enabled = false;
            animator.enabled = false;
        }
    }
}
