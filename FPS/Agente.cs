using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Agente : MonoBehaviour
{
    NavMeshAgent agente;
    public Transform posEnemigo;
    // Start is called before the first frame update
    void Start()
    {
        agente = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        //Dar una posicion al agente, el agente comprueba que la posicion esta en NavMesh
        // y si puede ir a ella, se mueve
        agente.destination = posEnemigo.position;
    }
}
