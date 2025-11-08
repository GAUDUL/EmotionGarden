using TMPro;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] private RectTransform canvasRect;
    [SerializeField] private GameObject positiveObj;
    [SerializeField] private GameObject negativeObj;
    [SerializeField] private WordData wordData;
    [SerializeField] private float spawnInterval = 1f;

    private float timer = 0f;

    void Start()
    {
        
    }

    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= spawnInterval)
        {
            SpawnWord();
            timer = 0f;
        }
    }
    
    void SpawnWord()
    {
        bool isPositive = Random.value > 0.5f;
        GameObject prefab = isPositive ? positiveObj : negativeObj;

        GameObject wordObj = Instantiate(prefab, canvasRect);
        RectTransform wordRect = wordObj.GetComponent<RectTransform>();

        float minX = -canvasRect.sizeDelta.x / 2 + wordRect.sizeDelta.x / 2;
        float maxX = canvasRect.sizeDelta.x / 2 - wordRect.sizeDelta.x / 2;
        float randomX = Random.Range(minX, maxX);
        wordRect.anchoredPosition =
            new Vector2(randomX, canvasRect.sizeDelta.y / 2 + wordRect.sizeDelta.y / 2);

        string word = isPositive ?
                        wordData.PositiveWords[Random.Range(0, wordData.PositiveWords.Count)] :
                        wordData.NegativeWords[Random.Range(0, wordData.NegativeWords.Count)];

        wordObj.GetComponentInChildren<TMP_Text>().text = word;

        FallingObject falling = wordObj.GetComponent<FallingObject>();
        falling.type = isPositive ? WordType.Positive : WordType.Negative;
    }
}
