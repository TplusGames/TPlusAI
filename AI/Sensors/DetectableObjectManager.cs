using System.Collections.Generic;
using UnityEngine;

namespace TPlus.AI
{
    public class DetectableObjectManager : MonoBehaviour
    {
        public static DetectableObjectManager Instance;

        private List<AI_Base> _detectableObjects = new List<AI_Base>();

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                return;
            }
            Destroy(gameObject);
        }

        public void RegisterDetectableObject(AI_Base obj)
        {
            _detectableObjects.Add(obj);
        }

        public void UnregisterDetectableObject(AI_Base obj)
        {
            _detectableObjects.Remove(obj);
        }

        public List<AI_Base> GetAllDetectableObjects()
        {
            return _detectableObjects;
        }
    }
}

