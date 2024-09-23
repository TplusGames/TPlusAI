using System;
using TPlus.StateMachine;
using UnityEngine;
using UnityEngine.AI;

namespace TPlus.AI
{
    [RequireComponent(typeof(NavMeshAgent))]
    [RequireComponent(typeof(VisionSensor))]
    public class AI_Base : HFSM_Base
    {
        public AISettings AISettings;
    
        public AISM_Idle IdleStateMachine { get; private set; }

        private NavMeshAgent _agent;
        private VisionSensor _visionSensor;

        protected override void Start()
        {
            RegisterAI();
            SetTickSpeed();
            InitializeReferences();
            InitializeStateMachines();
            base.Start();
        }

        protected virtual void OnDisable()
        {
            UnregisterAI();
        }

        private void RegisterAI()
        {
            DetectableObjectManager.Instance.RegisterDetectableObject(this);
        }

        private void UnregisterAI()
        {
            DetectableObjectManager.Instance.UnregisterDetectableObject(this);
        }

        private void SetTickSpeed()
        {
            _tickSpeed = AISettings.TickSpeed;
        }

        protected virtual void InitializeReferences()
        {
            _agent = GetComponent<NavMeshAgent>();
            _visionSensor = GetComponent<VisionSensor>();
        }

        protected virtual void InitializeStateMachines()
        {
            var info = new AISMInfo()
            {
                AI = this,
                Agent = _agent,
                VisionSensor = _visionSensor
            };
            IdleStateMachine = new AISM_Idle(null, info);
            ChangeStateMachine(IdleStateMachine);
        }

        public virtual bool IsHostile(AI_Base ai)
        {
            return true; 
        }
    }
}

