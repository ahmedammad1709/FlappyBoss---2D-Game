using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Buttons : MonoBehaviour
{
    [SerializeField] private Button pauseButton;
    [SerializeField] private Button resumeButton;
    [SerializeField] private GameObject pauseWindow;
    [SerializeField] private TextMeshProUGUI scoreText;
    bool isPause = false;
    private int currentScore;

    private void Start()
    {
        resumeButton.gameObject.SetActive(false);
        pauseButton.gameObject.SetActive(true);
        pauseWindow.SetActive(false);
        scoreText.text = "Score : 0";
    }

    public void updateScore(int score)
    {
        currentScore = score;
        scoreText.text = "Score : " + currentScore;
    }

    public int getCurrentScore()
    {
        return currentScore;
    }

    private void Update()
    {
        if (EventSystem.current.currentSelectedGameObject != null &&
        EventSystem.current.currentSelectedGameObject.GetComponent<TMP_InputField>() != null)
        {
            return;
        }

        if (Input.GetKey(KeyCode.Space))
        {
            resumeGame();
        }

        checkPause_Resume_Restart();
    }

    public void loadGamePlay()
    {
        SceneManager.LoadScene("GamePlay");
    }

    public void loadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void loadSelectPlayerScene()
    {
        FindFirstObjectByType<Audios>().ButtonClickAudio();
        SceneManager.LoadScene("Selectplayer");

    }

    public void pauseGame()
    {
        Time.timeScale = 0f;
        resumeButton.gameObject.SetActive(true);
        pauseButton.gameObject.SetActive(false);
        pauseWindow.SetActive(true);
    }

    public void resumeGame()
    {
        Time.timeScale = 1f;
        resumeButton.gameObject.SetActive(false);
        pauseButton.gameObject.SetActive(true);
        pauseWindow.SetActive(false);

    }

    void checkPause_Resume_Restart()
    {   
         
        if(Input.GetKeyDown(KeyCode.P))
        {
            if(!isPause)
            {
                pauseGame();
                isPause = true;
                FindFirstObjectByType<Audios>().ButtonClickAudio();
            }
            else
            {
                resumeGame();
                isPause = false;
                FindFirstObjectByType<Audios>().ButtonClickAudio();

            }
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            loadGamePlay();
        }
    }

    public void showLeaderBoard()
    {
        FindFirstObjectByType<GameManager>().show_Leaderboard();
        //FindFirstObjectByType<GameOverWindow>().removeRestartButton();

    }

    public void closeLeaderboard()
    {
        FindFirstObjectByType<GameManager>().close_Leaderboard();

    }

    public void submitHighScorer()
    {
        FindFirstObjectByType<GameManager>().LeaderBoardInput_SubmitButton();
    }

}
