using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Tree : MonoBehaviour, IDamageable {

#region Public Fields
    public enum TreeState {
        Tree,
        Log,
        Stump
    }
#endregion

#region Private Serializable Fields
    [SerializeField] private TreeState treeState;
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

        switch (treeState) {
            case TreeState.Tree:
                healthSystem = new HealthSystem(Data.treeCommonMaxHealth);
                break;
            case TreeState.Log:
                healthSystem = new HealthSystem(Data.logCommonMaxHealth);
                break;
            case TreeState.Stump:
                healthSystem = new HealthSystem(Data.stumpCommonMaxHealth);
                break;
        }

    }

    void Start() { }
#endregion

#region Private Methods

#endregion

#region Public Methods
    public void Damage(int amount) {

        healthSystem.Damage(amount);

        if (healthSystem.IsDead()) {
            //todo play particles
            switch (treeState) {
                case TreeState.Tree:
                    Instantiate(pfTreeStump, transform.localPosition, Quaternion.identity, null);

                    float stumpHeight = pfTreeStump.transform.localScale.y;
                    Vector3 bottomLogPos = new Vector3(transform.position.x, transform.position.y + stumpHeight, transform.position.z);
                    var bottomLog = Instantiate(pfTreeLog, bottomLogPos, Quaternion.identity, null);
                    bottomLog.transform.Rotate(Vector3.forward * 15);

                    float logHeight = pfTreeLog.transform.localScale.y;
                    Vector3 topLogPos = new Vector3(transform.position.x, transform.position.y + stumpHeight + logHeight, transform.position.z);
                    var topLog = Instantiate(pfTreeLog, topLogPos, Quaternion.identity, null);
                    topLog.transform.Rotate(Vector3.forward * 15);
                    break;
                case TreeState.Log:
                    break;
            }
            Destroy(gameObject);
        }
    }
#endregion
}