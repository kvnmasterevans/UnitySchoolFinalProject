using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Cody : MonoBehaviour
{
    [SerializeField] int codyAILevel = 2;
    [SerializeField] GameObject codySprite;
    [SerializeField] GameObject doorSprite;
    [SerializeField] GameObject laptopButton;
    [SerializeField] BarDecrease boredomBar; //the boredom meter
    

    [SerializeField] GameObject doorView;
    [SerializeField] GameObject laptopView;
    [SerializeField] GameObject phoneView;

    [SerializeField] float codyMovementOpportunity = 4f;
    [SerializeField] float inputTimeLimit = 5f;

    [SerializeField] TMPro.TMP_Text promptText;
    [SerializeField] Image codyTimerBar;

    KeystrokeCounter keystrokeCounter;

    private float codyCheckTimer;
    private float inputTimer;
    private char requiredLetter;
    private bool waitingForInput = false;

    private float currentTimer;

    // Lose game variable
    public GameObject losingScreen;

    private void Start()
    {
        keystrokeCounter = GetComponent<KeystrokeCounter>();
        codyCheckTimer = codyMovementOpportunity;
    }
    void Update()
    {
        if (waitingForInput)
        {
            HandleCodyInputTimer();
            return; // pauses the 4-second timer while Cody is shown
        }

        codyCheckTimer -= Time.deltaTime;

        if (codyCheckTimer < 0f)
        {
            codyCheckTimer = codyMovementOpportunity;
            CodyAppeared();
        }
    }

    void CodyAppeared()
    {
        if (codySprite.activeSelf)
            return;

        int roll = Random.Range(0, 11); // 0–10 inclusive

        Debug.Log("Rolled: " + roll + " | AI Level: " + codyAILevel);

        if (roll <= codyAILevel)
        {
            ShowCody();
        }
    }

    void ShowCody()
    {
        if (laptopView.activeSelf)
        {
            laptopView.SetActive(false);
        }

        if (phoneView.activeSelf)
        {
            phoneView.SetActive(false);
        }

        doorView.SetActive(true);
        codySprite.SetActive(true);
        doorSprite.SetActive(false);
        laptopButton.SetActive(false);
        boredomBar.SetPaused(true);
        keystrokeCounter.SetCountingEnabled(false);



        requiredLetter = (char)Random.Range(65, 91);

        inputTimer = inputTimeLimit;
        codyTimerBar.gameObject.SetActive(true);
        codyTimerBar.fillAmount = 1f;

        // Show prompt
        promptText.text = ""+ requiredLetter;
        promptText.gameObject.SetActive(true);

        waitingForInput = true;
        currentTimer = inputTimeLimit;
    }

    void HandleCodyInputTimer()
    {
        inputTimer -= Time.deltaTime;
        codyTimerBar.fillAmount = inputTimer / inputTimeLimit;

        if (inputTimer <= 0f)
        {
            Debug.Log("Too slow!");
            HideCody();
            // If input timer is 0 call LoseGame
            LoseGame();
            return;
        }

        if (Input.anyKeyDown)
        {
            string input = Input.inputString;

            if (!string.IsNullOrEmpty(input))
            {
                char pressed = char.ToUpper(input[0]);

                if (pressed == requiredLetter)
                {
                    HideCody();
                }
            }
        }
    }

    void HideCody()
    {
        codySprite.SetActive(false);
        doorSprite.SetActive(true);
        laptopButton.SetActive(true);
        codyTimerBar.gameObject.SetActive(false);
        boredomBar.SetPaused(false);
        waitingForInput = false;

        codyCheckTimer = codyMovementOpportunity; //resets cody's timer
    }

    // Creates LoseGame function and displays game over screen
    void LoseGame()
    {
        if (losingScreen != null)
        {
            losingScreen.SetActive(true);
            losingScreen.GetComponentInChildren<TMP_Text>().text = "Cody kicked you out";
        }
            

        Time.timeScale = 0f;
    }
}
