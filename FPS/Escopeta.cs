using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escopeta : Arma
{
  
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void Dispara()
    {
        print("Dispara Escopeta");
    }

    public override void Recarga()
    {
        print("Recarga de escopeta");
    }
}
