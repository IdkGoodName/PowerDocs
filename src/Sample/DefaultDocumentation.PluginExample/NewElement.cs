using System.Xml.Linq;
using DefaultDocumentation.Api;

namespace PowerDocs.PluginExample
{
    public sealed class NewElement : IElement
    {
        public string Name => "new";

        public void Write(IWriter writer, XElement element)
        {
            writer.Append("hello ").Append(element.Value);
        }
    }
}
