using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


// Component to watch an BoolValue ScriptableObject
// Extends from BaseValue component

public class BoolValueObserver : BaseValueObserver<bool> {

    // IntValue to watch
    [Header("Value")]
    [SerializeField]
    private BoolValue _value;
    protected override BaseValue<bool> value => _value;

    // String formatted value
    [Header("String values")]
    [SerializeField]
    protected string _formatted = "{0}";
    protected override string formatted => _formatted;

    // Events exposed
    [Header("Events")]
    [SerializeField]
    private BoolEvent _onValueChange;
    protected override UnityEvent<bool> onValueChange => _onValueChange;

    [SerializeField]
    private StringEvent _onValueChangeAsString;
    protected override StringEvent onValueChangeAsString => _onValueChangeAsString;
    
}
