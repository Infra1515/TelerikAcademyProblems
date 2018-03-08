using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree
{
    public class TreeAsDAG<T>
    {
        private IDictionary<T, TreeNode<T>> tree;

        public IDictionary<T, TreeNode<T>> Tree { get => tree; }

        public TreeAsDAG()
        {
            this.tree = new Dictionary<T, TreeNode<T>>();
        }

        public void AddChild(T parent, T child)
        {
            if (!this.Tree.ContainsKey(parent))
            {
                this.Tree.Add(parent, new TreeNode<T>(parent));
            }

            if (!this.Tree.ContainsKey(child))
            {
                this.Tree.Add(child, new TreeNode<T>(child));
            }

            if (this.Tree[parent].Children == null)
            {
                this.Tree[parent].Children = new List<T>();
            }

            if (this.Tree[child].Parents == null)
            {
                this.Tree[child].Parents = new List<T>();
            }

            this.Tree[parent].Children.Add(child);
            this.Tree[child].Parents.Add(parent);
        }

        public void RemoveChild(T parent, T child)
        {
            if (!this.Tree.ContainsKey(parent))
            {
                Console.WriteLine("No such parent in the tree!");
                return;
            }

            if (!this.Tree[parent].Children.Contains(child))
            {
                Console.WriteLine("No such parent in the tree!");
                return;
            }

            this.Tree[parent].Children.Remove(child);
            this.Tree[child].Parents.Remove(parent);
        }

        // how to fix this?
        public T FindRoot(T startingPt)
        {
            if (this.Tree[startingPt].Parents == null)
            {
                return startingPt;
            }
            else
            {
                foreach (var parent in this.Tree[startingPt].Parents)
                {
                    this.FindRoot(parent);
                }
            }

            return default(T);
        }
    }

    public class TreeNode<T>
    {
        public T Value { get; }

        public IList<T> Children { get; set; }

        public IList<T> Parents { get; set; }

        public TreeNode(T value)
        {
            this.Value = value;
        }

    }
}
