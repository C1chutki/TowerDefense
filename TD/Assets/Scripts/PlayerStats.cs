using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int basicturretIndex = 0;

    public static float Money;
    public int startMoney = 400;

    public static int Lives;
    public int startLives = 20;

    public static int Rounds;


    private void Start()
    {
        Money = startMoney;
        Lives = startLives;
        Rounds = 0;
    }

    
}
