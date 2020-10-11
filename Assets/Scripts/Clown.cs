using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Clown : MonoBehaviour
{
    [SerializeField]
    private AnimationClip explosionClip;

    [SerializeField]
    private Text nameText;

    public string clownName;


    private Animator animator;

    private float explosionTime;


    private void Awake()
    {
        animator = GetComponent<Animator>();
        explosionTime = explosionClip.length;
    }


    [ContextMenu("Explode")]
    public void Explode()
    {
        animator.SetTrigger("boom"); 
        Destroy(gameObject, explosionTime);
    }



    public void ChangeName(string newName)
    {
        clownName = newName;
        nameText.text = clownName;

    }





}
