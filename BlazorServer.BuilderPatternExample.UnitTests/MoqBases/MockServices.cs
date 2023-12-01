using BlazorServer.BuilderPatternExample.Domain.Models;
using BlazorServer.BuilderPatternExample.Services;

namespace BlazorServer.BuilderPatternExample.UnitTests.MoqBases
{
    public static class MockServices
    {
        public static Mock<TService> MockService<TService, T>()
            where TService : class, IServiceBase<T>
            where T : BaseModel
        { 
            var mock = new Mock<TService>();

            mock.Setup(x => x.Add(It.IsAny<T>())).Returns((T x) => x);

            return mock;
        }
    }
}
