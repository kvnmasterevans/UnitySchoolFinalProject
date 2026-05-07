using UnityEngine;

public class KeystrokeCounter : MonoBehaviour
{
    public int keyPressCount = 0;

    [Header("Game State")]
    public bool canCountKeys = true;

    [Header("Audio")]
    public AudioSource audioSource;
    public AudioClip[] clackSounds;

    void Update()
    {
        if (canCountKeys)
        {
            CheckKeys();
        }
        else
        {
            if (audioSource != null && audioSource.isPlaying)
                audioSource.Pause();
        }
    }

    void CheckKeys()
    {
        bool validKeyHeld = false;

        foreach (KeyCode key in System.Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKey(key) && IsAllowedKey(key))
            {
                validKeyHeld = true;

                if (Input.GetKeyDown(key))
                {
                    keyPressCount++;
                    Debug.Log("Key presses: " + keyPressCount);
                }

                break;
            }
        }

        if (validKeyHeld)
        {
            if (audioSource != null && !audioSource.isPlaying)
            {
                if (audioSource.clip == null)
                    PlayClack();
                else
                    audioSource.UnPause();
            }
        }
        else
        {
            if (audioSource != null && audioSource.isPlaying)
                audioSource.Pause();
        }
    }

    void PlayClack()
    {
        if (clackSounds.Length == 0) return;

        int index = Random.Range(0, clackSounds.Length);

        audioSource.clip = clackSounds[index];
        audioSource.loop = true;
        audioSource.Play();
    }

    bool IsAllowedKey(KeyCode key)
    {
        if (key == KeyCode.Escape)
            return false;

        if (key >= KeyCode.F1 && key <= KeyCode.F12)
            return false;

        return true;
    }

    public void SetCountingEnabled(bool enabled)
    {
        canCountKeys = enabled;
    }
}