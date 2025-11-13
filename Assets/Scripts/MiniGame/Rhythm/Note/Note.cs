using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Note : MonoBehaviour
{
    [SerializeField] protected float fallSpeed = 3f;

    protected virtual void Update()
    {
        transform.Translate(Vector2.down * fallSpeed * Time.deltaTime);
    }

    public virtual float GetNoteLength()
    {
        return GetComponent<SpriteRenderer>().bounds.size.y;
    }

    protected virtual void OnTriggerEnter2D(Collider2D other) { }
    protected virtual void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("JudgeLine"))
        {
            Destroy(gameObject);
        }
    }

}
