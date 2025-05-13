using UnityEngine;

public class BackgroundMover : MonoBehaviour
{
    public float speed = 2f;
    public float resetPositionX;
    public float startPositionX;
    bool isGameOver = false;

    void Update()
    {
        if (!isGameOver)
        {

            transform.Translate(Vector2.left * speed * Time.deltaTime);

            // Reset background position to loop
            if (transform.position.x <= resetPositionX)
            {
                transform.position = new Vector2(startPositionX, transform.position.y);
            }

        }
    }

    public void stopBackground()
    {
        isGameOver = true;
    }
}
