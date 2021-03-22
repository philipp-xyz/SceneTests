using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnStuff : MonoBehaviour {

    public GameObject prefab;
    public int amount;
    
    void Start() {
        //spawnt eine menge prefabs beim start der szene
        for (int i = 0; i < amount; i++) {
            SpawnPrefab();
        }
    }
    
    void Update() {
        //spawnt prefab bei tastendruck
        if (Input.GetKeyDown(KeyCode.Space)) {
            SpawnPrefab();
        }
    }

    void SpawnPrefab() {
        Instantiate(prefab, transform.position, Quaternion.identity);
    }
}
