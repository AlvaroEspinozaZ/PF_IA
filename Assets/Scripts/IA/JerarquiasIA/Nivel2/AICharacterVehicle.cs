using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AICharacterVehicle : AICharacterControl
{
    #region Rate
    protected int index = 0;
    protected float[] arrayRate;
    protected int bufferSize = 10;
    public float randomWaitScandMin = 1;
    public float randomWaitScandMax = 1;


    protected float Framerate = 0;
    #endregion
    public override void LoadComponent()
    {
        base.LoadComponent();
        Framerate = 0;
        index = 0;
        arrayRate = new float[bufferSize];
        for (int i = 0; i < arrayRate.Length; i++)
        {
            arrayRate[i] = (float)UnityEngine.Random.Range(randomWaitScandMin, randomWaitScandMax);
        }

    }
    #region Move

    public virtual void Wander()
    {

    }
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
