using System;
using Ceres.Annotations;
using Ceres.Graph;
using Ceres.Graph.Flow;
using R3.Chris;
using Chris.Resource;
using UObject = UnityEngine.Object;
namespace Chris.Gameplay.Flow
{
    [Serializable]
    [CeresGroup("Utilities")]
    [CeresLabel("Load {0} Async")]
    public class FlowNode_SoftAssetReferenceTLoadAssetAsync<TObject>: FlowNode where TObject: UObject
    {
        [InputPort, HideInGraphEditor]
        public CeresPort<SoftAssetReference<TObject>> reference;
                
        [InputPort]
        public DelegatePort<EventDelegate<TObject>> onComplete;

        protected override void LocalExecute(ExecutionContext executionContext)
        {
            reference.Value.LoadAsync().AddTo(executionContext.Graph).RegisterCallback(onComplete.Value);
        }
    }
    
    [Serializable]
    [CeresGroup("Utilities")]
    [CeresLabel("Load Asset Async")]
    [RequirePort(typeof(SoftAssetReference))]
    public class FlowNode_SoftAssetReferenceLoadAssetAsync: FlowNode
    {
        [InputPort, HideInGraphEditor]
        public CeresPort<SoftAssetReference> reference;
                
        [InputPort]
        public DelegatePort<EventDelegate<UObject>> onComplete;

        protected override void LocalExecute(ExecutionContext executionContext)
        {
            reference.Value.LoadAsync().AddTo(executionContext.Graph).RegisterCallback(onComplete.Value);
        }
    }
}