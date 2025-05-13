using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameOverWindow : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI yourScoretext;
    private int yourScore;

    public void displayYourScore()
    {
        //restartButtonTransform.localPosition = new Vector2 (3, -1);
        //Player score = FindFirstObjectByType<Player>();
        yourScore = FindFirstObjectByType<Buttons>().getCurrentScore();
        yourScoretext.text = "Your Score : " + yourScore;
    }
   
   
}
