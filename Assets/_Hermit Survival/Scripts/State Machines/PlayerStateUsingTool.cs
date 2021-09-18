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

    public PlayerStateUsingTool() {
        this.player = Player.Instance;
    }

#region Private Methods

    void IState.OnEnter() {

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