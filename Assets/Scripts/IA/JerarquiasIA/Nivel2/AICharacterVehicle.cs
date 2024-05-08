using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AICharacterVehicle : AICharacterControl
{
    public override void LoadComponent()
    {
        base.LoadComponent();

    }
    #region Move

    public virtual void MoveToPosition(Vector3 position)
    {
       
    }
    public virtual void MoveToPositionEvade()
    {

    }
    public virtual void MoveToPositionWanderEnemy()
    {

    }
    public virtual void MoveToPositionWander()
    {

    }
    public virtual void MoveToAllied()
    {
    }
    public virtual void MoveToObject()
    {

    }

    public virtual void MoveToEnemy()
    {
    }
    #endregion

}
