using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tanque : MonoBehaviour,IDaniable
{
    public float vida;

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void RecibeDanio(float danio)
    {
        vida -= danio;
        if (vida <= 0)
        {
            Destroy(gameObject);
        }
    }

}
