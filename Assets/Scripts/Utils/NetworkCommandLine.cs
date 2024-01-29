using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class NetworkCommandLine : MonoBehaviour
{
    private NetworkManager _networkMgr;
    // Start is called before the first frame update
    void Start()
    {
        _networkMgr = GetComponentInParent<NetworkManager>();

        if (Application.isEditor) return;

        var args = GetCommandlineArgs();

        if (args.TryGetValue("-mode", out var mode))
        {
            switch (mode)
            {
                case "server":
                    _networkMgr.StartServer();
                    break;
                case "host":
                    _networkMgr.StartHost();
                    break;
                case "client":
                    _networkMgr.StartClient();
                    break;
            }
        }
    }

    private Dictionary<string, string> GetCommandlineArgs()
    {
        var argDictionary = new Dictionary<string, string>();
        var args = System.Environment.GetCommandLineArgs();

        for (int i = 0; i < args.Length; ++i)
        {
            var arg = args[i].ToLower();
            if (arg.StartsWith("-"))
            {
                var value = i < args.Length - 1 ? args[i + 1].ToLower() : null;
                value = (value?.StartsWith("-") ?? false ? null : value);
                
                argDictionary.Add(arg, value);
            }
        }

        return argDictionary;
    }
}
