using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.DynamicProxy;
using FluentValidation;
using FreeCourse.Core.CrossCuttingConcerns.Validation;
using FreeCourse.Core.Utilities.Interceptors;

namespace FreeCourse.Core.Aspects.Validation
{
    public class ValidationAspect:MethodInterception
    {
        private Type _type;

        public ValidationAspect(Type type)
        {
            if (!typeof(IValidator).IsAssignableFrom(type))
            {
                throw new Exception("Sistem hatalı");
            }
            _type = type;
        }

        protected override void OnBefore(IInvocation invocation)
        {
            var validator = (IValidator)Activator.CreateInstance(_type);
            var entityType = _type.BaseType.GetGenericArguments()[0];
            var entities = invocation.Arguments.Where(x => x.GetType() == entityType);
            foreach (var entity in entities)
            {
                ValidationTool.Validate(validator,entity);
            }
        }
    }
}
