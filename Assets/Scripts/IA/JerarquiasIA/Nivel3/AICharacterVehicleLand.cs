using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class AICharacterVehicleLand : AICharacterVehicle
{
    protected NavMeshAgent agent;
    public float rangeWander = 10.0f;
    public Vector3 pointWander = Vector3.zero;

 

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
        if (_VisionSensor.AlliedView != null)
        {
            MoveToPosition(_VisionSensor.AlliedView.transform.position);
        }
    }
    public override void MoveToEnemy()
    {
        if (_VisionSensor.EnemyView == null)
        {
            Debug.Log("no enemigo");
            return;
        }
        else if (_VisionSensor.EnemyView != null)
        {
            Debug.Log("moviendo enemigo");
            MoveToPosition(_VisionSensor.EnemyView.transform.position);
        }
    }
    //public override void MoveToObject()
    //{
    //    if (_AIEye.ViewToy != null)
    //    {
    //        MoveToPosition(_AIEye.ViewToy.transform.position);
    //    }
    //}
    public override void Wander()
    {
      
        float distance = (transform.position - pointWander).magnitude;
        if (distance < 1)
        {
            if (RandomPoint(transform.position, rangeWander, out pointWander))
            {
                this.MoveToPosition(pointWander);
            }
        }
        else
        { 
            if (Framerate > arrayRate[index])
            {
                index++;
                index = index % arrayRate.Length;
                if (RandomPoint(transform.position, rangeWander, out pointWander))
                {
                    this.MoveToPosition(pointWander);
                }
                Framerate = 0;
            }
            Framerate += Time.deltaTime;
        }
    }
    public void Patrol(Transform aliedToSave)
    {

        float distance = (transform.position - pointWander).magnitude;
        if (distance < 1)
        {
            if (RandomPoint(aliedToSave.position, rangeWander, out pointWander))
            {
                this.MoveToPosition(pointWander);
            }
        }
        else
        {
            if (Framerate > arrayRate[index])
            {
                index++;
                index = index % arrayRate.Length;
                if (RandomPoint(aliedToSave.position, rangeWander, out pointWander))
                {
                    this.MoveToPosition(pointWander);
                }
                Framerate = 0;
            }
            Framerate += Time.deltaTime;
        }
    }
    bool RandomPoint(Vector3 center, float range, out Vector3 result)
    {
        for (int i = 0; i < 30; i++)
        {
            Vector3 randomPoint = center + Random.insideUnitSphere * range;
            NavMeshHit hit;
            if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas))
            {
                result = hit.position;
                return true;
            }
        }
        result = Vector3.zero;
        return false;
    }
    #endregion
}
