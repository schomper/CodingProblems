namespace ProblemsSolution.Utilities
{
    /// <summary>
    /// Class which represents a node within a binary tree
    /// </summary>
    public class BinaryTreeNode
    {
        /// <summary>
        /// The value stored within the node
        /// </summary>
        public string Value;

        /// <summary>
        /// The child on the left
        /// </summary>
        public BinaryTreeNode Left = null;

        /// <summary>
        /// The child on the right
        /// </summary>
        public BinaryTreeNode Right = null;

        /// <summary>
        /// Constructor for a BinaryTreeNode
        /// </summary>
        /// <param name="value">The value stored within the node</param>
        /// <param name="left">The child on the left</param>
        /// <param name="right">The child on the right</param>
        public BinaryTreeNode(string value, BinaryTreeNode left, BinaryTreeNode right)
        {
            Value = value;
            Left = left;
            Right = right;
        }
    }
}
