using System;
using KissU.Util.Datas.Sql.Matedatas;

namespace KissU.Util.Datas.Tests.Integration.Sql.Builders.Samples {

    public class TestEntityMatedata : IEntityMatedata {
        public string GetTable( Type entity ) {
            return $"t_{entity.Name}";
        }

        public string GetSchema( Type entity ) {
            return $"as_{entity.Name}";
        }

        public string GetColumn( Type entity, string property ) {
            if ( property == "DecimalValue" )
                return property;
            return $"{entity.Name}_{property}";
        }
    }
}
