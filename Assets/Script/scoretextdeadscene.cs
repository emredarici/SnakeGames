using UnityEngine;
using TMPro;
using System.Collections;
public class scoretextdeadscene : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI dsScoreText;
    private int currentScore = 0;

    public int dsScore;
    void Start()
    {
        dsScore = PlayerPrefs.GetInt("Score");
    }

    void Update()
    {
        scoreUpdate();


    }
    void scoreUpdate()
    {
        if (dsScore >= currentScore)
        {
            StartCoroutine(scoreUp());

        }
        else if (dsScore == 0)
        {
            currentScore = 0;
        }

    }
    public IEnumerator scoreUp()
    {
        currentScore += 1;
        dsScoreText.text = "SCORE: " + currentScore;
        Debug.Log(currentScore);
        yield return new WaitForSeconds(2);
    }
}
