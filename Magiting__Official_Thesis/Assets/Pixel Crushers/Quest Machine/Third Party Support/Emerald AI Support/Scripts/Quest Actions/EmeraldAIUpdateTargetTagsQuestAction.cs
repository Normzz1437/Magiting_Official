// Copyright © Pixel Crushers. All rights reserved.

using UnityEngine;
using PixelCrushers.EmeraldAISupport;

namespace PixelCrushers.QuestMachine.EmeraldAISupport
{

    /// <summary>
    /// Set the behavior of Emerald AIs of a specific faction.
    /// </summary>
    public class EmeraldAIUpdateTargetTagsQuestAction : QuestAction
    {

        [EmeraldAIFaction]
        [SerializeField]
        private int m_faction;

        [EmeraldAIFaction]
        [SerializeField]
        private int m_newFaction;

        //[EmeraldAIFaction]
        //[SerializeField]
        //private int m_opposingFaction1;

        //[EmeraldAIFaction]
        //[SerializeField]
        //private int m_opposingFaction2;

        //[EmeraldAIFaction]
        //[SerializeField]
        //private int m_opposingFaction3;

        //[EmeraldAIFaction]
        //[SerializeField]
        //private int m_opposingFaction4;

        //[EmeraldAIFaction]
        //[SerializeField]
        //private int m_opposingFaction5;

        public int faction
        {
            get { return m_faction; }
            set { m_faction = value; }
        }

        public int newFaction
        {
            get { return m_newFaction; }
            set { m_newFaction = value; }
        }

        //public int opposingFaction1
        //{
        //    get { return m_opposingFaction1; }
        //    set { m_opposingFaction1 = value; }
        //}

        //public int opposingFaction2
        //{
        //    get { return m_opposingFaction2; }
        //    set { m_opposingFaction2 = value; }
        //}

        //public int opposingFaction3
        //{
        //    get { return m_opposingFaction3; }
        //    set { m_opposingFaction3 = value; }
        //}

        //public int opposingFaction4
        //{
        //    get { return m_opposingFaction4; }
        //    set { m_opposingFaction4 = value; }
        //}

        //public int opposingFaction5
        //{
        //    get { return m_opposingFaction5; }
        //    set { m_opposingFaction5 = value; }
        //}

        public override void Execute()
        {
            base.Execute();
            EmeraldAIUtility.ApplyToFaction(faction, UpdateTargetTags);
        }

        private void UpdateTargetTags(EmeraldAI.EmeraldAISystem ai)
        {
            if (ai == null) return;
            var newFactionString = GetFactionString(newFaction);
            if (QuestMachine.debug) Debug.Log("Quest Machine: Set Emerald AI " + ai.name + " faction to " + newFactionString + ".", ai);
            ai.CurrentFaction = newFaction;
            //ai.OpposingFaction1 = opposingFaction1;
            //ai.OpposingFaction2 = opposingFaction2;
            //ai.OpposingFaction3 = opposingFaction3;
            //ai.OpposingFaction4 = opposingFaction4;
            //ai.OpposingFaction5 = opposingFaction5;
        }

        private string GetFactionString(int i)
        {
            return (EmeraldAI.EmeraldAISystem.StringFactionList != null && (0 <= i && i < EmeraldAI.EmeraldAISystem.StringFactionList.Count)) ? EmeraldAI.EmeraldAISystem.StringFactionList[i] : null;
        }

        public override string GetEditorName()
        {
            return "Quest Machine: Set Emerald AI faction and tags";
        }

    }
}
