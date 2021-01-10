using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private PlayerInput playerInput;

    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer spriteRenderer;

    //이동관련변수
    [SerializeField]
    private float speed;
    private Vector3 movement;

    [SerializeField]
    private float jumpPower;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        AnimationController();
        //애니메이션 관리
    }

    //////////////////////////////////////////////////////////////////////////////

    // 이동
    public void Move(float h) //h는 호라이젠탈 값
    {
        rb.velocity = new Vector2(speed * h, rb.velocity.y);
        /* movement.Set(h, 0, 0); //x,y,z 좌표를 첫번째 인수, 두번째 인수, 세번째 인수에 할당된 값에 따라 부여함
         movement = movement.normalized * speed * Time.deltaTime; //델타타임: 1초에 어느 방향으로 얼만큼 움직일거냐

         rb.MovePosition(this.transform.position + movement); //기존 위치에 movement만큼 더해 위치 설정*/

        //spriteRenderer.flipX = h == -1; //h값이 -1이면 X축방향으로 이미지 반전
    }

    public void Flip()
    {
        if (playerInput.isFlip == true)
        {
            spriteRenderer.flipX = false;
        }
    }



    //점프
    public void Jump()
    {
        if (playerInput.canJump == true)
        {
            rb.velocity = Vector2.up * jumpPower;
            /*rb.velocity = Vector2.zero; //점프 전 움직임 멈추기 0벡터
            Vector2 jumpVelocity = new Vector2(0, jumpPower); //jumpPower만큼 y축 좌표 이동

            rb.AddForce(jumpVelocity, ForceMode2D.Impulse); //즉각적으로 이동방향 반영*/
        }
    }

    //애니메이션 관리
    private void AnimationController()
    {
        if (rb.velocity.x != 0)
        {
            anim.SetBool("isWalking", true);
        }// 이동 에니메이션 실행 bool
        else
        {
            anim.SetBool("isWalking", false);
        }//이동 에니메이션 중지

        //만약 점프 실행 중일 경우
        //settrigger 실행*/
    }
}
