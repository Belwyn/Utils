using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


// This file contains classes of generic implementations of UnityEvent<>.
// This is needed because Unity can't serialize generic types.

namespace Belwyn.Utils.Test {

    [System.Serializable]
    public abstract class EventDebug<T> {

        protected virtual UnityEvent<T> ev { get; set; }

        public EventDebug(UnityEvent<T> e) {
            ev = e;
        }

        public void Invoke(T arg) {
            #if TEST_BUILD
            ev?.Invoke(arg);
            #endif
        }

    }


    [System.Serializable] public class IntEventDebug : EventDebug<int> {
        [SerializeField] private IntEvent _event;
        protected override UnityEvent<int> ev => _event;
        public IntEventDebug() : base(new IntEvent()) {}
    }
    [System.Serializable] public class StringEventDebug : EventDebug<string> {
        [SerializeField] private StringEvent _event;
        protected override UnityEvent<string> ev => _event;
        public StringEventDebug() : base(new StringEvent()) {}
    }
    [System.Serializable] public class BoolEventDebug : EventDebug<bool> {
        [SerializeField] private BoolEvent _event;
        protected override UnityEvent<bool> ev => _event;
        public BoolEventDebug() : base(new BoolEvent()) { }
    }
    [System.Serializable] public class FloatEventDebug : EventDebug<float> {
        [SerializeField] private FloatEvent _event;
        protected override UnityEvent<float> ev => _event;
        public FloatEventDebug() : base(new FloatEvent()) { }
    }
    [System.Serializable] public class Vector2EventDebug : EventDebug<Vector2> {
        [SerializeField] private Vector2Event _event;
        protected override UnityEvent<Vector2> ev => _event;
        public Vector2EventDebug() : base(new Vector2Event()) { }
    }
    [System.Serializable] public class Vector3EventDebug : EventDebug<Vector3> {
        [SerializeField] private Vector3Event _event;
        protected override UnityEvent<Vector3> ev => _event;
        public Vector3EventDebug() : base(new Vector3Event()) { }
    }
    [System.Serializable] public class GameObjectEventDebug : EventDebug<GameObject> {
        [SerializeField] private GameObjectEvent _event;
        protected override UnityEvent<GameObject> ev => _event;
        public GameObjectEventDebug() : base(new GameObjectEvent()) { }
    }

}