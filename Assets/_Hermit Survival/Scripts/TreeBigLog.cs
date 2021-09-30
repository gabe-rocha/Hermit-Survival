using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TreeBigLog : MonoBehaviour, IDamageable {

#region Private Serializable Fields
    [SerializeField] private GameObject pfTreeHalfLog, pfBigLogSplittingParticles;
#endregion

#region Private Fields
    private Rigidbody rb;
    private HealthSystem healthSystem;
#endregion

#region MonoBehaviour CallBacks
    void Awake() {
        rb = GetComponent<Rigidbody>();
        if (rb == null) {
            Debug.LogError($"{name} is missing a RigidBody");
        }
        healthSystem = new HealthSystem(Data.treeCommonMaxHealth);
    }

#endregion

#region Private Methods

#endregion

#region Public Methods
    public void Damage(int amount) {

        healthSystem.Damage(amount);

        if (healthSystem.IsDead()) {
            //todo play particles

            Instantiate(pfTreeHalfLog, transform.localPosition, transform.rotation, null);

            var logHeight = pfTreeHalfLog.GetComponent<CapsuleCollider>().height;
            Vector3 topLogPos = transform.localPosition + (transform.up * logHeight);
            Instantiate(pfTreeHalfLog, topLogPos, transform.rotation, null);
            Instantiate(pfBigLogSplittingParticles, topLogPos, Quaternion.identity, null);

            Destroy(gameObject);
        }
    }
#endregion
}