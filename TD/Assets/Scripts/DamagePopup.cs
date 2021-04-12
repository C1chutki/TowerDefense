using UnityEngine;
using System;
using TMPro;


public class DamagePopup : MonoBehaviour
{

    float time = 0;

    void Update ()
    {
        if (time >= 0.4f) {
            Destroy(gameObject);
        }

        time += Time.deltaTime;
    }
}
