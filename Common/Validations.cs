using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public static class Validations
    {
        public enum ValidationTypes
        {
            GreatherThanZero = 0,
            IsNotNullOrEmpyAndWhiteSpaces = 1,
            IsInt = 2,
            IsString = 3,
            IsDecimal = 4,
            IsBool = 5,
            IsDateTime = 6
        }

        public static bool Validar(ValidationTypes validationType, object toValidate)
        {
            switch (validationType)
            {
                case ValidationTypes.GreatherThanZero:
                    if (Convert.ToInt32(toValidate) > 0)
                    {
                        return true;
                    }
                    return false;
                case ValidationTypes.IsNotNullOrEmpyAndWhiteSpaces:
                    if (string.IsNullOrWhiteSpace(toValidate.ToString()))
                    {
                        return false;
                    }
                    return true;
            }
            return false;
        }
    }
}
