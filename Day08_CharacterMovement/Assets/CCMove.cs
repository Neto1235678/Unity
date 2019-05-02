using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCMove : MonoBehaviour
{
    public float moveSpeed = 8f;
    public float jumpHeight = 2f;
    public LayerMask groundMask;
    public Transform groundCheck;

    CharacterController cc;
    Vector3 velocity;
    [SerializeField]
    bool isGround = false;

    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        isGround = Physics.CheckSphere(groundCheck.position, 0.5f, groundMask, QueryTriggerInteraction.Ignore);
        if(isGround && velocity.y < 0)
        {
            velocity.y = 0f;
        }

        Vector3 move = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        move = move.normalized;
        cc.Move(move * Time.deltaTime * moveSpeed);
        if (move != Vector3.zero)
            transform.forward = move;

        if (Input.GetButtonDown("Jump") && isGround)
            velocity.y += Mathf.Sqrt(jumpHeight * -2f * Physics.gravity.y);

        velocity.y += Physics.gravity.y * Time.deltaTime;// 중력적용
        cc.Move(velocity * Time.deltaTime);
    }

    // p(i + 1) = p(i) + v(i + 1) * dt // 속도의 정의
    // v(i+1) = v(i) + a(i+1) * dt // 가속도의 정의
    // a(i+1) = F(i+1) / m      : F = m * a     => F = m * g


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawSphere(groundCheck.position, 0.5f);
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        var h = hit.gameObject.GetComponent<HealingPlatform>();
        if (h != null)
            GetComponent<HealOverTime>().Heal();
    }
}


// CC 캐릭터 45도 넘어가면 미끄러지게
// RB 미끌리는건 막는거. 둘다 같이. 45도 넘어가면 미끌리게