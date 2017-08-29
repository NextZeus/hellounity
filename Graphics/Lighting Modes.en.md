# Lighting Modes

This page assumes you have already read documentation on [lighting in Unity](https://docs.unity3d.com/Manual/LightingInUnity.html).

To control lighting precomputation and composition in Unity, you need to assign a **Light Mode** to a Light. This **Light Mode** defines the Light’s intended use. To assign a Light Mode, select the Light in your Scene and, in the [Light Inspector window](https://docs.unity3d.com/Manual/GlobalIllumination.html), select **Mode**.

![](https://docs.unity3d.com/uploads/Main/LightModes-0.png)

The Modes and their possible mappings are:

* [Realtime](https://docs.unity3d.com/Manual/LightMode-Realtime.html)
* [Mixed](https://docs.unity3d.com/Manual/LightMode-Mixed.html) - Mixed Lights have their own sub-modes. Set these in the Lighting window:
	* [Baked Indirect](https://docs.unity3d.com/Manual/LightMode-Mixed-BakedIndirect.html)
	* [Shadowmask](https://docs.unity3d.com/Manual/LightMode-Mixed-DistanceShadowmask.html)
	* [Distance Shadowmask](https://docs.unity3d.com/Manual/LightMode-Mixed-Shadowmask.html)
	* [Subtractive](https://docs.unity3d.com/Manual/LightMode-Mixed-Subtractive.html)
*Baked(LightMode-Baked)

For more information, see the [Reference card for Light Modes](https://drive.google.com/open?id=1v-LnDOJcsSsa0ViF7kBs6xgY9Q_z-1k6h95LE0lf46U).

The Modes are listed above in the order of least to most light path precomputations required (See How Modes work, below). Note that this order does not necessarily correlate with the amount of time the actual precomputation requires.

## How Modes work

Each Mode in the Light Inspector window corresponds to a group of settings in the Lighting window (menu: **Window** > **Lighting** > **Settings** > **Scene**).

![](https://docs.unity3d.com/uploads/Main/LightModes-1.png)

The available Light Modes in the Light component (left), and the corresponding settings available for those modes in the Lighting Scene window (right).

| **Light Inspector**| **Lighting window**|**Function**|
|:--------------:|:--------------:|:------:|
|**Realtime**|	**Realtime Lighting**|	Unity calculates and updates the lighting of Realtime Lights every frame during run time. No Realtime Lights are precomputed.|
|**Mixed**|	**Mixed Lighting**|	Unity can calculate some properties of Mixed Lights during run time, but only within strong limitations. Some Mixed Lights are precomputed.|
|**Baked**|	**Lightmapping Settings**|	Unity pre-calculates the illumination from Baked Lights before run time, and does not include them in any run-time lighting calculations. All Baked Lights are precomputed.|

Use these settings to adjust each mode. The adjustments you make apply to all Lights with that Mode assigned to them. For example, if you open the Lighting window, navigate to the **Realtime Lighting Settings** and tick **Realtime Global Illumination**, all Lights that have their **Mode** set to **Realtime** mode use **Realtime Global Illumination**.

Precomputation yields two sets of results:

* Unity stores results for static GameObjects as Texture atlases in UV Texture coordinate space. Unity provides several settings to [control this layouting](https://docs.unity3d.com/Manual/GlobalIllumination.html).
* [Light Probes](https://docs.unity3d.com/Manual/LightProbes.html) store a representation of light in empty space as seen from their particular position. Dynamic GameObjects moving through this portion of empty space use this information to receive illumination from the precomputed lighting.


