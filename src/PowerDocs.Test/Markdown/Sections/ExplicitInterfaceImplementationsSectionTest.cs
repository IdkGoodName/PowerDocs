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
    public sealed class ExplicitInterfaceImplementationsSectionTest : ASectionTest<ExplicitInterfaceImplementationsSection>
    {
        protected override IReadOnlyDictionary<string, DocItem> GetItems() =>
            AssemblyInfo.ClassDocItem.IntoEnumerable<DocItem>()
            .Concat(AssemblyInfo.ExplicitPropertyDocItem)
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
        public void Name_should_be_ExplicitInterfaceImplementations() => Check.That(Name).IsEqualTo("ExplicitInterfaceImplementations");

        [Fact]
        public void Write_should_write_When_TypeDocItem() => Test(
            AssemblyInfo.ClassDocItem,
@"| Explicit Interface Implementations | |
| :--- | :--- |
| [DefaultDocumentation.AssemblyInfo.IInterface.Property](DefaultDocumentation.AssemblyInfo.IInterface.Property 'DefaultDocumentation.AssemblyInfo.DefaultDocumentation.AssemblyInfo.IInterface.Property') | |
");
    }
}
