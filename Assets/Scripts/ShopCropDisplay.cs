using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopCropDisplay : MonoBehaviour
{
    public CropController.CropType crop;

    public Image cropImage;
    public TMP_Text amountText, priceText;

    public void UpdateDisplay()
    {
        CropInfo info = CropController.instance.GetCropInfo(crop);

        cropImage.sprite = info.finalCrop;
        amountText.text = "x" + info.cropAmount;

        priceText.text = "$" + info.cropPrice + " each";
    }

    public void SellCrop()
    {
        CropInfo info = CropController.instance.GetCropInfo(crop);

        if (info.cropAmount > 0)
        {
            // 현재 보유중인 개수만큼 작물 가격을 판 돈을 지급
            CurrencyController.instance.AddMoney(info.cropAmount * info.cropPrice);
            CropController.instance.RemoveCrop(crop);

            UpdateDisplay();
        }
    }
}
