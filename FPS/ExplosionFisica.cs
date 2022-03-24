using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionFisica : MonoBehaviour
{
    public float radio;
    public float fuerza;
    public float fuerzaArriba;
    // Start is called before the first frame update
    void Start()
    {
        //Detectar los objetos fisicos que hay alrededor
        RaycastHit[] Hits = Physics.SphereCastAll(transform.position, radio, Vector3.right);
        //Dar una fuerza a esos objetos
        foreach(RaycastHit r in Hits)
        {
            print(r.collider.name);
            //les doy un impulso hacia arriba
            if (r.rigidbody)
            {
                //r.rigidbody.AddForce(Vector3.up * fuerza, ForceMode.Impulse);
                r.rigidbody.AddExplosionForce(fuerza, transform.position, radio, fuerzaArriba,ForceMode.Impulse);
            }
            //TODO detectar al jugador y quitarle vida
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //Se usa para pintar Gizmos
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
      //  Gizmos.DrawSphere(transform.position, radio);
        Gizmos.DrawWireSphere(transform.position, radio);
    }

}
