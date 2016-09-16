using UnityEngine;
using System.Collections;
using System;

public class StoneMaterial : SphereMaterial {

    public override float Drag { get { return 1.4f; } }

    public override float AngularDrag { get { return 0.4f; } }

    public override float Mass { get { return 1f; } }

    public override float Speed { get { return 4f; } }

    public override SphereMaterialType SphereMaterialType { get { return SphereMaterialType.WOOD; } }

    public override bool UseGravity { get { return true; } }

    public override void MaterialUpdate() {
        
    }
}