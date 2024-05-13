using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisionSensorFireAttack : VisionSensor
{
    [Header("Vision Attack")]
    public DataViewBase AttackVision = new DataViewBase();
    [Header("Vision Fire")]
    public DataViewBase FireVision = new DataViewBase();
    // Start is called before the first frame update
    private void Start()
    {
        LoadComponent();
    }

    public override void LoadComponent()
    {
        FireVision.Owner = GetComponent<Health>();
        AttackVision.Owner = FireVision.Owner;
        
        base.LoadComponent();
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
        FireVision.CreateMesh();
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
            FireVision.IsInSight(EnemyView.AimOffset);
        }
        else
        {
            AttackVision.InSight = false;
            FireVision.InSight = false;
        }
            
    }
    private void OnDrawGizmos()
    {
        AttackVision.OnDrawGizmos();
        FireVision.OnDrawGizmos();
        base.DrawGizmos();
    }
}
