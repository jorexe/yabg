using UnityEngine;
using System.Collections;
using System;

public class WoodenMaterial : SphereMaterial {

    public override float drag { get { return 1.2f; } }

    public override float angularDrag { get { return 0.2f; } }

    public override float mass { get { return 0.5f; } }

    public override float speed { get { return 4f; } }

    public override SphereMaterialType sphereMaterialType { get { return SphereMaterialType.WOOD; } }

    public override bool useGravity { get { return true; } }

    public override void MaterialUpdate() {
        
    }
}