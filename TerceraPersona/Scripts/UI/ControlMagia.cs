using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlMagia : MonoBehaviour
{
    //Cambiar el gui de la magia
    public Image magiaImage;

    public void SetMagia(float magiaNormalizada)
    {
        //ya viene convertida 0-1
        magiaImage.fillAmount = magiaNormalizada;
    }
  
}
