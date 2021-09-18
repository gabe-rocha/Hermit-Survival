using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeStump : MonoBehaviour, IDamageable {

    [SerializeField] private ItemSO itemData;
    [SerializeField] private WoodPiece pfWood;
    private float health;

    void Start() {
        health = itemData.health;
    }

    void IDamageable.Damage(int amount) {
        health -= amount;
        if(health <= 0) {

            for (var a = 0; a < itemData.relatedNumber; a++) {
                Instantiate(pfWood, null);
            }

            //todo play particles
            Destroy(gameObject);
        }
    }

}