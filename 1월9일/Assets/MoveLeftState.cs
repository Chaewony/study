using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeftState : State
{
    Enemy enemy;

    public void onEnter(Enemy enemy)
    {
        this.enemy = enemy;
    }

    void State.Update()
    {
        enemy.transform.Translate(new Vector3(-0.1f, 0, 0));

        if (enemy.transform.position.x < -3.0f)
        {
            enemy.SetState(new MoveState());
        }
    }

    public void onExit()
    {
       
    }
}
