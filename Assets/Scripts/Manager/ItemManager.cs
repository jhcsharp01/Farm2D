using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Manager
{
    public class ItemManager : MonoBehaviour
    {
        public Harvest[] harvests;

        private Dictionary<CollectType, Harvest> harvestMap
        = new Dictionary<CollectType, Harvest>();

        private void Awake()
        {
            foreach (var harvest in harvests)
            {
                Add(harvest);
            }
        }

        private void Add(Harvest harvest)
        {
            if (!harvestMap.ContainsKey(harvest.type))
            {
                harvestMap.Add(harvest.type, harvest);
            }
        }

        public Harvest GetItem(CollectType type)
        {
            if (harvestMap.ContainsKey(type))
            {
                return harvestMap[type];
            }
            return null;
        }

    }
}

