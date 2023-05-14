﻿using System.IO;
using DefaultDocumentation.Api;
using DefaultDocumentation.Markdown.Internal;
using DefaultDocumentation.Models;

namespace PowerDocs.Markdown.UrlFactories
{
    /// <summary>
    /// Handles id for known <see cref="DocItem"/>.
    /// </summary>
    public sealed class DocItemFactory : IUrlFactory
    {
        /// <summary>
        /// The name of this implementation used at the configuration level.
        /// </summary>
        public const string ConfigName = "DocItem";

        /// <inheritdoc/>
        public string Name => ConfigName;

        /// <inheritdoc/>
        public string? GetUrl(IGeneralContext context, string id)
        {
            if (!context.Items.TryGetValue(id, out DocItem item))
            {
                return null;
            }

            if (item is ExternDocItem externItem)
            {
                return externItem.Url;
            }

            DocItem pagedItem = item;
            while (!pagedItem.HasOwnPage(context))
            {
                pagedItem = pagedItem.Parent!;
            }

            string url = context.GetFileName(pagedItem);
            if (context.GetRemoveFileExtensionFromUrl() && Path.HasExtension(url))
            {
                url = url.Substring(0, url.Length - Path.GetExtension(url).Length);
            }
            if (item != pagedItem)
            {
                url += "#" + PathCleaner.Clean(item.FullName, context.GetInvalidCharReplacement());
            }

            return url;
        }
    }
}
