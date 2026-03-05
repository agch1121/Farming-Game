using UnityEngine;
using UnityEngine.InputSystem;

public class GrowBlock : MonoBehaviour
{
    public enum GrowthStage
    {
        barren,
        ploughed,
        planted,
        growing1,
        growing2,
        ripe
    }

    public GrowthStage currentStage;
    public SpriteRenderer theSR;
    public Sprite soilTiled, soilWatered;

    public SpriteRenderer cropSR;
    public Sprite cropPlanted, cropGrowing1, cropGrowing2, cropRipe;

    public bool isWatered;

    public bool preventUse;

    private Vector2Int gridPosition;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Keyboard.current.eKey.wasPressedThisFrame)
        {
            AdvancedStage();

            SetSoilSprite();
        }*/
#if UNITY_EDITOR
        if (Keyboard.current.nKey.wasPressedThisFrame)
        {
            AdvanceCrop();
        }
    }
#endif
    public void AdvancedStage()
    {
        currentStage = currentStage + 1;

        if((int)currentStage >= 6)
        {
            currentStage = GrowthStage.barren;
        }
    }

    public void SetSoilSprite()
    {
        if(currentStage == GrowthStage.barren)
        {
            theSR.sprite = null;
        }
        else
        {
            if (isWatered)
            {
                theSR.sprite = soilWatered;
            }
            else
            {
                theSR.sprite = soilTiled;
            }
        }
        // 토양 상태 변화시 항상 SetSoilSprite()함수가 호출되므로 여기에 업데이트 함수를 선언해 단순화
        UpdateGridInfo();
    }

    public void PloughSoil()
    {
        if(currentStage == GrowthStage.barren && preventUse == false)
        {
            currentStage = GrowthStage.ploughed;

            SetSoilSprite();
        }
    }

    public void WaterSoil()
    {
        if (preventUse == false)
        {
            isWatered = true;

            SetSoilSprite();
        }
    }

    public void PlantCrop()
    {
        if(currentStage == GrowthStage.ploughed && isWatered && preventUse == false)
        {
            currentStage = GrowthStage.planted;

            UpdateCropSprite();
        }
    }

    void UpdateCropSprite()
    {
        switch (currentStage)
        {
            case GrowthStage.planted:
                cropSR.sprite = cropPlanted;
                break;

            case GrowthStage.growing1:
                cropSR.sprite = cropGrowing1;
                break;

            case GrowthStage.growing2:
                cropSR.sprite = cropGrowing2;
                break;

            case GrowthStage.ripe:
                cropSR.sprite = cropRipe;
                break;
        }

        UpdateGridInfo();
    }

    public void AdvanceCrop()
    {
        if (isWatered && preventUse == false)
        {
            if(currentStage == GrowthStage.planted || currentStage == GrowthStage.growing1 || currentStage == GrowthStage.growing2)
            {
                currentStage++;

                isWatered = false;
                SetSoilSprite();
                UpdateCropSprite();
            }
        }
    }

    public void HarvestCrop()
    {
        if(currentStage == GrowthStage.ripe && preventUse == false)
        {
            currentStage = GrowthStage.ploughed;

            SetSoilSprite();
            cropSR.sprite = null;
        }
    }

    public void SetGridPosition(int x, int y)
    {
        gridPosition = new Vector2Int(x, y);
    }

    void UpdateGridInfo()
    {
        GridInfo.instance.UpdateInfo(this, gridPosition.x, gridPosition.y);
    }
}
