using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlSlot : MonoBehaviour
{
    public Image ImagenIcono;
    public TMPro.TextMeshProUGUI cantidad_txt;
    public Item ItemData;

    //protegemos la cantidad
    int cantidad = 1;

    public int Cantidad { get => cantidad; set => cantidad = value; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetIcono()
    {
        ImagenIcono.sprite = ItemData.icono;
    }
    public void SetCantidad(int _cantidad)
    {
        cantidad_txt.text = _cantidad.ToString();
    }
    public void UsaObjeto()
    {
      
        //quiero usar la pocion
        ItemData.Usa();
    }
}
