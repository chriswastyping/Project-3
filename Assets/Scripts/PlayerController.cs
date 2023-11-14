using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    public float jumpForce = 10;
    public float gravityModifier = 10;
    
    // prevents double-jumping
    public bool isOnGround = true;

    // Game Over
    public bool gameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        // Physics of the jump
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        // Spacebar to jump
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse); 
            isOnGround = false;
        }
    }

    private void OnCollisionEnter(Collision collision) 
    {
           
        // Game Over

        if(collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;

        } else if(collision.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
            Debug.Log("Game Over");
            
        }
    }
}
