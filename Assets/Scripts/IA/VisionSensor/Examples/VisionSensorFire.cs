using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisionSensorFire : VisionSensor
{
    [Header("Vision Fire")]
    public DataViewBase FireVision = new DataViewBase();
    // Start is called before the first frame update
    private void Start()
    {
        LoadComponent();
    }
    public override void LoadComponent()
    {

        FireVision.Owner = MainVision.Owner;
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
            FireVision.IsInSight(EnemyView.AimOffset);
        }
        else
            FireVision.InSight = false;
    }
    private void OnDrawGizmos()
    {
        FireVision.OnDrawGizmos();
        base.DrawGizmos();
    }
}
