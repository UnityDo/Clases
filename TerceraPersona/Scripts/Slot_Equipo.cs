using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot_Equipo : MonoBehaviour
{
    public Image imagenSlot;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetIcono(Sprite icono)
    {
        imagenSlot.sprite = icono;
    }
}
