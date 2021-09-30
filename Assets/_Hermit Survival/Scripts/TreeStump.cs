using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TreeStump : MonoBehaviour, IDamageable {

#region Private Serializable Fields
    [SerializeField] private GameObject pfWoodPiece;
#endregion

#region Private Fields
    private int amountToDrop = Data.stumpCommonWoodAmount;
    private Rigidbody rb;
    private HealthSystem healthSystem;
#endregion

#region MonoBehaviour CallBacks
    void Awake() {
        rb = GetComponent<Rigidbody>();
        if (rb == null) {
            Debug.LogError($"{name} is missing a RigidBody");
        }
        healthSystem = new HealthSystem(Data.stumpCommonMaxHealth);
    }

#endregion

#region Private Methods

#endregion

#region Public Methods
    public void Damage(int amount) {

        healthSystem.Damage(amount);

        if (healthSystem.IsDead()) {
            //todo play particles

            for (int i = 0; i < amountToDrop; i++) {
                float randomX = Random.Range(-1f, 1f);
                float randomZ = Random.Range(-1f, 1f);
                Vector3 spawnPosition = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);
                Instantiate(pfWoodPiece, spawnPosition, Quaternion.identity, null);
            }

            Destroy(gameObject);
        }
    }
#endregion
}