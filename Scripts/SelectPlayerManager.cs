using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectPlayerManager : MonoBehaviour
{
    public void player(int index)
    {
        PlayerPrefs.SetInt("SelectedPlayer", index);
        SceneManager.LoadScene("GamePlay");

    } 

    public void loadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
