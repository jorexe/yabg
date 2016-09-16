using UnityEngine;
using System.Collections;

public abstract class SphereMaterial {

    public abstract SphereMaterialType sphereMaterialType { get; }

    public abstract float mass { get; }

    public abstract float drag { get; }

    public abstract float angularDrag { get; }

    public abstract float speed { get; }

    public abstract bool useGravity { get; }

    public abstract void MaterialUpdate();

}