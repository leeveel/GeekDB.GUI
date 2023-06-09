using System;
using System.Linq;
using System.Windows.Forms;
using JsonTreeView.Extensions;
using JsonTreeView.Generic;
using JsonTreeView.Linq;

namespace JsonTreeView
{
    class JTokenContextMenuStrip : ContextMenuStrip
    {
        /// <summary>
        /// Source <see cref="TreeNode"/> at the origin of this <see cref="ContextMenuStrip"/>
        /// </summary>
        protected JTokenTreeNode JTokenNode;

        protected ToolStripItem CollapseAllToolStripItem;
        protected ToolStripItem ExpandAllToolStripItem;

        #region >> Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="JTokenContextMenuStrip"/> class.
        /// </summary>
        public JTokenContextMenuStrip()
        {
            CollapseAllToolStripItem = new ToolStripMenuItem("收缩所有", null, CollapseAll_Click);
            ExpandAllToolStripItem = new ToolStripMenuItem("展开所有", null, ExpandAll_Click);

            Items.Add(CollapseAllToolStripItem);
            Items.Add(ExpandAllToolStripItem);
        }

        #endregion

        #region >> ContextMenuStrip

        /// <inheritdoc />
        protected override void OnVisibleChanged(EventArgs e)
        {
            if (Visible)
            {
                JTokenNode = FindSourceTreeNode<JTokenTreeNode>();

                // Collapse item shown if node is expanded and has children
                CollapseAllToolStripItem.Visible = JTokenNode.IsExpanded
                    && JTokenNode.Nodes.Cast<TreeNode>().Any();

                // Expand item shown if node if not expanded or has a children not expanded
                ExpandAllToolStripItem.Visible = !JTokenNode.IsExpanded
                    || JTokenNode.Nodes.Cast<TreeNode>().Any(t => !t.IsExpanded);
            }

            base.OnVisibleChanged(e);
        }

        #endregion

        /// <summary>
        /// Click event handler for <see cref="CollapseAllToolStripItem"/>.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void CollapseAll_Click(Object sender, EventArgs e)
        {
            if (JTokenNode != null)
            {
                JTokenNode.TreeView.BeginUpdate();

                var nodes = JTokenNode.EnumerateNodes().Take(1000);
                foreach (var treeNode in nodes)
                {
                    treeNode.Collapse();
                }

                JTokenNode.TreeView.EndUpdate();
            }
        }


        /// <summary>
        /// Click event handler for <see cref="ExpandAllToolStripItem"/>.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void ExpandAll_Click(Object sender, EventArgs e)
        {
            if (JTokenNode != null && JTokenNode.TreeView != null)
            {
                JTokenNode.TreeView.BeginUpdate();

                var nodes = JTokenNode.EnumerateNodes().Take(1000);
                foreach (var treeNode in nodes)
                {
                    treeNode.Expand();
                }

                JTokenNode.TreeView.EndUpdate();
            }
        }


        /// <summary>
        /// Identify the Source <see cref="TreeNode"/> at the origin of this <see cref="ContextMenuStrip"/>.
        /// </summary>
        /// <typeparam name="T">Subtype of <see cref="TreeNode"/> to return.</typeparam>
        /// <returns></returns>
        public T FindSourceTreeNode<T>() where T : TreeNode
        {
            var treeView = SourceControl as TreeView;

            return treeView?.SelectedNode as T;
        }
    }
}
