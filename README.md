# Utils
Core Unity engine utilities for development

This repository contains a project with some engine utilities to create new projects with a nice-to-have scaffold to work and develop with

The scenes in the project will exemplify the usages of some systems.

## Design Patterns

#### Object Pool class
The Pool<> abstract class can be inherited with a type of MonoBehaviour. Given a gameobject and a maximum number of items to have available in the pool, calling RetrieveItem() and DestroyItem(item) will give an instance of the object, or dispose of it, managing the hierarchy pool and enabling/disabling gameobjects efficiently, so no in-game object creation or destruction is produced.

### Singleton Behaviour
The SingletonBehaviour<> can be inherited with a type of Monobehaviour. This abstract class ensures when Awake() is called that there is only one instance of this component, and can be accessed statically.

### Permanent Gameobject
The PermanentGameobject component marks the Gameobject as persistent, so it is kept alive between scenes.
This in conjuction with a SingletonBehaviour can be really useful for creating a manager.

### Events
Just some definition of generic events, because unity can't serialize generic classes, so you don't have to declare an IntEvent class to use it in the inspector anymore.


## Value Observers
This is a system useful for storing a value and making it easy for any component to observe and read any changes on that value at any given time, while being totally agnostic.

#### Value asset
The Values are declared as ScriptableObjects, an abstract generic BaseValue<> with all the functionality and some type-defined implementations line IntValue, FloatValue, BoolValue or StringValue (you can create more if you need them!)

The Values have a property to access and change the value. When changing it, it invokes an event with the new value. You can add and remove listeners with its public methods.

#### Value Observer component
The other part of this system are the ValueObservers. Again there is an abstract generic BaseValueObserver<> and the implementation of the other types of data created (if you need more Values, you may need more ValueObservers!)

The value observer is a component in which you can assign via inspector the Value you want to observer, and it automatically subscribers or unsubscribes to the Value event fired when it changes, so it auto wires without any additional code.

The observer also serializes in the inspector some events (if the data type is serializable), an event with the value so you can execute whatever you may need with the value, and an event with the value as a String for dynamic UI text representation.

#### What this means ####
The key to this system is that the value is a project Asset, so it's independent of any scene logic, and when you change the asset Value data it essentially "broadcasts" its change so any observer can respond to it without any hardcoding, dependency or extra code.

**--- Beware ---**

This system should not be overused. A ScriptableObject keeps its data in editor on disk between sessions, so you may want to reset values when starting or ending processes. Having *EVERYTHING* working with this can be a real pain.
Use it for broadcasting data and having an agnostic responsive UI!


## Build Configurations

This is a system to define scripting symbols in configuration assets for each platform. There are two default configurations, Editing and Shipping, that are used in addition with your own configuration.

Those defaults are there because symbols in code are processed at compilation time, so you can't use them dynamically. They will be used for some other utilities in this project, so I implemented them as an addition.

Create a BuildConfiguration asset in the project window context menu, and in the inspector assign the scripting symbols you will be using, and mark if the configuration will be Testing or Shipping (or none).

You can override the configuration for other platforms. If not, the standalone will be applied to every platform (I only added Android and iOS, add any more you need!)

At the bottom of the asset inspector there's a button, it applies the configuration to the project. In the Build submenu on top of the unity window you can apply the defaults, or open a simple window to help you apply your configuration assets from the project.
