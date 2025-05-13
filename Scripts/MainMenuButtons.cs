using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour
{
    public GameObject settingWindow;

    private void Start()
    {
        settingWindow.SetActive(false);
    }

    public void playGame()
    {
        //FindFirstObjectByType<Audios>().ButtonClickAudio();

        SceneManager.LoadScene("SelectPlayer");
    }

    public void quitGame()
    {
        Debug.Log("Application Quit !");
        Application.Quit();
    }

    public void openSetting()
    {
        settingWindow.SetActive(true);
    }

    public void closeSetting()
    {
        settingWindow.SetActive(false);
    }

   
}
