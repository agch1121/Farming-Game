using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopSeedDisplay : MonoBehaviour
{
    public CropController.CropType crop;

    public Image seedImage;
    public TMP_Text seedAmount, priceText;

    public void UpdateDisplay()
    {
        CropInfo info = CropController.instance.GetCropInfo(crop);

        seedImage.sprite = info.seedType;
        seedAmount.text = "x" + info.seedAmount;

        priceText.text = "$" + info.seedPrice + " each";
    }

    public void BuySeed(int amount)
    {
        CropInfo info = CropController.instance.GetCropInfo(crop);

        // 현재 구매하려는 씨앗의 개수만큼 돈이 있는지 확인
        if (CurrencyController.instance.CheckMoney(info.seedPrice * amount))
        {
            CropController.instance.AddSeed(crop, amount);

            CurrencyController.instance.SpendMoney(info.seedPrice * amount);

            UpdateDisplay();

            AudioManager.instance.PlaySFXPitchAdjusted(5);
        }
    }
}
