using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void exit()
    {
        Application.Quit();
    }

    public void play()
    {
        SceneManager.LoadScene("Game");
    }
}
