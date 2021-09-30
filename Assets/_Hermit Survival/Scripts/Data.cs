using System.Collections;
using System.Collections.Generic;

public static class Data {
    public enum Events {
        GameManagerReady,
        LevelLoaded,
        GamePaused,
        GameUnpaused,
        GameOver
    }

    internal static int treeCommonMaxHealth = 30;
    internal static int halfLogCommonMaxHealth = 20;
    internal static int stumpCommonMaxHealth = 15;
    internal static int halfLogCommonWoodAmount = 5;
    internal static int stumpCommonWoodAmount = 2;
}