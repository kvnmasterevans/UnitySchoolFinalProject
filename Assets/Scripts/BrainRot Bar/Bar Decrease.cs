using UnityEngine;

public class HoldMeter : MonoBehaviour
{
    public float value = 0f;
    public float maxValue = 2f;

    public float fillSpeed = 1f;
    public float drainSpeed = 0.5f;

    private bool holding = false;

    void Update()
    {
        if (holding)
            value += fillSpeed * Time.deltaTime;
        else
            value -= drainSpeed * Time.deltaTime;

        value = Mathf.Clamp(value, 0f, maxValue);
    }

    public void SetHolding(bool state)
    {
        holding = state;
    }

    public float GetFill()
    {
        return value / maxValue;
    }
}