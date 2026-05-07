using UnityEngine;
using UnityEngine.UI;

public class BarDecrease : MonoBehaviour
{
    public Image fillImage;

    public float value = 2f;
    public float maxValue = 2f;

    public float fillSpeed = 1f;
    public float drainSpeed = 0.5f;

    private bool holding = false;

    public bool isPaused = false; //draining is paused when cody is on screen


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
}