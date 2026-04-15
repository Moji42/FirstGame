using UnityEngine;

public class GameManager : MonoBehaviour
{
    // vars

    // allows scripts to access the game manager from anywhere
    public static GameManager instance;

    // access the score text on screen
    public TMPro.TextMeshProUGUI scoreText;

    // curent score
    private int score = 0;

    // total crates in the scene
    public int totalCrates = 5;

    void Awake()
    {
        // if there is no instance of the game manager, set it to this one
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            // if there is already an instance, destroy this one
            Destroy(gameObject);
        }
    }

    public void AddScore()
    {
        score++;
        scoreText.text = "Score: " + score;

        if (score >= totalCrates)
        {
            scoreText.text = "You Win!";
        }
    }
}
