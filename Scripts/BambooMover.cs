using System;
using UnityEngine;

public class BambooMover : MonoBehaviour
{
    public float moveSpeed = 1.4f;
    private bool isgameOver = false;

    private void Update()
    {
        if (isgameOver) 
        {   
            return; 
        }
        else 
        { 
            transform.position += Vector3.left * moveSpeed * Time.deltaTime;
        }

        if (transform.position.x < -14.5)
        {
            Debug.Log("Bamboo destroy");

            Destroy(gameObject);
        }
    }

    public void stopMovingBamboo()
    {
        isgameOver = true;
    }

}
