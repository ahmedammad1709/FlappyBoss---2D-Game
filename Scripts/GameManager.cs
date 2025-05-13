using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
//using static UnityEngine.Rendering.DebugUI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Button pauseButton;
    [SerializeField] private Button resumeButton;
    [SerializeField] private Button replayButton;
    [SerializeField] private GameObject gameOverWindow;
    [SerializeField] private GameObject leaderBoard;
    [SerializeField] private GameObject leaderBoardInput;
    [SerializeField] private TMP_InputField nameInputField;
    public BackgroundMover[] backgroundMovers;

    int myScore;

    private void Start()
    {
        gameOverWindow.SetActive(false);
        leaderBoardInput.SetActive(false);
        leaderBoard.SetActive(false);
    }

    public void show_Leaderboard()
    {
        leaderBoard.SetActive(true);
        gameOverWindow.SetActive(false);
        leaderBoardInput.SetActive(false);
    }
    public void close_Leaderboard()
    {
        leaderBoard.SetActive(false);
        gameOverWindow.SetActive(true);
        leaderBoardInput.SetActive(false);
    }

    public void gameOver()
    {
        FindFirstObjectByType<BambooSpawner>().StopSpawning();
        FindFirstObjectByType<Audios>().playerDeadAudio();  // for Player dead voice 
        //Stops all the bamboos
        BambooMover[] movers = Object.FindObjectsOfType<BambooMover>();
        foreach (BambooMover mover in movers)
        {
            mover.stopMovingBamboo();
        }

        Player score = FindFirstObjectByType<Player>();
        LeaderBoard board = FindFirstObjectByType<LeaderBoard>();
        myScore = score.playerScore;

        if (board.IsHighScore(myScore))
        {
            leaderBoardInput.SetActive(true);
        }


        //checkHighScore();

        gameOverWindow.SetActive(true);
        FindFirstObjectByType<GameOverWindow>().displayYourScore();
        resumeButton.gameObject.SetActive(false);
        pauseButton.gameObject.SetActive(false);
        replayButton.gameObject.SetActive (false);

        foreach (var mover in backgroundMovers)
        {
            mover.stopBackground();
        }
    }

    public void LeaderBoardInput_SubmitButton()
    {
       
        string playerName = nameInputField.text;
        string formattedName;

        if (string.IsNullOrEmpty(playerName))
        {
            formattedName = "Player  "; // Exactly 8 characters
        }
        else if (playerName.Length >= 12)
        {
            formattedName = playerName.Substring(0, 12); // Trim to 8
        }
        else
        {
            formattedName = playerName;
        }

        LeaderBoard board = FindFirstObjectByType<LeaderBoard>();
        board.AddEntry(formattedName, myScore);
        board.ShowLeaderboard();
        gameOverWindow.SetActive(false);
        //FindFirstObjectByType<GameOverWindow>().removeRestartButton();
        leaderBoardInput.SetActive(false);

    }


    //Logic for high Score + LeaderBoard

    

    //void checkHighScore()
    //{
    //    int highScore = PlayerPrefs.GetInt("HighScore", 0);
    //    Player score = FindFirstObjectByType<Player>();
    //    if (score.playerScore > highScore)
    //    {
    //        highScore = score.playerScore;
    //        PlayerPrefs.SetInt("HighScore", highScore);
    //        Debug.Log("High Score : " + highScore);
    //    }
    //}

}
