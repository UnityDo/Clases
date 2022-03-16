using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Muzzle : MonoBehaviour
{
    public GameObject muzzle;
   
    //Se llama desde la animacion pazerckFire
    public void ActivaMuzzle()
    {
        muzzle.SetActive(true);
    }
    //Se llama desde la animacion pazerckFire
    public void DesactivaMuzzle()
    {
        muzzle.SetActive(false);
    }
}
