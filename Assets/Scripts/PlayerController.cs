using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D theRB;
    public float moveSpeed;

    public InputActionReference moveInput;
    public Animator anim;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    void Awake()
    {
        // 게임이 시작될 때 이 액션을 사용하겠다고 선언
        moveInput.action.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        //theRB.linearVelocity = new Vector2(moveSpeed, 0f);
        theRB.linearVelocity = moveInput.action.ReadValue<Vector2>().normalized * moveSpeed;

        if (theRB.linearVelocity.x < 0f)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else if(theRB.linearVelocity.x > 0f)
        {
            transform.localScale = Vector3.one;
        }

            anim.SetFloat("speed", theRB.linearVelocity.magnitude);
    }
}
