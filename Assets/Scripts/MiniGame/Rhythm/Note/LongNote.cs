using UnityEngine;

public class LongNote : Note
{
    [SerializeField] private float requiredHoldTime = 1.5f;
    private float holdTimer = 0f;
    private bool inJudgeZone = false;

     void Start()
    {
        float noteLength = fallSpeed * requiredHoldTime;

        Vector3 scale = transform.localScale;
        scale.y = noteLength;
        transform.localScale = scale;

        Vector3 pos = transform.position;
        pos.y = transform.position.y + noteLength / 2f;
        transform.position = pos;

    }

    protected override void Update()
    {
        base.Update();
        if (inJudgeZone)
        {
            var player = FindObjectOfType<PlayerState>();
            if (player != null && player.isSmiling)
            {
                holdTimer += Time.deltaTime;
                if (holdTimer >= requiredHoldTime)
                {
                    Debug.Log("Good (LongNote)");
                    Destroy(gameObject);
                }
            }
            else
            {
                holdTimer = 0f;
            }
        }

    }

    protected override void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("JudgeLine"))
        {
            inJudgeZone = true;
        }
    }

    protected override void OnTriggerExit2D(Collider2D other)
    {
        base.OnTriggerExit2D(other);
        if (holdTimer < requiredHoldTime)
            Debug.Log("Miss (LongNote)");
    }

    public float GetrequiredHoldTime() => requiredHoldTime;
}
