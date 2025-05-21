using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankVartant : MonoBehaviour
{
    public Animator animator;
    public TankMovement tankMovement;
    public TankShot tankShot;
    public HealthSystem healthSystem;
    public SpriteRenderer gunConektor, gun, hull, track1, tower, track2;
    public TankData tankData;
    private void Start()
    {
        tankMovement.moveSpeed = tankData.moveSpeed;
        tankShot.bulletDamage = tankData.bulletDamage;
        tankShot.bulletSpeed = tankData.bulletSpeed;
        healthSystem.health = tankData.health;
        healthSystem.healthMax = tankData.health;
        gunConektor.sprite = tankData.gunConektor;
        gun.sprite = tankData.gun;
        hull.sprite = tankData.hull;
        track1.sprite = tankData.track;
        track2.sprite = tankData.track;
        tower.sprite = tankData.tower;
        var overrideController = new AnimatorOverrideController(animator.runtimeAnimatorController);
        overrideController["MoveAnimation1"] = tankData.moveAnimation;
        animator.runtimeAnimatorController = overrideController;
    }


}
