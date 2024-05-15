using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisionSensorAttack : VisionSensor
{
    [Header("Vision Attack")]
    public DataViewBase AttackVision = new DataViewBase();
    // Start is called before the first frame update
    private void Start()
    {
        LoadComponent();
    }
    public override void LoadComponent()
    {

       
        base.LoadComponent();
        AttackVision.Owner = MainVision.Owner;
    }

    // Update is called once per frame
    void Update()
    {
        this.UpdateScand();
    }
    private void OnValidate()
    {
        base.CreateMesh();
        AttackVision.CreateMesh();
    }
    public override void UpdateScand()
    {
        if (Framerate > arrayRate[index])
        {
            index++;
            index = index % arrayRate.Length;
            base.Scan();
            Framerate = 0;
        }
        Framerate += Time.deltaTime;


        if (EnemyView != null)
        {
            AttackVision.IsInSight(EnemyView.AimOffset);
        }
        else
            AttackVision.InSight = false;
    }
    private void OnDrawGizmos()
    {
        AttackVision.OnDrawGizmos();
        base.DrawGizmos();
    }
}
