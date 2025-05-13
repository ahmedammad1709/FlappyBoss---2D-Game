using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    public GameObject[] player;

    private void Start()
    {
        int index = PlayerPrefs.GetInt("SelectedPlayer", 0);
        Instantiate(player[index]);
    }
   
}
