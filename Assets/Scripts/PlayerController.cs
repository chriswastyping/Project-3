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

    // Jump Animation
    private Animator playerAnim;
    
    // Explosion Effects
    public ParticleSystem explosionParticle;

    // Dirt Particle
    public ParticleSystem dirtParticle;

    // Sound FX
    public AudioClip jumpSound;
    public AudioClip crashSound;
    private AudioSource playerAudio;

    // Start is called before the first frame update
    void Start()
    {
        // Physics of the jump
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
        // Jump Animation
        playerAnim = GetComponent<Animator>();
        //Sound FX
        playerAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // Spacebar to jump
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse); 
            isOnGround = false;
            // Jump Animation, calling the parameter
            playerAnim.SetTrigger("Jump_trig");
            // Dirt
            dirtParticle.Stop();
            // Sound FX JUMP
            playerAudio.PlayOneShot(jumpSound, 1.0f);
        }
    }

    private void OnCollisionEnter(Collision collision) 
    {
           
        // Game Over

        if(collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            dirtParticle.Play();

        } else if(collision.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
            Debug.Log("Game Over");
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            explosionParticle.Play();
            dirtParticle.Stop();
            playerAudio.PlayOneShot(crashSound, 1.0f);
        }
    }
}
