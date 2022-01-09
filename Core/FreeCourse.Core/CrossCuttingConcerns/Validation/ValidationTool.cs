﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace FreeCourse.Core.CrossCuttingConcerns.Validation
{
    public static class ValidationTool
    {
        public static void Validate(IValidator validator, object entity)
        {
            var result = new ValidationContext<object>(entity);
            var validate = validator.Validate(result);
            if (!validate.IsValid)
            {
                throw new ValidationException(validate.Errors);

            }
        }
    }
}
