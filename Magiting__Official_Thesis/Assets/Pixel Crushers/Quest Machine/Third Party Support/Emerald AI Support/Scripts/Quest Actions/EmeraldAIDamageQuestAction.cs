// Copyright © Pixel Crushers. All rights reserved.

using UnityEngine;
using PixelCrushers.EmeraldAISupport;

namespace PixelCrushers.QuestMachine.EmeraldAISupport
{

    /// <summary>
    /// Damages all Emerald AIs belonging to a specified faction.
    /// </summary>
    public class EmeraldAIDamageQuestAction : QuestAction
    {

        [EmeraldAIFaction]
        [SerializeField]
        private int m_faction;

        [SerializeField]
        private int m_damageAmount;

        [SerializeField]
        private EmeraldAI.EmeraldAISystem.TargetType m_targetType;

        public int faction
        {
            get { return m_faction; }
            set { m_faction = value; }
        }

        public int damageAmount
        {
            get { return m_damageAmount; }
            set { m_damageAmount = value; }
        }

        public EmeraldAI.EmeraldAISystem.TargetType targetType
        {
            get { return m_targetType; }
            set { m_targetType = value; }
        }

        public override void Execute()
        {
            base.Execute();
            EmeraldAIUtility.ApplyToFaction(faction, Damage);
        }

        private void Damage(EmeraldAI.EmeraldAISystem ai)
        {
            if (ai == null) return;
            if (QuestMachine.debug) Debug.Log("Quest Machine: Emerald AI " + ai.name + " taking " + damageAmount + " damage from " + targetType + ".", ai);
            ai.Damage(damageAmount, targetType);
        }

        public override string GetEditorName()
        {
            return "Damage Emerald AI faction for " + damageAmount;
        }

    }
}
