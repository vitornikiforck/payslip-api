using Autofac;
using MediatR;
using MediatR.Pipeline;
using Payslip.Api.Behaviours;
using Payslip.Application;
using System.Reflection;

namespace Payslip.Api.Extensions
{
    public static class MediatorExtensions
    {
        public static void AddMediator(this ContainerBuilder containerBuilder)
        {
            // Baseado em: https://github.com/jbogard/MediatR/blob/master/samples/MediatR.Examples.Autofac/Program.cs#L22

            var mediatrOpenTypes = new[]
            {
                typeof(IRequestHandler<,>),
                typeof(IRequestExceptionHandler<,,>),
                typeof(IRequestExceptionAction<,>),
                typeof(INotificationHandler<>),
            };
            containerBuilder.RegisterAssemblyTypes(typeof(IMediator).GetTypeInfo().Assembly).AsImplementedInterfaces();

            foreach (var mediatrOpenType in mediatrOpenTypes)
            {
                containerBuilder.RegisterAssemblyTypes(GetAssemblies().ToArray())
                    .AsClosedTypesOf(mediatrOpenType)
                    .AsImplementedInterfaces();
            }

            containerBuilder.RegisterGeneric(typeof(ValidationBehaviour<,>)).As(typeof(IPipelineBehavior<,>));
            containerBuilder.RegisterGeneric(typeof(RequestPostProcessorBehavior<,>)).As(typeof(IPipelineBehavior<,>));
            containerBuilder.RegisterGeneric(typeof(RequestPreProcessorBehavior<,>)).As(typeof(IPipelineBehavior<,>));
            containerBuilder.RegisterGeneric(typeof(RequestExceptionActionProcessorBehavior<,>)).As(typeof(IPipelineBehavior<,>));
            containerBuilder.RegisterGeneric(typeof(RequestExceptionProcessorBehavior<,>)).As(typeof(IPipelineBehavior<,>));

            containerBuilder.Register<ServiceFactory>(ctx =>
            {
                var c = ctx.Resolve<IComponentContext>();
                return t => c.Resolve(t);
            });
        }

        private static IEnumerable<Assembly> GetAssemblies()
        {
            yield return typeof(IMediator).GetTypeInfo().Assembly;
            yield return typeof(AppModule).GetTypeInfo().Assembly;
        }
    }
}