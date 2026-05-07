using UnityEngine;
using UnityEngine.EventSystems;

public class Hold2Fill : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public BarDecrease barDecrease;

    public void OnPointerDown(PointerEventData eventData)
    {
        barDecrease.SetHolding(true);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        barDecrease.SetHolding(false);
    }
}