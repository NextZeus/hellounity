# 照明窗

照明窗口（菜单：窗口 > 照明>设置）是Unity [全局照明](https://docs.unity3d.com/Manual/GIIntro.html)（GI）功能的主要控制点。虽然Unity中的GI可以通过默认设置获得良好的效果，但照明窗口的属性允许您调整GI流程的许多方面，自定义场景或根据需要优化质量，速度和存储空间。此窗口还包括环境光，光环，曲奇和雾的设置。

## 概观

照明窗口的控件分为三个选项卡：

* **“场景”**选项卡设置适用于整个场景，而不是单个GameObjects。这些设置控制照明效果和优化选项。
* 所述全局地图标签显示所有由GI照明过程中产生的光照资产文件。
* **“对象映射”** 选项卡显示当前所选GameObject的GI lightmap纹理（包括阴影掩码）的预览。

窗口还显示了显示内容下方的 **“自动生成”** 复选框。如果勾选此复选框，Unity会在您编辑场景时更新光照贴图数据。请注意，更新通常需要几秒钟而不是瞬间发生。如果您自动生成**“自动生成”**框，则复选框右侧的**“生成照明”**按钮将激活; 当您需要时，使用此按钮来触发光照贴图更新。如果要从场景中清除烘焙数据而不清除GI缓存，请使用**“生成照明”**按钮。

## 场景标签

**“场景”**选项卡包含适用于整个场景的设置，而不是单个GameObjects。“场景”选项卡包含几个部分：

* [环境](https://docs.unity3d.com/Manual/GlobalIllumination.html#Environment)
* [实时照明](https://docs.unity3d.com/Manual/GlobalIllumination.html#RealtimeLighting)
* [混合照明](https://docs.unity3d.com/Manual/GlobalIllumination.html#MixedLighting)
* [Lightmapping设置](https://docs.unity3d.com/Manual/GlobalIllumination.html#LightmappingSettings)
* [其他设置](https://docs.unity3d.com/Manual/GlobalIllumination.html#OtherSettings)
* [调试设置](https://docs.unity3d.com/Manual/GlobalIllumination.html#DebugSettings)

## 环境

环境照明部分包含天空盒，漫射照明和反射的设置。

![](https://docs.unity3d.com/uploads/Main/GlobalIllumination-0.png)

|   属性     |   功能  |
|:----------:|--------:|
|Skybox材质	|天空盒是一种物质，在场景中的其他物体后面，以模拟天空或其他遥远的背景。使用此属性选择要用于场景的天空物料。默认值为[“标准资产”](https://docs.unity3d.com/Manual/HOWTO-InstallStandardAssets.html)中的**“默认天空材料”**框。|
|太阳源|	当使用程序性天空盒时，使用此方法指定具有方向Light组件的GameObject，以指示“太阳”的方向（或任何大的远距离光源照亮场景）。如果设置为无（默认），则假定场景中最亮的定向光代表太阳。|
|环境照明|	这些设置会影响远离环境的光线。|
|资源|	漫射环境光（也称为环境光）是场景周围存在的光，不会来自任何特定的源对象。使用它来定义源颜色。默认值为Skybox。|
|颜色|	选择此项以对场景中的所有环境光使用平面颜色。|
|梯度|	选择此选项可以从天空，地平线和地面选择不同颜色的环境光，并在它们之间平滑融合。|
|空中包厢|	选择此项以使用天空盒的颜色（如果由Skybox Material指定）来确定来自不同角度的环境光。这允许比Gradient更精确的效果。|
|强度乘数|	用于设置场景中漫反射环境光的亮度，定义为0到8之间的值。默认值为1。|
|环境模式|	使用它来指定应用于处理场景中环境光的全局照明模式。此属性仅在场景中启用实时照明和烘烤照明时可用。|
|即时的|	如果要实时计算和更新场景中的环境光，请选择实时。|
|烘烤的|	如果要在运行时将环境光预先计算并设置到场景中，请选择“ 烘烤”。|
|环境思考|	这些设置控制Reflection Probe烘焙中涉及的全局设置以及影响全局反射的设置。|
|资源|	使用此设置可指定是否要使用天空盒进行反射效果，还是选择多维数据集地图。默认值为Skybox。|
空中包厢|	选择此选项可使用天空盒进行反射。如果选择Skybox，则会显示一个名为Resolution的附加选项。使用它来设置天空盒的分辨率以作为反射目的。|
|习惯|	选择此选项可使用多维数据集映射进行反射。如果选择自定义，则会显示一个名为Cubemap的附加选项。使用它来设置天空盒的多维数据集映射以作为反射目的。|
|压缩|	使用它来定义反射纹理是否被压缩。默认设置为自动。|
|汽车|	如果压缩格式合适，则反射纹理被压缩。|
|未压缩|	反射纹理存储在未压缩的存储器中。|
|压缩|	纹理被压缩。|
|强度乘数|	反射源（反射源属性中指定的天空盒或立方体贴图）在反射对象中可见的程度。|
|反弹|	当来自一个对象的反射然后被另一个对象反射时，会发生反射“反弹”。反射通过使用反射探测器在场景中捕获。使用此属性设置反射探测器评估反射在对象之间的次数。如果这设置为1，则Unity仅考虑初始反射（来自Reflection Source属性中指定的skybox或多维数据集映射）。|

## 实时照明

![](https://docs.unity3d.com/uploads/Main/GlobalIllumination-1.png)

|   属性     |   功能  |
|:----------:|--------:|
|实时全球照明	|如果勾选此复选框，Unity将实时计算和更新照明。有关更多信息，请参阅[实时全局照明文档](https://docs.unity3d.com/Manual/LightMode-Realtime.html)。|

## 混合照明

![](https://docs.unity3d.com/uploads/Main/GlobalIllumination-2.png)

|   属性     |   功能  |
|:----------:|--------:|
|烤全球照明|	如果勾选此复选框，则Unity预先计算照明，并在运行时将其设置为场景。有关详细信息，请参阅[烘焙全局照明](https://docs.unity3d.com/Manual/LightMode-Baked.html)文档。|
|照明模式|	**照明模式**确定[混合灯光](https://docs.unity3d.com/Manual/LightMode-Mixed.html)和阴影与场景中GameObjects一起使用的方式。**注意**: 更改**照明模式**时，还需要重新烘烤场景。如果在“照明”窗口中启用了**“自动生成”**，则会自动进行。如果未启用自动生成，请单击生成照明以查看更新的照明效果。|
|实时影子颜色	|定义用于渲染实时阴影的颜色。此设置仅在**“照明模式”**设置为**“减影”**时可用。|

## Lightmapping设置

![](https://docs.unity3d.com/uploads/Main/GlobalIllumination-3.png)

|   属性     |   功能  |
|:----------:|--------:|
|Lightmapper|	使用它来指定用于计算场景中的光照图的内部照明计算软件。选项是Enlighten和Progressive（实验）。默认值为Enlighten。查看文档[进Lightmapper](https://docs.unity3d.com/Manual/ProgressiveLightmapper.html)有关实验的详细信息进 Lightmapper功能。|
|间接决议|	使用此值指定要用于间接照明计算的每个单位的纹素数。增加这个值可以提高间接光的视觉质量，同时也增加了烘烤光照的时间。默认值为2。|
|光照分辨率|	使用此值指定每单位用于光照贴图的纹素数。增加此值可提高光照贴图质量，同时也可增加烘烤时间。默认值为40。|
|光照贴图|	使用此值指定烘焙光图中不同形状之间的间隔（以纹素单位）。默认值为2。|
|光照尺寸|	完整光照贴图纹理的大小（以像素为单位），其中包含单个对象纹理的单独区域。默认值为1024。|
|压缩光照贴图|	压缩光照贴图需要更少的存储空间，但是压缩过程可以在纹理中引入不需要的视觉效果。勾选此复选框以压缩光照贴图，或者取消选中它以使其不被压缩。该复选框默认勾选。|
|环境光遮蔽|	打勾时，会打开一组设置，允许您控制[环境遮挡](https://docs.unity3d.com/Manual/LightingBakedAmbientOcclusion.html)中表面的相对亮度。较高的值表示闭塞和充分亮起的区域之间的较大对比度。这仅适用于由GI系统计算的间接照明。默认情况下启用此设置。|
|最大距离|	设置一个值以控制射线的投射距离，以确定对象是否被遮挡。较大的值产生较长的光线并为光照贴图贡献更多的阴影，而较小的值产生较短的光线，仅当对象彼此非常接近时才会贡献阴影。值为0会投射无限长射线，没有最大距离。默认值为1。|
|间接贡献|	使用滑块来缩放间接光的亮度，如最终的光照图（即环境光，或从物体反射和发射的光）从0到10之间的值。默认值为1.小于1的值减少强度，而值大于1会增加。|
|直接贡献|	使用滑块可以从0到10之间的值缩放直射光的亮度。默认值为0.该值越高，对比度越大，直接照明应用。|
|最终聚集|	当启用**最终聚集**时，GI计算中的最终光反弹以与烘焙光图相同的分辨率计算。这提高了光照图的视觉质量，但是在编辑器中以额外的烘烤时间为代价。|
|雷计数|	使用此值定义每个最终聚集点发射的光线数。默认值为256。|
|去噪|	勾选此复选框以将去噪滤波器应用于最终的收集输出。默认情况下勾选此框。|
|定向模式|	您可以将光线图设置为在物体表面上的每个点存储关于主要入射光的信息。有关更多详细信息，请参阅[定向光图](https://docs.unity3d.com/Manual/LightmappingDirectional.html)的文档。默认模式为Directional。|
|定向|	在定向模式下，产生第二个光照贴图以存储入射光的主要方向。这允许漫反射法线贴图与GI协同工作。定向模式需要大约两倍的附加光照贴图数据的存储空间。|
|非定向|	无方向模式切换这两个选项。|
|间接强度|	使用此滑块来控制实时存储的间接光的亮度和从0到5之间的烘烤光照。从1以上的值增加了间接光的强度，而小于1的值降低了间接光强度。默认值为1。|
|反照率提升|	使用此滑块通过加强场景中材料的反照率，从1到10之间的值来控制表面之间反射的光量。增加此值可将反照率值绘制为白色，用于间接光计算。默认值1是物理上准确的。|
|Lightmap参数|	Unity除了“照明”窗口的属性之外，还使用一组通用参数进行光照映射。该属性的菜单有几个默认值，但您也可以使用“创建新”选项创建自己的lightmap参数文件。有关详细信息，请参阅[“Lightmap参数”](https://docs.unity3d.com/Manual/LightmapParameters.html)页面。默认值为Default-Medium。|

## 其他设置

![](https://docs.unity3d.com/uploads/Main/GlobalIllumination-4.png)

|   属性     |   功能  |
|:----------:|--------:|
|其他设置|	雾，光晕[https://docs.unity3d.com/Manual/class-Halo.html]，[耀斑](https://docs.unity3d.com/Manual/class-Flare.html)和[曲奇](https://docs.unity3d.com/Manual/Cookies.html)的设置。|
|多雾路段|	启用或禁用场景中的雾。请注意，[延迟渲染路径](https://docs.unity3d.com/Manual/RenderingPaths.html)不能使用雾。对于延迟渲染，[全球雾](https://docs.unity3d.com/Manual/script-GlobalFog)效应可能适合您的需求。|
|    颜色|	设置Unity用于在场景中绘制雾的颜色。|
|    模式|	定义雾距与相机距离的积累方式。|
|线性|	雾密度随距离线性增加。|
|开始| 设置雾开始的相机的距离。|
|结束|	设置距离相机的距离，雾完全遮蔽了场景GameObjects。|
|指数|	雾密度随距离呈指数增长。|
|密度|	使用它来控制雾的密度。当密度增加时，雾显得更加密集。|
|指数平方|	烟雾密度甚至比距离（指数和平方）指数增长更快。|
|密度|	使用它来控制雾的密度。当密度增加时，雾显得更加密集。|
|光晕纹理|	设置您要用于在灯光周围绘制[光晕](https://docs.unity3d.com/Manual/class-Halo.html)的纹理。|
|光晕力量|	定义光线周围的光环的可视性，从0到1之间的值。|
|耀斑褪色速度|	定义在最初出现之后，[镜头](https://docs.unity3d.com/Manual/class-LensFlare.html)在视野中褪色的时间（秒）。默认设置为3。|
|耀斑力|	从0到1之间的值中定义镜头闪光灯的可见性。|
|现货Cookie|	设置要用于[聚光灯](https://docs.unity3d.com/Manual/Lighting.html)的[Cookie](https://docs.unity3d.com/Manual/HOWTO-LightCookie.html)纹理。|

## 调试设置

![](https://docs.unity3d.com/uploads/Main/GlobalIllumination-5.png)

|   属性     |   功能  |
|:----------:|--------:|
|调试设置|	有助于您调试场景的设置。|
|更新统计资料|	如果勾选，“照明设置”窗口底部的统计窗口将随场景更改而更新。这可能会影响播放模式下的性能。为了在播放模式下获得更好的效果，请取消选中此框。|
|光探测器可视化|	使用此选项可以在“场景”视图中过滤哪些[“光探针”](https://docs.unity3d.com/Manual/LightProbes.html)。默认值为“ 选择使用的探针”。|
|只有选择使用的探头|	影响当前选择的只有光探测器才能在“场景”视图中显示。|
|所有探针无细胞	|所有光探针都可以在场景视图中进行显示。|
|所有探针与细胞	|所有光探针都可以在场景视图中进行显示，并且还会显示用于光探测数据插值的四面体。|
|没有|	在“场景”视图中不显示“光探测器”。|
|显示重量	|当勾选时，Unity从用于主动选择的光探针中的线条绘制到用于插值的四面体上的位置。这是一种调试探针插补和放置问题的方法。|
|显示闭塞|	当勾选时，如果混合照明模式是[距离阴影掩码](https://docs.unity3d.com/Manual/LightMode-Mixed-DistanceShadowmask.html)或[阴影掩码](https://docs.unity3d.com/Manual/LightMode-Mixed-Shadowmask.html)，Unity将显示Light Probe的遮挡数据。|

在“场景”选项卡的底部，“ 统计”窗口列出了场景中“灯”的信息。灯由类型，网格，发射材料，光探针和反射探头分隔。

![](https://docs.unity3d.com/uploads/Main/GlobalIllumination-6.png)

还要注意，有一个可停靠窗口，称为[“光源”](http://mdeditor.infra.hq.unity3d.com/?&_ga=2.245305990.2072518565.1503381887-1300961171.1497254613#LightingExplorer)，可帮助您处理大量的光源。

## 全球地图标签

使用全局地图选项卡查看照明系统正在使用的实际纹理。这些包括强度光图，阴影掩模和方向图。仅当使用[烘烤照明](https://docs.unity3d.com/Manual/LightMode-Baked.html)或[混合照明](https://docs.unity3d.com/Manual/LightMode-Mixed.html)时可用; [实时照明](https://docs.unity3d.com/Manual/LightMode-Realtime.html)的预览为空白。

![](https://docs.unity3d.com/uploads/Main/GlobalIllumination-7.png)

## 对象映射选项卡

使用“ 对象映射”选项卡可以查看仅当前选定的 **GameObject** 的烘焙纹理的预览，包括阴影掩码。

![](https://docs.unity3d.com/uploads/Main/GlobalIllumination-8.png)



