# Shadows
Unity’s lights can cast Shadows from a GameObject onto other parts of itself or onto other nearby GameObjects. Shadows add a degree of depth and realism to a Scene, because they bring out the scale and position of GameObjects that can otherwise look flat.

![](https://docs.unity3d.com/uploads/Main/ShadowIntro.png)
Scene with GameObjects casting shadows

## How do Shadows work?

Consider a simple Scene with a single light source. Light rays travel in straight lines from that source, and may eventually hit GameObjects in the Scene. Once a ray has hit a GameObject, it can’t travel any further to illuminate anything else (that is, it “bounces” off the first GameObject and doesn’t pass through). The shadows cast by the GameObject are simply the areas that are not illuminated because the light couldn’t reach them.

![](https://docs.unity3d.com/uploads/Main/ShadowMapIntro.svg)

Another way to look at this is to imagine a Camera at the same position as the light. The areas of the Scene that are in shadow are precisely those areas that the Camera can’t see.

![](https://docs.unity3d.com/uploads/Main/ShadowLightsEyeView.svg)

A “light’s eye view” of the same Scene

In fact, this is exactly how Unity determines the positions of shadows from a light. The light uses the same principle as a Camera to “render” the Scene internally from its point of view. A depth buffer system, as used by Scene Cameras, keeps track of the surfaces that are closest to the light; surfaces in a direct line of sight receive illumination but all the others are in shadow. The depth map in this case is known as a **Shadow Map** (you may find the [Wikipedia Page](http://en.wikipedia.org/wiki/Shadow_mapping) on shadow mapping useful for further information).

## Enabling Shadows

Use the Shadow Type property in the Inspector to enable and define shadows for an individual light.

![](https://docs.unity3d.com/uploads/Main/ShadowTypeInspector.svg)

|	Property:	|Function:|
|:-----------:|---------:|
|**Shadow Type**|	The Hard Shadows setting produces shadows with a sharp edge. Hard shadows are not particularly realistic compared to Soft Shadows but they involve less processing, and are acceptable for many purposes. Soft shadows also tend to reduce the “blocky” aliasing effect from the shadow map.|
|**Strength**|	This determines how dark the shadows are. In general, some light is scattered by the atmosphere and reflected off other GameObjects, so you usually don’t want shadows to be set to maximum strength.|
|**Resolution**|	This sets the rendering resolution for the shadow map’s “Camera” mentioned above. If your shadows have very visible edges, then you might want to increase this value.|
|**Bias**|	Use this to fine-tune the position and definition of your shadow. See Shadow mapping and the Bias property, below, for more information.|
|**Normal Bias**|	Use this to fine-tune the position and definition of your shadow. See Shadow mapping and the Bias property, below, for more information.|
|**Shadow Near Plane**|	This allows you to choose the value for the near plane when rendering shadows. GameObjects closer than this distance to the light do not cast any shadows.|

Each [Mesh Renderer](https://docs.unity3d.com/Manual/class-MeshRenderer.html) in the Scene also has a **Cast Shadows** and a **Receive Shadows** property, which must be enabled as appropriate.

![](https://docs.unity3d.com/uploads/Main/ShadowCastMeshInspector.svg)

Enable **Cast Shadows** by selecting **On** from the drop-down menu to enable or disable shadow casting for the mesh. Alternatively, select **Two Sided** to allow shadows to be cast by either side of the surface (so backface culling is ignored for shadow casting purposes), or **Shadows Only** to allow shadows to be cast by an invisible GameObject.

## Shadow mapping and the Bias property

The shadows for a given Light are determined during the final Scene rendering. When the Scene is rendered to the main Camera view, each pixel position in the view is transformed into the coordinate system of the Light. The distance of a pixel from the Light is then compared to the corresponding pixel in the shadow map. If the pixel is more distant than the shadow map pixel, then it is presumably obscured from the Light by another GameObject and it obtains no illumination.

![](https://docs.unity3d.com/uploads/Main/ShadowBiasGood.jpg)

Correct shadowing

A surface directly illuminated by a Light sometimes appears to be partly in shadow. This is because pixels that should be exactly at the distance specified in the shadow map are sometimes calculated as being further away (this is a consequence of using shadow filtering, or a low-resolution image for the shadow map). The result is arbitrary patterns of pixels in shadow when they should really be lit, giving a visual effect known as “shadow acne”.

![](https://docs.unity3d.com/uploads/Main/ShadowBiasAcne.jpg)

Shadow acne in the form of false self-shadowing artifacts

To prevent shadow acne, a **Bias** value can be added to the distance in the shadow map to ensure that pixels on the borderline definitely pass the comparison as they should, or to ensure that while rendering into the shadow map, GameObjects can be inset a little bit along their normals. These values are set by the **Bias** and **Normal Bias** properties in the [Light](https://docs.unity3d.com/Manual/class-Light.html) Inspector window when shadows are enabled.

Do not set the **Bias** value too high, because areas around a shadow near the GameObject casting it are sometimes falsely illuminated. This results in a disconnected shadow, making the GameObject look as if it is flying above the ground.


![](https://docs.unity3d.com/uploads/Main/ShadowBiasPeterPanning.jpg)
A high Bias value makes the shadow appear “disconnected” from the GameObject

Likewise, setting the Normal Bias value too high makes the shadow appear too narrow for the GameObject:

![](https://docs.unity3d.com/uploads/Main/ShadowBiasTooThin.jpg)

A high Normal Bias value makes the shadow shape too narrow

In some situations, **Normal Bias** can cause an unwanted effect called “light bleeding”, where light bleeds through from nearby geometry into areas that should be shadowed. A potential solution is to open the GameObject’s [Mesh Renderer](https://docs.unity3d.com/Manual/class-MeshRenderer.html) and change the **Cast Shadows** property to **Two Sided**. This can sometimes help, although it can be more resource-instensive and increase performance overhead when rendering the Scene.

The bias values for a Light may need tweaking to make sure that unwanted effects occur. It is generally easier to gauge the right value by eye rather than attempting to calculate it.

To further prevent shadow acne we are using a technique known as **Shadow pancaking** (see [Directional light shadows: Shadow pancaking](https://docs.unity3d.com/Manual/DirLightShadows.html)). This generally works well, but can create visual artifacts for very large triangles.

![](https://docs.unity3d.com/uploads/Main/ShadowNearOffsetTooLow.png)

A low Shadow near plane offset value create the appearance of holes in shadows

Tweak the **Shadow Near Plane Offset** property to troubleshoot this problem. Setting this value too high introduces shadow acne.

![](https://docs.unity3d.com/uploads/Main/ShadowNearOffsetOk.png)

Correct shadowing


