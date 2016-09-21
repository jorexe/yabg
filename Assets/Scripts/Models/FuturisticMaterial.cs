using UnityEngine;
using System.Collections;
using System;

public class FuturisticMaterial : SphereMaterial {

    public override float Drag { get { return 1.2f; } }

    public override float AngularDrag { get { return 0.2f; } }

    public override float Mass { get { return 0.5f; } }

    public override float Speed { get { return 4f; } }

    public override SphereMaterialType SphereMaterialType { get { return SphereMaterialType.FUTURISTIC; } }

    public override bool UseGravity { get { return true; } }

    public override void MaterialUpdate() {
        
    }
}