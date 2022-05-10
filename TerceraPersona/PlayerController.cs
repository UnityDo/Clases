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
    float distancia = 5000;
    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        cameraJugador = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        navMeshAgent.SetDestination(posDestino.position);
    }
    void OnPulsa()
    {
        print("Has pulsado");
        //Lanzamos un Raycast desde las posicion de la camara
        Ray ray = cameraJugador.ScreenPointToRay(Mouse.current.position.ReadValue());

        if(Physics.Raycast(ray,out RaycastHit hit, distancia, layerMask))
        {
            print(hit.collider.name);
            posDestino.position = hit.point+new Vector3(0,offY);
        }
    }
}
