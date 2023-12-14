// Copyright © Pixel Crushers. All rights reserved.

using UnityEngine;
using PixelCrushers.EmeraldAISupport;

namespace PixelCrushers.QuestMachine.EmeraldAISupport
{

    /// <summary>
    /// Set the behavior of Emerald AIs of a specific faction.
    /// </summary>
    public class EmeraldAISetBehaviorQuestAction : QuestAction
    {

        [EmeraldAIFaction]
        [SerializeField]
        private int m_faction;

        [SerializeField]
        private EmeraldAI.EmeraldAISystem.CurrentBehavior m_behavior;

        public int faction
        {
            get { return m_faction; }
            set { m_faction = value; }
        }

        public EmeraldAI.EmeraldAISystem.CurrentBehavior behavior
        {
            get { return m_behavior; }
            set { m_behavior = value; }
        }

        public override void Execute()
        {
            base.Execute();
            EmeraldAIUtility.ApplyToFaction(faction, SetBehavior);
        }

        private void SetBehavior(EmeraldAI.EmeraldAISystem ai)
        {
            if (ai == null) return;
            if (QuestMachine.debug) Debug.Log("Quest Machine: Set Emerald AI " + ai.name + " behavior to " + behavior + ".", ai);
            ai.EmeraldEventsManagerComponent.ChangeBehavior(behavior);
        }

        public override string GetEditorName()
        {
            return "Emerald AI set behavior to " + behavior;
        }

    }
}
