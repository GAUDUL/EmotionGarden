using UnityEngine;

public enum WordType { Positive, Negative }

public class FallingObject : MonoBehaviour
{
    public WordType type;
    [SerializeField] private float fallSpeed = 200f;

    private RectTransform rect;

    void Start()
    {
        rect = GetComponent<RectTransform>();
    }

    void Update()
    {
        rect.anchoredPosition += Vector2.down * fallSpeed * Time.deltaTime;

        if(rect.anchoredPosition.y < -rect.parent.GetComponent<RectTransform>().sizeDelta.y / 2 - rect.sizeDelta.y)
        {
            Destroy(gameObject);
        }
    }
}
