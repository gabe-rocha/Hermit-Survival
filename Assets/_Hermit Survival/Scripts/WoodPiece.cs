using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WoodPiece : Item {

#region Public Fields
    [SerializeField] private float moveSpeed;
    [SerializeField] private float range;
#endregion

#region Private Serializable Fields

#endregion

#region Private Fields
    Player player;
    Rigidbody rb;
#endregion

#region MonoBehaviour CallBacks
    void Awake() {
        rb = GetComponent<Rigidbody>();
        if (rb == null) {
            Debug.LogError($"{name} is missing a rigidbody");
        }
    }

    void Start() {
        player = Player.Instance;

        if (player == null) {
            Debug.LogError($"{name} is missing a player");
        }
    }

    void Update() {
        if (Vector3.Distance(transform.position, player.transform.position) <= range) {
            rb.isKinematic = true;
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, moveSpeed * Time.deltaTime);
        } else {
            rb.isKinematic = false;
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            player.AddItem(this);
            Destroy(gameObject);
        }
    }
#endregion

#region Private Methods
#endregion

#region Public Methods
#endregion
}