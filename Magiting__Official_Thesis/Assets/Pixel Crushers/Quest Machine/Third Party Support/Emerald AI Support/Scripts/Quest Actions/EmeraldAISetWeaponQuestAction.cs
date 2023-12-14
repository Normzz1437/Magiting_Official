// Copyright © Pixel Crushers. All rights reserved.

using UnityEngine;
using PixelCrushers.EmeraldAISupport;

namespace PixelCrushers.QuestMachine.EmeraldAISupport
{

    /// <summary>
    /// Enables or disables weapons of Emerald AIs of a specific faction.
    /// </summary>
    public class EmeraldAISetWeaponQuestAction : QuestAction
    {

        [EmeraldAIFaction]
        [SerializeField]
        private int m_faction;

        public enum Mode { Enable, Disable }

        [SerializeField]
        private Mode m_mode = Mode.Enable;

        public enum WeaponType { Melee, Ranged }

        [SerializeField]
        private WeaponType m_weaponType = WeaponType.Melee;

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

        public WeaponType weaponType
        {
            get { return m_weaponType; }
            set { m_weaponType = value; }
        }

        public override void Execute()
        {
            base.Execute();
            EmeraldAIUtility.ApplyToFaction(faction, SetWeapon);
        }

        protected void SetWeapon(EmeraldAI.EmeraldAISystem ai)
        {
            if (ai == null) return;
            if (QuestMachine.debug) Debug.Log("Quest Machine: Set Emerald AI " + ai.name + " weapon " + mode + ".", ai);
            switch (mode)
            {
                case Mode.Enable:
                    ai.EmeraldEventsManagerComponent.EquipWeapon(GetWeaponTypeString());
                    break;
                case Mode.Disable:
                    ai.EmeraldEventsManagerComponent.UnequipWeapon(GetWeaponTypeString());
                    break;
            }
        }

        protected string GetWeaponTypeString()
        {
            return (weaponType == WeaponType.Melee) ? "Melee" : "Ranged";
        }

        public override string GetEditorName()
        {
            return "Emerald AI " + mode + " weapon";
        }

    }
}
