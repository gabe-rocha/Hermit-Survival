using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TargetController : MonoBehaviour {

#region Public Fields

#endregion

#region Private Serializable Fields
    [SerializeField] private LayerMask targettable;
#endregion

#region Private Fields

#endregion

#region MonoBehaviour CallBacks
    void Awake() {
        //component = GetComponent<Component>();
        //if(component == null) {
        //Debug.LogError($"{name} is missing a component");
        //}

    }

    void Start() {

    }

    void Update() {
        if (GameManager.Instance.gameState != GameManager.GameStates.Playing) {
            return;
        }

        var screenCenter = new Vector3(Screen.width / 2f, Screen.height / 2f, 0f);
        var screenCenterWorldPos = Camera.main.ScreenToWorldPoint(screenCenter);
        var ray = Camera.main.ScreenPointToRay(screenCenter);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit)) {
            Debug.Log($"Looking at {hit.collider.gameObject.name}");
        }

    }
#endregion

#region Private Methods

#endregion

#region Public Methods

#endregion
}