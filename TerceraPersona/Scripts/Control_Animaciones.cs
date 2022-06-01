using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control_Animaciones : MonoBehaviour
{
    public AnimatorOverrideController magoOverride;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CambiadeAnimatorController()
    {
        animator.runtimeAnimatorController = magoOverride;
        
    }
}
