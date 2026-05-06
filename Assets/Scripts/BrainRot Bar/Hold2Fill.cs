using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class HoldButtonUI : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [Header("UI")]
    public Image fillImage;

    [Header("Meter Settings")]
    public float value = 0f;
    public float maxValue = 2f;

    public float fillSpeed = 1f;
    public float drainSpeed = 0.5f;

    private bool holding = false;

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

    public void OnPointerDown(PointerEventData eventData)
    {
        holding = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        holding = false;
    }
}