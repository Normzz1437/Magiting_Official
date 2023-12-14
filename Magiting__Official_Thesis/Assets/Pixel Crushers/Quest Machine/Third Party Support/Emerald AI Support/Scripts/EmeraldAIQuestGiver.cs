// Copyright © Pixel Crushers. All rights reserved.

using UnityEngine;
using UnityEngine.AI;
using EmeraldAI;

namespace PixelCrushers.QuestMachine.EmeraldAISupport
{
    /// <summary>
    /// Use this in place of QuestGiver on an Emerald AI if you want it to 
    /// stop its AI activity while the player is talking to it.
    /// </summary>
    public class EmeraldAIQuestGiver : QuestGiver
    {

        private const string UnpausePlayerMessage = "Unpause Player";

        private EmeraldAISystem emeraldAISystem;
        private NavMeshAgent navMeshAgent;

        public override void Awake()
        {
            base.Awake();
            emeraldAISystem = GetComponent<EmeraldAISystem>();
            navMeshAgent = GetComponent<NavMeshAgent>();
        }

        public override void OnEnable()
        {
            base.OnEnable();
            MessageSystem.AddListener(this, QuestMachineMessages.GreetedMessage, id);
            MessageSystem.AddListener(this, UnpausePlayerMessage, string.Empty);
        }

        public override void OnDisable()
        {
            base.OnDisable();
            MessageSystem.RemoveListener(this, QuestMachineMessages.GreetedMessage, id);
            MessageSystem.RemoveListener(this, UnpausePlayerMessage, string.Empty);
        }

        public override void OnMessage(MessageArgs messageArgs)
        {
            switch (messageArgs.message)
            {
                case QuestMachineMessages.GreetedMessage:
                    StopAI();
                    break;
                case UnpausePlayerMessage:
                    ResumeAI();
                    break;
                default:
                    base.OnMessage(messageArgs);
                    break;
            }
        }

        public virtual void StopAI()
        {
            if (player)
            {
                emeraldAISystem.EmeraldEventsManagerComponent.RotateAITowardsTarget(player.transform, -1);
            }
                emeraldAISystem.Deactivate();
                navMeshAgent.ResetPath();
                navMeshAgent.isStopped = true;
                navMeshAgent.enabled = false;
        }

        public virtual void ResumeAI()
        {
            emeraldAISystem.Activate();
            navMeshAgent.enabled = true;
            navMeshAgent.isStopped = false;
            if (player)
            {
                emeraldAISystem.EmeraldEventsManagerComponent.CancelRotateAITowardsTarget();
            }
        }

    }
}
