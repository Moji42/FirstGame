using UnityEngine;

public class Collectible : MonoBehaviour
{
    // spin speed for visual flair
    public float spinSpeed = 90f;

    void Update()
    {
        // rotate the crate so it's obvious it's collectible
        transform.Rotate(0, spinSpeed * Time.deltaTime, 0);
    }

    void OnTriggerEnter(Collider other)
    {
        // check if the player touched it
        if (other.CompareTag("Player"))
        {
            // tell the game manager to add a point
            GameManager.instance.AddScore();

            // destroy this crate
            Destroy(gameObject);
        }
    }
}