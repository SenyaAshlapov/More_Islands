extern "C" void RegisterStaticallyLinkedModulesGranular()
{
	void RegisterModule_SharedInternals();
	RegisterModule_SharedInternals();

	void RegisterModule_Core();
	RegisterModule_Core();

	void RegisterModule_AI();
	RegisterModule_AI();

	void RegisterModule_Animation();
	RegisterModule_Animation();

	void RegisterModule_Audio();
	RegisterModule_Audio();

	void RegisterModule_Director();
	RegisterModule_Director();

	void RegisterModule_IMGUI();
	RegisterModule_IMGUI();

	void RegisterModule_Input();
	RegisterModule_Input();

	void RegisterModule_InputLegacy();
	RegisterModule_InputLegacy();

	void RegisterModule_JSONSerialize();
	RegisterModule_JSONSerialize();

	void RegisterModule_ParticleSystem();
	RegisterModule_ParticleSystem();

	void RegisterModule_Physics();
	RegisterModule_Physics();

	void RegisterModule_Physics2D();
	RegisterModule_Physics2D();

	void RegisterModule_RuntimeInitializeOnLoadManagerInitializer();
	RegisterModule_RuntimeInitializeOnLoadManagerInitializer();

	void RegisterModule_Subsystems();
	RegisterModule_Subsystems();

	void RegisterModule_TextRendering();
	RegisterModule_TextRendering();

	void RegisterModule_TextCoreFontEngine();
	RegisterModule_TextCoreFontEngine();

	void RegisterModule_TextCoreTextEngine();
	RegisterModule_TextCoreTextEngine();

	void RegisterModule_UI();
	RegisterModule_UI();

	void RegisterModule_UIElementsNative();
	RegisterModule_UIElementsNative();

	void RegisterModule_UIElements();
	RegisterModule_UIElements();

	void RegisterModule_VR();
	RegisterModule_VR();

	void RegisterModule_WebGL();
	RegisterModule_WebGL();

	void RegisterModule_XR();
	RegisterModule_XR();

}

template <typename T> void RegisterUnityClass(const char*);
template <typename T> void RegisterStrippedType(int, const char*, const char*);

void InvokeRegisterStaticallyLinkedModuleClasses()
{
	// Do nothing (we're in stripping mode)
}

