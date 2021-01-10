using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private PlayerMove playerMove;
    private PlayerAttack playerAttack;

    private float h;

    public bool canJump = false;
    //public bool canJumpMy { get { return canJump; } }

    public bool isFlip = false;
    //public bool isFlipMy { get { return isFlip; } }

    // Start is called before the first frame update
    void Start()
    {
        playerMove = GetComponent<PlayerMove>();   
    }

    // Update is called once per frame
    void Update()
    {
        MovementInput();

        //움직임체크하는 인풋
        //점프 대쉬 더블점프 움직임 이동

        //공격 체크해주는 인풋
        //스킬공격 기본공격 연속공격

        //상호작용 체크해주는 인풋
        //스페이스 바 / 상자 밀기
    }
    
    private void FixedUpdate()
    {
        playerMove.Move(h);
    }

    ////////////////////////////////////////////////////////////////////////////////////////////

    private void MovementInput()
    {
        // if (can move == true)
        //     playerMovement.move();

        h = Input.GetAxisRaw("Horizontal");

        if(h==-1)
        {
            isFlip = true;
        }

        // if(can jump == true)
        //    playerMovement.jump();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            canJump = true;
        }

        /*if(canJump == true)
        {
            playerMove.Jump();
        }*/
    }

    private void AttackInput()
    {
        // if (can attack == true)점프공격 가능
        //    playerAttack.Attack();

        // if (can skillAttack == true)
        //    playerAttack.skillAttack();

        /*if (Input.GetKeyDown(KeyCode.Z))
        {
            playerAttack.Attack();
        }*/
    }

     private void InteractionInput()
    {
        // if(can inter == true)
        //     대화시작, 채집, 채광
    }
}
