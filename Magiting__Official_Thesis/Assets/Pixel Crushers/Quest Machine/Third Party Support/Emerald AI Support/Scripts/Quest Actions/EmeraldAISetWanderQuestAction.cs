// Copyright © Pixel Crushers. All rights reserved.

using UnityEngine;
using PixelCrushers.EmeraldAISupport;

namespace PixelCrushers.QuestMachine.EmeraldAISupport
{

    /// <summary>
    /// Set the wander type of Emerald AIs of a specific faction.
    /// </summary>
    public class EmeraldAISetWanderQuestAction : QuestAction
    {

        [EmeraldAIFaction]
        [SerializeField]
        private int m_faction;

        [SerializeField]
        private EmeraldAI.EmeraldAISystem.WanderType m_wanderType;

        public int faction
        {
            get { return m_faction; }
            set { m_faction = value; }
        }

        public EmeraldAI.EmeraldAISystem.WanderType wanderType
        {
            get { return m_wanderType; }
            set { m_wanderType = value; }
        }

        public override void Execute()
        {
            base.Execute();
            EmeraldAIUtility.ApplyToFaction(faction, SetBehavior);
        }

        private void SetBehavior(EmeraldAI.EmeraldAISystem ai)
        {
            if (ai == null) return;
            if (QuestMachine.debug) Debug.Log("Quest Machine: Set Emerald AI " + ai.name + " wander type to " + wanderType + ".", ai);
            ai.EmeraldEventsManagerComponent.ChangeWanderType(wanderType);
        }

        public override string GetEditorName()
        {
            return "Emerald AI set wander type to " + wanderType;
        }

    }
}
