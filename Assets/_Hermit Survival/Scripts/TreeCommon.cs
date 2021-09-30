using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TreeCommon : MonoBehaviour, IDamageable {

#region Private Serializable Fields
    [SerializeField] private GameObject pfTreeStump, pfTreeLog;
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

            Instantiate(pfTreeStump, transform.localPosition, Quaternion.identity, null);
            float stumpHeight = pfTreeStump.GetComponent<CapsuleCollider>().height;
            Vector3 logPos = new Vector3(transform.position.x, transform.position.y + stumpHeight, transform.position.z);
            var log = Instantiate(pfTreeLog, logPos, Quaternion.identity, null);
            log.transform.Rotate(log.transform.forward * 5f);

            Destroy(gameObject);
        }
    }
#endregion
}