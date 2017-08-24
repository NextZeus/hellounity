# The Light Inspector

Lights determine the shading of an object and the shadows it casts. As such, they are a fundamental part of graphical rendering. See documentation on [lighting](https://docs.unity3d.com/Manual/LightingOverview.html) and [Global Illumination](https://docs.unity3d.com/Manual/GlobalIllumination.html) for further details about lighting concepts in Unity.

![](https://docs.unity3d.com/uploads/Main/class-Light-0.png)

|   Property:|	Function:|
|:-----------|:----------:|
|**Type**|	The current type of light. Possible values are Directional, Point, Spot and Area (see the lighting overview for details of these types).|
|**Range**|	Define how far the light emitted from the center of the object travels (**Point** and **Spot** lights only).|
|**Spot Angle**|	Define the angle (in degrees) at the base of a spot light’s cone (**Spot** light only).|
|**Color**|	Use the color picker to set the color of the emitted light.|
|**Mode**|	Specify the [Light Mode](https://docs.unity3d.com/Manual/LightModes.html) used to determine if and how a light is “baked”. Possible modes are Realtime, Mixed and Baked. See documentation on [Realtime Lighting](https://docs.unity3d.com/Manual/LightMode-Realtime.html), [Mixed Lighting](https://docs.unity3d.com/Manual/LightMode-Mixed.html), and [Baked Lighting](https://docs.unity3d.com/Manual/LightMode-Baked.html) for more detailed information.|
|**Intensity**|	Set the brightness of the light. The default value for a **Directional** light is 0.5. The default value for a **Point**, **Spot** or **Area** light is 1.|
|**Indirect Multiplier**|	Use this value to vary the intensity of indirect light. Indirect light is light that has bounced from one object to another. The **Indirect Multiplier** defines the brightness of bounced light calculated by the global illumination (GI) system. If you set **Indirect Multiplier** to a value lower than 1, the bounced light becomes dimmer with every bounce. A value higher than 1 makes light brighter with each bounce. This is useful, for example, when a dark surface in shadow (such as the interior of a cave) needs to be brighter in order to make detail visible. Alternatively, if you want to use [Realtime Global Illumination](https://docs.unity3d.com/Manual/GlobalIllumination.html), but want to limit a single real-time Light so that it only emits direct light, set its Indirect Multiplier to 0.|
|**Shadow Type**|	Determine whether this Light casts Hard Shadows, Soft Shadows, or no shadows at all. See documentation on Shadows for information on hard and soft shadows.|
|Baked Shadow Angle| If Type is set to Directional and Shadow Type is set to Soft Shadows, this property adds some artificial softening to the edges of shadows and gives them a more natural look.|
Baked Shadow Radius| If Type is set to Point or Spot and Shadow Type is set to Soft Shadows, this property adds some artificial softening to the edges of shadows and gives them a more natural look.|
|Realtime Shadows|	These properties are available when Shadow Type is set to Hard Shadows or Soft Shadows. Use these properties to control real-time shadow rendering settings.|
|Strength| Use the slider to control how dark the shadows cast by this Light are, represented by a value between 0 and 1. This is set to 1 by default.|
|Resolution|	Control the rendered resolution of shadow maps. A higher resolution increases the fidelity of shadows, but requires more GPU time and memory usage.|
|Bias|	Use the slider to control the distance at which shadows are pushed away from the light, defined as a value between 0 and 2. This is useful for avoiding false self-shadowing artifacts. See Shadow mapping and the bias property for more information. This is set to 0.05 by default.|
|Normal Bias| 	Use the slider to control distance at which the shadow casting surfaces are shrunk along the surface normal, defined as a value between 0 and 3. This is useful for avoiding false self-shadowing artifacts. See documentation on Shadow mapping and the bias property for more information. This is set to 0.4 by default.|
|Near Plane|	Use the slider to control the value for the near clip plane when rendering shadows, defined as a value between 0.1 and 10. This value is clamped to 0.1 units or 1% of the light’s **Range** property, whichever is lower. This is set to 0.2 by default.|
|**Cookie**|	Specify a Texture mask through which shadows are cast (for example, to create silhouettes, or patterned illumination for the Light).|
|**Draw Halo**|	Tick this box to draw a spherical [Halo](https://docs.unity3d.com/Manual/class-Halo.html) of light with a diameter equal to the **Range** value. You can also use the Halo component to achieve this. Note that the Halo component is drawn in addition to the halo from the Light component, and that the Halo component’s **Size** parameter determines its radius, not its diameter.|
|**Flare**|	If you want to set a [Flare](https://docs.unity3d.com/Manual/class-Flare.html) to be rendered at the Light’s position, place an Asset in this field to be used as its source.|
|**Render Mode**|	Use this drop-down to set the rendering priority of the selected Light. This can affect lighting fidelity and performance (see Performance Considerations, below).|
|Auto|	The rendering method is determined at run time, depending on the brightness of nearby lights and the current [Quality Settings](https://docs.unity3d.com/Manual/class-QualitySettings.html).|
|Important|	The light is always rendered at per-pixel quality. Use Important mode only for the most noticeable visual effects (for example, the headlights of a player’s car).|
|Not Important|	The light is always rendered in a faster, vertex/object light mode.|
|Culling Mask	| Use this to selectively exclude groups of objects from being affected by the Light. For more information, see [Layers](https://docs.unity3d.com/Manual/Layers.html).|


## Details

If you create a Texture that contains an alpha channel and assign it to the **Cookie** variable of the light, the cookie is projected from the light. The cookie’s alpha mask modulates the light’s brightness, creating light and dark spots on surfaces. This is a great way to add complexity or atmosphere to a scene.

All [built-in shaders](https://docs.unity3d.com/Manual/Built-inShaderGuide.html) in Unity seamlessly work with any type of light. However, [VertexLit](https://docs.unity3d.com/Manual/Built-inShaderGuide.html) shaders cannot display Cookies or Shadows.

All Lights can optionally cast Shadows. To do this, set the **Shadow Type** property of each individual Light to either **Hard Shadows** or **Soft Shadows**. See documentation on [Shadows](https://docs.unity3d.com/Manual/ShadowOverview.html) for more information.


## Directional Light Shadows

See documentation on [directional light shadows](https://docs.unity3d.com/Manual/DirLightShadows.html) for an in-depth explanation of how they work. Note that shadows are disabled for directional lights with cookies when forward rendering is used. It is possible to write custom shaders to enable shadows in this case; see documentation on [writing surface shaders](https://docs.unity3d.com/Manual/SL-SurfaceShaders.html) for further details.

## Hints

* **Spot** lights with cookies can be extremely effective for creating the effect of light coming in from a window.
* Low-intensity point lights are good for providing depth to a Scene.
* For maximum performance, use a [VertexLit](https://docs.unity3d.com/Manual/Built-inShaderGuide.html) shader. This shader only does per-vertex lighting, giving a much higher throughput on low-end cards.


### 单词
* Indirect Multiplier 间接乘数
* dimmer 暗淡, 黯淡, 暗