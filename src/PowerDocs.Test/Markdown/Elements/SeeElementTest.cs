﻿using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using DefaultDocumentation.Models;
using NFluent;
using Xunit;

namespace PowerDocs.Markdown.Elements
{
    public sealed class SeeElementTest : AElementTest<SeeElement>
    {
        protected override IReadOnlyDictionary<string, DocItem> GetItems() => new DocItem[] { AssemblyInfo.NamespaceDocItem }.ToDictionary(i => i.Id);

        [Fact]
        public void Name_should_be_see() => Check.That(Name).IsEqualTo("see");

        [Fact]
        public void Write_should_write_When_cref() => Test(
            new XElement("see", new XAttribute("cref", AssemblyInfo.NamespaceDocItem.Id)),
            "[DefaultDocumentation](N:DefaultDocumentation 'DefaultDocumentation')");

        [Fact]
        public void Write_should_write_When_cref_with_value() => Test(
            new XElement("see", new XAttribute("cref", AssemblyInfo.NamespaceDocItem.Id), "dummy"),
            "[dummy](N:DefaultDocumentation 'DefaultDocumentation')");

        [Fact]
        public void Write_should_write_When_href() => Test(
            new XElement("see", new XAttribute("href", "dummyurl")),
            "[dummyurl](dummyurl 'dummyurl')");

        [Fact]
        public void Write_should_write_When_href_with_value() => Test(
            new XElement("see", new XAttribute("href", "dummyurl"), "dummy"),
            "[dummy](dummyurl 'dummyurl')");

        [Fact]
        public void Write_should_write_When_langword() => Test(
            new XElement("see", new XAttribute("langword", "class")),
            "[class](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/class 'https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/class')");

        [Fact]
        public void Write_should_write_When_langword_with_value() => Test(
            new XElement("see", new XAttribute("langword", "class"), "dummy"),
            "[dummy](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/class 'https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/class')");

        [Fact]
        public void Write_should_write_When_langword_is_await() => Test(
            new XElement("see", new XAttribute("langword", "await")),
            "[await](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/await 'https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/await')");

        [Fact]
        public void Write_should_write_When_langword_is_true() => Test(
            new XElement("see", new XAttribute("langword", "true")),
            "[true](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool')");

        [Fact]
        public void Write_should_write_When_langword_is_false() => Test(
            new XElement("see", new XAttribute("langword", "false")),
            "[false](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool')");
    }
}
