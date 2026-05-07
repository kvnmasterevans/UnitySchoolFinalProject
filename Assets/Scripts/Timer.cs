using UnityEngine;
using TMPro;
using System;

public class Timer : MonoBehaviour
{
    [SerializeField] TMP_Text timerText;
    [SerializeField] float remainingTime = 60;
    [SerializeField] float decreaseTimeRate = 1;

    // Update is called once per frame
    void Update()
    {
        // Count down the remain time & prevent it from going below 0
        if (remainingTime > 0)
            remainingTime -= Time.deltaTime * decreaseTimeRate;
        else
            remainingTime = 0;

        // Format the time to a digital clock format
        int minute = Mathf.FloorToInt(remainingTime / 60);
        int second = Mathf.FloorToInt(remainingTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minute, second);
    }
}
