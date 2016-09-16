using UnityEngine;
using System.Collections;

public class MaterialPicker : MonoBehaviour {

    public SphereMaterialType SphereMaterialType;
    private MeshRenderer mr;

    void Start() {
        mr = GetComponent<MeshRenderer>();
        mr.material = MaterialManager.Instance.getMaterial(SphereMaterialType);
    }

    void OnTriggerEnter(Collider other) {
        Sphere sphere = other.gameObject.GetComponent<Sphere>();
        if (sphere != null && sphere.SphereMaterialType != SphereMaterialType) {
            sphere.setMaterial(SphereMaterialType);
        }
    }
}