﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class TurtleTransition : MonoBehaviour {
    public GameObject SmallTurtle;
    public GameObject BigTurtle;
    public Transform SunShafts;
    public VisualEffect Effect;

    public float Duration = 2f;
    public float ModelTransitionTime = 0.25f;
    private float timer;
    private bool hasTransitioned;
    private bool isActive;

    public void TriggerEffect() {
        // Effect.gameObject.SetActive(true);
        // Effect.SendEvent("OnStart");
        // SunShafts.position = Vector3.left * 1000;
        SoundManager.PlaySound("start_game");
        isActive = true;
        hasTransitioned = false;
        timer = 0f;
    }

    public void EndEffect() {
        // Effect.SendEvent("OnStop");
        // SunShafts.position = Vector3.zero;
        isActive = false;
        transform.localScale = Vector3.one;
    }

    private void Update() {
        if (isActive) {
            timer += GameTime.DeltaTime;
            if (timer <= Duration / 2f) {
                transform.localScale = Vector3.one * (1 - timer / (Duration / 2f));
            } else if (timer > Duration / 2f) {
                if (!hasTransitioned) {
                    SmallTurtle.SetActive(false);
                    BigTurtle.SetActive(true);
                    hasTransitioned = true;
                }

                transform.localScale = Vector3.one * ((timer - Duration / 2f) / (Duration / 2f));
            }
            
            if (timer >= Duration) {
                EndEffect();
            }
        }
    }
}