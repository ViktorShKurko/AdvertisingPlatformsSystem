namespace AdvertisingPlatformsSystem.Storages;

public class AgentLocationMapTree
{
    public IReadOnlyDictionary<ulong, AgentInfo> Agents => _agents;
    private Dictionary<ulong, AgentInfo> _agents;
    
    
    private class TreeNode
    {
        public string Key { get; private set; }
        private readonly Dictionary<string, TreeNode> _children;
        private readonly HashSet<ulong> _agentsIds;
        
        public TreeNode(string key) 
        {
            Key = key;
            _children = new Dictionary<string, TreeNode>();
            _agentsIds = new HashSet<ulong>();
        }
    }
}