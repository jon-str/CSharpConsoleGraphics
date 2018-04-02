using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace STR_GraphicsLib
{
    public static class STR_Utilities
    {
        public static int Access1DArrayAs2D ( int iX , int iY , int iWidthPx ) => ( iX + iY * iWidthPx );

        public static T GenericTypeConverter<T, U> ( U gen_ValueToConvert ) => STR_Utilities.GenericCast<U , T>.Do ( gen_ValueToConvert );

        public static class GenericCast<T, U>
        {
            public static readonly Func<T , U> Do;

            static GenericCast ( )
            {
                var param1 = Expression.Parameter ( typeof ( T ) );

                Do = Expression.Lambda<Func<T , U>> ( Expression.Convert ( param1 , typeof ( U ) ) , param1 ).Compile ( );
            }
        }
    }
}
