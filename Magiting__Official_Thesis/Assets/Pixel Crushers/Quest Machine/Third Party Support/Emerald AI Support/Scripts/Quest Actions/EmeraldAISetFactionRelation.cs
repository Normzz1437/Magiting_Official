// Copyright © Pixel Crushers. All rights reserved.

using UnityEngine;
using PixelCrushers.EmeraldAISupport;

namespace PixelCrushers.QuestMachine.EmeraldAISupport
{

    /// <summary>
    /// Set a faction's relation to another faction or the player. Affects all
    /// Emerald AIs in the faction.
    /// </summary>
    public class EmeraldAISetFactionRelation : QuestAction
    {

        [EmeraldAIFaction]
        [SerializeField]
        private int m_faction;

        [EmeraldAIFaction]
        [SerializeField]
        private int m_targetFaction;

        [Tooltip("Ignore Target Faction and set relation to player instead.")]
        [SerializeField]
        private bool m_setRelationToPlayer;

        [SerializeField]
        private EmeraldAI.EmeraldAISystem.PlayerFactionClass.RelationType relationType = EmeraldAI.EmeraldAISystem.PlayerFactionClass.RelationType.Neutral;

        public int faction
        {
            get { return m_faction; }
            set { m_faction = value; }
        }

        public int targetFaction
        {
            get { return m_targetFaction; }
            set { m_targetFaction = value; }
        }

        public bool setRelationToPlayer
        {
            get { return m_setRelationToPlayer; }
            set { m_setRelationToPlayer = value; }
        }

        public override void Execute()
        {
            base.Execute();
            EmeraldAIUtility.ApplyToFaction(faction, UpdateTargetTags);
        }

        private void UpdateTargetTags(EmeraldAI.EmeraldAISystem ai)
        {
            if (ai == null) return;
            var targetFactionString = GetFactionString(targetFaction);
            if (QuestMachine.debug) Debug.Log("Quest Machine: Set Emerald AI " + ai.name + " relation to " + (setRelationToPlayer ? "player" : targetFactionString) + " to " + relationType + ".", ai);
            if (setRelationToPlayer)
            {
                ai.PlayerFaction[0].RelationTypeRef = relationType;
            }
            else
            {
                ai.FactionRelations[ai.AIFactionsList.IndexOf(faction)] = (int)relationType;
            }
        }

        private string GetFactionString(int i)
        {
            return (EmeraldAI.EmeraldAISystem.StringFactionList != null && (0 <= i && i < EmeraldAI.EmeraldAISystem.StringFactionList.Count)) ? EmeraldAI.EmeraldAISystem.StringFactionList[i] : null;
        }

        public override string GetEditorName()
        {
            return setRelationToPlayer ? "Quest Machine: Set Emerald AI Relation to Player" : "Quest Machine: Set Emerald AI Relation";
        }

    }
}
