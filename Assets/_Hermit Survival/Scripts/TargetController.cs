using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TargetController : MonoBehaviour {

#region Public Fields

#endregion

#region Private Serializable Fields
#endregion

#region Private Fields
    private Player player;
#endregion

#region MonoBehaviour CallBacks
    void Awake() {
        player = GetComponent<Player>();
        if(player == null) {
            Debug.LogError($"{name} couldn't find the Player");
        }
    }

    void Start() {

    }

    void Update() {
        // if(GameManager.Instance.gameState != GameManager.GameStates.Playing) {
        //     return;
        // }

        // var ray = Camera.main.ScreenPointToRay(Input.mousePosition); //mouse will always be in the middle of the screen in a FPS
        // RaycastHit hit;
        // if(Physics.Raycast(ray, out hit)) {
        //     Transform selectable = hit.transform;
        //     if(selectable.CompareTag("Selectable")) {
        //         var distance = Mathf.Abs(selectable.position.z - player.transform.position.z);
        //         if(distance <= player.lookAtRange) {
        //             player.lookingAt = hit.transform;
        //             EventManager.Instance.TriggerEventWithStringParam(EventManager.Events.PlayerLookingAt, hit.transform.name);
        //         }
        //     }
        // } else {
        //     player.lookingAt = null;
        // }

        // Debug.DrawRay(player.equipedTool.transform.position, player.equipedTool.transform.forward * player.equipedTool.range, Color.green);
    }
#endregion

#region Private Methods

#endregion

#region Public Methods

#endregion
}