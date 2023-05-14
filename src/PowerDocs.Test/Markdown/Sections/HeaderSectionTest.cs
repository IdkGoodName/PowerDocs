﻿using System.Collections.Generic;
using System.Linq;
using DefaultDocumentation.Markdown.Extensions;
using DefaultDocumentation.Models;
using NFluent;
using Xunit;

namespace PowerDocs.Markdown.Sections
{
    public sealed class HeaderSectionTest : ASectionTest<HeaderSection>
    {
        protected override GeneratedPages GetGeneratedPages() =>
            GeneratedPages.Assembly
            | GeneratedPages.Namespaces
            | GeneratedPages.Types
            | GeneratedPages.Members;

        protected override IReadOnlyDictionary<string, DocItem> GetItems() => new DocItem[] { AssemblyInfo.AssemblyDocItem }.ToDictionary(i => i.Id);

        [Fact]
        public void Name_should_be_Header() => Check.That(Name).IsEqualTo("Header");

        [Fact]
        public void Write_should_not_write_When_not_PageItem() => Test(
            w => w.SetCurrentItem(AssemblyInfo.NamespaceDocItem),
            string.Empty);

        [Fact]
        public void Write_should_write() => Test(
            AssemblyInfo.MethodWithReturnDocItem,
@"#### [Test](Test 'Test')
### [DefaultDocumentation](N:DefaultDocumentation 'DefaultDocumentation').[AssemblyInfo](T:DefaultDocumentation.AssemblyInfo 'DefaultDocumentation.AssemblyInfo')");

        [Fact]
        public void Write_should_write_newline_When_needed() => Test(
            AssemblyInfo.MethodWithReturnDocItem,
            w => w.Append("pouet"),
@"pouet
#### [Test](Test 'Test')
### [DefaultDocumentation](N:DefaultDocumentation 'DefaultDocumentation').[AssemblyInfo](T:DefaultDocumentation.AssemblyInfo 'DefaultDocumentation.AssemblyInfo')");
    }
}
