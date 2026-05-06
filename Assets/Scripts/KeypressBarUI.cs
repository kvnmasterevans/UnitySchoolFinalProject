using UnityEngine;
using UnityEngine.UI;

public class KeypressBarUI : MonoBehaviour
{
    public KeystrokeCounter counter;
    public Image bar;
    public int maxKeyPresses = 100;

    public GameObject winningScreen;

    private bool gameWon = false;

    void Start()
    {
        Time.timeScale = 1f;

        if (winningScreen != null)
            winningScreen.SetActive(false);

        if (bar != null)
            bar.fillAmount = 0f;
    }

    void Update()
    {
        if (counter == null || bar == null || gameWon) return;

        float normalized = (float)counter.keyPressCount / maxKeyPresses;
        bar.fillAmount = Mathf.Clamp01(normalized);

        if (counter.keyPressCount >= maxKeyPresses)
        {
            gameWon = true;
            WinGame();
        }
    }

    void WinGame()
    {
        if (winningScreen != null)
            winningScreen.SetActive(true);

        Time.timeScale = 0f;
    }
}