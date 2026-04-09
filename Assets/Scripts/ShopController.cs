using UnityEngine;

public class ShopController : MonoBehaviour
{
    // 상점 창 열고 닫기 기능
    public void OpenClose()
    {
        // 인벤토리창이 꺼져있을때만 상점 창 열수 있음
        if (UIController.instance.theIC.gameObject.activeSelf == false)
        {
            gameObject.SetActive(!gameObject.activeSelf); // 이미 상점창이 켜져있다면 비활성화 시킴
        }
    }
    
}
