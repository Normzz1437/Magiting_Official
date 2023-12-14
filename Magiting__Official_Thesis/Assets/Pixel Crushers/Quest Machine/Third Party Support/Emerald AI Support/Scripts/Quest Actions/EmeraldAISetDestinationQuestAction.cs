// Copyright © Pixel Crushers. All rights reserved.

using UnityEngine;
using PixelCrushers.EmeraldAISupport;

namespace PixelCrushers.QuestMachine.EmeraldAISupport
{

    /// <summary>
    /// Set the destination of Emerald AIs of a specific faction.
    /// </summary>
    public class EmeraldAISetDestinationQuestAction : QuestAction
    {

        [EmeraldAIFaction]
        [SerializeField]
        private int m_faction;

        [SerializeField]
        private StringField m_destination = new StringField();

        public int faction
        {
            get { return m_faction; }
            set { m_faction = value; }
        }

        public StringField destination
        {
            get { return m_destination; }
            set { m_destination = value; }
        }

        public override void Execute()
        {
            base.Execute();
            EmeraldAIUtility.ApplyToFaction(faction, SetDestination);
        }

        private void SetDestination(EmeraldAI.EmeraldAISystem ai)
        {
            if (ai == null) return;
            if (StringField.IsNullOrEmpty(destination))
            {
                if (QuestMachine.debug) Debug.Log("Quest Machine: Emerald AI " + ai.name + " destination ID is blank.", ai);
            }
            else
            {
                var go = QuestMachineMessages.FindGameObjectWithID(destination);
                if (go == null)
                {
                    if (QuestMachine.debug) Debug.LogWarning("Quest Machine: Emerald AI " + ai.name + " can't find destination with ID/name '" + destination + "'.", ai);
                }
                else
                {
                    if (QuestMachine.debug) Debug.LogWarning("Quest Machine: Emerald AI " + ai.name + " set destination to '" + destination + "'.", ai);
                    ai.EmeraldEventsManagerComponent.SetDestination(go.transform);
                }
            }
        }

        public override string GetEditorName()
        {
            return "Emerald AI set destination to " + destination;
        }

    }
}
