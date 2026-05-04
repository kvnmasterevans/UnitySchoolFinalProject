using UnityEngine;
using UnityEngine.UI;

public class KeypressBarUI : MonoBehaviour
{
    public KeystrokeCounter counter;   // reference to your other script
    public Image bar;                 // the UI image
    public int maxKeyPresses = 100;

    void Update()
    {
        if (counter == null) return;

        float normalized = (float)counter.keyPressCount / maxKeyPresses;
        bar.fillAmount = Mathf.Clamp01(normalized);
    }
}
