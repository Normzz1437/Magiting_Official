using UnityEngine;

namespace PixelCrushers.QuestMachine.EmeraldAISupport
{

    /// <summary>
    /// This Spawner subclass provides special handling for spawning 
    /// Emerald AI entities because Emerald AI tries to manipulate the
    /// AI's NavMeshAgent in Awake(), before the AI has been moved into position.
    /// </summary>
    public class EmeraldSpawner : Spawner
    {
        protected override void SpawnAndPlaceEntity()
        {
            if (!IsThereSpaceForEntity()) return;
            var prefab = ChooseWeightedRandomPrefab();
            if (prefab == null)
            {
                if (Debug.isDebugBuild) Debug.LogWarning("Quest Machine: A prefab entry is blank in this spawner. Not spawning.", this);
                return;
            }
            spawnCount++;
            var instance = Instantiate(prefab.prefab, transform.position, transform.rotation);
            instance.transform.SetParent(spawnAsRootObjects ? null : this.transform);
            var spawnedEntity = instance.GetComponent<SpawnedEntity>() ?? instance.AddComponent<SpawnedEntity>();
            spawnedEntity.spawnerName = StringField.GetStringValue(spawnerName);
            spawnedEntity.disabled -= OnSpawnedEntityDisabled;
            spawnedEntity.disabled += OnSpawnedEntityDisabled;
            PlaceSpawnedEntity(spawnedEntity);

        }
    }
}
