using System.Collections;
using System.Collections.Generic;

public class HealthSystem {

    private int currentHealth;
    private int maxHealth;
    private bool isDead;

    public HealthSystem(int maxHealth) {
        this.maxHealth = maxHealth;
        this.currentHealth = maxHealth;
        this.isDead = false;
    }

    public int GetCurrentHealth() {
        return currentHealth;
    }

    public int GetMaxHealth() {
        return maxHealth;
    }

    public bool IsDead() {
        return currentHealth <= 0;
    }

    public void Damage(int amount) {
        currentHealth -= amount;
        if (currentHealth < 0) {
            currentHealth = 0;
        }
    }

    public void Heal(int amount) {
        currentHealth += amount;
        if (currentHealth > maxHealth) {
            currentHealth = maxHealth;
        }
    }
}