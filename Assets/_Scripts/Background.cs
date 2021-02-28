﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    // Holds the current offset.
    private float offset;

    // Reference to this object's material.
    private Material mat;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        mat = GetComponent<Renderer>().material;
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        offset += (Time.deltaTime / 20.0f);
        mat.SetTextureOffset("_MainTex", new Vector2(offset, 0));
    }
}
