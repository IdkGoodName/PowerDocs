using System.Collections.Generic;
using DefaultDocumentation.Models.Parameters;

namespace PowerDocs.Models
{
    /// <summary>
    /// Exposes <see cref="TypeParameterDocItem"/> instances.
    /// </summary>
    public interface ITypeParameterizedDocItem
    {
        /// <summary>
        /// Gets the <see cref="TypeParameterDocItem"/> of this instance.
        /// </summary>
        IEnumerable<TypeParameterDocItem> TypeParameters { get; }
    }
}
