using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Clicking : MonoBehaviour
{
    public float ClickPWR = 1;
    //public static int ClickPWR = 1;

    public Button upgrade;

    void Start()
    {
        Button btn = upgrade.GetComponent<Button>();
        btn.onClick.AddListener(Upgrade);
    }

    void Upgrade ()
    {
        ClickPWR++;
    }
}
