﻿using System.Collections.Generic;
using System.Linq;
using DefaultDocumentation.Api;
using DefaultDocumentation.Markdown.Extensions;
using DefaultDocumentation.Markdown.UrlFactories;
using DefaultDocumentation.Models;
using NFluent;
using Xunit;

namespace PowerDocs.Markdown.Sections
{
    public sealed class InterfacesSectionTest : ASectionTest<InterfacesSection>
    {
        protected override IReadOnlyDictionary<string, DocItem> GetItems() =>
            AssemblyInfo.ClassDocItem.IntoEnumerable<DocItem>()
            .Concat(AssemblyInfo.InterfaceDocItem)
            .ToDictionary(i => i.Id);

        protected override IUrlFactory[] GetUrlFactories() => new IUrlFactory[]
        {
            new DocItemFactory()
        };

        protected override ISection[] GetSections() => new ISection[]
        {
            new TitleSection()
        };

        [Fact]
        public void Name_should_be_Interfaces() => Check.That(Name).IsEqualTo("Interfaces");

        [Fact]
        public void Write_should_write_When_TypeDocItem() => Test(
            AssemblyInfo.ClassDocItem,
@"| Interfaces | |
| :--- | :--- |
| [AssemblyInfo.IInterface](IInterface 'DefaultDocumentation.AssemblyInfo.IInterface') | |
");
    }
}
