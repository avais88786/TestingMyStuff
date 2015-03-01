using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

    public static class AttributeUtilities
    {
        /// <summary>
        /// For a ViewModel, retrieve the first instance of an attribute associated with the current Property being bound.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ViewModel"></param>
        /// <returns></returns>
        public static T1 GetFirstAttribute<T1>(ModelMetadata ViewData)
        {
            try
            {
                var CustomAttributes = ViewData.ContainerType.GetProperty(ViewData.PropertyName).GetCustomAttributes(typeof(T1), false);
                if (CustomAttributes.Length > 0)
                {
                    return (T1)CustomAttributes[0];
                }
            }
            catch (Exception)
            {
                return default(T1);
            }
            return default(T1); 
        }


        /// <summary>
        /// For a ViewModel, retrieve the first instance of an attribute associated with the current Property being bound.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ViewModel"></param>
        /// <returns></returns>
        public static T1 GetFirstAttribute<T1>( ViewDataDictionary ViewData  )
        {
            try
            {
                var CustomAttributes = ViewData.ModelMetadata.ContainerType.GetProperty(ViewData.ModelMetadata.PropertyName).GetCustomAttributes(typeof(T1), false);
                if (CustomAttributes.Length > 0)
                {
                    return (T1)CustomAttributes[0];
                }
            }
            catch (Exception)
            {
                return default(T1); 
              
            }
                

            return default(T1); 
        }
    }
