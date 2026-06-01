# Shader Recovery Postfix Report - 20260601-092210

## Result Snapshot
- Shader assets scanned: 43
- Shader files still containing DummyShaderTextExporter: 9
- Shader files still containing solid-white dummy fragment: 7
- Shader files still referencing package include paths: 0
- Materials still referencing dummy shaders: 31

## Remaining Dummy Shader Usage
| Material Count | Shader Name | Category |
|---:|---|---|
| 19 | Shader Graphs/SH_FakeUnlit_Texture | Custom Shader Graph export |
| 3 | Shader Graphs/SH_FX_Particle_Dissolve_Alpha | Custom Shader Graph export |
| 2 | Shader Graphs/SH_FakeUnlit_Color | Custom Shader Graph export |
| 2 | Shader Graphs/SH_FX_Particle_Dissolve_Additive | Custom Shader Graph export |
| 1 | Custom/URP/UnlitRimWithShadows | Custom handwritten shader |
| 1 | Shader Graphs/SH_FX_Sprite_Multiply | Custom Shader Graph export |
| 1 | Shader Graphs/SH_Snake | Custom Shader Graph export |
| 1 | Shader Graphs/SH_Tile_FakeUnlit | Custom Shader Graph export |
| 1 | Toony Colors Pro 2/Hybrid Shader 2 | Third-party: Toony Colors Pro 2 |

## Notes
- Package manifest/lock were left unchanged after testing because adding URP package dependencies caused unrelated C# ambiguity errors in Unity package code.
- URP/Core hidden shaders were replaced with self-contained fallback shaders to avoid package include failures in this decoded project.
- TextMeshPro shaders were restored from Unity package sample source and required local TMPro cginc files copied into Assets/Shader.
- Toony Colors Pro 2 and custom Shader Graph exports still need original source or targeted rewrites.
