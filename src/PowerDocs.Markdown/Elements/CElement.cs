﻿using System.Xml.Linq;
using DefaultDocumentation.Api;

namespace PowerDocs.Markdown.Elements
{
    /// <summary>
    /// Handles <c>c</c> xml element.
    /// </summary>
    public sealed class CElement : IElement
    {
        /// <summary>
        /// The name of this implementation used at the configuration level.
        /// </summary>
        public const string ConfigName = "c";

        /// <inheritdoc/>
        public string Name => ConfigName;

        /// <inheritdoc/>
        public void Write(IWriter writer, XElement element)
        {
            writer
                .Append("`")
                .Append(element.Value)
                .Append("`");
        }
    }
}
