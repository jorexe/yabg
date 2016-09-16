using UnityEngine;
using System.Collections;

public class MaterialPicker : MonoBehaviour {

    public static Dictionary<SphereMaterialType, >
    public SphereMaterial sphereMaterial;

    void OnTriggerEnter(Collider other) {
        Player player = other.gameObject.GetComponent<Player>();
        if (player != null && player.sphereMaterial != sphereMaterial) {
            player.sphereMaterial = sphereMaterial;
        }
    }
}
