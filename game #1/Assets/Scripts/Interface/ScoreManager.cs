using UnityEngine.UI;
using UnityEngine;


public class ScoreManager : MonoBehaviour
{

    public int score;
    public Text scoreDisplay;
    

    public void Update()
    {
        scoreDisplay.text = "—чет:" + " " + score.ToString();
      
    
    }
    public void Kill()
    {

        score++;
    }
}
