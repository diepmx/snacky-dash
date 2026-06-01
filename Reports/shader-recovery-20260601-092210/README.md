# Shader Recovery Report - 20260601-092210

## Scope
- Unity version: 6000.2.10f1
- Shader assets scanned: 43
- Material assets scanned: 155
- Shader files with DummyShaderTextExporter: 43
- Shader files with solid-white dummy fragment: 24
- Materials referencing dummy-exported local shaders: 143
- Materials referencing missing local shader GUIDs: 0

## Render Pipeline Notes
ProjectSettings references Universal Render Pipeline assets, but Packages/manifest.json and packages-lock.json do not list com.unity.render-pipelines.universal explicitly. Before restoring package shaders, confirm whether Unity 6 resolves URP as a built-in/editor package in this project or whether the manifest lost explicit URP dependencies during decode.

## Shader Category Summary
| Category | Shader Count | Dummy Count |
|---|---:|---:|
| Unity URP/Core hidden shader | 19 | 19 |
| Custom Shader Graph export | 7 | 7 |
| Unity URP package shader | 4 | 4 |
| TextMeshPro package shader | 3 | 3 |
| UI/third-party UI shader | 3 | 3 |
| Unknown/custom shader | 2 | 2 |
| Third-party/custom JuicedUp | 2 | 2 |
| Custom handwritten shader | 1 |  |
| Third-party: Toony Colors Pro 2 | 1 |  |
| Third-party: Shapes2D | 1 |  |

## Top Shader Usage By Material Count
| Material Count | Shader Name | Category | Dummy | Shader File |
|---:|---|---|---|---|
| 48 | TextMeshPro/Distance Field | TextMeshPro package shader | True | Assets\Shader\TextMeshPro_Distance Field.shader |
| 31 | Universal Render Pipeline/Lit | Unity URP package shader | True | Assets\Shader\Universal Render Pipeline_Lit.shader |
| 19 | Shader Graphs/SH_FakeUnlit_Texture | Custom Shader Graph export | True | Assets\Shader\Shader Graphs_SH_FakeUnlit_Texture.shader |
| 13 | TextMeshPro/Mobile/Distance Field | TextMeshPro package shader | True | Assets\Shader\TextMeshPro_Mobile_Distance Field.shader |
| 12 | Unity built-in shader reference | Unity built-in shader | False |  |
| 7 | Universal Render Pipeline/Particles/Unlit | Unity URP package shader | True | Assets\Shader\Universal Render Pipeline_Particles_Unlit.shader |
| 3 | Shader Graphs/SH_FX_Particle_Dissolve_Alpha | Custom Shader Graph export | True | Assets\Shader\Shader Graphs_SH_FX_Particle_Dissolve_Alpha.shader |
| 3 | UI/Additive | UI/third-party UI shader | True | Assets\Shader\UI_Additive.shader |
| 3 | Universal Render Pipeline/Unlit | Unity URP package shader | True | Assets\Shader\Universal Render Pipeline_Unlit.shader |
| 2 | Shader Graphs/SH_FakeUnlit_Color | Custom Shader Graph export | True | Assets\Shader\Shader Graphs_SH_FakeUnlit_Color.shader |
| 2 | Shader Graphs/SH_FX_Particle_Dissolve_Additive | Custom Shader Graph export | True | Assets\Shader\Shader Graphs_SH_FX_Particle_Dissolve_Additive.shader |
| 2 | TextMeshPro/Sprite | TextMeshPro package shader | True | Assets\Shader\TextMeshPro_Sprite.shader |
| 1 | AssetKits/Additive | Unknown/custom shader | True | Assets\Shader\AssetKits_Additive.shader |
| 1 | Custom/URP/UnlitRimWithShadows | Custom handwritten shader | True | Assets\Shader\Custom_URP_UnlitRimWithShadows.shader |
| 1 | JuicedUp/DarkOverlayMasked | Third-party/custom JuicedUp | True | Assets\Shader\JuicedUp_DarkOverlayMasked.shader |
| 1 | JuicedUp/DarkOverlayStencilWriter | Third-party/custom JuicedUp | True | Assets\Shader\JuicedUp_DarkOverlayStencilWriter.shader |
| 1 | Shader Graphs/SH_FX_Sprite_Multiply | Custom Shader Graph export | True | Assets\Shader\Shader Graphs_SH_FX_Sprite_Multiply.shader |
| 1 | Shader Graphs/SH_Snake | Custom Shader Graph export | True | Assets\Shader\Shader Graphs_SH_Snake.shader |
| 1 | Shader Graphs/SH_Tile_FakeUnlit | Custom Shader Graph export | True | Assets\Shader\Shader Graphs_SH_Tile_FakeUnlit.shader |
| 1 | Toony Colors Pro 2/Hybrid Shader 2 | Third-party: Toony Colors Pro 2 | True | Assets\Shader\Toony Colors Pro 2_Hybrid Shader 2.shader |

## Generated Files
- shader-inventory.csv: every shader GUID/name/path, dummy status, category, recommended recovery path.
- material-shader-map.csv: every material and the shader GUID/name it references.
- shader-usage-summary.csv: shader-to-material usage counts and material lists.

## Immediate Recovery Order
1. Restore high-use package shaders first: URP Lit/Unlit/Particles Unlit, TMP shaders, Sprite/UI defaults.
2. Restore third-party package shaders next: Toony Colors Pro 2, Shapes2D, UI Effect/Additive, JuicedUp.
3. Rebuild custom Shader Graph exports after package shaders are stable: SH_FakeUnlit_Texture, SH_Snake, SH_Tile_FakeUnlit, dissolve FX.
