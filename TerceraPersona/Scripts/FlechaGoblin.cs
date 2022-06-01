using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlechaGoblin : MonoBehaviour
{
    Rigidbody rb;
    float danio;
    public float velocidadFlecha;
   public GameObject particulasImpacto;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * velocidadFlecha, ForceMode.VelocityChange);
        Destroy(gameObject, 5f);
    }
    private void OnTriggerEnter(Collider other)
    {
       
        //si puede pegar a otros o no
        if (other.CompareTag("Player"))
        {
            if (other.TryGetComponent(out IDaniable daniable))
            {
                daniable.RecibeDanio(danio);
                print("Daña jugador");
                particulasImpacto.SetActive(true);
                Destroy(gameObject, .3f);
                Destroy(particulasImpacto, .5f);
            }
        }

    }
   public void SetDanio(float _danio)
    {
        danio = _danio;
    }


}
