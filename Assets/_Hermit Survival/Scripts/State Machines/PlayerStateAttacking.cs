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
        player.thirdPersonController.MoveSpeed = 0.1f;
        Debug.Log("Player State: Attacking");

        lastAttackTime = Time.time;
        player.animator.SetTrigger("Attack01");

        float attackRange = 1;
        Collider[] arrColliders = Physics.OverlapSphere(player.transform.position + player.transform.forward, attackRange);
        // Physics.SphereCastAll(player.transform.position + player.transform.forward, attackRange, player.transform.forward, attackRange);

        foreach (var col in arrColliders) {
            //if damageable, damage
            var go = col.gameObject;
            var damageable = go.GetComponent<IDamageable>();
            if (damageable != null) {
                var damage = Random.Range(player.equipedWeapon.weaponData.weaponDamageRange.x, player.equipedWeapon.weaponData.weaponDamageRange.y);
                damageable.Damage(damage);
                Debug.Log($"{go.name} was hit for {damage}");
            }
        }
    }

    void IState.OnExit() {

        player.thirdPersonController.MoveSpeed = 5f;
    }

    IState IState.Tick() {

        if (Time.time > lastAttackTime + (1f / player.equipedWeapon.weaponData.weaponSpeed)) {

            var isMoving = player.characterController.velocity != Vector3.zero;
            if (!isMoving) {
                return player.stateIdle;
            } else {
                return player.stateWalking;
            }

        } else {
            return this;
        }

    }

#endregion

#region Public Methods

#endregion
}