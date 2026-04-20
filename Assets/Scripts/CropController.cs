using System.Collections.Generic;
using UnityEngine;

public class CropController : MonoBehaviour
{
    public static CropController instance;

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

    public enum CropType
    {
        pumpkin,
        lettuce,
        carrot,
        hay,
        potato,
        strawberry,
        tomato,
        avocado
    }

    public List<CropInfo> cropList = new List<CropInfo>();

    public CropInfo GetCropInfo(CropType cropToGet)
    {
        int position = -1;

        for (int i = 0; i < cropList.Count; i++)
        {
            if (cropList[i].cropType == cropToGet)
            {
                position = i;
            }
        }

        if(position >= 0)
        {
            return cropList[position];
        }
        else
        {
            return null;
        }
    }

    public void UseSeed(CropType seedToUse)
    {
        foreach(CropInfo info in cropList)
        {
            // 씨앗 심을시 갯수 1개 감소
            if(info.cropType == seedToUse)
            {
                info.seedAmount--;
            }
        }
    }

    public void AddCrop(CropType cropToAdd)
    {
        foreach (CropInfo info in cropList)
        {
            // 작물 추가시 갯수 1개 증가
            if (info.cropType == cropToAdd)
            {
                info.cropAmount++;
            }
        }
    }

    public void AddSeed(CropType SeedToAdd, int amount)
    {
        foreach(CropInfo info in cropList)
        {
            if(info.cropType == SeedToAdd)
            {
                info.seedAmount += amount;
            }
        }
    }

    public void RemoveCrop(CropType cropToRemove)
    {
        foreach (CropInfo info in cropList)
        {
            if (info.cropType == cropToRemove)
            {
                info.seedAmount = 0;
            }
        }
    }
}

[System.Serializable]
public class CropInfo
{
    public CropController.CropType cropType;
    public Sprite finalCrop, seedType, planted, growStage1, growStage2, ripe;

    public int seedAmount, cropAmount;

    // 작물의 성장 여부 확률
    [Range(0f, 100f)]
    public float growthFailChance;

    public float seedPrice, cropPrice;
}
