﻿using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using JsonTreeView.Generic;

namespace JsonTreeView
{
    /// <summary>
    /// Specialized <see cref="TreeNode"/> for handling <see cref="JObject"/> representation in a <see cref="TreeView"/>.
    /// </summary>
    sealed class JObjectTreeNode : JTokenTreeNode
    {
        #region >> Properties

        public JObject JObjectTag => Tag as JObject;

        #endregion

        #region >> Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="JObjectTreeNode"/> class.
        /// </summary>
        public JObjectTreeNode(JObject jObject)
            : base(jObject)
        {
        }

        #endregion

        #region >> JTokenTreeNode

        /// <inheritdoc />
        public override void AfterCollapse()
        {
            base.AfterCollapse();

            Text = $@"{{{JObjectTag.Type}}} {GetAbstractTextForTag()} 元素个数:{JObjectTag.Count}";
        }

        /// <inheritdoc />
        public override void AfterExpand()
        {
            base.AfterExpand();

            Text = $@"{{{JObjectTag.Type}}} 元素个数:{JObjectTag.Count}";
        }

        #endregion
    }
}
