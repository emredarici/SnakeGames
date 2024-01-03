using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class snakeMove : MonoBehaviour
{
    private Vector2 direction = Vector2.right;
    private List<Transform> segments = new List<Transform>();
    public Transform segmentPrefab;
    scoreSystem score;
    public GameObject gameOver;

    void Start()
    {
        score = GameObject.Find("GameManager").GetComponent<scoreSystem>();
        segments.Add(this.transform);
        PlayerPrefs.SetInt("Score", score.score);

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            direction = Vector2.up;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            direction = Vector2.down;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            direction = Vector2.right;
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            direction = Vector2.left;
        }
    }
    private void FixedUpdate()
    {
        this.transform.position = new Vector2(Mathf.Round(this.transform.position.x) + direction.x, Mathf.Round(this.transform.position.y) + direction.y);

        for (int i = segments.Count - 1; i > 0; i--)
        {
            segments[i].position = segments[i - 1].position;
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "RedLine")
        {
            direction = new Vector2(0f, 0f);
            SceneManager.LoadScene("DeadScene");
        }

    }
    private void Grow()
    {
        Transform segment = Instantiate(this.segmentPrefab);
        segment.position = segments[segments.Count - 1].position;
        segments.Add(segment);
        score.score++;
        PlayerPrefs.SetInt("Score", score.score);


    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Food")
        {
            Grow();

        }

    }
}

