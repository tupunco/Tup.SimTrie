using System;
using System.Collections.Generic;
using System.Text;

namespace Tup.SimTrie
{
    /// <summary>
    /// Trie 查找树
    /// </summary>
    /// <remarks>
    /// 参考: http://en.wikipedia.org/wiki/Trie
    /// </remarks>
    public class TrieTree
    {
        private TrieNode m_root = new TrieNode();

        /// <summary>
        /// 构建 Trie 树
        /// </summary>
        /// <param name="values">参与构建 Trie 树的字符串列表</param>
        public void Build(IEnumerable<string> values)
        {
            if (values == null)
                throw new ArgumentNullException("values");

            foreach (var item in values)
            {
                Build(item);
            }
        }
        /// <summary>
        /// 构建 Trie 树
        /// </summary>
        /// <param name="value">参与构建 Trie 树的字符串</param>
        public void Build(string value)
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentNullException("value");

            TrieNode nNode = null;
            TrieNode cNode = m_root;
            var cChildNodes = cNode.ChildNodes;
            foreach (var curItem in value)
            {
                if (cChildNodes == null)
                    cChildNodes = new Dictionary<char, TrieNode>();

                if (cChildNodes.Count == 0 || !cChildNodes.TryGetValue(curItem, out nNode))
                {
                    nNode = new TrieNode();
                    cChildNodes.Add(curItem, nNode);
                }
                cNode.ChildNodes = cChildNodes;

                cNode = nNode;
                cChildNodes = cNode.ChildNodes;
            }
            cNode.IsSegment = true;
        }
        /// <summary>
        /// 判断字符串是否在 Trie 树上
        /// </summary>
        /// <param name="value">待匹配字符串</param>
        /// <returns>找到结果返回True</returns>
        public bool Find(string value)
        {
            return Find(value, false);
        }
        /// <summary>
        /// 判断字符串是否在 Trie 树上
        /// </summary>
        /// <param name="value">待匹配字符串</param>
        /// <param name="fuzzy">是否模糊匹配</param>
        /// <returns>找到结果返回 True, 模糊匹配传入 True 后, 只要待匹配字符串前缀有匹配情况就返回 True</returns>
        public bool Find(string value, bool fuzzy)
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentNullException("value");

            TrieNode cNode = m_root;
            var cChildNodes = cNode.ChildNodes;
            foreach (var curItem in value)
            {
                if (cChildNodes != null && cChildNodes.TryGetValue(curItem, out cNode))
                    cChildNodes = cNode.ChildNodes;
                else
                    return false;

                if (fuzzy && cNode.IsSegment)
                    return true;
            }
            return cNode.IsSegment;
        }
        /// <summary>
        /// Trie 节点
        /// </summary>
        class TrieNode
        {
            /// <summary>
            /// 子节点
            /// </summary>
            public Dictionary<char, TrieNode> ChildNodes { get; set; }
            /// <summary>
            /// 当前节点是否是段结束节点
            /// </summary>
            public bool IsSegment { get; set; }
        }
    }
}
