// Copyright © Pixel Crushers. All rights reserved.

using PixelCrushers.EmeraldAISupport;
using UnityEngine;

namespace PixelCrushers.QuestMachine.EmeraldAISupport
{

    /// <summary>
    /// Enables or disables items of Emerald AIs of a specific faction.
    /// </summary>
    public class EmeraldAISetItemQuestAction : QuestAction
    {

        [EmeraldAIFaction]
        [SerializeField]
        private int m_faction;

        public enum Mode { Enable, Disable, DisableAll }

        [SerializeField]
        private Mode m_mode = Mode.Enable;

        [SerializeField]
        private int m_itemID;

        public int faction
        {
            get { return m_faction; }
            set { m_faction = value; }
        }

        public Mode mode
        {
            get { return m_mode; }
            set { m_mode = value; }
        }

        public int itemID
        {
            get { return m_itemID; }
            set { m_itemID = value; }
        }

        public override void Execute()
        {
            base.Execute();
            EmeraldAIUtility.ApplyToFaction(faction, SetWeapon);
        }

        private void SetWeapon(EmeraldAI.EmeraldAISystem ai)
        {
            if (ai == null) return;
            if (QuestMachine.debug)
            {
                if (mode == Mode.DisableAll) Debug.Log("Quest Machine: Disable all items on Emerald AI " + ai.name + ".", ai);
                else Debug.Log("Quest Machine: " + mode + " Emerald AI " + ai.name + " item " + itemID + ".", ai);
            }
            switch (mode)
            {
                case Mode.Enable:
                    ai.EmeraldEventsManagerComponent.EnableItem(itemID);
                    break;
                case Mode.Disable:
                    ai.EmeraldEventsManagerComponent.DisableItem(itemID);
                    break;
                case Mode.DisableAll:
                    ai.EmeraldEventsManagerComponent.DisableAllItems();
                    break;
            }
        }

        public override string GetEditorName()
        {
            return (mode == Mode.DisableAll) ? "Emerald AI disable all items"
                : mode + " Emerald AI item " + itemID;
        }

    }
}
