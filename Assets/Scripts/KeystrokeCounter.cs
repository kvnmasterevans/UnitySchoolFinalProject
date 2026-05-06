using UnityEngine;

public class KeystrokeCounter : MonoBehaviour
{
    public int keyPressCount = 0;

    [Header("Audio")]
    public AudioSource audioSource;
    public AudioClip[] clackSounds; // drag your 9 clips here

    void Update()
    {
        if (Input.anyKeyDown)
        {
            // Optional: filter out keys you don't want
            if (IsValidKey())
            {
                keyPressCount++;
                PlayClack();
                Debug.Log("Key presses: " + keyPressCount);
            }
        }
    }


    void PlayClack()
    {
        // Don't start a new sound if one is already playing
        if (audioSource.isPlaying) return;

        if (clackSounds.Length == 0) return;

        int index = Random.Range(0, clackSounds.Length);
        audioSource.clip = clackSounds[index];
        audioSource.Play();
    }



    bool IsValidKey()
    {
        // Block Escape
        if (Input.GetKeyDown(KeyCode.Escape))
            return false;

        // Block F1–F12
        for (int i = (int)KeyCode.F1; i <= (int)KeyCode.F12; i++)
        {
            if (Input.GetKeyDown((KeyCode)i))
                return false;
        }

        return true;
    }
}
