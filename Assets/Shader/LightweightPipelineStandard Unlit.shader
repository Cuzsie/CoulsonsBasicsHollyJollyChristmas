Shader "LightweightPipeline/Standard Unlit" {
	Properties {
		_MainTex ("Texture", 2D) = "white" {}
		_Color ("Color", Vector) = (1,1,1,1)
		_Cutoff ("AlphaCutout", Range(0, 1)) = 0.5
		[Toggle] _SampleGI ("SampleGI", Float) = 0
		_BumpMap ("Normal Map", 2D) = "bump" {}
		[HideInInspector] _Surface ("__surface", Float) = 0
		[HideInInspector] _Blend ("__blend", Float) = 0
		[HideInInspector] _AlphaClip ("__clip", Float) = 0
		[HideInInspector] _SrcBlend ("Src", Float) = 1
		[HideInInspector] _DstBlend ("Dst", Float) = 0
		[HideInInspector] _ZWrite ("ZWrite", Float) = 1
		[HideInInspector] _Cull ("__cull", Float) = 2
	}
	SubShader {
		LOD 100
		Tags { "IgnoreProjectors" = "true" "RenderPipeline" = "LightweightPipeline" "RenderType" = "Opaque" }
		Pass {
			Name "StandardUnlit"
			LOD 100
			Tags { "IgnoreProjectors" = "true" "RenderPipeline" = "LightweightPipeline" "RenderType" = "Opaque" }
			Blend Zero Zero, Zero Zero
			ZWrite Off
			Cull Off
			GpuProgramID 16038
			Program "vp" {
				SubProgram "d3d11 " {
					"!!vs_4_0
					
					#version 330
					#extension GL_ARB_explicit_attrib_location : require
					#extension GL_ARB_explicit_uniform_location : require
					
					layout(std140) uniform UnityPerDraw {
						mat4x4 unity_ObjectToWorld;
						vec4 unused_0_1[21];
					};
					layout(std140) uniform UnityPerFrame {
						vec4 unused_1_0[19];
						mat4x4 unity_MatrixVP;
						vec4 unused_1_2[3];
					};
					layout(std140) uniform UnityPerMaterial {
						vec4 _MainTex_ST;
						vec4 unused_2_1[2];
					};
					in  vec4 in_POSITION0;
					in  vec2 in_TEXCOORD0;
					out vec3 vs_TEXCOORD0;
					vec4 u_xlat0;
					vec4 u_xlat1;
					void main()
					{
					    vs_TEXCOORD0.xy = in_TEXCOORD0.xy * _MainTex_ST.xy + _MainTex_ST.zw;
					    vs_TEXCOORD0.z = 0.0;
					    u_xlat0 = in_POSITION0.yyyy * unity_ObjectToWorld[1];
					    u_xlat0 = unity_ObjectToWorld[0] * in_POSITION0.xxxx + u_xlat0;
					    u_xlat0 = unity_ObjectToWorld[2] * in_POSITION0.zzzz + u_xlat0;
					    u_xlat0 = u_xlat0 + unity_ObjectToWorld[3];
					    u_xlat1 = u_xlat0.yyyy * unity_MatrixVP[1];
					    u_xlat1 = unity_MatrixVP[0] * u_xlat0.xxxx + u_xlat1;
					    u_xlat1 = unity_MatrixVP[2] * u_xlat0.zzzz + u_xlat1;
					    gl_Position = unity_MatrixVP[3] * u_xlat0.wwww + u_xlat1;
					    return;
					}"
				}
				SubProgram "d3d11 " {
					Keywords { "_ALPHATEST_ON" }
					"!!vs_4_0
					
					#version 330
					#extension GL_ARB_explicit_attrib_location : require
					#extension GL_ARB_explicit_uniform_location : require
					
					layout(std140) uniform UnityPerDraw {
						mat4x4 unity_ObjectToWorld;
						vec4 unused_0_1[21];
					};
					layout(std140) uniform UnityPerFrame {
						vec4 unused_1_0[19];
						mat4x4 unity_MatrixVP;
						vec4 unused_1_2[3];
					};
					layout(std140) uniform UnityPerMaterial {
						vec4 _MainTex_ST;
						vec4 unused_2_1[2];
					};
					in  vec4 in_POSITION0;
					in  vec2 in_TEXCOORD0;
					out vec3 vs_TEXCOORD0;
					vec4 u_xlat0;
					vec4 u_xlat1;
					void main()
					{
					    vs_TEXCOORD0.xy = in_TEXCOORD0.xy * _MainTex_ST.xy + _MainTex_ST.zw;
					    vs_TEXCOORD0.z = 0.0;
					    u_xlat0 = in_POSITION0.yyyy * unity_ObjectToWorld[1];
					    u_xlat0 = unity_ObjectToWorld[0] * in_POSITION0.xxxx + u_xlat0;
					    u_xlat0 = unity_ObjectToWorld[2] * in_POSITION0.zzzz + u_xlat0;
					    u_xlat0 = u_xlat0 + unity_ObjectToWorld[3];
					    u_xlat1 = u_xlat0.yyyy * unity_MatrixVP[1];
					    u_xlat1 = unity_MatrixVP[0] * u_xlat0.xxxx + u_xlat1;
					    u_xlat1 = unity_MatrixVP[2] * u_xlat0.zzzz + u_xlat1;
					    gl_Position = unity_MatrixVP[3] * u_xlat0.wwww + u_xlat1;
					    return;
					}"
				}
				SubProgram "d3d11 " {
					Keywords { "_ALPHATEST_ON" "_ALPHAPREMULTIPLY_ON" }
					"!!vs_4_0
					
					#version 330
					#extension GL_ARB_explicit_attrib_location : require
					#extension GL_ARB_explicit_uniform_location : require
					
					layout(std140) uniform UnityPerDraw {
						mat4x4 unity_ObjectToWorld;
						vec4 unused_0_1[21];
					};
					layout(std140) uniform UnityPerFrame {
						vec4 unused_1_0[19];
						mat4x4 unity_MatrixVP;
						vec4 unused_1_2[3];
					};
					layout(std140) uniform UnityPerMaterial {
						vec4 _MainTex_ST;
						vec4 unused_2_1[2];
					};
					in  vec4 in_POSITION0;
					in  vec2 in_TEXCOORD0;
					out vec3 vs_TEXCOORD0;
					vec4 u_xlat0;
					vec4 u_xlat1;
					void main()
					{
					    vs_TEXCOORD0.xy = in_TEXCOORD0.xy * _MainTex_ST.xy + _MainTex_ST.zw;
					    vs_TEXCOORD0.z = 0.0;
					    u_xlat0 = in_POSITION0.yyyy * unity_ObjectToWorld[1];
					    u_xlat0 = unity_ObjectToWorld[0] * in_POSITION0.xxxx + u_xlat0;
					    u_xlat0 = unity_ObjectToWorld[2] * in_POSITION0.zzzz + u_xlat0;
					    u_xlat0 = u_xlat0 + unity_ObjectToWorld[3];
					    u_xlat1 = u_xlat0.yyyy * unity_MatrixVP[1];
					    u_xlat1 = unity_MatrixVP[0] * u_xlat0.xxxx + u_xlat1;
					    u_xlat1 = unity_MatrixVP[2] * u_xlat0.zzzz + u_xlat1;
					    gl_Position = unity_MatrixVP[3] * u_xlat0.wwww + u_xlat1;
					    return;
					}"
				}
			}
			Program "fp" {
				SubProgram "d3d11 " {
					"!!ps_4_0
					
					#version 330
					#extension GL_ARB_explicit_attrib_location : require
					#extension GL_ARB_explicit_uniform_location : require
					
					layout(std140) uniform UnityPerMaterial {
						vec4 unused_0_0;
						vec4 _Color;
						vec4 unused_0_2;
					};
					uniform  sampler2D _MainTex;
					in  vec3 vs_TEXCOORD0;
					layout(location = 0) out vec4 SV_Target0;
					vec4 u_xlat10_0;
					void main()
					{
					    u_xlat10_0 = texture(_MainTex, vs_TEXCOORD0.xy);
					    SV_Target0 = u_xlat10_0 * _Color;
					    return;
					}"
				}
				SubProgram "d3d11 " {
					Keywords { "_ALPHATEST_ON" }
					"!!ps_4_0
					
					#version 330
					#extension GL_ARB_explicit_attrib_location : require
					#extension GL_ARB_explicit_uniform_location : require
					
					layout(std140) uniform UnityPerMaterial {
						vec4 unused_0_0;
						vec4 _Color;
						float _Cutoff;
					};
					uniform  sampler2D _MainTex;
					in  vec3 vs_TEXCOORD0;
					layout(location = 0) out vec4 SV_Target0;
					vec4 u_xlat0;
					vec4 u_xlat10_0;
					bool u_xlatb0;
					float u_xlat1;
					void main()
					{
					    u_xlat10_0 = texture(_MainTex, vs_TEXCOORD0.xy);
					    u_xlat1 = u_xlat10_0.w * _Color.w + (-_Cutoff);
					    u_xlat0 = u_xlat10_0 * _Color;
					    SV_Target0 = u_xlat0;
					    u_xlatb0 = u_xlat1<0.0;
					    if(((int(u_xlatb0) * int(0xffffffffu)))!=0){discard;}
					    return;
					}"
				}
				SubProgram "d3d11 " {
					Keywords { "_ALPHATEST_ON" "_ALPHAPREMULTIPLY_ON" }
					"!!ps_4_0
					
					#version 330
					#extension GL_ARB_explicit_attrib_location : require
					#extension GL_ARB_explicit_uniform_location : require
					
					layout(std140) uniform UnityPerMaterial {
						vec4 unused_0_0;
						vec4 _Color;
						float _Cutoff;
					};
					uniform  sampler2D _MainTex;
					in  vec3 vs_TEXCOORD0;
					layout(location = 0) out vec4 SV_Target0;
					vec4 u_xlat0;
					vec4 u_xlat10_0;
					float u_xlat1;
					bool u_xlatb1;
					void main()
					{
					    u_xlat10_0 = texture(_MainTex, vs_TEXCOORD0.xy);
					    u_xlat1 = u_xlat10_0.w * _Color.w + (-_Cutoff);
					    u_xlat0 = u_xlat10_0 * _Color;
					    u_xlatb1 = u_xlat1<0.0;
					    if(((int(u_xlatb1) * int(0xffffffffu)))!=0){discard;}
					    SV_Target0.xyz = u_xlat0.www * u_xlat0.xyz;
					    SV_Target0.w = u_xlat0.w;
					    return;
					}"
				}
			}
		}
		Pass {
			LOD 100
			Tags { "IgnoreProjectors" = "true" "LIGHTMODE" = "DepthOnly" "RenderPipeline" = "LightweightPipeline" "RenderType" = "Opaque" }
			Blend Zero Zero, Zero Zero
			ColorMask 0 -1
			Cull Off
			GpuProgramID 116670
			Program "vp" {
				SubProgram "d3d11 " {
					"!!vs_4_0
					
					#version 330
					#extension GL_ARB_explicit_attrib_location : require
					#extension GL_ARB_explicit_uniform_location : require
					
					layout(std140) uniform UnityPerDraw {
						mat4x4 unity_ObjectToWorld;
						vec4 unused_0_1[21];
					};
					layout(std140) uniform UnityPerFrame {
						vec4 unused_1_0[19];
						mat4x4 unity_MatrixVP;
						vec4 unused_1_2[3];
					};
					layout(std140) uniform UnityPerMaterial {
						vec4 _MainTex_ST;
						vec4 unused_2_1[2];
					};
					in  vec4 in_POSITION0;
					in  vec2 in_TEXCOORD0;
					out vec2 vs_TEXCOORD0;
					vec4 u_xlat0;
					vec4 u_xlat1;
					void main()
					{
					    vs_TEXCOORD0.xy = in_TEXCOORD0.xy * _MainTex_ST.xy + _MainTex_ST.zw;
					    u_xlat0 = in_POSITION0.yyyy * unity_ObjectToWorld[1];
					    u_xlat0 = unity_ObjectToWorld[0] * in_POSITION0.xxxx + u_xlat0;
					    u_xlat0 = unity_ObjectToWorld[2] * in_POSITION0.zzzz + u_xlat0;
					    u_xlat0 = u_xlat0 + unity_ObjectToWorld[3];
					    u_xlat1 = u_xlat0.yyyy * unity_MatrixVP[1];
					    u_xlat1 = unity_MatrixVP[0] * u_xlat0.xxxx + u_xlat1;
					    u_xlat1 = unity_MatrixVP[2] * u_xlat0.zzzz + u_xlat1;
					    gl_Position = unity_MatrixVP[3] * u_xlat0.wwww + u_xlat1;
					    return;
					}"
				}
				SubProgram "d3d11 " {
					Keywords { "_ALPHATEST_ON" }
					"!!vs_4_0
					
					#version 330
					#extension GL_ARB_explicit_attrib_location : require
					#extension GL_ARB_explicit_uniform_location : require
					
					layout(std140) uniform UnityPerDraw {
						mat4x4 unity_ObjectToWorld;
						vec4 unused_0_1[21];
					};
					layout(std140) uniform UnityPerFrame {
						vec4 unused_1_0[19];
						mat4x4 unity_MatrixVP;
						vec4 unused_1_2[3];
					};
					layout(std140) uniform UnityPerMaterial {
						vec4 _MainTex_ST;
						vec4 unused_2_1[2];
					};
					in  vec4 in_POSITION0;
					in  vec2 in_TEXCOORD0;
					out vec2 vs_TEXCOORD0;
					vec4 u_xlat0;
					vec4 u_xlat1;
					void main()
					{
					    vs_TEXCOORD0.xy = in_TEXCOORD0.xy * _MainTex_ST.xy + _MainTex_ST.zw;
					    u_xlat0 = in_POSITION0.yyyy * unity_ObjectToWorld[1];
					    u_xlat0 = unity_ObjectToWorld[0] * in_POSITION0.xxxx + u_xlat0;
					    u_xlat0 = unity_ObjectToWorld[2] * in_POSITION0.zzzz + u_xlat0;
					    u_xlat0 = u_xlat0 + unity_ObjectToWorld[3];
					    u_xlat1 = u_xlat0.yyyy * unity_MatrixVP[1];
					    u_xlat1 = unity_MatrixVP[0] * u_xlat0.xxxx + u_xlat1;
					    u_xlat1 = unity_MatrixVP[2] * u_xlat0.zzzz + u_xlat1;
					    gl_Position = unity_MatrixVP[3] * u_xlat0.wwww + u_xlat1;
					    return;
					}"
				}
			}
			Program "fp" {
				SubProgram "d3d11 " {
					"!!ps_4_0
					
					#version 330
					#extension GL_ARB_explicit_attrib_location : require
					#extension GL_ARB_explicit_uniform_location : require
					
					layout(location = 0) out vec4 SV_TARGET0;
					void main()
					{
					    SV_TARGET0 = vec4(0.0, 0.0, 0.0, 0.0);
					    return;
					}"
				}
				SubProgram "d3d11 " {
					Keywords { "_ALPHATEST_ON" }
					"!!ps_4_0
					
					#version 330
					#extension GL_ARB_explicit_attrib_location : require
					#extension GL_ARB_explicit_uniform_location : require
					
					layout(std140) uniform UnityPerMaterial {
						vec4 unused_0_0;
						vec4 _Color;
						float _Cutoff;
					};
					uniform  sampler2D _MainTex;
					in  vec2 vs_TEXCOORD0;
					layout(location = 0) out vec4 SV_TARGET0;
					float u_xlat0;
					vec4 u_xlat10_0;
					bool u_xlatb0;
					void main()
					{
					    u_xlat10_0 = texture(_MainTex, vs_TEXCOORD0.xy);
					    u_xlat0 = u_xlat10_0.w * _Color.w + (-_Cutoff);
					    u_xlatb0 = u_xlat0<0.0;
					    if(((int(u_xlatb0) * int(0xffffffffu)))!=0){discard;}
					    SV_TARGET0 = vec4(0.0, 0.0, 0.0, 0.0);
					    return;
					}"
				}
			}
		}
	}
	Fallback "Hidden/InternalErrorShader"
	CustomEditor "LightweightUnlitGUI"
}