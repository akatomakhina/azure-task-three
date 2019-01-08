using Castle.DynamicProxy;
using FluentValidation;
using ProductProjectAzure.Logic.Common.Exceptions;
using SimpleInjector;

namespace ProductProjectAzure.Logic.Validator
{
    public class ValidatorInterceptor : IAsyncInterceptor
    {
        private readonly Container _container;

        public ValidatorInterceptor(Container container)
        {
            _container = container;
        }

        public void InterceptAsynchronous(IInvocation invocation)
        {
            Validate(invocation);
        }

        public void InterceptAsynchronous<TResult>(IInvocation invocation)
        {
            Validate(invocation);
        }

        public void InterceptSynchronous(IInvocation invocation)
        {
            Validate(invocation);
        }

        private void Validate(IInvocation invocation)
        {
            var arguments = invocation.Arguments;

            foreach (var argument in arguments)
            {
                if (!(argument.Equals(null)) && argument.GetType().IsClass)
                {
                    var validatorType = typeof(AbstractValidator<>).MakeGenericType(argument.GetType());

                    var concreteValidator = (IValidator)_container.GetRegistration(validatorType)?.GetInstance();

                    if (concreteValidator.Equals(null))
                        continue;

                    var result = concreteValidator.Validate(argument);

                    if (!result.IsValid)
                    {
                        throw new ProductServiceException(ErrorType.ValidationException);
                    }
                }
            }

            invocation.Proceed();
        }
    }
}
