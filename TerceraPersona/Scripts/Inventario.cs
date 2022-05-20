using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventario : MonoBehaviour
{
    //El inventario tiene una lista de items
    public List<Item> Items;
    int maxItems = 70;
    public Item itemTest;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public bool TryAddItem(Item item)
    {
        //TODO verificar las excepciones
        //Tenemos un numero maximo de items
        //No puedo meter un objeto si ya tengo el maximo
        if (Items.Count < maxItems)
        {
            //TODO para gestionar las cantidades
            Items.Add(item);
            //Que se pinte el objeto en el inventario
            Control_UI.instancia.inventarioUI.AddInventarioUI(item, 1);
            return true;
        }
        else
        {
            return false;
        }
        
    }
    //Funcion de testeo
    [ContextMenu ("Tes Añadir al inventario")]
    public void AddInventario()
    {
        for (int i = 0; i < maxItems; i++)
        {
            Items.Add(itemTest);
        }
    }
    [ContextMenu("Tes Limpia el inventario")]
    public void LimpiaInventario()
    {
        Items.Clear();
    }
}
