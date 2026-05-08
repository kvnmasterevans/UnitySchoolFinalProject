using UnityEngine;
using TMPro;
using System;

public class Timer : MonoBehaviour
{
    [SerializeField] TMP_Text timerText;
    [SerializeField] float remainingTime = 60;
    [SerializeField] float decreaseTimeRate = 1;

    // Lose game variable
    public GameObject losingScreen;

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

        // Checks if time ran out and calls LoseGame
        if (remainingTime <= 0)
        {
            LoseGame();
            return;
        }
    }

    // Creates LoseGame function and displays game over screen
    void LoseGame()
    {
        if (losingScreen != null)
        {
            losingScreen.SetActive(true);
            losingScreen.GetComponentInChildren<TMP_Text>().text = "You missed the submission deadline";
        }
            
            

        Time.timeScale = 0f;
    }
}
