using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStateUsingTool : IState {

#region Public Fields

#endregion

#region Private Serializable Fields

#endregion

#region Private Fields
    Player player;
    float lastUseTime;
#endregion

    public PlayerStateUsingTool(Player player) {
        this.player = player;
    }

#region Private Methods

    void IState.OnEnter() {
        lastUseTime = Time.time;

        Physics.Raycast(Camera.main.gameObject.transform.position, player.transform.forward, player.equipedTool.range);

    }

    void IState.OnExit() {

    }

    IState IState.Tick() {

        return this;
    }

#endregion

#region Public Methods

#endregion
}