﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodBook : MonoBehaviour
{
    Collider2D c2d;

    void Awake()
    {
        c2d = GetComponent<Collider2D>();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        var player = col.gameObject.GetComponent<PlayerController>();
        if (player != null)
        {
            Debug.Log("Add wood ability");
            col.gameObject.AddComponent<WoodAbility>();
            Destroy(gameObject);
        }
    }

    public void DisableCollision(float time=3f)
    {
        StartCoroutine(DisableCollisionCoroutine(time));
    }

    IEnumerator DisableCollisionCoroutine(float time)
    {
        // Prevent the user from taking the book
        // c2d.enabled = false;
        yield return new WaitForSeconds(time);
        // c2d.enabled = true;
    }
}
