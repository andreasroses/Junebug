using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationUpdater : MonoBehaviour{
    [SerializeField] private Animator animator;
    private Transform playerTransform;
    void Start(){
        playerTransform = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
