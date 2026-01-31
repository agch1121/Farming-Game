using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Transform target;

    public Transform clampMin, clampMax;
    private Camera cam;
    private float halfWidth, halfHeight;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        target = FindAnyObjectByType<PlayerController>().transform;

        clampMin.SetParent(null);
        clampMax.SetParent(null);

        cam = GetComponent<Camera>();

        halfHeight = cam.orthographicSize; //orthorgraphicSize : 2D 카메라 화면 크기
        halfWidth = cam.orthographicSize * cam.aspect; // aspect : 게임 내 화면의 종횡비 ex) 16:9
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);

        Vector3 clampedPosition = transform.position;

        clampedPosition.x = Mathf.Clamp(clampedPosition.x, clampMin.position.x + halfWidth, clampMax.position.x - halfWidth);
        clampedPosition.y = Mathf.Clamp(clampedPosition.y, clampMin.position.y + halfHeight, clampMax.position.y - halfHeight);

        transform.position = clampedPosition;
    }
}
