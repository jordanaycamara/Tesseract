using System;
using System.Collections.Generic;
using System.Text;
using FluentNHibernate.Mapping;
using NHibernate.Mapping;
using Tesseract.Database.Interfaces;

namespace Tesseract.Database.Mappings.Base
{
    public class IdentifiableMap<T> : ClassMap<T> where T : IIdentifiable
    {
        public IdentifiableMap()
        {
            Id(x => x.Id);
        }
    }
}
