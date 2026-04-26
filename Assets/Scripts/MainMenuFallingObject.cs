using UnityEngine;

public class MainMenuFallingObject : MonoBehaviour
{
    public float minFallSpeed = 2f, maxFallSpeed = 5f, minRotSpeed = -360f, maxRotSpeed = 360f;
    private float fallSpeed, rotSpeed;
    private float rotValue;

    public float destroyHeight = -6f; // 낙하 오브젝트가 파괴될 높이

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        fallSpeed = Random.Range(minFallSpeed, maxFallSpeed);
        rotSpeed = Random.Range(minRotSpeed, maxRotSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.down * fallSpeed * Time.deltaTime; // 매 프레임마다 조금씩 낙하속도 업데이트

        rotValue += rotSpeed * Time.deltaTime;
        transform.rotation = Quaternion.Euler(0f, 0f, rotValue);

        if (transform.position.y < destroyHeight)
        {
            Destroy(gameObject);
        }
    }
}
