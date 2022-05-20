using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlVida : MonoBehaviour
{
    public Image vidaImagen;

    public void SetVida(float vidaNormalizada)
    {
        //ya viene convertida 0-1
        vidaImagen.fillAmount = vidaNormalizada;
    }
  
}
