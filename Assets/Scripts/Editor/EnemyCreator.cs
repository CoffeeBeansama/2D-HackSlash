using UnityEngine;
using UnityEditor;
using HackSlash.Enemies;


namespace HackSlash
{
    public class EnemyCreator : EditorWindow
    {

        static string EnemyDataPath = "Assets/Scripts/Scriptable Objects/Enemies";
        static string EnemyName;
        
        static int EnemyMaximumHealth;
        static int EnemyDamage;
        
        static int SelectedLayer;

        static float EnemyMovementSpeed;
        static float EnemyAttackRange;
   

        static Sprite DefaultSprite;
        static GameObject EnemyTemplate;
        static Animator controller;

        bool ShowBasics = true;
        bool ShowAnimations = true;


        static bool AddIdleAnimation = false;
        static bool AddWalkingAnimation = false;
        static bool AddAttackAnimation = false;
        static bool AddHurtAnimation = false;
        static bool AddDeathAnimation = false;


        [MenuItem("Enemy/Enemy Creator")]
        static void Init()
        {
            // Get existing open window or if none, make a new one:
            EnemyCreator window = (EnemyCreator)EditorWindow.GetWindow(typeof(EnemyCreator));
            window.Show();
        }


       

        private void OnGUI()
        {


            AddPublicFields();
           

            if (GUILayout.Button("Create New Enemy", GUILayout.Width(200), GUILayout.Width(200), GUILayout.Height(32)))
            {


                CreateNewEnemy();

                

            }
        }


        private void AddPublicFields()
        {
      
            EditorGUILayout.Space();
            GUILayout.Label("Create Enemy Profile", EditorStyles.boldLabel);

            ShowBasics = EditorGUILayout.Foldout(ShowBasics, "Enemy Info");
            if (ShowBasics)
            {
                GUILayout.Label("Choose Enemy Name", EditorStyles.boldLabel);
                EnemyName = EditorGUILayout.TextField(EnemyName, GUILayout.Width(200), GUILayout.Height(25));

                GUILayout.Label("Choose Maximum Enemy Health", EditorStyles.boldLabel);
                EnemyMaximumHealth = EditorGUILayout.IntField(EnemyMaximumHealth, GUILayout.Width(200), GUILayout.Height(25));

                GUILayout.Label("Choose Enemy Damage", EditorStyles.boldLabel);
                EnemyDamage = EditorGUILayout.IntField(EnemyDamage, GUILayout.Width(200), GUILayout.Height(25));
                EditorGUILayout.Space();
                GUILayout.Label("Select Enemy MovementSpeed", EditorStyles.boldLabel);
                EnemyMovementSpeed = (float)EditorGUILayout.Slider(EnemyMovementSpeed, 0, 20, GUILayout.Width(200), GUILayout.Height(EditorGUIUtility.singleLineHeight));
                EditorGUILayout.Space();
                GUILayout.Label("Select Enemy Range", EditorStyles.boldLabel);
                EnemyAttackRange = (float)EditorGUILayout.Slider(EnemyAttackRange, 0, 20, GUILayout.Width(200), GUILayout.Height(EditorGUIUtility.singleLineHeight));
                EditorGUILayout.Space();
                GUILayout.Label("Select Default Sprite", EditorStyles.boldLabel);
                DefaultSprite = (Sprite)EditorGUILayout.ObjectField(DefaultSprite, typeof(Sprite), false, GUILayout.Width(200), GUILayout.Height(EditorGUIUtility.singleLineHeight));
                EditorGUILayout.Space();
                GUILayout.Label("Select Enemy Layer", EditorStyles.boldLabel);
                SelectedLayer = EditorGUILayout.LayerField(SelectedLayer, GUILayout.Width(200), GUILayout.Height(16));

                EditorGUILayout.Space();
                EditorGUILayout.Space();
            }


            GUILayout.Label("Create Enemy Animations", EditorStyles.boldLabel);
            ShowAnimations = EditorGUILayout.Foldout(ShowAnimations, "Animations");

            if (ShowAnimations)
            {
                AddIdleAnimation = EditorGUILayout.Toggle("Add Idle Animation", AddIdleAnimation);
                AddWalkingAnimation = EditorGUILayout.Toggle("Add Walking Animation", AddWalkingAnimation);
                AddAttackAnimation = EditorGUILayout.Toggle("Add Attack Animation", AddAttackAnimation);
                AddHurtAnimation = EditorGUILayout.Toggle("Add Hurt Animation", AddHurtAnimation);
                AddDeathAnimation = EditorGUILayout.Toggle("Add Death Animation", AddDeathAnimation);
            }



            GUILayout.Label("Enemy Data ScriptableObject Path", EditorStyles.boldLabel);
            EnemyDataPath = EditorGUILayout.TextField(EnemyDataPath, GUILayout.Width(200), GUILayout.Height(16));

            



        }

        private void CreateNewEnemy()
        {
            EnemyTemplate = new GameObject();


            EnemyTemplate.name = EnemyName;
            EnemyTemplate.AddComponent<EnemyStateManager>();
            EnemyTemplate.GetComponent<SpriteRenderer>().sprite = DefaultSprite;
            EnemyTemplate.gameObject.layer = SelectedLayer;


            CreateScriptableObject(EnemyDataPath,EnemyName);
            AddAnimation();
            


        }

