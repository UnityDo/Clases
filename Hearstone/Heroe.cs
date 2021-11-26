using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Heroe : MonoBehaviour
{
    public DataHeroe dataHeroe;

    public Image imagenCara;
    public TextMeshProUGUI textoVida;
    private int vida;
  public Golpe golpe;
    // Start is called before the first frame update
    void Start()
    {
     
        RellenaDatos();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void RellenaDatos()
    {
        imagenCara.sprite = dataHeroe.sprite;
        textoVida.text = dataHeroe.vida.ToString();
        vida = dataHeroe.vida;
    }
   public int GetVida()
    {
        return vida;
    }
   public void SetVida(int _vida)
    {
        vida = _vida;
        textoVida.text = vida.ToString();
    }
    public void PoneDanio(int danio)
    {
        StartCoroutine(AnimacionesGolpe(danio));
    }
    IEnumerator AnimacionesGolpe(int danio)
    {
        golpe.PintaDanio(danio);
        golpe.IniciaGolpe();
        yield return new WaitForSeconds(1);
        golpe.AcabaGolpe();
        
    }

}
