using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//obliga a tener el componente CanvasGroup
[RequireComponent(typeof(CanvasGroup))]
public class AnimationCode : MonoBehaviour
{
    CanvasGroup canvasGroup;
    float alpha = 1;
    public enum AnimationTipos { FadeIn,FadeOut}
    public AnimationTipos animationTipos;
    // Start is called before the first frame update
    void Start()
    {
        canvasGroup=GetComponent<CanvasGroup>();
        switch (animationTipos)
        {
            case AnimationTipos.FadeIn:
                StartCoroutine(FadeIn());
                break;
            case AnimationTipos.FadeOut:
                StartCoroutine(FadeOut());
                break;
        };
    }

    // Update is called once per frame
    void Update()
    {
     
    }
    //Fade Out alpha 1->0
    IEnumerator FadeOut()
    {
        for (float i = 1; i >0; i-=0.02f)
        {
            canvasGroup.alpha = i;
            //espera un fotograma
            yield return null;
        }
        canvasGroup.alpha = 0;
        print("Fin del alfa");
    }
    //alfa empieza en 0 y pasa a 1
    IEnumerator FadeIn()
    {
        
        for (float i = 0; i <1; i += 0.01f)
        {
            canvasGroup.alpha = i;
            //espera un fotograma
            yield return null;
        }
        canvasGroup.alpha = 1;
        print("Fin del alfa");
    }
}
