﻿using System.Collections.Generic;
using System.Linq;
using DefaultDocumentation.Models;
using DefaultDocumentation.Models.Members;
using ICSharpCode.Decompiler.TypeSystem;
using NFluent;
using Xunit;

namespace PowerDocs.Markdown.Sections
{
    public sealed class ImplementSectionTest : ASectionTest<ImplementSection>
    {
        protected override IReadOnlyDictionary<string, DocItem> GetItems() => new DocItem[]
        {
            AssemblyInfo.InterfaceDocItem,
            AssemblyInfo.InterfaceMethodDocItem,
            AssemblyInfo.InterfaceEventDocItem
        }.ToDictionary(i => i.Id);

        [Fact]
        public void Name_should_be_Implement() => Check.That(Name).IsEqualTo("Implement");

        [Fact]
        public void Write_should_not_write_When_no_implementation() => Test(string.Empty);

        [Fact]
        public void Write_should_write_When_TypeDocItem() => Test(
            AssemblyInfo.ClassDocItem,
            "Implements [IInterface](T:DefaultDocumentation.AssemblyInfo.IInterface 'DefaultDocumentation.AssemblyInfo.IInterface'), [System.Collections.IEnumerator](T:System.Collections.IEnumerator 'System.Collections.IEnumerator')");

        [Fact]
        public void Write_should_write_newline_When_needed() => Test(
            AssemblyInfo.ClassDocItem,
            w => w.Append("pouet"),
@"pouet

Implements [IInterface](T:DefaultDocumentation.AssemblyInfo.IInterface 'DefaultDocumentation.AssemblyInfo.IInterface'), [System.Collections.IEnumerator](T:System.Collections.IEnumerator 'System.Collections.IEnumerator')");

        [Fact]
        public void Write_should_write_When_MethodDocItem() => Test(
            new MethodDocItem(AssemblyInfo.ClassDocItem, AssemblyInfo.Get<IMethod>($"M:{typeof(AssemblyInfo).FullName}.{nameof(AssemblyInfo.MoveNext)}"), null),
            "Implements [MoveNext()](M:System.Collections.IEnumerator.MoveNext 'System.Collections.IEnumerator.MoveNext')");

        [Fact]
        public void Write_should_write_When_PropertyDocItem() => Test(
            new PropertyDocItem(AssemblyInfo.ClassDocItem, AssemblyInfo.Get<IProperty>($"P:{typeof(AssemblyInfo).FullName}.{nameof(AssemblyInfo.Current)}"), null),
            "Implements [Current](P:System.Collections.IEnumerator.Current 'System.Collections.IEnumerator.Current')");

        [Fact]
        public void Write_should_write_When_EventDocItem() => Test(
            new EventDocItem(AssemblyInfo.ClassDocItem, AssemblyInfo.Get<IEvent>($"E:{typeof(AssemblyInfo).FullName}.{nameof(AssemblyInfo.SecondEvent)}"), null),
            "Implements [SecondEvent](E:DefaultDocumentation.AssemblyInfo.IInterface.SecondEvent 'DefaultDocumentation.AssemblyInfo.IInterface.SecondEvent')");

        [Fact]
        public void Write_should_write_When_ExplicitInterfaceImplementationDocItem() => Test(
            AssemblyInfo.ExplicitMethodDocItem,
            "Implements [Method()](M:DefaultDocumentation.AssemblyInfo.IInterface.Method 'DefaultDocumentation.AssemblyInfo.IInterface.Method()')");
    }
}
