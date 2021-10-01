using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStateWalking : IState {

#region Public Fields

#endregion

#region Private Serializable Fields

#endregion

#region Private Fields
    Player player;
#endregion

    public PlayerStateWalking() {
        this.player = Player.Instance;
    }

#region Private Methods

    void IState.OnEnter() {
        Debug.Log("Walking");

    }

    void IState.OnExit() {

    }

    IState IState.Tick() {

        if (Input.GetButtonDown("Fire1")) {
            return player.stateAttacking;
        }

        var isMoving = player.characterController.velocity != Vector3.zero;
        if (!isMoving) {
            return player.stateIdle;
        }

        return this;
    }

#endregion

#region Public Methods

#endregion
}