using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CreaParteCuerpo : MonoBehaviour
{
    SkinnedMeshRenderer[] SkinnedMeshRenderers;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    [ContextMenu("CreaPiezas")]
    void CreaPiezas()
    {
        SkinnedMeshRenderers = GetComponentsInChildren<SkinnedMeshRenderer>();
        foreach (SkinnedMeshRenderer s in SkinnedMeshRenderers)
        {
            //Crear un nuevo gameobject
            GameObject basePieza = new GameObject();
           
            basePieza.name = s.name + "_P";
            //meterle un mesh filter
            //asociar a ese mehs filter el mesh del skinnedMeshRenderer
            basePieza.AddComponent<MeshFilter>().mesh = s.sharedMesh;
            //asociar un mesh renderer cojemos el material del skinnedMeshRenderer y se lo pasamos al mesh render
            basePieza.AddComponent<MeshRenderer>().material = s.material;
            //le metemos un rigibody
            basePieza.AddComponent<Rigidbody>();
        }
    }
}
