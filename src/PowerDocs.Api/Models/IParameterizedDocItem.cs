using System.Collections.Generic;
using DefaultDocumentation.Models.Parameters;

namespace PowerDocs.Models
{
    /// <summary>
    /// Exposes <see cref="ParameterDocItem"/> instances.
    /// </summary>
    public interface IParameterizedDocItem
    {
        /// <summary>
        /// Gets the <see cref="ParameterDocItem"/> of this instance.
        /// </summary>
        IEnumerable<ParameterDocItem> Parameters { get; }
    }
}
