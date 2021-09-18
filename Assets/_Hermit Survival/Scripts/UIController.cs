using System.Collections;
using System.Collections.Generic;
using TMPro;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

#region Public Fields

#endregion

#region Private Serializable Fields
    [SerializeField] private TextMeshProUGUI textPlayerLookingAt;
#endregion

#region Private Fields

#endregion

#region MonoBehaviour CallBacks

    private void OnEnable() {
        EventManager.Instance.StartListeningWithStringParam(EventManager.Events.PlayerLookingAt, UpdatePlayerLookingAt);
    }
    private void OnDisable() {
        EventManager.Instance.StopListeningWithStringParam(EventManager.Events.PlayerLookingAt, UpdatePlayerLookingAt);
    }

    void Awake() {
        //component = GetComponent<Component>();
        //if(component == null) {
        //Debug.LogError($"{name} is missing a component");
        //}
    }

    void Start() {

    }

    void Update() {
        textPlayerLookingAt.text = "";
    }
#endregion

#region Private Methods
    private void UpdatePlayerLookingAt(string item) {
        textPlayerLookingAt.text = $"{item}";
    }
#endregion

#region Public Methods

#endregion
}