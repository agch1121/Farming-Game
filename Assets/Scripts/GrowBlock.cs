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
    public Sprite soilTiled;

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
    }

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
            theSR.sprite = soilTiled;
        }
    }

    public void PloughSoil()
    {
        if(currentStage == GrowthStage.barren)
        {
            currentStage = GrowthStage.ploughed;

            SetSoilSprite();
        }
    }
}
