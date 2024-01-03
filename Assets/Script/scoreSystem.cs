using UnityEngine;
using TMPro;


public class scoreSystem : MonoBehaviour
{

    public int score;
    public TextMeshProUGUI scoreText;
    void Update()
    {
        scoreText.text = "SCORE:" + score;
    }
}
