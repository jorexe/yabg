using UnityEngine;
using System.Collections;

public class Sphere: MonoBehaviour {

    public SphereMaterialType SphereMaterialType;

    SphereMaterial sphereMaterial;

    public float speed = 4;

    public Rigidbody rb;
    public MeshRenderer mr;
    public MeshFilter mf;
    SphereCollider sphereCollider;
    MeshCollider meshCollider;

    void Start() {
        rb = GetComponent<Rigidbody>();
        mr = GetComponent<MeshRenderer>();
        mf = GetComponent<MeshFilter>();
        meshCollider = GetComponent<MeshCollider>();
        sphereCollider = GetComponent<SphereCollider>();
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
            case SphereMaterialType.PAPER:
                sphereMaterial = new PaperMaterial();
                break;
            case SphereMaterialType.FUTURISTIC:
                sphereMaterial = new FuturisticMaterial();
                break;
            default:
                Debug.LogError("Material not implemented: " + material);
                break;
        }
        mr.material = MaterialManager.Instance.getMaterial(material);
        mf.mesh = MaterialManager.Instance.getMesh(material);
        updateMaterialPhysics();
    }

    private void updateMaterialPhysics() {
        rb.mass = sphereMaterial.Mass;
        rb.drag = sphereMaterial.Drag;
        rb.angularDrag = sphereMaterial.AngularDrag;
        rb.useGravity = sphereMaterial.UseGravity;
        speed = sphereMaterial.Speed;
        if (SphereMaterialType == SphereMaterialType.PAPER) {
            meshCollider.enabled = true;
            sphereCollider.enabled = false;
        } else {
            sphereCollider.enabled = true;
            meshCollider.enabled = false;
        }
    }
}