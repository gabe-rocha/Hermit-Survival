using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStateIdle : IState {

#region Public Fields

#endregion

#region Private Serializable Fields

#endregion

#region Private Fields
    Player player;
#endregion

    public PlayerStateIdle() {
        this.player = Player.Instance;
    }

#region Private Methods

    void IState.OnEnter() {
        Debug.Log("Idle");

    }

    void IState.OnExit() {

    }

    IState IState.Tick() {

        var isMoving = player.characterController.velocity != Vector3.zero;
        if(isMoving) {
            return player.stateWalking;
        }

        if(Input.GetButtonDown("Fire1")) {
            return player.stateAttacking;
        }

        return this;
    }

#endregion

#region Public Methods

#endregion
}