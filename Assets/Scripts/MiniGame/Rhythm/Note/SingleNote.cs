using UnityEngine;

public class SingleNote : Note
{
    private bool isHit = false;
    void Start()
    {
        float noteLength = GetComponent<SpriteRenderer>().bounds.size.y;

        Vector3 pos = transform.position;
        pos.y += noteLength / 2f;
        transform.position = pos;
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("JudgeLine") && !isHit)
        {
            var player = FindObjectOfType<PlayerState>();
            if (player != null && player.isSmiling)
            {
                Debug.Log("Good");
                isHit = true;
                Destroy(gameObject);
            }
        }
    }

    protected override void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("JudgeLine") && !isHit)
        {
            Debug.Log("Miss");
        }
        base.OnTriggerExit2D(other);
    }
}
