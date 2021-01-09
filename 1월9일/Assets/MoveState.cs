using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveState : State //스테이트 상속
{
    private Enemy enemy;

    public void onEnter(Enemy enemy)
    {
        this.enemy = enemy;
    }

    public void Update()
    {
        enemy.transform.Translate(new Vector3(0.1f, 0, 0));

        if (enemy.transform.position.x > 3.0f)
        {
            enemy.SetState(new MoveLeftState());
        }

        //방향결정
        //거리 결정
        //이동
        //플레이어와 거리 계산
        //상태 전환
    }

    public void onExit()
    {
       
    }
}
