using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPTarget : MonoBehaviour
{
    public Transform target;

    void Update()
    {
        transform.LookAt(target);
    }
}
