using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeSolution
{
    /*
     * 给你两棵二叉树 root 和 subRoot 。
     * 检验 root 中是否包含和 subRoot 具有相同结构和节点值的子树。
     * 如果存在，返回 true ；否则，返回 false 。
     */
    public class SubTreeSolution
    {
        public bool IsSubtree(TreeNode root, TreeNode subRoot)
        {
            return DFS(root, subRoot);
        }

        private bool DFS(TreeNode root, TreeNode sub)
        {
            if (root == null)
                return false;

            return Check(root, sub) || Check(root.left, sub) || Check(root.right, sub);
        }

        private bool Check(TreeNode root, TreeNode sub)
        {
            if (root == null && sub == null)
                return true;

            if (root == null || sub == null || root.val != sub.val)
                return false;

            return Check(root.left, sub.left) && Check(root.right, sub.right);
        }

        public void Run()
        {
            var root = new TreeNode(3,
                new TreeNode(4, new TreeNode(1), new TreeNode(2)),
                new TreeNode(5));

            var subRoot = new TreeNode(4, new TreeNode(1), new TreeNode(2));

            bool flag = IsSubtree(root, subRoot);
            Console.WriteLine(flag);
        }
    }

    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }

}
