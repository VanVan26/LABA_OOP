using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba1_3
{
        public class TreeNode
        {
            private string _value;
            private List<TreeNode> _children;
           

            public TreeNode(string value)
            {
                this._value = value;
                this._children = new List<TreeNode>();
            }

            public void AddChildren(TreeNode node)
            {
                this._children.Add(node);
            }

            public string ToStringWithLevel(int level = 0)
            {
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < level; i++)
                {
                    sb.Append("+");
                }
                sb.Append(this._value);
                foreach (var level_node in _children)
                {
                    sb.Append('\n');
                    sb.Append(level_node.ToStringWithLevel(level + 1));
                }
                return sb.ToString();
            }
            public override string ToString()
            {
                return ToStringWithLevel(0);
            }
        }
}    
