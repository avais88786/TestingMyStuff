using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StructureMap;
using OTOMCollapse.DependenyResolver;

namespace OTOMCollapse.DependenctResolver
{
    public class StructureMapContainer
    {
        private static IContainer _iContainer;

        public static IContainer Container
        {
            get {
                if (_iContainer == null) {
                    _iContainer = new Container(c =>
                    {
                        c.AddRegistry(new DefaultRegistry());
                    });
                }
                
                    return _iContainer; 
        }
        }
}

}