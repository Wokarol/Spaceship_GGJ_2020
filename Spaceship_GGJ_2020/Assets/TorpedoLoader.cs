﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using DG.Tweening;

public class TorpedoLoader : MonoBehaviour
{
    [SerializeField] private Transform theTorpedo = null;
    [SerializeField] private Transform theStart = null;
    [SerializeField] private Transform theLaunch = null;
    [Space]                            
    [SerializeField] private float slidingTime = 5f;

    private Animator animator;
    private bool isLoading;

    public bool TheTorpedoInBay { get; private set; } = true;
    public Transform TheTorpedo => theTorpedo;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void LoadTorpedo()
    {
        if (isLoading || TheTorpedoInBay)
            return;
        animator.SetTrigger("Load");
        isLoading = true;
    }

    public void LoadedTorpedo()
    {
        
        isLoading = false;
        TheTorpedo.gameObject.SetActive(true);
        TheTorpedo.position = theStart.position;
        TheTorpedo.DOMove(theLaunch.position, slidingTime).SetEase(Ease.Linear)
            .OnComplete(() => { TheTorpedoInBay = true; });
    }

    public void TorpedoTaken()
    {
        TheTorpedoInBay = false;
    }
}