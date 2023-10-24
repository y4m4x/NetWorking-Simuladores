using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using Unity.Netcode;
using UnityEngine;

public class PlayerNetwork : NetworkBehaviour
{
    [SerializeField] float moveSpeed = 3f;
    [SerializeField] private Transform spawnObjectPrefab;
    private Transform spawnBullet;
    private void Update()
    {
        if (!IsOwner) return;

        Vector3 moveDir = Vector3.zero;

        if (Input.GetKey(KeyCode.W)) moveDir.z = 1f;
        if (Input.GetKey(KeyCode.S)) moveDir.z = -1f;
        if (Input.GetKey(KeyCode.A)) moveDir.x = -1f;
        if (Input.GetKey(KeyCode.D)) moveDir.x = 1f;

        if (Input.GetKeyDown(KeyCode.T))
        {
            spawnBullet = Instantiate(spawnObjectPrefab, transform.position, Quaternion.identity);
            spawnBullet.GetComponent<NetworkObject>().Spawn(true);
        }

        transform.Translate(moveDir * moveSpeed * Time.deltaTime);
    }
}
