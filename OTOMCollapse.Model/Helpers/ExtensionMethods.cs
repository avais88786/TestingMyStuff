using OTOMCollapse.Infrastructure;
using OTOMCollapse.Models.RepeatGroups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using OTOMCollapse.Infrastructure.Infrastructure;

namespace OTOMCollapse.Models.Helpers
{
    public static class ExtensionMethods
    {
        public static int GetMaxRepeatGroupValueOf<TModel, TKey>(this TModel model, Expression<Func<TModel, TKey>> selector) where TModel:class where TKey:IEnumerable
        {
            MemberInfo memberInfo = ((MemberExpression)selector.Body).Member;

            MaximumRepeatGroupsAttribute attr = ((MaximumRepeatGroupsAttribute)memberInfo.GetCustomAttribute(typeof(MaximumRepeatGroupsAttribute), false));

            if (attr == null)
                return 1;
            
            return attr.Value;
        }


        public static IEnumerable<string> GetCodeListNames<T>(this T model) where T : class
        {
            Type modelType = model.GetType();

            var codeListNames = new List<String>();

            modelType.GetProperties().ToList().ForEach(p=> 
            {
                
                CodeListNameAttribute codeListAttr = ((CodeListNameAttribute)p.GetCustomAttribute(typeof(CodeListNameAttribute), true));

                if (codeListAttr != null)
                    codeListNames.Add(codeListAttr.CodeListName);
            });
            

            return codeListNames;
        }

        
    }
}
