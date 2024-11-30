using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateContainer : MonoBehaviour
{
    public Transform[] Layers => layers;
    
    [SerializeField] private Transform[] layers;
}
