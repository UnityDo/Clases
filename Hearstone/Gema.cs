using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gema : MonoBehaviour
{
    bool usada = false;
    Image imagenGema;
    // Start is called before the first frame update
    private void Awake()
    {
        imagenGema = GetComponent<Image>();
    }
    void Start()
    {
        
      
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Inicial()
    {
        usada = false;
        imagenGema.color = Color.white;
    }
    public void Usa()
    {
        if (usada)
        {
            imagenGema.color = Color.grey;
        }
        else
        {
            imagenGema.color = Color.white;
        }
      
    }
    public void CambiaUsa()
    {
        //Interruptor logico
        /*
        if (usada)
        {
            usada = false;
        }
        else
        {
            usada = true;
        }*/
        usada = !usada;
    }
}
