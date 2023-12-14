// Copyright © Pixel Crushers. All rights reserved.

using UnityEngine;
using PixelCrushers.EmeraldAISupport;

namespace PixelCrushers.QuestMachine.EmeraldAISupport
{

    /// <summary>
    /// Set the confidence of Emerald AIs of a specific faction.
    /// </summary>
    public class EmeraldAISetConfidenceQuestAction : QuestAction
    {

        [EmeraldAIFaction]
        [SerializeField]
        private int m_faction;

        [SerializeField]
        private EmeraldAI.EmeraldAISystem.ConfidenceType m_confidence;

        public int faction
        {
            get { return m_faction; }
            set { m_faction = value; }
        }

        public EmeraldAI.EmeraldAISystem.ConfidenceType confidence
        {
            get { return m_confidence; }
            set { m_confidence = value; }
        }

        public override void Execute()
        {
            base.Execute();
            EmeraldAIUtility.ApplyToFaction(faction, SetBehavior);
        }

        private void SetBehavior(EmeraldAI.EmeraldAISystem ai)
        {
            if (ai == null) return;
            if (QuestMachine.debug) Debug.Log("Quest Machine: Set Emerald AI " + ai.name + " confidence to " + confidence + ".", ai);
            ai.EmeraldEventsManagerComponent.ChangeConfidence(confidence);
        }

        public override string GetEditorName()
        {
            return "Emerald AI set confidence to " + confidence;
        }

    }
}
