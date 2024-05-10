
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    public Text score;
    public ScoreManager scoreManager;


    private void Start()
    {
        score.text = ("Your score:") + " " + scoreManager.score.ToString();
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}