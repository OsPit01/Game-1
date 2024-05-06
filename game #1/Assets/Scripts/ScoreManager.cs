using UnityEngine.UI;
using UnityEngine;
using Unity.VisualScripting;

public class ScoreManager : MonoBehaviour
{

    public int score;
    public Text scoreDisplay;
    private Enemy enemy;

    public void Update()
    {
        scoreDisplay.text = score.ToString();
    
    }
    public void DestroyUnitScore()
    {
       
       if (enemy.isDestroyed == true)
        {
            score++;
        }
    }
}
