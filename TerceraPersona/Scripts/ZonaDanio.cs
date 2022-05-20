using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZonaDanio : MonoBehaviour
{
    public float danio;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        //Cualquiera que entre y tenga collider y sea daniable recibe danio
        if(other.TryGetComponent(out IDaniable daniable))
        {
            daniable.RecibeDanio(danio);
        }
    }
    private void OnTriggerStay (Collider other)
    {
        //Cualquiera que entre y tenga collider y sea daniable recibe danio
        if (other.TryGetComponent(out IDaniable daniable))
        {
            daniable.RecibeDanio(danio);
        }
    }
}
