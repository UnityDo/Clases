using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Zombie : MonoBehaviour
{
    NavMeshAgent navmeshAgent;
    public Transform jugador;
    Animator animator;
    public float rangoMelee;
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
        print(navmeshAgent.desiredVelocity.magnitude);
        animator.SetFloat("Velocidad", navmeshAgent.desiredVelocity.magnitude);
        print(Vector3.Distance(transform.position, jugador.position));
        if (Vector3.Distance(transform.position, jugador.position) <= rangoMelee)
        {
            //se para el agente
            navmeshAgent.isStopped = true;
            animator.SetBool("Atancado", true);
        }
    }
}
