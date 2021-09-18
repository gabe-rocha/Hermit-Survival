using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

#region Public Fields

#endregion

#region Private Serializable Fields
#endregion

#region Private Fields
    private StateMachine stateMachine;
    internal IState stateIdle, stateWalking, stateUsingTool;
    internal CharacterController characterController;
    internal Animator animator;
    internal bool isMoving = false;
    internal ITool equipedTool;

#endregion

#region MonoBehaviour CallBacks
    void Awake() {
        characterController = GetComponent<CharacterController>();
        if (characterController == null) {
            Debug.LogError($"{name} is missing a component - CharacterController");
        }

        animator = GetComponent<Animator>();
        if (animator == null) {
            Debug.LogError($"{name} is missing a component - Animator");
        }

    }

    void Start() {
        stateIdle = new PlayerStateIdle(this);
        stateWalking = new PlayerStateWalking(this);

        stateMachine = new StateMachine();
        stateMachine.SetState(stateIdle);
    }

    void Update() {
        stateMachine.Tick();
    }
#endregion

#region Private Methods

#endregion

#region Public Methods

#endregion
}