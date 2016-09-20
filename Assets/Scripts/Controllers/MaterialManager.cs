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
    [Header("Materials")]
    public Material WoodenMaterial;
    public Material StoneMaterial;
    public Material PaperMaterial;

    [Header("Meshes")]
    public Mesh StandardMesh;
    public Mesh PaperMesh;

    public Material getMaterial(SphereMaterialType material) {
        switch(material) {
            case SphereMaterialType.WOOD:
                return WoodenMaterial;
            case SphereMaterialType.STONE:
                return StoneMaterial;
            case SphereMaterialType.PAPER:
                return PaperMaterial;
        }
        return null;
    }

    public Mesh getMesh(SphereMaterialType material) {
        switch (material) {
            case SphereMaterialType.WOOD:
            case SphereMaterialType.STONE:
                return StandardMesh;
            case SphereMaterialType.PAPER:
                return PaperMesh;
        }
        return null;
    }
	
}