class NavMeshAgent; template <> void RegisterUnityClass<NavMeshAgent>(const char*);
class NavMeshData; template <> void RegisterUnityClass<NavMeshData>(const char*);
class NavMeshObstacle; template <> void RegisterUnityClass<NavMeshObstacle>(const char*);
class NavMeshProjectSettings; template <> void RegisterUnityClass<NavMeshProjectSettings>(const char*);
class NavMeshSettings; template <> void RegisterUnityClass<NavMeshSettings>(const char*);
class Animation; template <> void RegisterUnityClass<Animation>(const char*);
class AnimationClip; template <> void RegisterUnityClass<AnimationClip>(const char*);
class Animator; template <> void RegisterUnityClass<Animator>(const char*);
class AnimatorController; template <> void RegisterUnityClass<AnimatorController>(const char*);
class AnimatorOverrideController; template <> void RegisterUnityClass<AnimatorOverrideController>(const char*);
class Avatar; template <> void RegisterUnityClass<Avatar>(const char*);
class AvatarMask; template <> void RegisterUnityClass<AvatarMask>(const char*);
class Motion; template <> void RegisterUnityClass<Motion>(const char*);
class RuntimeAnimatorController; template <> void RegisterUnityClass<RuntimeAnimatorController>(const char*);
class AudioBehaviour; template <> void RegisterUnityClass<AudioBehaviour>(const char*);
class AudioClip; template <> void RegisterUnityClass<AudioClip>(const char*);
class AudioListener; template <> void RegisterUnityClass<AudioListener>(const char*);
class AudioManager; template <> void RegisterUnityClass<AudioManager>(const char*);
class AudioMixer; template <> void RegisterUnityClass<AudioMixer>(const char*);
class AudioMixerGroup; template <> void RegisterUnityClass<AudioMixerGroup>(const char*);
class AudioMixerSnapshot; template <> void RegisterUnityClass<AudioMixerSnapshot>(const char*);
class AudioSource; template <> void RegisterUnityClass<AudioSource>(const char*);
class SampleClip; template <> void RegisterUnityClass<SampleClip>(const char*);
class Behaviour; template <> void RegisterUnityClass<Behaviour>(const char*);
class BuildSettings; template <> void RegisterUnityClass<BuildSettings>(const char*);
class Camera; template <> void RegisterUnityClass<Camera>(const char*);
namespace Unity { class Component; } template <> void RegisterUnityClass<Unity::Component>(const char*);
class ComputeShader; template <> void RegisterUnityClass<ComputeShader>(const char*);
class Cubemap; template <> void RegisterUnityClass<Cubemap>(const char*);
class CubemapArray; template <> void RegisterUnityClass<CubemapArray>(const char*);
class DelayedCallManager; template <> void RegisterUnityClass<DelayedCallManager>(const char*);
class EditorExtension; template <> void RegisterUnityClass<EditorExtension>(const char*);
class FlareLayer; template <> void RegisterUnityClass<FlareLayer>(const char*);
class GameManager; template <> void RegisterUnityClass<GameManager>(const char*);
class GameObject; template <> void RegisterUnityClass<GameObject>(const char*);
class GlobalGameManager; template <> void RegisterUnityClass<GlobalGameManager>(const char*);
class GraphicsSettings; template <> void RegisterUnityClass<GraphicsSettings>(const char*);
class InputManager; template <> void RegisterUnityClass<InputManager>(const char*);
class LevelGameManager; template <> void RegisterUnityClass<LevelGameManager>(const char*);
class Light; template <> void RegisterUnityClass<Light>(const char*);
class LightingSettings; template <> void RegisterUnityClass<LightingSettings>(const char*);
class LightmapSettings; template <> void RegisterUnityClass<LightmapSettings>(const char*);
class LightProbes; template <> void RegisterUnityClass<LightProbes>(const char*);
class LowerResBlitTexture; template <> void RegisterUnityClass<LowerResBlitTexture>(const char*);
class Material; template <> void RegisterUnityClass<Material>(const char*);
class Mesh; template <> void RegisterUnityClass<Mesh>(const char*);
class MeshFilter; template <> void RegisterUnityClass<MeshFilter>(const char*);
class MeshRenderer; template <> void RegisterUnityClass<MeshRenderer>(const char*);
class MonoBehaviour; template <> void RegisterUnityClass<MonoBehaviour>(const char*);
class MonoManager; template <> void RegisterUnityClass<MonoManager>(const char*);
class MonoScript; template <> void RegisterUnityClass<MonoScript>(const char*);
class NamedObject; template <> void RegisterUnityClass<NamedObject>(const char*);
class Object; template <> void RegisterUnityClass<Object>(const char*);
class PlayerSettings; template <> void RegisterUnityClass<PlayerSettings>(const char*);
class PreloadData; template <> void RegisterUnityClass<PreloadData>(const char*);
class QualitySettings; template <> void RegisterUnityClass<QualitySettings>(const char*);
namespace UI { class RectTransform; } template <> void RegisterUnityClass<UI::RectTransform>(const char*);
class ReflectionProbe; template <> void RegisterUnityClass<ReflectionProbe>(const char*);
class Renderer; template <> void RegisterUnityClass<Renderer>(const char*);
class RenderSettings; template <> void RegisterUnityClass<RenderSettings>(const char*);
class RenderTexture; template <> void RegisterUnityClass<RenderTexture>(const char*);
class ResourceManager; template <> void RegisterUnityClass<ResourceManager>(const char*);
class RuntimeInitializeOnLoadManager; template <> void RegisterUnityClass<RuntimeInitializeOnLoadManager>(const char*);
class Shader; template <> void RegisterUnityClass<Shader>(const char*);
class ShaderNameRegistry; template <> void RegisterUnityClass<ShaderNameRegistry>(const char*);
class SkinnedMeshRenderer; template <> void RegisterUnityClass<SkinnedMeshRenderer>(const char*);
class Skybox; template <> void RegisterUnityClass<Skybox>(const char*);
class Sprite; template <> void RegisterUnityClass<Sprite>(const char*);
class SpriteAtlas; template <> void RegisterUnityClass<SpriteAtlas>(const char*);
class SpriteRenderer; template <> void RegisterUnityClass<SpriteRenderer>(const char*);
class TagManager; template <> void RegisterUnityClass<TagManager>(const char*);
class TextAsset; template <> void RegisterUnityClass<TextAsset>(const char*);
class Texture; template <> void RegisterUnityClass<Texture>(const char*);
class Texture2D; template <> void RegisterUnityClass<Texture2D>(const char*);
class Texture2DArray; template <> void RegisterUnityClass<Texture2DArray>(const char*);
class Texture3D; template <> void RegisterUnityClass<Texture3D>(const char*);
class TimeManager; template <> void RegisterUnityClass<TimeManager>(const char*);
class Transform; template <> void RegisterUnityClass<Transform>(const char*);
class PlayableDirector; template <> void RegisterUnityClass<PlayableDirector>(const char*);
class ParticleSystem; template <> void RegisterUnityClass<ParticleSystem>(const char*);
class ParticleSystemRenderer; template <> void RegisterUnityClass<ParticleSystemRenderer>(const char*);
class BoxCollider; template <> void RegisterUnityClass<BoxCollider>(const char*);
class CapsuleCollider; template <> void RegisterUnityClass<CapsuleCollider>(const char*);
class Collider; template <> void RegisterUnityClass<Collider>(const char*);
class MeshCollider; template <> void RegisterUnityClass<MeshCollider>(const char*);
class PhysicMaterial; template <> void RegisterUnityClass<PhysicMaterial>(const char*);
class PhysicsManager; template <> void RegisterUnityClass<PhysicsManager>(const char*);
class Rigidbody; template <> void RegisterUnityClass<Rigidbody>(const char*);
class SphereCollider; template <> void RegisterUnityClass<SphereCollider>(const char*);
class Collider2D; template <> void RegisterUnityClass<Collider2D>(const char*);
class CompositeCollider2D; template <> void RegisterUnityClass<CompositeCollider2D>(const char*);
class Physics2DSettings; template <> void RegisterUnityClass<Physics2DSettings>(const char*);
class PolygonCollider2D; template <> void RegisterUnityClass<PolygonCollider2D>(const char*);
class Rigidbody2D; template <> void RegisterUnityClass<Rigidbody2D>(const char*);
namespace TextRendering { class Font; } template <> void RegisterUnityClass<TextRendering::Font>(const char*);
namespace UI { class Canvas; } template <> void RegisterUnityClass<UI::Canvas>(const char*);
namespace UI { class CanvasGroup; } template <> void RegisterUnityClass<UI::CanvasGroup>(const char*);
namespace UI { class CanvasRenderer; } template <> void RegisterUnityClass<UI::CanvasRenderer>(const char*);

