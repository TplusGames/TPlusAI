using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectableObject : MonoBehaviour
{
    public EDetectableObjectType DetectableObjectType;
    protected virtual void Start()
    {
        DetectableObjectManager.Instance.RegisterDetectableObject(this);
    }
    protected virtual void OnDisable()
    {
        DetectableObjectManager.Instance.UnregisterDetectableObject(this);
    }
}
public enum EDetectableObjectType
{
    Player,
    Human,
    Preditor,
    Prey
}
