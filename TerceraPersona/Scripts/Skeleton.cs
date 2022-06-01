using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : Enemigo, IDaniable
{
    public float distancia;
    public VisualizaEstados visualizaEstados;
    // Start is called before the first frame update
    public GameObject particulasGolpe;
   public override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
        animator.SetFloat("Velocidad", agente.velocity.magnitude);
     

        if (Vector3.Distance(transform.position, GameController.instancia.playerController.gameObject.transform.position)<=stats_Enemigo.rangoAtaqueMelee)
        {
            //parar el agente
            agente.isStopped = true;
            animator.SetBool("Atacando",true);
            visualizaEstados.CambiaMaterialAtaque();
        }
        else
        {
            agente.isStopped = false;
            animator.SetBool("Atacando", false);
            visualizaEstados.CambiaMaterialMueve();
        }
    }
    //Se llama desde el Animator
    public void AtaqueEspada()
    {
        print("Ataca");

        //Si el juegador esta dentro de una bola que tiramos en ese momento
        Collider[] colliders = Physics.OverlapSphere(transform.position + (transform.forward * 2) + new Vector3(0, 1.5f, 0), stats_Enemigo.rangoAtaqueEspada);
        foreach(Collider c in colliders)
        {
            print(c.name);
            if (c.CompareTag("Player"))
            {
                if(c.TryGetComponent(out IDaniable daniable))
                {
                    daniable.RecibeDanio(stats_Enemigo.danioMelee);
                  GameObject clonParticulas=  Instantiate(particulasGolpe, c.transform);
                    clonParticulas.transform.localScale = Vector3.one * 0.5f;
                    clonParticulas.transform.position = clonParticulas.transform.position + Vector3.up*1.5f;
                    Destroy(clonParticulas, 5f);
                }
            }
        }
       
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position+(transform.forward*2)+new Vector3(0,1.5f,0), stats_Enemigo.rangoAtaqueEspada);
    }

    public void RecibeDanio(float danio)
    {
        print("Enemigo" + danio);
        vidaActual -= danio;
        if (vidaActual <= 0)
        {
            animator.SetTrigger("Muerte");
            Destroy(agente);
            Destroy(this);
        }
    }
}
