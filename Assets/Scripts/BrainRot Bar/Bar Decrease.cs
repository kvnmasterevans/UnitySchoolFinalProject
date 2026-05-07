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


    void Start()
    {
        value = maxValue;
    }

    void Update()
    {
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
        holding = state;
    }
}