
using UnityEngine;

public class foodScript : MonoBehaviour
{
    public BoxCollider2D foodArea;
    private void Start()
    {
        RandomPosition();
    }
    private void RandomPosition()
    {
        Bounds bounds = this.foodArea.bounds;
        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = Random.Range(bounds.min.y, bounds.max.y);

        this.transform.position = new Vector2(Mathf.Round(x), Mathf.Round(y));
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Snake")
        {
            RandomPosition();
        }
    }
}
