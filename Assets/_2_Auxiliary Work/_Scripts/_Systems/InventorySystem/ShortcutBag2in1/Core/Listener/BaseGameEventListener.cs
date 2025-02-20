﻿using UnityEngine;
using UnityEngine.Events;

/****************
 * UTF-8
 ***************/
namespace iii_UMVR06_TPSDefenseGame_Subroutines_2.InventorySystem {

    public abstract class BaseGameEventListener<T, E, UER> : MonoBehaviour,
        IGameEventListener<T> where E : BaseGameEvent<T> where UER : UnityEvent<T> {
        
        [SerializeField] private E gameEvent;
        public E GameEvent { get { return gameEvent; } set { gameEvent = value; } }

        [SerializeField] private UER unityEventResponse;

        private void OnEnable() {
            if(gameEvent == null) { return; }

            GameEvent.RegisterListener(this);
        }

        private void OnDisale() {
            if(gameEvent == null) { return; }

            GameEvent.UnregisterListener(this);
        }

        public void OnEventRaised(T item) {
            if(unityEventResponse != null) {
                unityEventResponse.Invoke(item);
            }
        }
    }

}
