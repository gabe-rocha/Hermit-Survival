using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStateAttacking : IState {

#region Public Fields

#endregion

#region Private Serializable Fields

#endregion

#region Private Fields
    Player player;
    float lastAttackTime;
    bool canAttack = true;
#endregion

    public PlayerStateAttacking() {
        this.player = Player.Instance;
        lastAttackTime = float.NegativeInfinity;
    }

#region Private Methods
    void IState.OnEnter() {
        Debug.Log("Attacking");

        if(Time.time > lastAttackTime + (1f / player.equipedWeapon.weaponData.weaponSpeed)) {
            lastAttackTime = Time.time;
            canAttack = true;
            if(player.equipedWeapon != null) {
                player.animator.SetTrigger("AttackWeapon");
            } else if(player.equipedWeapon != null) {
                player.animator.SetTrigger("AttackPunch");
            }
        }
    }

    void IState.OnExit() {

    }

    IState IState.Tick() {

        if(canAttack) {
            canAttack = false;
            var arrayHits = Physics.BoxCastAll(Camera.main.transform.position, Vector3.one * (player.equipedWeapon.weaponData.weaponRange / 2), Camera.main.transform.forward, Quaternion.identity, player.equipedWeapon.weaponData.weaponRange);

            foreach (var hit in arrayHits) {
                IDamageable damageable;
                hit.transform.gameObject.TryGetComponent<IDamageable>(out damageable);
                if(damageable != null) {
                    damageable.Damage(UnityEngine.Random.Range(player.equipedWeapon.weaponData.weaponDamageRange.x, player.equipedWeapon.weaponData.weaponDamageRange.y + 1));
                    Debug.Log($"I just attacked a {hit.transform.name}");
                }
            }
        }

        var isMoving = player.characterController.velocity != Vector3.zero;
        if(!isMoving) {
            return player.stateIdle;
        } else {
            return player.stateWalking;
        }
    }

#endregion

#region Public Methods

#endregion
}