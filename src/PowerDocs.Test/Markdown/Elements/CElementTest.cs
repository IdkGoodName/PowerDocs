﻿using System.Xml.Linq;
using NFluent;
using Xunit;

namespace PowerDocs.Markdown.Elements
{
    public sealed class CElementTest : AElementTest<CElement>
    {
        [Fact]
        public void Name_should_be_c() => Check.That(Name).IsEqualTo("c");

        [Fact]
        public void Write_should_write() => Test(
            new XElement("c", "test"),
            "`test`");
    }
}
