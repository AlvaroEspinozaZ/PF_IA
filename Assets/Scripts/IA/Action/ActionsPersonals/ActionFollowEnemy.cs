using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
[TaskCategory("IA SC/Node Move")]

public class ActionFollowEnemy : ActionNodeVehicle
{
    public override void OnStart()
    {
        base.OnStart();
    }
    public override TaskStatus OnUpdate()
    {
        if (aICharacterVehicle.Health.IsDead)
            return TaskStatus.Failure;
        SwitchMoveToEnemy();
        return TaskStatus.Success;
       
    }
    void SwitchMoveToEnemy()
    {
        switch (Unit)
        {
            case TypeUnit.Dog:
                if (aICharacterVehicle is AICharacterVehicleDog)
                {
                    ((AICharacterVehicleSoldier)aICharacterVehicle).MoveToEnemy();
                }
                break;
            case TypeUnit.None:
                break;
            default:
                break;
        }
        
    }
}
