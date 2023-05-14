using DefaultDocumentation.Api;

namespace PowerDocs.PluginExample
{
    public sealed class NewSection : ISection
    {
        public string Name => "New";

        public void Write(IWriter writer)
        {
            writer.Append("helloworld");
        }
    }
}
