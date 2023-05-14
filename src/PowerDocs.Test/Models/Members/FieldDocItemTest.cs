using System;
using NFluent;
using Xunit;

namespace PowerDocs.Models.Members
{
    public sealed class FieldDocItemTest
    {
        [Fact]
        public void FieldDocItem_Should_throw_When_parent_is_null()
        {
            Check.ThatCode(() => new FieldDocItem(null, null, null)).Throws<ArgumentNullException>();
        }

        [Fact]
        public void FieldDocItem_Should_throw_When_field_is_null()
        {
            Check.ThatCode(() => new FieldDocItem(AssemblyInfo.ClassDocItem, null, null)).Throws<ArgumentNullException>();
        }
    }
}
