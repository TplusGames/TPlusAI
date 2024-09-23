using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectableObjectManager : MonoBehaviour
{
    public static DetectableObjectManager Instance;

    private List<DetectableObject> _detectableObjects = new List<DetectableObject>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            return;
        }
        Destroy(gameObject);
    }

    public void RegisterDetectableObject(DetectableObject obj)
    {
        _detectableObjects.Add(obj);
    }

    public void UnregisterDetectableObject(DetectableObject obj)
    {
        _detectableObjects.Remove(obj);
    }

    public List<DetectableObject> GetAllDetectableObjects()
    {
        return _detectableObjects;
    }
}
