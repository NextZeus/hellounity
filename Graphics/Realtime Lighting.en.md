# Realtime Lighting

Real-time Lights are [Light components](https://docs.unity3d.com/Manual/class-Light.html) which have their **Mode** property set to **Realtime**.

Use **Realtime** mode for Lights that need to change their properties or which are spawned via scripts during gameplay. Unity calculates and updates the lighting of these Lights every frame at run time. They can change in response to actions taken by the player, or events which take place in the Scene. For example, you can set them to switch on and off (like a flickering light), change their Transforms (like a torch being carried through a dark room), or change their visual properties, like their color and intensity.

Real-time Lights illuminate and cast realistic shadows on both static and dynamic GameObjects. They cast shadows up to the **Shadow Distance** (defined in **Edit** > **Project Settings** > **Quality**).

You can also combine real-time Lights with **Realtime Global Illumination** (**Realtime GI**), so that they contribute indirect lighting to static and dynamic GameObjects.

## Using real-time lighting with Realtime GI

The combination of real-time lighting with Realtime GI is the most flexible and realistic lighting option in Unity. To enable Realtime GI, open the [Lighting window](https://docs.unity3d.com/Manual/GlobalIllumination.html) (menu: **Window** > **Lighting** > **Settings**) and tick **Realtime Global Illumination**.

When **Realtime GI** is enabled, real-time Lights contribute indirect lighting into the Scene, as well as direct lighting. Use this combination for light sources which change slowly and have a high visual impact on your Scene, such as the sun moving across the sky, or a slowly pulsating light in a closed corridor. You don’t need to use **Realtime GI** for Lights that change quickly, or for special effects, because the latency of the system does not make it worth the overhead.

Note that **Realtime GI** uses significant system resources compared to the less complex **Baked GI**. Global Illumination is managed in Unity by a piece of middleware called Enlighten, which has its own overheads (system memory and CPU cycles). See documentation on [Global Illumination](https://docs.unity3d.com/Manual/GlobalIllumination.html) for more information.

**Realtime GI** is suitable for games targeting mid-level to high-end PC systems, and games targeting current-gen consoles such as the PS4 and Xbox One. Some high-end mobile devices might also be powerful enough to make use of this feature, but you should keep Scenes small and the resolution for real-time light maps low to conserve system resources.

To disable the effect of **Realtime GI** on a specific light, select the Light GameObject and, in the Light component, set the **Indirect Multiplier** to 0. This means that the Light does not contribute any indirect light. To disable **Realtime GI** altogether, open the Lighting window (menu: **Window** > **Lighting** > **Settings**) and untick **Realtime Global Illumination**.

## Disadvantages of using real-time lighting with Realtime GI

* Increased memory requirements, due to the additional set of low resolution real-time light maps used to store the real-time indirect bounces computed by the Enlighten lighting system.
* Increased shader calculation requirements, due to sampling of the additional set of real-time light maps and probes used to store the real-time indirect bounces computed by the Enlighten lighting system.
* Indirect lighting converges over time, so property changes cannot be too abrupt. Adaptive HDR tone mapping might help you hide this; to learn more, see the Unity Post Processing Stack ([Asset Store](https://www.assetstore.unity3d.com/en/?&_ga=2.194424751.36024221.1503977217-1300961171.1497254613#!/content/83912)).

## Technical details

In the case of real-time Lights (that is, Light components with their **Mode** set to **Realtime**), the last emission (or path segment) from the surface to the Light is not precomputed. This means that Lights can move around the Scene, and change visual properties like color and intensity. See documentation on [Using Enlighten in Unity](https://docs.unity3d.com/Manual/Using%20Enlighten%20with%20Unity.pdf) for more information on path segments.

If the Light also casts shadows, both dynamic and static GameObjects in the Scene are rendered into the Light’s [shadow map](https://docs.unity3d.com/Manual/Shadows.html). This shadow map is sampled by the [Material Shaders](https://docs.unity3d.com/Manual/Shaders.html) of both static and dynamic GameObjects, so that they cast real-time shadows on each other. The **Shadow Distance** (menu: **Edit** > **Project Settings** > **Quality** > **Shadows**) controls the maximum distance at which shadows start to fade out and disappear entirely, which in turn affects performance and image quality.

If **Realtime GI** is not enabled, real-time Lights only calculate direct lighting on dynamic and static GameObjects. If **Realtime GI** is enabled, Unity uses Enlighten to precompute the surface-to-surface light paths for static GameObjects.

![](https://docs.unity3d.com/uploads/Main/LightMode-Realtime-0.png)

Precomputed **Realtime GI** mode: Unity only precomputes surface-to-surface information

The last path segment (that is, the segment from the surface to the Light emitter) is not part of the precomputation. The only information stored is that if the surface is illuminated, then the following surfaces and probes are also illuminated, and the intensities of the various illuminations. There is a separate set of low-resolution real-time light maps, which Enlighten iteratively updates on the CPU at run time with the information of real-time Lights. Because this iterative process is computationally intensive, it is split across several frames. In other words, it takes a couple of frames until the light has fully bounced across the static elements in the Scene, and the real-time light maps and [Light Probes](https://docs.unity3d.com/Manual/LightProbes.html) have converged to the final result.

For Lights with properties that change slowly (such as a light-emitting sun moving across the sky), this does not pose a problem. However, for Lights with properties that change quickly (such as a flickering lightbulb), the iterative nature of Realtime GI may prove unsuitable. Fast property changes do not register significantly with the bounced light system, so there is no point in including them in the calculations.

There are several ways to address this problem. One way is to reduce the real-time light map resolution. Because this results in less calculation at run time, the lighting converges faster. Another option is to increase the [CPU Usage](https://docs.google.com/document/d/1SEkozSX298iM6N1MONyss8IA2B5rtrfTStE72Tul2Y0/edit) setting for the **Realtime GI** runtime. By dedicating more CPU time, the runtime converges faster. The tradeoff is of course that other systems receive less CPU time to do their work. Whether this is acceptable depends on each individual project. Note that as this is a per-Scene setting, you can dedicate more or less CPU time based on the complexity of each individual Scene in the project.

Even though **Realtime GI** is enabled on a per-Scene basis for all real-time Lights, it is still possible to prevent individual real-time Lights from being considered by **Realtime GI**. To achieve this, set the Light component’s **Mode** to **Realtime** and its [indirect multiplier](https://docs.google.com/document/d/1vmBiK2Ez-A7Z1OpJjWB1IJ4_OSDIVwPgmq8xNhMUMfk/edit) to 0, removing all indirect light contributions.

