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

    public PlayerStateIdle(Player player) {
        this.player = player;
    }

#region Private Methods

    void IState.OnEnter() {

    }

    void IState.OnExit() {

    }

    IState IState.Tick() {

        var isMoving = player.characterController.velocity != Vector3.zero;
        if (isMoving) {
            return player.stateWalking;
        }

        if (Input.GetButton("Fire1") && player.equipedTool != null) {
            return player.stateUsingTool;
        }

        return this;
    }

#endregion

#region Public Methods

#endregion
}