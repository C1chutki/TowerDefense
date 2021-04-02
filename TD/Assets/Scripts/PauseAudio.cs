using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseAudio : MonoBehaviour
{

    public bool stop;

    public void OnMouseDown()
    {
        stop = !stop;
        BGMusic.Instance.gameObject.GetComponent<AudioSource>().volume = stop ? 0 : 0.1f;

    }
}