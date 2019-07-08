using Moq;
using System;
using System.Data;

namespace nanoORMTest.Composers
{
    public class DefaultDataReader
    {
        public static Mock<IDataReader> GetDefaultDataReader()
        {
            var dataReader = new Mock<IDataReader>();
            dataReader.Setup(m => m.FieldCount).Returns(3);
            dataReader.Setup(m => m.GetName(0)).Returns("Name");
            dataReader.Setup(m => m.GetName(1)).Returns("Date");
            dataReader.Setup(m => m.GetName(2)).Returns("Id");

            dataReader.Setup(m => m.GetFieldType(0)).Returns(typeof(string));
            dataReader.Setup(m => m.GetFieldType(1)).Returns(typeof(DateTime));
            dataReader.Setup(m => m.GetFieldType(2)).Returns(typeof(int));

            dataReader.SetupSequence(m => m.Read())
                .Returns(true)
                .Returns(true)
                .Returns(false);

            return dataReader;
        }
    }
}
