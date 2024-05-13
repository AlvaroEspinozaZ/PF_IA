using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
[TaskCategory("IA SC/Node Attack")]
public class ActionFire : ActionNodeActions
{
    public override void OnStart()
    {
        base.OnStart();
    }
    public override TaskStatus OnUpdate()
    {
        if (aICharacterAction.Health.IsDead)
            return TaskStatus.Failure;

        SwitchFirePlay();

        return TaskStatus.Success;
    }
    void SwitchFirePlay()
    {
        switch (Unit)
        {
            case TypeUnit.Dog:
                //if(aICharacterAction is ait)
                break;
            case TypeUnit.Sheep:
                break;
            case TypeUnit.None:
                break;
            default:
                break;
        }
    }
}
