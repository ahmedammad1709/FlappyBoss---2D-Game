using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D myBody;
    [SerializeField] private float jumpForce = 4f;

    bool isPlayerAlive = true;
    public int playerScore =0;


    private void Start()
    {
        myBody = GetComponent<Rigidbody2D>();
    }


    private void Update()
    {
        move();
    }

    void move()
    {
        if(Input.GetKey(KeyCode.UpArrow) || Input.touchCount >0 || Input.GetKey(KeyCode.Space) && isPlayerAlive)
        {
            myBody.linearVelocity = new Vector2(myBody.linearVelocity.x, jumpForce);
            //myBody.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bamboo"))
        {
            Debug.Log("Touched with bamboo");
            Destroy(gameObject);
            FindFirstObjectByType<GameManager>().gameOver();
        }
        if (collision.gameObject.CompareTag("Ground"))
        {
            Debug.Log("Touched with ground");
            Destroy(gameObject);
            FindFirstObjectByType<GameManager>().gameOver();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Score"))
        {
            playerScore++;
            FindFirstObjectByType<Buttons>().updateScore(playerScore);
        }
    }

}
