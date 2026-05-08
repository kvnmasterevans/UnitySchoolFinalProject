using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BarDecrease : MonoBehaviour
{
    public Image fillImage;

    public float value = 2f;
    public float maxValue = 2f;

    public float fillSpeed = 1f;
    public float drainSpeed = 0.5f;

    private bool holding = false;

    public bool isPaused = false; //draining is paused when cody is on screen

    // Lose game variable
    public GameObject losingScreen;

    void Start()
    {
        value = maxValue;
    }

    void Update()
    {
        if (isPaused) return;

        if (holding)
        {
            value += fillSpeed * Time.deltaTime;
        }
        else
        {
            value -= drainSpeed * Time.deltaTime;
        }

        value = Mathf.Clamp(value, 0f, maxValue);

        if (fillImage != null)
        {
            fillImage.fillAmount = value / maxValue;
        }

        // Checks if boredom meter is 0 and calls LoseGame
        if (value <= 0)
        {
            LoseGame();
            return;
        }
    }

    public void SetHolding(bool state)
    {
        if (isPaused)
            holding = false;
        else
            holding = state;
    }

    public void SetPaused(bool state)
    {
        isPaused = state;

        if (isPaused)
        {
            holding = false;
        }
    }

    // Creates LoseGame function and displays game over screen
    void LoseGame()
    {
        if (losingScreen != null)
        {
            losingScreen.SetActive(true);
            
            losingScreen.GetComponentInChildren<TMP_Text>().text = "You got too bored and fell asleep";
        }
            

        Time.timeScale = 0f;
    }
}