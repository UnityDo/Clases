using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
[RequireComponent(typeof(NavMeshAgent))]
public class Tanque : MonoBehaviour,IDaniable,IQuemable
{
    public float vida;
    public float armadura;
    NavMeshAgent navMeshAgent;
    public Transform jugador;
    float distancia;
    public float rangoAtaque;
    bool estaAtacando = false;
    //Para el disparo
    public GameObject misil;
    public Transform posDisparo;
    public Transform puntoPivoteTorreta;
    public float cadenciaAtaque;
    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {

        if (navMeshAgent.SetDestination(jugador.position))
        {
            puntoPivoteTorreta.LookAt(jugador.position);
            //Comprobar la distancia entre el enemigo y el jugador
            distancia = Vector3.Distance(jugador.position, transform.position);
            //Comparar la distancia con el rangoAtaque
            if (distancia <= rangoAtaque)
            {
                
                //puede atacar

                navMeshAgent.isStopped = true;
                if (!estaAtacando)
                {
                    print("Ataca");
                    //Ataca();
                    InvokeRepeating("Ataca", 0.5f, cadenciaAtaque);
                    estaAtacando = true;
                }
            }
            else
            {
                //se esta moviendo
                CancelInvoke("Ataca");
                estaAtacando = false;
                navMeshAgent.isStopped = false;
       
                //no puede atacar
            }
        }
        else
        {
            print("No lo puedo alcanzar");
        }
    }

    private void Ataca()
    {
        GameObject clonBala = Instantiate(misil, posDisparo.transform.position, posDisparo.transform.rotation);
        clonBala.GetComponent<Rigidbody>().useGravity = true;
        clonBala.GetComponent<Rigidbody>().mass = 0.5f;
       clonBala.GetComponent<Bala>().fuerzaDisparo = 10f;
    }

    public void RecibeDanio(float danio)
    {
        vida -= danio;
        if (vida <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void Quemo(float danioFuego)
    {
        RecibeDanio(Mathf.Abs(armadura - danioFuego));
    }

    public void Ardiendo(float danioFuego)
    {
        throw new System.NotImplementedException();
    }
}
