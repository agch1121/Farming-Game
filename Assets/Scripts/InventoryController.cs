using UnityEngine;

public class InventoryController : MonoBehaviour
{

    public SeedDisplay[] seeds;
    public CropDisplay[] crops;

    public void OpenClose()
    {
        if (UIController.instance.theShop.gameObject.activeSelf == false)
        {
            if (gameObject.activeSelf == false) // 게임 오브젝트가 비활성화 상태일경우
            {
                gameObject.SetActive(true);

                UpdateDisplay();
            }
            else
            {
                gameObject.SetActive(false);
            }
        }
    }

    public void UpdateDisplay()
    {
        foreach (SeedDisplay seed in seeds)
        {
            seed.UpdateDisplay();
        }

        foreach (CropDisplay crop in crops)
        {
            crop.UpdateDisplay();
        }
    }
}
