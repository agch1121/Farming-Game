using System.Collections.Generic;
using UnityEngine;

public class GridController : MonoBehaviour
{
    public static GridController instance;

    private void Awake()
    {
        instance = this;
    }

    public Transform minPoint, maxPoint;
    public GrowBlock baseGridBlock;

    private Vector2Int gridSize; // Vector2의 x, y값을 정수값만 저장함
    public List<BlockRow> blockRows = new List<BlockRow>();

    public LayerMask gridBlockers;

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
            blockRows.Add(new BlockRow());
            for (int x = 0; x < gridSize.x; x++)
            {
                GrowBlock newBlock = Instantiate(baseGridBlock, startpoint + new Vector3(x, y, 0f), Quaternion.identity);

                newBlock.transform.SetParent(transform);
                newBlock.theSR.sprite = null;

                newBlock.SetGridPosition(x, y);

                blockRows[y].blocks.Add(newBlock);

                // 검사 박스 크기를 0.9로 하는 이유는 약간의 버퍼 공간을 생성해 가장자리에 걸쳐진 영역에 블록이 자라지 않는 문제를 방지를 위함
                if (Physics2D.OverlapBox(newBlock.transform.position, new Vector2(.9f, .9f), 0f, gridBlockers))
                {
                    newBlock.theSR.sprite = null;
                    newBlock.preventUse = true;
                } 
            }
        }

        if(GridInfo.instance.hasGrid == false)
        {
            GridInfo.instance.CreateGrid();
        }

        baseGridBlock.gameObject.SetActive(false);
    }

    public GrowBlock GetBlock(float x, float y)
    {
        x = Mathf.RoundToInt(x);
        y = Mathf.RoundToInt(y);

        x -= minPoint.position.x;
        y -= minPoint.position.y;

        // 목록 인덱스로 float값을 사용할 수 없으므로 int 값으로 치환
        int intX = Mathf.RoundToInt(x);
        int intY = Mathf.RoundToInt(y);

        if (intX < gridSize.x && intY < gridSize.y)
        {
            return blockRows[intY].blocks[intX];
        }

        return null;
    }
}

[System.Serializable] // 직렬화 설정 => 없으면 인스펙터 창에 해당 클래스를 사용한 배열 확인 불가
public class BlockRow
{
    public List<GrowBlock> blocks = new List<GrowBlock>();
}
