using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundsSurvived : MonoBehaviour
{
    public Text RoundsText;
    public int levelToUnlock = 2;

    void OnEnable()
    {
        PlayerPrefs.SetInt("levelReached", levelToUnlock);
        StartCoroutine(AnimateText());
    }

    IEnumerator AnimateText ()
    {
        RoundsText.text = "0";
        int round = 0;

        yield return new WaitForSeconds(1f);

        while (round < PlayerStats.Rounds)
        {
            round++;
            RoundsText.text = round.ToString();

            yield return new WaitForSeconds(.07f);
        }

    }
}
