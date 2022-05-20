using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlGiro : MonoBehaviour
{
    public float rotationSpeed;
    float timeCount = 0;
    public void RotateTowards(Transform target)
    {
         timeCount += Time.deltaTime;
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, timeCount * rotationSpeed);
        print(transform.rotation);
    }
    public void ReiniciaContador()
    {
        timeCount = 0;
    }
}
