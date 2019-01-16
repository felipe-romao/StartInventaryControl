using FluentNHibernate.Mapping;
using StartInventaryControl.Data;

namespace StartInventaryControl.Map
{
    public class ColorMap : ClassMap<Color>
    {
        public ColorMap()
        {
            Id(c => c.ID);
            Map(c => c.Name);
            Table("Color");
        }
    }
}
