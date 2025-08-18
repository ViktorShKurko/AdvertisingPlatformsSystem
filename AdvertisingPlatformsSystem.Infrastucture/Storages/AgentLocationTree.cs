using AdvertisingPlatformsSystem.Domain;

namespace AdvertisingPlatformsSystem.Storages;

public class AgentLocationMapTree
{
    public IReadOnlyDictionary<long, AgentInfo> Agents => _agents;
    private Dictionary<long, AgentInfo> _agents;
    private TreeNode _root;
    
    public IEnumerable<AgentInfo> GetAgentsByLocation(string location)
    {
        var agentsIds = FindAgentsIdsByLocation(location);
        foreach (var agentsId in agentsIds)
        {
            yield return _agents[agentsId];
        }
    }
    
    public void SetAgentLocationsData(IEnumerable<AgentInfo> agentLocationInfos)
    {
        var newRoot = new TreeNode(".");
        SetAgentsData(agentLocationInfos);
        
        foreach (var agentLocationInfo in agentLocationInfos)
        {
            foreach (var location in agentLocationInfo.Locations)
            {
                AddLocation(newRoot ,location, agentLocationInfo.Id);
            }
        }
        
        _root = newRoot;
    }
    
    private void AddLocation(TreeNode root, string location, long agentId)
    {
        var mapItems = location.Split('/');
        var queueMap = new Queue<string>(mapItems);
        var current = root;
        
        while (queueMap.Count > 0) 
        {
            var currentMapKey = queueMap.Dequeue();
            var child = current.GetOrAddChildNode(currentMapKey);
            current = child;
            
            if(current.ContainsAgent(agentId))
                return;
        }

        current.AddAgent(agentId);
    }
    
    private IEnumerable<long> FindAgentsIdsByLocation(string location)
    {
        var mapItems = location.Split('/');
        var queueMap = new Queue<string>(mapItems);
        var current = _root;
        
        while (queueMap.Count > 0 && current != null)
        {
            var currentMapKey = queueMap.Dequeue();
            var child = current.GetChildByKey(currentMapKey);
            if (child != null)
            {
                foreach (var agentId in child.AgentsIds)
                {
                    yield return agentId;
                }
            }

            current = child;
        }
    }
    
    private void SetAgentsData(IEnumerable<AgentInfo> agentLocationInfos)
    {
        _agents = agentLocationInfos.ToDictionary(k => k.Id, v => v);
    }
    
    private class TreeNode
    {
        public string Key { get; private set; }
        private readonly Dictionary<string, TreeNode> _children;
        private readonly HashSet<long> _agentsIds;
        public IReadOnlyCollection<long> AgentsIds => _agentsIds;
        
        public TreeNode(string key) 
        {
            Key = key;
            _children = new Dictionary<string, TreeNode>();
            _agentsIds = new HashSet<long>();
        }
        
        public bool ContainsAgent(long agentId) => _agentsIds.Contains(agentId);
        
        public TreeNode? GetChildByKey(string key)
        {
            return _children.GetValueOrDefault(key);
        }

        public void AddAgent(long agentId)
        {
            _agentsIds.Add(agentId);
        }
        
        public TreeNode GetOrAddChildNode(string key) 
        {
            if (!_children.TryGetValue(key, out var node))
            {
                node = new TreeNode(key);
                _children.Add(key, node);
            }
            
            return node;
        }
    }
}