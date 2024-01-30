using System;
using Unity.Netcode;
using UnityEngine;

namespace HelloWorld
{
    public class NetworkTransformTest : NetworkBehaviour
    {
        private void Update()
        {
            if (IsServer)
            {
                float theta = Time.frameCount / 10f;
                transform.position = new Vector3((float) Math.Cos(theta), 0.0f, (float)Math.Sin(theta));
            }
        }
    }
}
