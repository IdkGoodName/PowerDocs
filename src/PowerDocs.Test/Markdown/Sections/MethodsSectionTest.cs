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
    public sealed class MethodsSectionTest : ASectionTest<MethodsSection>
    {
        protected override IReadOnlyDictionary<string, DocItem> GetItems() =>
            AssemblyInfo.ClassDocItem.IntoEnumerable<DocItem>()
            .Concat(AssemblyInfo.MethodWithReturnDocItem)
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
        public void Name_should_be_Methods() => Check.That(Name).IsEqualTo("Methods");

        [Fact]
        public void Write_should_write_When_TypeDocItem() => Test(
            AssemblyInfo.ClassDocItem,
@"| Methods | |
| :--- | :--- |
| [MoveNext()](MoveNext() 'DefaultDocumentation.AssemblyInfo.MoveNext()') | |
");
    }
}
