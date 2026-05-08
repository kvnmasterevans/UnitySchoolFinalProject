using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class ButtonHoverHighligh : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] TMP_Text buttonText;

    [SerializeField] Color normalColor = Color.white;
    [SerializeField] Color hoverColor = Color.yellow;

    public void OnPointerEnter(PointerEventData eventData)
    {
        buttonText.color = hoverColor;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        buttonText.color = normalColor;
    }
}