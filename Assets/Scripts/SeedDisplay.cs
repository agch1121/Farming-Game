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
        PlayerController.instance.SwitchSeed(crop); // 플레이어가 장착한 씨앗봉투 교체

        UIController.instance.SwitchSeed(crop); // UI툴바에 있는 씨앗봉투를 선택된 씨앗봉투로 교체

        UIController.instance.theIC.OpenClose(); // 씨앗 선택시 인벤토리창 자동으로 닫기
    }
}
