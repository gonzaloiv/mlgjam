using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfigSystem : Singleton<ConfigSystem> {
    public LaunchMode launchMode = LaunchMode.Production;
}