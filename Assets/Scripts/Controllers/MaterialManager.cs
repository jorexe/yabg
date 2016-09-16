using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MaterialManager : MonoBehaviour {

    private static MaterialManager instance;

    public static MaterialManager Instance { get {
            return instance;
        }
    }

    void Awake() {
        if (instance != null && instance != this) {
            Destroy(this.gameObject);
        } else {
            instance = this;
        }
        //DontDestroyOnLoad(transform.gameObject);
    }

    public Material WoodenMaterial;
    public Material StoneMaterial;

    public Material getMaterial(SphereMaterialType material) {
        switch(material) {
            case SphereMaterialType.WOOD:
                return WoodenMaterial;
            case SphereMaterialType.STONE:
                return StoneMaterial;
        }
        return null;
    }
	
}
