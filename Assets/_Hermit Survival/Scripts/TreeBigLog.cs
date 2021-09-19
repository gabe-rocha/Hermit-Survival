using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TreeBigLog : MonoBehaviour, IDamageable {

#region Public Fields

#endregion

#region Private Serializable Fields
    [SerializeField] private ItemSO itemData;
    [SerializeField] private GameObject pfBottomLog, pfTopLog;
#endregion

#region Private Fields
    Rigidbody rb;
#endregion

#region MonoBehaviour CallBacks
    void Awake() {
        rb = GetComponent<Rigidbody>();
        if (rb == null) {
            Debug.LogError($"{name} is missing a rigid body");
        }
    }

    void Start() {
        rb.AddForce(transform.forward * 200);
        transform.Rotate(Vector3.up * UnityEngine.Random.Range(1, 15));
    }

    void Update() {

    }
#endregion

#region Private Methods

#endregion

#region Public Methods
    public void Damage(int value) {

        if (itemData.health <= 0) {
            Instantiate(pfTopLog, transform.position, Quaternion.identity, null);
            Instantiate(pfBottomLog, transform.position, Quaternion.identity, null);
            Destroy(gameObject);
        }
    }
#endregion
}