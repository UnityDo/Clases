using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarajaH : MonoBehaviour
{
   public List<DataHearstoneCarta> DataHearstoneCartas;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public DataHearstoneCarta SacaCarta()
    {
        DataHearstoneCarta cartaH=null;
        //Sacar una carta aleatoria
        int alea = Random.Range(0, DataHearstoneCartas.Count);
        cartaH = DataHearstoneCartas[alea];
        //elimino del mazo
        DataHearstoneCartas.Remove(cartaH);
        
        return cartaH;
    }
}
