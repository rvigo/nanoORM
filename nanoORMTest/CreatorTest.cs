using Xunit;
using nanoORM;
using nanoORMTest.Composers;
using System;

namespace nanoORMTest
{
    public class CreatorTest
    {
        [Fact]
        public void Should_Return_A_String_Query_From_T()
        {
            DefaultEntity defaultEntity = new DefaultEntity("Mocked Name", DateTime.Today, 1);
            string res = Creator.CreateQueryString(defaultEntity);

            Assert.IsType<string>(res);
        }

        [Fact]
        public void Should_Return_An_Object_Of_T()
        {
            var dataReader = DefaultDataReader.GetDefaultDataReader();
            var res = Creator.CreateObject<DefaultEntity>(dataReader.Object);

            Assert.IsType<DefaultEntity>(res);
        }
    }
}
