using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteController : MonoBehaviour
{
    [SerializeField] private GameObject singleNotePrefab;
    [SerializeField] private GameObject longNotePrefab;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private float bpm = 80f;
    private float beatInterval;
    private float timer;    



    void Start()
    {
        beatInterval = 60f / bpm;
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= beatInterval)
        {
            timer -= beatInterval;
            SpawnNote();
        }
    }
    
    
    void SpawnNote()
    {
        bool isLong = Random.value < 0.3f;
        GameObject prefab = isLong ? longNotePrefab : singleNotePrefab;
        GameObject note = Instantiate(prefab, spawnPoint.position, Quaternion.identity);

        if (isLong)
        {
            LongNote ln = note.GetComponent<LongNote>();
            timer -= ln.GetrequiredHoldTime();
        }
    }

}
