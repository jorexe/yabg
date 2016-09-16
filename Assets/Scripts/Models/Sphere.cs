using UnityEngine;
using System.Collections;

public class Sphere: MonoBehaviour {

    public SphereMaterialType SphereMaterialType;

    SphereMaterial sphereMaterial;

    public float speed = 4;

    public Rigidbody rb;
    public MeshRenderer mr;

    void Start() {
        rb = GetComponent<Rigidbody>();
        mr = GetComponent<MeshRenderer>();
        if (sphereMaterial == null) {
            setMaterial(SphereMaterialType);
        }
    }

    void Update() {
        sphereMaterial.MaterialUpdate();
    }

    public void setMaterial(SphereMaterialType material) {
        this.SphereMaterialType = material;
        switch(material) {
            case SphereMaterialType.WOOD:
                sphereMaterial = new WoodenMaterial();
                break;
            case SphereMaterialType.STONE:
                sphereMaterial = new StoneMaterial();
                break;
            default:
                Debug.LogError("Material not implemented: " + material);
                break;
        }
        mr.material = MaterialManager.Instance.getMaterial(material);
        updateMaterialPhysics();
    }

    private void updateMaterialPhysics() {
        rb.mass = sphereMaterial.Mass;
        rb.drag = sphereMaterial.Drag;
        rb.angularDrag = sphereMaterial.AngularDrag;
        rb.useGravity = sphereMaterial.UseGravity;
        speed = sphereMaterial.Speed;
    }
}