using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public void PlayGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("LastMinuteEssay");
    }

    public void PlayAgain()
{
    Time.timeScale = 1f;
    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
}
    public void QuitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }
}