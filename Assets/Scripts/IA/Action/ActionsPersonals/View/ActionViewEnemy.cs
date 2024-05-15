using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
[TaskCategory("IA SC/Node Move")]
public class ActionViewEnemy : ActionView
{
    public override void OnStart()
    {
        base.OnStart();
    }
    public override TaskStatus OnUpdate()
    {
        if (aICharacterVehicle != null)
        {
            if (aICharacterVehicle.Health.IsDead)
            {
                return TaskStatus.Failure;
            }
        }

        if (aICharacterVehicle != null)
        {
            if (aICharacterVehicle._VisionSensor.EnemyView != null)
            {
                return TaskStatus.Success;
            }
        }

        if (aICharacterAction != null)
        {
            if (aICharacterAction._VisionSensor.EnemyView != null)
            {
                return TaskStatus.Success;
            }
        }

        return TaskStatus.Failure;
    }
}
