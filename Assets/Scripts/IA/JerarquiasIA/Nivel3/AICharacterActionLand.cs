using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AICharacterActionLand : AICharacterAction
{
    protected WeaponManager weaponManager;
    public override void LoadComponent()
    {
        base.LoadComponent();
    }
    

    public virtual void FirePLay()
    {
        weaponManager.Fire();
    }
    public virtual void StopPlay()
    {
        weaponManager.StopFire();
    }
}