        private void AddAnimation()
        {
            var controller = UnityEditor.Animations.AnimatorController.CreateAnimatorControllerAtPath($"Assets/Animation/EnemyAnimation/Controllers/{EnemyName}.controller");


            string IdleAnimation = "Idle";
            string WalkAnimation = "Walk";
            string AttackAnimation = "Attack";
            string HurtAnimation = "Hurt";
            string DeathAnimation = "Death";

            

          
            EnemyTemplate.GetComponent<Animator>().runtimeAnimatorController = controller;

            

            var rootStateMachine = controller.layers[0].stateMachine;


            if (AddIdleAnimation) 
            { 
                var stateMachineA = rootStateMachine.AddState(IdleAnimation);
                AnimationClip clip1 = new AnimationClip();
                AssetDatabase.CreateAsset(clip1, $"Assets/Animation/EnemyAnimation/{EnemyName}/{EnemyName} {IdleAnimation} Animation.anim");
                var stateAMachineAMotion = stateMachineA.motion = (AnimationClip)AssetDatabase.LoadAssetAtPath($"Assets/Animation/EnemyAnimation/{EnemyName}/{EnemyName} {IdleAnimation} Animation.anim", typeof(AnimationClip));
                controller.AddParameter("EnemyIdle", AnimatorControllerParameterType.Bool);
                

                
            }

            if (AddWalkingAnimation)
            {
                var stateMachineB = rootStateMachine.AddState(WalkAnimation);
                AnimationClip clip2 = new AnimationClip();
                AssetDatabase.CreateAsset(clip2, $"Assets/Animation/EnemyAnimation/{EnemyName}/{EnemyName} {WalkAnimation} Animation.anim");
                var stateBMachineAMotion = stateMachineB.motion = (AnimationClip)AssetDatabase.LoadAssetAtPath($"Assets/Animation/EnemyAnimation/{EnemyName}/{EnemyName} {WalkAnimation} Animation.anim", typeof(AnimationClip));
                controller.AddParameter("EnemyWalk", AnimatorControllerParameterType.Bool);

                



            }

            if (AddAttackAnimation)
            {
                var stateMachineC = rootStateMachine.AddState(AttackAnimation);
                AnimationClip clip3 = new AnimationClip();
                AssetDatabase.CreateAsset(clip3, $"Assets/Animation/EnemyAnimation/{EnemyName}/{EnemyName} {AttackAnimation} Animation.anim");
                var stateCMachineAMotion = stateMachineC.motion = (AnimationClip)AssetDatabase.LoadAssetAtPath($"Assets/Animation/EnemyAnimation/{EnemyName}/{EnemyName} {AttackAnimation} Animation.anim", typeof(AnimationClip));
                controller.AddParameter("EnemyAttack", AnimatorControllerParameterType.Bool);
            }
            

            if (AddDeathAnimation)
            {
                var stateMachineD = rootStateMachine.AddState(DeathAnimation);
                AnimationClip clip4 = new AnimationClip();
                AssetDatabase.CreateAsset(clip4, $"Assets/Animation/EnemyAnimation/{EnemyName}/{EnemyName} {DeathAnimation} Animation.anim");
                var stateDMachineAMotion = stateMachineD.motion = (AnimationClip)AssetDatabase.LoadAssetAtPath($"Assets/Animation/EnemyAnimation/{EnemyName}/{EnemyName} {DeathAnimation} Animation.anim", typeof(AnimationClip));
                controller.AddParameter("EnemyDeath", AnimatorControllerParameterType.Bool);
            }

            if (AddHurtAnimation)
            {
                var stateMachineE = rootStateMachine.AddState(HurtAnimation);
                AnimationClip clip4 = new AnimationClip();
                AssetDatabase.CreateAsset(clip4, $"Assets/Animation/EnemyAnimation/{EnemyName}/{EnemyName} {HurtAnimation} Animation.anim");
                var stateDMachineAMotion = stateMachineE.motion = (AnimationClip)AssetDatabase.LoadAssetAtPath($"Assets/Animation/EnemyAnimation/{EnemyName}/{EnemyName} {HurtAnimation} Animation.anim", typeof(AnimationClip));
                controller.AddParameter("EnemyHurt", AnimatorControllerParameterType.Bool);
            }

























        }


      

        private void CreateScriptableObject(string _path,string _assetName)
        {
            EnemyData newEnemyData = ScriptableObject.CreateInstance<EnemyData>();

            AssetDatabase.CreateAsset(newEnemyData,$"{_path}/{_assetName}.asset");

            EnemyTemplate.GetComponent<EnemyStateManager>().Stats = newEnemyData;
            EnemyTemplate.GetComponent<EnemyHealthScript>().Stats = newEnemyData;


            newEnemyData.AttackRadius = EnemyAttackRange;
            newEnemyData.Damage = EnemyDamage;
            newEnemyData.MaxHealth = EnemyMaximumHealth;
            newEnemyData.MovementSpeed = EnemyMovementSpeed;

        }
    }
}
