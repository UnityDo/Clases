using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bala : MonoBehaviour
{
    Rigidbody rb;
    public float fuerzaDisparo;
    public GameObject explosion;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    // Start is called before the first frame update
    void Start()
    {
       
        rb.AddForce(transform.forward* fuerzaDisparo, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        //Destruir el propio misil
        Destroy(gameObject, 0.1f);
        //Instanciar una explosion particulas
        //Crear el sonido de explosion (Se ubica en el espacio?)
        //Generar una onda expansiva q mueva los objetos
        Instantiate(explosion, collision.contacts[0].point, Quaternion.identity);
       
       

    }
}
