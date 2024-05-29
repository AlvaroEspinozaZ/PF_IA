using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class AICharacterVehicleLand : AICharacterVehicle
{
    protected NavMeshAgent agent;

    public override void LoadComponent()
    {
        agent = GetComponent<NavMeshAgent>();
        base.LoadComponent();
    }

    #region Move
    public override void MoveToPosition(Vector3 position)
    {
        agent.SetDestination(position);
        
    }
    public override void MoveToAllied()
    {
        if (_AIEye.ViewAllied != null)
        {
            MoveToPosition(_AIEye.ViewAllied.transform.position);
        }
    }
    public override void MoveToEnemy()
    {
        if (_AIEye.ViewEnemy != null)
        {
            MoveToPosition(_AIEye.ViewEnemy.transform.position);
        }
    }
    public override void MoveToObject()
    {
        if (_AIEye.ViewToy != null)
        {
            MoveToPosition(_AIEye.ViewToy.transform.position);
        }
    }
    public override void Wander()
    {
        if (_AIEye.ViewEnemy == null)
        {
           //Mover Wander
        }
    }

    #endregion
}
