using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventario_UI : MonoBehaviour
{
    public GameObject panelInventario;
    public GameObject slotInventario;

    public Sprite iconoNuevo;
    public int cantidadNueva;
    //TEst por ver como se rellena
    public List<GameObject> Slots;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    [ContextMenu("AddInventarioUI")]
    public void AddInventarioUI(Item itemData, int cantidad)
    {
        
        
        GameObject clonSlot = Instantiate(slotInventario);
        clonSlot.GetComponent<ControlSlot>().ItemData = itemData;
        clonSlot.GetComponent<ControlSlot>().SetIcono();
        clonSlot.GetComponent<ControlSlot>().SetCantidad(cantidad);
        clonSlot.name = itemData.nombre;
        Slots.Add(clonSlot);
        clonSlot.transform.SetParent( panelInventario.transform);
        
    }
}
