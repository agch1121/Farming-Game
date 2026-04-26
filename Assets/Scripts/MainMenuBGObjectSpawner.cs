using UnityEngine;

public class MainMenuBGObjectSpawner : MonoBehaviour
{
    public Transform minPos, maxPos;

    public GameObject[] objects;

    public float timeBetweenSpawns;
    private float spawnCounter;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        spawnCounter -= Time.deltaTime;
        if (spawnCounter <= 0)
        {
            spawnCounter = timeBetweenSpawns; // 스폰 카운터 재설정

            // 랜덤 작물 중 하나 골라서 생성
            GameObject newObject = Instantiate(objects[Random.Range(0, objects.Length)]);

            newObject.transform.position = new Vector3(Random.Range(minPos.position.x, maxPos.position.x), minPos.position.y, 0f);
            newObject.SetActive(true);
        }
    }
}
