using System.Collections;
using System.Collections.Generic;
using System;

using UnityEngine;
using UnityEngine.UI;

using Belwyn.Utils;


// Simple class that adds some amount of images to a transform 
public class Spawner : MonoBehaviour
{

    // Pool definition of the time we want
    // This is required for Unity to serialize the generic class
    [Serializable]
    private class SpawnPool : Pool<Image> { }
    [SerializeField]
    private SpawnPool _pool;

    // Transform were it'll manage the images
    [SerializeField]
    private Transform _spawnTransform;    

    // <!> It's our responsibility to manage the components obtained from the pool <!>
    // The pool only optimizes the gameobject retrieval efficiently
    [SerializeField]
    public List<Image> _images;


    private bool _isInit = false;


    private void Awake() {
        if (!_isInit) Init();
    }

    private void Init() {
        _pool.Init(_spawnTransform);
        _images = new List<Image>();
        _isInit = true;
    }



    public void Spawn(int amount) {

        // Safety check
        if (!_isInit) Init();
        amount = Math.Max(amount, 0);
        amount = Math.Min(amount, _pool.maxItems);

        // Clean
        while(_images.Count > 0) {
            _pool.DestroyItem(_images[0]);
            _images.RemoveAt(0);
        }

        // Spawn images
        for (int i = 0; i < amount; i++) {
            Image image = _pool.RetrieveItem();
            _images.Add(image);
            image.transform.SetParent(_spawnTransform);
            image.gameObject.SetActive(true);            
        }

    }


}
