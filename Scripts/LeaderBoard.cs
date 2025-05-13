using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LeaderBoard : MonoBehaviour
{
    public GameObject leaderboardPanel;
    public TextMeshProUGUI[] leaderboardTexts; 
    public TextMeshProUGUI[] leaderboardScoreText;
    private List<LeaderboardEntry> leaderboard = new List<LeaderboardEntry>();

    [System.Serializable]
    public class LeaderboardEntry
    {
        public string name;
        public int score;
    }

    [System.Serializable]
    private class Wrapper
    {
        public List<LeaderboardEntry> list;
    }

    private void Start()
    {
        //ClearLeaderboard();
        LoadLeaderboard();
        DisplayLeaderboard();
    }

    public void ClearLeaderboard()
    {
        // Clear the in-memory list
        leaderboard.Clear();

        // Delete the leaderboard JSON
        PlayerPrefs.DeleteKey("Leaderboard");

        // (Optional) If you're still storing individual names/scores — delete them
        for (int i = 0; i < 5; i++)
        {
            PlayerPrefs.DeleteKey("PlayerName" + i);
            PlayerPrefs.DeleteKey("PlayerScore" + i);
        }

        PlayerPrefs.Save();

        // Refresh the leaderboard display
        DisplayLeaderboard();
    }



    public void LoadLeaderboard()
    {
        string json = PlayerPrefs.GetString("Leaderboard", "");
        if (!string.IsNullOrEmpty(json))
        {
            leaderboard = JsonUtility.FromJson<Wrapper>(json).list;
        }
    }

    public void SaveLeaderboard()
    {
        Wrapper wrapper = new Wrapper();
        wrapper.list = leaderboard;
        PlayerPrefs.SetString("Leaderboard", JsonUtility.ToJson(wrapper));
    }

    public void AddEntry(string name, int score)
    {
        leaderboard.Add(new LeaderboardEntry { name = name, score = score });
        leaderboard.Sort((a, b) => b.score.CompareTo(a.score)); // Descending
        if (leaderboard.Count > 5) leaderboard.RemoveAt(5); // Top 5 only
        SaveLeaderboard();
    }

    public bool IsHighScore(int score)
    {
        if (leaderboard.Count < 5) return true;
        return score > leaderboard[leaderboard.Count - 1].score;
    }

    public void DisplayLeaderboard()
    {
        for (int i = 0; i < leaderboardTexts.Length; i++)
        {
            if (i < leaderboard.Count)
            {
                leaderboardTexts[i].text = (i + 1) + "\t\t\t" + leaderboard[i].name;
                leaderboardScoreText[i].text = leaderboard[i].score.ToString();
            }
            else
            {
                leaderboardTexts[i].text = $"{i + 1}. ---";
                leaderboardScoreText[i].text = "---";
            }
        }
    }

    public void ShowLeaderboard()
    {
        leaderboardPanel.SetActive(true);
        DisplayLeaderboard();
    }

    public void HideLeaderboard()
    {
        leaderboardPanel.SetActive(false);

    }
}
