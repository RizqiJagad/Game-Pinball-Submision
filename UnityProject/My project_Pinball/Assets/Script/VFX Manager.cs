using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXManager : MonoBehaviour
{
    public GameObject vfxPrefab; // Ganti nama variabel untuk lebih jelas
    
    public void PlayVFX(Vector3 spawnPosition)
    {
        Instantiate(vfxPrefab, spawnPosition, Quaternion.identity);
    }
}
