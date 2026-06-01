Shader "Shader Graphs/SH_FX_Particle_Dissolve_Alpha" {
    Properties {
        [NoScaleOffset] _Texture ("Texture", 2D) = "white" {}
        [NoScaleOffset] _Dissolve_Texture ("Dissolve Texture", 2D) = "white" {}
        _Dissolve_Tiling ("Dissolve Tiling", Vector) = (1,1,0,0)
        _Dissolve_Speed ("Dissolve Speed", Vector) = (0,0,0,0)
        _Dissolve_Smoothness ("Dissolve Smoothness", Float) = 20
        _Dissolve_Steps ("Dissolve Steps", Float) = 50
        _Color ("Color", Color) = (1,1,1,1)
    }
    SubShader {
        Tags { "Queue"="Transparent" "RenderType"="Transparent" }
        Cull Off ZWrite Off Blend SrcAlpha OneMinusSrcAlpha
        Pass {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct appdata {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
                fixed4 color : COLOR;
            };

            struct v2f {
                float4 pos : SV_POSITION;
                float2 uv : TEXCOORD0;
                fixed4 color : COLOR;
            };

            sampler2D _Texture;
            sampler2D _Dissolve_Texture;
            float4 _Dissolve_Tiling;
            float4 _Dissolve_Speed;
            half _Dissolve_Smoothness;
            fixed4 _Color;

            v2f vert(appdata v) {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                o.color = v.color;
                return o;
            }

            fixed4 frag(v2f i) : SV_Target {
                fixed4 c = tex2D(_Texture, i.uv) * i.color;
                fixed colorEnabled = step(0.001, _Color.a);
                c.rgb *= lerp(fixed3(1, 1, 1), _Color.rgb, colorEnabled);
                float2 duv = i.uv * max(_Dissolve_Tiling.xy, 0.0001.xx) + _Time.y * _Dissolve_Speed.xy;
                half noise = tex2D(_Dissolve_Texture, duv).r;
                half softness = max(_Dissolve_Smoothness, 0.001);
                c.a *= saturate(noise * softness);
                clip(c.a - 0.001);
                return c;
            }
            ENDCG
        }
    }
    Fallback Off
}
