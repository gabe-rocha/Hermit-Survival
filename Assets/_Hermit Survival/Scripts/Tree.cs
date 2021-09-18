using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Tree : MonoBehaviour, IDamageable {

#region Public Fields

#endregion

#region Private Serializable Fields
    [SerializeField] private int health = 10;
    [SerializeField] private GameObject pfTreeStump, pfTreeBigLog;
#endregion

#region Private Fields
    Rigidbody rb;
#endregion

#region MonoBehaviour CallBacks
    void Awake() {
        rb = GetComponent<Rigidbody>();
        if(rb == null) {
            Debug.LogError($"{name} is missing a RigidBody");
        }
    }

    void Start() { }
#endregion

#region Private Methods

#endregion

#region Public Methods
    public void Damage(int amount) {

        health -= amount;

        if(health <= 0) {
            //todo play particles
            Instantiate(pfTreeStump, null);
            Instantiate(pfTreeBigLog, null);
            Destroy(gameObject);
        }
    }
#endregion
}