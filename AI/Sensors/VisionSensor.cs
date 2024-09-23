using System.Collections;
using System.Collections.Generic;
using TPlus.AI;
using UnityEngine;

public class VisionSensor : MonoBehaviour
{
    public delegate void EnemySpotted(Transform target);
    public event EnemySpotted OnEnemySpotted;

    [SerializeField] private AISettings aiSettings;

    private float _cosVisionConeAngle;

    private void Start()
    {
        InvokeRepeating(nameof(PerformVisionScan), 0,aiSettings.TickSpeed);
        _cosVisionConeAngle = Mathf.Cos(aiSettings.VisionConeAngle * Mathf.Deg2Rad);
    }

    private void PerformVisionScan()
    {
        for (int i = DetectableObjectManager.Instance.GetAllDetectableObjects().Count - 1; i >= 0; i--)
        {
            var detectable = DetectableObjectManager.Instance.GetAllDetectableObjects()[i];

            if (detectable.gameObject == this.gameObject)
                continue;

            var vectorToTarget = detectable.transform.position - transform.position;

            if (vectorToTarget.sqrMagnitude > aiSettings.VisionRange * aiSettings.VisionRange)
            {
                continue;
            }

            if (Vector3.Dot(vectorToTarget.normalized, transform.forward) < _cosVisionConeAngle)
            {
                continue;
            }

            RaycastHit hit;
            if (Physics.Raycast(transform.position, vectorToTarget, out hit))
            {
                if (hit.transform.gameObject == detectable.gameObject)
                {
                    Debug.Log(gameObject.name + " can see " + detectable.gameObject.name);
                    Debug.DrawLine(transform.position, hit.point, Color.red, 1f);

                    if (detectable.DetectableObjectType == EDetectableObjectType.Player)
                    {
                        OnEnemySpotted?.Invoke(detectable.transform);
                    }
                }
            }
        }
    }
}
