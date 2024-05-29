using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime.Tasks;
[TaskCategory("IA SC/Node View")]

public class ActionNoViewEnemy : ActionView
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
            if (aICharacterVehicle._VisionSensor.EnemyView == null)
            {
                return TaskStatus.Success;
            }
        }

        if (aICharacterAction != null)
        {
            if (aICharacterAction._VisionSensor.EnemyView == null)
            {
                return TaskStatus.Success;
            }
        }

        return TaskStatus.Failure;
    }
}
