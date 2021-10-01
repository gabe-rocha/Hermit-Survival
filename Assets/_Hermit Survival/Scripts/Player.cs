using System;
using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

#region Public Fields
    public static Player Instance { get => instance; set => instance = value; }
#endregion

#region Private Serializable Fields
    [SerializeField] internal Weapon equipedWeapon;
#endregion

#region Private Fields
    private static Player instance;
    private Inventory inventory;
    private StateMachine stateMachine;
    internal IState stateIdle, stateWalking, stateAttacking;
    internal CharacterController characterController;
    internal ThirdPersonController thirdPersonController;
    internal Animator animator;
#endregion

#region MonoBehaviour CallBacks
    void Awake() {
        if (Instance == null) {
            Instance = this;
        } else {
            Destroy(this);
        }

        characterController = GetComponent<CharacterController>();
        thirdPersonController = GetComponent<ThirdPersonController>();

        if (characterController == null) {
            Debug.LogError($"{name} is missing a component - CharacterController");
        }

        animator = GetComponent<Animator>();
        if (animator == null) {
            Debug.LogError($"{name} is missing a component - Animator");
        }
    }

    void Start() {
        inventory = new Inventory();
        stateIdle = new PlayerStateIdle();
        stateWalking = new PlayerStateWalking();
        stateAttacking = new PlayerStateAttacking();

        stateMachine = new StateMachine();
        stateMachine.SetState(stateIdle);
    }

    internal void AddItem(Item item) {
        inventory.AddItem(item);
    }

    void Update() {
        stateMachine.Tick();
    }
#endregion

#region Private Methods
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Gatherable")) {
            Debug.Log($"Player touched a Gatherable: {other.gameObject.name}");
            Destroy(other.gameObject);
        }
    }
#endregion

#region Public Methods

#endregion
}