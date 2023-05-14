﻿using DefaultDocumentation.Models;

namespace PowerDocs.Markdown.FileNameFactories
{
    /// <summary>
    /// <see cref="Api.IFileNameFactory"/> implementation using <see cref="DocItem.FullName"/> as file name.
    /// </summary>
    public sealed class FullNameFactory : AMarkdownFactory
    {
        /// <summary>
        /// The name of this implementation used at the configuration level.
        /// </summary>
        public const string ConfigName = "FullName";

        /// <inheritdoc/>
        public override string Name => ConfigName;

        /// <inheritdoc/>
        protected override string GetMarkdownFileName(IGeneralContext context, DocItem item) => item.FullName;
    }
}
