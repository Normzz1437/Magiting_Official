// Copyright © Pixel Crushers. All rights reserved.

using UnityEngine;
using PixelCrushers.EmeraldAISupport;

namespace PixelCrushers.QuestMachine.EmeraldAISupport
{

    /// <summary>
    /// Kills all Emerald AIs belonging to a specified faction.
    /// </summary>
    public class EmeraldAIKillQuestAction : QuestAction
    {

        [EmeraldAIFaction]
        [SerializeField]
        private int m_faction;

        public int faction
        {
            get { return m_faction; }
            set { m_faction = value; }
        }

        public override void Execute()
        {
            base.Execute();
            EmeraldAIUtility.ApplyToFaction(faction, Damage);
        }

        private void Damage(EmeraldAI.EmeraldAISystem ai)
        {
            if (ai == null) return;
            if (QuestMachine.debug) Debug.Log("Quest Machine: Killing Emerald AI " + ai.name + ".", ai);
            ai.EmeraldEventsManagerComponent.KillAI();
        }

        public override string GetEditorName()
        {
            return "Kill Emerald AI faction";
        }

    }
}