void RegisterAllClasses()
{
void RegisterBuiltinTypes();
RegisterBuiltinTypes();
	//Total: 98 non stripped classes
	//0. NavMeshAgent
	RegisterUnityClass<NavMeshAgent>("AI");
	//1. NavMeshData
	RegisterUnityClass<NavMeshData>("AI");
	//2. NavMeshObstacle
	RegisterUnityClass<NavMeshObstacle>("AI");
	//3. NavMeshProjectSettings
	RegisterUnityClass<NavMeshProjectSettings>("AI");
	//4. NavMeshSettings
	RegisterUnityClass<NavMeshSettings>("AI");
	//5. Animation
	RegisterUnityClass<Animation>("Animation");
	//6. AnimationClip
	RegisterUnityClass<AnimationClip>("Animation");
	//7. Animator
	RegisterUnityClass<Animator>("Animation");
	//8. AnimatorController
	RegisterUnityClass<AnimatorController>("Animation");
	//9. AnimatorOverrideController
	RegisterUnityClass<AnimatorOverrideController>("Animation");
	//10. Avatar
	RegisterUnityClass<Avatar>("Animation");
	//11. AvatarMask
	RegisterUnityClass<AvatarMask>("Animation");
	//12. Motion
	RegisterUnityClass<Motion>("Animation");
	//13. RuntimeAnimatorController
	RegisterUnityClass<RuntimeAnimatorController>("Animation");
	//14. AudioBehaviour
	RegisterUnityClass<AudioBehaviour>("Audio");
	//15. AudioClip
	RegisterUnityClass<AudioClip>("Audio");
	//16. AudioListener
	RegisterUnityClass<AudioListener>("Audio");
	//17. AudioManager
	RegisterUnityClass<AudioManager>("Audio");
	//18. AudioMixer
	RegisterUnityClass<AudioMixer>("Audio");
	//19. AudioMixerGroup
	RegisterUnityClass<AudioMixerGroup>("Audio");
	//20. AudioMixerSnapshot
	RegisterUnityClass<AudioMixerSnapshot>("Audio");
	//21. AudioSource
	RegisterUnityClass<AudioSource>("Audio");
	//22. SampleClip
	RegisterUnityClass<SampleClip>("Audio");
	//23. Behaviour
	RegisterUnityClass<Behaviour>("Core");
	//24. BuildSettings
	RegisterUnityClass<BuildSettings>("Core");
	//25. Camera
	RegisterUnityClass<Camera>("Core");
	//26. Component
	RegisterUnityClass<Unity::Component>("Core");
	//27. ComputeShader
	RegisterUnityClass<ComputeShader>("Core");
	//28. Cubemap
	RegisterUnityClass<Cubemap>("Core");
	//29. CubemapArray
	RegisterUnityClass<CubemapArray>("Core");
	//30. DelayedCallManager
	RegisterUnityClass<DelayedCallManager>("Core");
	//31. EditorExtension
	RegisterUnityClass<EditorExtension>("Core");
	//32. FlareLayer
	RegisterUnityClass<FlareLayer>("Core");
	//33. GameManager
	RegisterUnityClass<GameManager>("Core");
	//34. GameObject
	RegisterUnityClass<GameObject>("Core");
	//35. GlobalGameManager
	RegisterUnityClass<GlobalGameManager>("Core");
	//36. GraphicsSettings
	RegisterUnityClass<GraphicsSettings>("Core");
	//37. InputManager
	RegisterUnityClass<InputManager>("Core");
	//38. LevelGameManager
	RegisterUnityClass<LevelGameManager>("Core");
	//39. Light
	RegisterUnityClass<Light>("Core");
	//40. LightingSettings
	RegisterUnityClass<LightingSettings>("Core");
	//41. LightmapSettings
	RegisterUnityClass<LightmapSettings>("Core");
	//42. LightProbes
	RegisterUnityClass<LightProbes>("Core");
	//43. LowerResBlitTexture
	RegisterUnityClass<LowerResBlitTexture>("Core");
	//44. Material
	RegisterUnityClass<Material>("Core");
	//45. Mesh
	RegisterUnityClass<Mesh>("Core");
	//46. MeshFilter
	RegisterUnityClass<MeshFilter>("Core");
	//47. MeshRenderer
	RegisterUnityClass<MeshRenderer>("Core");
	//48. MonoBehaviour
	RegisterUnityClass<MonoBehaviour>("Core");
	//49. MonoManager
	RegisterUnityClass<MonoManager>("Core");
	//50. MonoScript
	RegisterUnityClass<MonoScript>("Core");
	//51. NamedObject
	RegisterUnityClass<NamedObject>("Core");
	//52. Object
	//Skipping Object
	//53. PlayerSettings
	RegisterUnityClass<PlayerSettings>("Core");
	//54. PreloadData
	RegisterUnityClass<PreloadData>("Core");
	//55. QualitySettings
	RegisterUnityClass<QualitySettings>("Core");
	//56. RectTransform
	RegisterUnityClass<UI::RectTransform>("Core");
	//57. ReflectionProbe
	RegisterUnityClass<ReflectionProbe>("Core");
	//58. Renderer
	RegisterUnityClass<Renderer>("Core");
	//59. RenderSettings
	RegisterUnityClass<RenderSettings>("Core");
	//60. RenderTexture
	RegisterUnityClass<RenderTexture>("Core");
	//61. ResourceManager
	RegisterUnityClass<ResourceManager>("Core");
	//62. RuntimeInitializeOnLoadManager
	RegisterUnityClass<RuntimeInitializeOnLoadManager>("Core");
	//63. Shader
	RegisterUnityClass<Shader>("Core");
	//64. ShaderNameRegistry
	RegisterUnityClass<ShaderNameRegistry>("Core");
	//65. SkinnedMeshRenderer
	RegisterUnityClass<SkinnedMeshRenderer>("Core");
	//66. Skybox
	RegisterUnityClass<Skybox>("Core");
	//67. Sprite
	RegisterUnityClass<Sprite>("Core");
	//68. SpriteAtlas
	RegisterUnityClass<SpriteAtlas>("Core");
	//69. SpriteRenderer
	RegisterUnityClass<SpriteRenderer>("Core");
	//70. TagManager
	RegisterUnityClass<TagManager>("Core");
	//71. TextAsset
	RegisterUnityClass<TextAsset>("Core");
	//72. Texture
	RegisterUnityClass<Texture>("Core");
	//73. Texture2D
	RegisterUnityClass<Texture2D>("Core");
	//74. Texture2DArray
	RegisterUnityClass<Texture2DArray>("Core");
	//75. Texture3D
	RegisterUnityClass<Texture3D>("Core");
	//76. TimeManager
	RegisterUnityClass<TimeManager>("Core");
	//77. Transform
	RegisterUnityClass<Transform>("Core");
	//78. PlayableDirector
	RegisterUnityClass<PlayableDirector>("Director");
	//79. ParticleSystem
	RegisterUnityClass<ParticleSystem>("ParticleSystem");
	//80. ParticleSystemRenderer
	RegisterUnityClass<ParticleSystemRenderer>("ParticleSystem");
	//81. BoxCollider
	RegisterUnityClass<BoxCollider>("Physics");
	//82. CapsuleCollider
	RegisterUnityClass<CapsuleCollider>("Physics");
	//83. Collider
	RegisterUnityClass<Collider>("Physics");
	//84. MeshCollider
	RegisterUnityClass<MeshCollider>("Physics");
	//85. PhysicMaterial
	RegisterUnityClass<PhysicMaterial>("Physics");
	//86. PhysicsManager
	RegisterUnityClass<PhysicsManager>("Physics");
	//87. Rigidbody
	RegisterUnityClass<Rigidbody>("Physics");
	//88. SphereCollider
	RegisterUnityClass<SphereCollider>("Physics");
	//89. Collider2D
	RegisterUnityClass<Collider2D>("Physics2D");
	//90. CompositeCollider2D
	RegisterUnityClass<CompositeCollider2D>("Physics2D");
	//91. Physics2DSettings
	RegisterUnityClass<Physics2DSettings>("Physics2D");
	//92. PolygonCollider2D
	RegisterUnityClass<PolygonCollider2D>("Physics2D");
	//93. Rigidbody2D
	RegisterUnityClass<Rigidbody2D>("Physics2D");
	//94. Font
	RegisterUnityClass<TextRendering::Font>("TextRendering");
	//95. Canvas
	RegisterUnityClass<UI::Canvas>("UI");
	//96. CanvasGroup
	RegisterUnityClass<UI::CanvasGroup>("UI");
	//97. CanvasRenderer
	RegisterUnityClass<UI::CanvasRenderer>("UI");

}
