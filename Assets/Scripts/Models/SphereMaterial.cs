using UnityEngine;
using System.Collections;

public abstract class SphereMaterial {

    public abstract SphereMaterialType SphereMaterialType { get; }

    public abstract float Mass { get; }

    public abstract float Drag { get; }

    public abstract float AngularDrag { get; }

    public abstract float Speed { get; }

    public abstract bool UseGravity { get; }

    public abstract void MaterialUpdate();

}