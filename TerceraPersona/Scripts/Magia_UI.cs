using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Magia_UI : MonoBehaviour
{
    public Image magia1, magia2;
  
  public  void PoneSpriteMagia1(Sprite iconoMagia)
    {
        magia1.sprite = iconoMagia;
    }
   public void PoneSpriteMagia2(Sprite iconoMagia)
    {
        magia2.sprite = iconoMagia;
    }
}
