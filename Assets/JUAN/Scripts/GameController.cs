using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class GameController : MonoBehaviour
{
    Vector2 checkpointPos;
    Rigidbody2D playerRb;
    [SerializeField] private ParticleSystem testParticleSystem = default;
    [SerializeField] private AudioClip deathClip = default; // Audio clip for death sound
    

    private void Awake()
    {
        playerRb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        checkpointPos = transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle"))
        {
            Die();
        }

        if (collision.CompareTag("Octopus"))
        {
            Die();
        }
    }



    public void UpdateCheckpoint(Vector2 pos)
    {
        checkpointPos = pos;
    }

    void Die()
    {
        StartCoroutine(Respawn(1.5f));
        PlayDeathSound(); // Play the death sound
    }

    void PlayDeathSound()
    {
        if (deathClip != null)
        {
            AudioSource.PlayClipAtPoint(deathClip, transform.position);
        }
    }

    IEnumerator Respawn(float duration)
    {
        testParticleSystem.Play();
        playerRb.velocity = Vector2.zero;
        playerRb.simulated = false;


        transform.localScale = Vector3.zero;
        yield return new WaitForSeconds(duration);
        transform.position = checkpointPos;
        transform.localScale = Vector3.one;


        playerRb.simulated = true;
    }

}