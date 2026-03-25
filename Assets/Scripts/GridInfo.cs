using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GridInfo : MonoBehaviour
{
    public static GridInfo instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public bool hasGrid;
    public List<InfoRow> theGrid;

    public void CreateGrid()
    {
        hasGrid = true;

        for(int y = 0; y < GridController.instance.blockRows.Count; y++)
        {
            theGrid.Add(new InfoRow());

            // 조건문 : 해당 행 내의 블록 목록을 살펴보고 얼마나 많은 블록이 있는 지 확인
            for(int x = 0; x < GridController.instance.blockRows[y].blocks.Count; x++)
            {
                theGrid[y].blocks.Add(new BlockInfo());
            }
        }
    }

    public void UpdateInfo(GrowBlock theBlock, int xPos, int yPos)
    {
        theGrid[yPos].blocks[xPos].currentStage = theBlock.currentStage;
        theGrid[yPos].blocks[xPos].isWatered = theBlock.isWatered;
        theGrid[yPos].blocks[xPos].cropType = theBlock.cropType;
        // 해당 로직을 CropController에서 사용하지 않는 이유는 계산을 더 빨리 하기 위함
        theGrid[yPos].blocks[xPos].growFailChance = theBlock.growFailChance;
    }

    public void GrowCrop()
    {
        for(int y = 0; y < theGrid.Count; y++)
        {
            for(int x = 0; x < theGrid[y].blocks.Count; x++)
            {
                if (theGrid[y].blocks[x].isWatered == true)
                {
                    float growFailTest = Random.Range(0f, 100f);

                    if (growFailTest > theGrid[y].blocks[x].growFailChance)
                    {
                        switch (theGrid[y].blocks[x].currentStage)
                        {
                            case GrowBlock.GrowthStage.planted:

                                theGrid[y].blocks[x].currentStage = GrowBlock.GrowthStage.growing1;

                                break;
                            case GrowBlock.GrowthStage.growing1:

                                theGrid[y].blocks[x].currentStage = GrowBlock.GrowthStage.growing2;

                                break;
                            case GrowBlock.GrowthStage.growing2:

                                theGrid[y].blocks[x].currentStage = GrowBlock.GrowthStage.ripe;

                                break;
                        }
                    }
                    // 작물 성장 후 물뿌림 상태 초기화 -> 연속 성장을 막기 위함
                    theGrid[y].blocks[x].isWatered = false;
                }

                // 당일에 경작한 땅에 어떤 작물을 심지않거나 물을 주지 않은경우 다음날 일반땅으로 초기화
                if (theGrid[y].blocks[x].currentStage == GrowBlock.GrowthStage.ploughed)
                {
                    theGrid[y].blocks[x].currentStage = GrowBlock.GrowthStage.barren;
                }
            }
        }
    }

    /*
    private void Update()
    {
        if(Keyboard.current.yKey.wasPressedThisFrame)
            GrowCrop();
    }
    */
}

[System.Serializable]
public class BlockInfo
{
    public bool isWatered;
    public GrowBlock.GrowthStage currentStage;
    public CropController.CropType cropType;
    public float growFailChance;
}

[System.Serializable]
public class InfoRow
{
    public List<BlockInfo> blocks = new List<BlockInfo>();
}
