using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SeedDisplay : MonoBehaviour
{
    public CropController.CropType crop;

    public Image seedImage;
    public TMP_Text seedAmount;

    public void UpdateDisplay()
    {
        CropInfo info = CropController.instance.GetCropInfo(crop);

        seedImage.sprite = info.seedType;
        seedAmount.text = "x" + info.seedAmount;
    }

    public void SelectSeed()
    {
        PlayerController.instance.SwitchSeed(crop); // ÇÃ·¹ÀÌ¾î°¡ ÀåÂøÇÑ ¾¾¾ÑºÀÅõ ±³Ã¼

        UIController.instance.SwitchSeed(crop); // UIÅø¹Ù¿¡ ÀÖ´Â ¾¾¾ÑºÀÅõ¸¦ ¼±ÅÃµÈ ¾¾¾ÑºÀÅõ·Î ±³Ã¼
    }
}
