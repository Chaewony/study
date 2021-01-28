using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private PlayerMove playerMove;
    private PlayerAttack playerAttack;
    private PlayerInteraction playerInteraction;
    
    [SerializeField]
    private Collider2D attackCol; //칼 콜리더

    private float h;

    // Start is called before the first frame update
    void Start()
    {
        playerMove = GetComponent<PlayerMove>();
        playerAttack = GetComponent<PlayerAttack>();
        playerInteraction = GetComponent<PlayerInteraction>();   
        attackCol.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        MovementInput();
        AttackInput();
        InteractionInput();

        //움직임체크하는 인풋
        //점프 대쉬 더블점프 움직임 이동

        //공격 체크해주는 인풋
        //스킬공격 기본공격 연속공격

        //상호작용 체크해주는 인풋
        //스페이스 바 / 상자 밀기
    }

    private void FixedUpdate()
    {
        playerMove.Move(h); //좌우 이동
    }

    ////////////////////////////////////////////////////////////////////////////////////////////

    private void MovementInput()
    {
        h = Input.GetAxisRaw("Horizontal");

        if (Input.GetKeyDown(KeyCode.A))//대쉬
        {
            playerMove.Dash();
        }

        if (Input.GetKeyDown(KeyCode.Space)) //점프
        {
            playerMove.Jump();
        }
    }

    private void AttackInput()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            StartCoroutine(playerAttack.Attack());
        }
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
        if (Input.GetKeyDown(KeyCode.Return)) //엔터가 리턴인가봄
        {
            playerInteraction.Talk();
        }
    }
}
