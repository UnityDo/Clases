using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Zombie : MonoBehaviour,IQuemable,IDaniable
{
    NavMeshAgent navmeshAgent;
    public Transform jugador;
    Animator animator;
    public float rangoMelee;
   public CapsuleCollider capsuleCollider;
    public float danioAtaque;
    public float vida;
    //un script externo
    public FieldOfView fieldOfView;
    bool seQuema = false;
    public GameObject ragdollZombie;
    private void Awake()
    {
        navmeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>(); 
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        navmeshAgent.SetDestination(jugador.position);
     
        animator.SetFloat("Velocidad", navmeshAgent.desiredVelocity.magnitude);
        
        if (Vector3.Distance(transform.position, jugador.position) <= rangoMelee)
        {
            //como saber si ve al jugador
            if (fieldOfView.visibleTargets != null)
            {
                if (fieldOfView.visibleTargets.Count > 0)
                {
                    //ve al jugador
                    //se para el agente
                    navmeshAgent.isStopped = true;
                    animator.SetBool("Atancado", true);
                }
            }
            
            
        }
        else
        {
            navmeshAgent.isStopped = false;
            animator.SetBool("Atancado", false);
        }
    }
    //Se llama desde la animacion de Ataque
    public void ActivaCollider()
    {
        capsuleCollider.enabled = true;
    }
    public void DesactivaCollider()
    {
        capsuleCollider.enabled = false;
    }

    public void Quemo(float danioFuego)
    {
        //Generar particulas de fuego
        RecibeDanio(danioFuego);

        if (!seQuema)
        {
            GameObject particulasFuego = Instantiate(Resources.Load("TinyFlames2"), transform) as GameObject;
            ParticleSystem.ShapeModule shapeModule = new ParticleSystem.ShapeModule();
            shapeModule = particulasFuego.GetComponent<ParticleSystem>().shape;
            shapeModule.skinnedMeshRenderer = GetComponentInChildren<SkinnedMeshRenderer>();

            particulasFuego.GetComponent<ParticleSystem>().Play();
            seQuema = true;
         
        }
    }

    public void Ardiendo(float danioFuego)
    {
        throw new System.NotImplementedException();
    }

    public void RecibeDanio(float danio)
    {
        vida -= danio;
        if (vida <= 0)
        {
            navmeshAgent.isStopped = true;
            //Creo la copia del ragdoll
          GameObject clonZombie=  Instantiate(ragdollZombie, transform.position, transform.rotation);
            CopiaPosicion(transform, clonZombie.transform);

            Destroy(gameObject);
            /*
            animator.SetTrigger("Muere");
            //Creamos un alaeatorio para la muerte
            int indiceAlea = Random.Range(0, 3);
            animator.SetFloat("Muertes", indiceAlea);
            Destroy(this);*/
        }
    }
    void CopiaPosicion(Transform zombie,Transform ragdoll)
    {
        if (zombie.childCount > 0)
        {
            foreach(Transform zombieTransform in zombie)
            {
                //Coger el transform del ragdoll
                Transform ragdollTransform = ragdoll.Find(zombieTransform.name);
                print(zombieTransform.name);
                if (ragdollTransform != null)
                {
                    ragdollTransform.localPosition = zombieTransform.localPosition;
                    ragdollTransform.localRotation = zombieTransform.localRotation;
                    CopiaPosicion(zombieTransform, ragdollTransform);
                }
            }
        }
    }
}
