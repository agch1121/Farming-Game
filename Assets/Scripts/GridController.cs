using UnityEngine;

public class GridController : MonoBehaviour
{
    public Transform minPoint, maxPoint;
    public GrowBlock baseGridBlock;

    private Vector2Int gridSize; // Vector2의 x, y값을 정수값만 저장함

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GenerateGrid();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GenerateGrid()
    {
        minPoint.position = new Vector3(Mathf.Round(minPoint.position.x), Mathf.Round(minPoint.position.y), 0f);
        maxPoint.position = new Vector3(Mathf.Round(maxPoint.position.x), Mathf.Round(maxPoint.position.y), 0f);

        Vector3 startpoint = minPoint.position + new Vector3(.5f, .5f, 0f);

        //Instantiate(baseGridBlock, startpoint, Quaternion.identity); // Quaternion.identity : 벡터 회전값을 0으로 초기화

        gridSize = new Vector2Int(Mathf.RoundToInt(maxPoint.position.x - minPoint.position.x),
            Mathf.RoundToInt(maxPoint.position.y - minPoint.position.y));

        for (int y = 0; y < gridSize.y; y++)
        {
            for (int x = 0; x < gridSize.x; x++)
            {
                GrowBlock newBlock = Instantiate(baseGridBlock, startpoint + new Vector3(x, y, 0f), Quaternion.identity);

                newBlock.transform.SetParent(transform);
            }
        }

        baseGridBlock.gameObject.SetActive(false);
    }
}
