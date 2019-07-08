using nanoORM;
using nanoORMTest.Composers;
using System.Collections.Generic;
using Xunit;

namespace nanoORMTest
{
    public class MappingTest
    {
        [Fact]
        public void Should_Return_A_Single_Item_Of_T()
        {
            var dataReader = DefaultDataReader.GetDefaultDataReader();
            DefaultEntity defaultEntity = Mapping.SingleItemMapping<DefaultEntity>(dataReader.Object);

            Assert.IsType<DefaultEntity>(defaultEntity);
        }

        [Fact]
        public void Should_Return_A_List_Of_T()
        {
            var dataReader = DefaultDataReader.GetDefaultDataReader();
            List<DefaultEntity> defaultEntityList = Mapping.ListMapping<DefaultEntity>(dataReader.Object);

            Assert.IsType<List<DefaultEntity>>(defaultEntityList);
        }
    }
}
