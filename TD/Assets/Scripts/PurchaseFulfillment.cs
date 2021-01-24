using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurchaseFulfillment : MonoBehaviour
{
    public void grantCredits(int credits)
    {
        Debug.Log("You received " + credits + " Credits");
    }
    public void removeAds()
    {
        Debug.Log("All ads will be removed now!");
    }
    public void getPremium()
    {
        Debug.Log("You were upgrade your account to premium version!");
    }
}
