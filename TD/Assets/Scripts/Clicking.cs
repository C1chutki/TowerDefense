using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Clicking : MonoBehaviour
{
    public Upgrades upgrades;
    public int clickpwr = 1;


    public void Start()
    {
        upgrades = FindObjectOfType<Upgrades>();
        clickpwr = PlayerPrefs.GetInt("Click");
    }


    //public Upgrades upgrades;

    //public int ClickPWR = 1;

    //public void Start()
    //{
    //    upgrades = FindObjectOfType<Upgrades>();
    //}

    //public void Update()
    //{
    //    PlayerPrefs.GetInt("click", upgrades.clickpower);
    //}

















    ////void Upgrade ()
    ////{
    ////    ClickPWR++;
    ////}

    ////public static int ClickPWR = 1;

    ////public Button upgrade;

    ////void Start()
    ////{
    ////    Button btn = upgrade.GetComponent<Button>();
    ////    btn.onClick.AddListener(Upgrade);
    ////}
}
