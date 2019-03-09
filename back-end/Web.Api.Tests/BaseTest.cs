namespace Sureal.Auth.Test.Helpers
{
    using System;
    using Moq;
    using Microsoft.Extensions.Logging;
    using System.Diagnostics.CodeAnalysis;
    using Autofac.Extras.Moq;

    [ExcludeFromCodeCoverage]
    public abstract class BaseTest<TSystemUnderTest> where TSystemUnderTest : class
    {
        protected void AndISetupErrorLogger(AutoMock mock)
        {
            AndISetUpLog(mock, LogLevel.Error);
        }

        protected void AndISetupInfoLogger(AutoMock mock)
        {
            AndISetUpLog(mock, LogLevel.Information);
        }

        protected void AndISetupDebugLogger(AutoMock mock)
        {
            AndISetUpLog(mock, LogLevel.Debug);
        }

        // protected void AndISetupAMapping<TFrom, TDestiny>(AutoMock mock) where TDestiny : new()
        // {
        //     var result = new TDestiny();
        //     mock.Mock<IMappingEngine>().Setup(m =>
        //         m.Map<TFrom, TDestiny>(
        //                 It.IsAny<TFrom>()
        //                 )
        //     ).Returns(result);
        // }

        // public void AndISetupAUpdateMapping<TSource, TCopyFrom>(AutoMock mock, TSource returnValue)
        // {
        //     mock.Mock<IMappingEngine>().Setup(m => m.Update(
        //         It.IsAny<TSource>(), It.IsAny<TCopyFrom>()
        //     )).Returns(returnValue);
        // }

        private void AndISetUpLog(AutoMock mock, LogLevel logLevel)
        {
            mock.Mock<ILogger<TSystemUnderTest>>().Setup(l => l.Log(
                It.Is<LogLevel>(ll => ll == logLevel),
                It.IsAny<EventId>(),
                It.IsAny<object>(),
                It.IsAny<Exception>(),
                It.IsAny<Func<object, Exception, string>>()
            ));
        }

    }
}