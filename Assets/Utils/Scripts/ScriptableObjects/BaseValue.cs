using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

// ScriptableObject
// An scriptable object that stores a value, with event functionalities to notify changes.
// In combination of an implementation of a BaseValueListener, this makes data comunication really easy, and independent from any system.

namespace Belwyn.Utils {

    public abstract class BaseValue<T> : ScriptableObject, ISerializationCallbackReceiver {

        // Stored value
        [SerializeField]
        [Delayed]
        [Header("Value (right-click to invoke)")]
        [ContextMenuItem("Invoke Change", "InvokeChange")]
        protected T _initialValue;

        private T _runtimeValue;


        // Property for the value. When setted, raises the event.
        public T value {
            get => _runtimeValue;
            set {
                _runtimeValue = value;
                onValueChange.Invoke(_runtimeValue);
            }
        }

        // Value change event
        protected abstract UnityEvent<T> onValueChange { get; }


        // ISerializationCallbackReceiver implementation
        // After serialization, store value in a runtiem vatiable to avoid writing on disk
        public void OnAfterDeserialize()
        {
		    _runtimeValue = _initialValue;
        }

        public void OnBeforeSerialize() {
        }


        ///// Methods

        // Editor invoke value change
        //[ContextMenu("Invoke change")]
        virtual protected void InvokeChange() {
            value = _initialValue;
        }


        // Listener managing
        public void AddListener(UnityAction<T> callback) {
            onValueChange.AddListener(callback);
        }

        public void RemoveListener(UnityAction<T> callback) {
            onValueChange.RemoveListener(callback);
        }

        private void OnDisable() {
            onValueChange.RemoveAllListeners();
        }

    }

}